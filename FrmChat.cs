#define ALTERNATE_SCROLL
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using jabber.client;
using jabber.protocol.client;
using System.Diagnostics;
using RealJabber.RealTimeTextUtil;

#if ALTERNATE_SCROLL
// Will only work on Windows, not in MONO (Mac/Linux)
using System.Runtime.InteropServices;
#endif

/// <summary>
/// This is an experimental demonstration XMPP Chat client that implements a new XMPP extension:
/// XMPP In-Band Real Time Text - Version 0.0.2 - http://www.realjabber.org
/// Written by Mark D. Rejhon - mailto:markybox@gmail.com - http://www.marky.com/resume
/// 
/// COPYRIGHT
/// Copyright 2011 by Mark D. Rejhon - Rejhon Technologies Inc.
/// 
/// LICENSE
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///     http://www.apache.org/licenses/LICENSE-2.0
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///
/// NOTES
/// Formerly based on the public-domain C# .NET Google Chat client at CodeProject
/// http://www.codeproject.com/KB/gadgets/googletalk.aspx
/// 
/// IMPORTANT NOTICE
/// Mark Rejhon retains copyright to the use of the name "RealJabber".
/// Modified versions of this software not released by Mark Rejhon must be released under a 
/// different name than "RealJabber".
/// </summary>
namespace RealJabber
{
    /// <summary>Display of a chat window</summary>
    public partial class FrmChat : Form
    {
        private const string CHAT_LINE_FORMAT = "{0} says: ";
        private const string CHAT_LINE_REALTIME = "{0} (typing): ";

        // Unicode 0x2503 is a thick bar character. Use 0 to hide cursor. Alternative is to use common '|' pipe character
        private const char CURSOR_CHAR = (char)(0x2503);

        private Color rttTextColor = Color.Blue;
        private char cursorChar = CURSOR_CHAR;
        private delegate void TextNowDecoded();
        private TextNowDecoded myDelegate;
        private ChatSession m_chat = new ChatSession();
        private bool rttEnabled = true;
        private RealTimeText.Encoder encoderRTT;
        private RichTextBox tempRTF = new RichTextBox();
        private RichTextBox cachedRTF1 = new RichTextBox();
        private RichTextBox cachedRTF2 = new RichTextBox();

        private Object convoLock = new Object();
        private bool convoUpdated = false;
        private Timer convoUpdateTimer = new Timer();

        /// <summary>Constructor</summary>
        public FrmChat()
        {
            InitializeComponent();
            timerRTTsend.Tick += new EventHandler(timerRTTsend_Tick);
            myDelegate = new TextNowDecoded(UpdateConversationWindow);
            convoUpdateTimer.Tick += new EventHandler(convoUpdateTimer_Tick);
        }

        /// <summary>The JID we are chatting to in this window</summary>
        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        private string _nickname;

        /// <summary>The JID we are chatting to in this window</summary>
        public jabber.JID JID
        {
            get { return _jid; }
            set { _jid = value; }
        }
        private string _jid;

        /// <summary>The XMPP library to communicate through</summary>
        public JabberClient JabberObject
        {
            get { return _jabberClient; }
            set { _jabberClient = value; }
        }
        private JabberClient _jabberClient;

        /// <summary>A flag indicating whether a message has been received already</summary>        
        public bool ReceiveFlag
        {
            get { return _receiveFlag; }
            set { _receiveFlag = value; }
        }
        private bool _receiveFlag;

        /// <summary>Form load event -- this window was just created</summary>
        private void FrmChat_Load(object sender, EventArgs e)
        {
            encoderRTT = new RealTimeText.Encoder(_jabberClient.Document, true);
            _jabberClient.OnMessage += new MessageHandler(_jabberClient_OnMessage);
            groupBoxParticipant1.Text = JID.Bare;
            groupBoxParticipantLocal.Text = _jabberClient.User;
            textboxSendMessage.Focus();
        }

        /// <summary>Window activation event</summary>
        private void FrmChat_Activated(object sender, EventArgs e)
        {
            textboxSendMessage.Focus();
            UpdateMenuCheckmarks();
        }

        /// <summary>Append a line of chat to conversation.  Also clears the real time text</summary>
        public void AppendConversation(jabber.JID from, string str, Color color)
        {
            m_chat.RemoveRealTimeMessage(from);
            ChatLine line = new ChatLine(from, str, color);
            m_chat.Lines.Add(line);
            ResetConversationMessageHistoryCache();
            UpdateConversationWindow();
        }

        /// <summary>Process the contents of an XMPP message</summary>
        public void HandleMessage(jabber.protocol.client.Message msg)
        {
            if (rttEnabled)
            {
                // Did we receive a <rtt> element?
                XmlElement rttBlock = (XmlElement)msg["rtt"];
                if (rttBlock != null)
                {
                    // Create a new real time mesage if not already created
                    RealTimeMessage rttMessage = m_chat.GetRealTimeMessage(msg.From);
                    if (rttMessage == null)
                    {
                        rttMessage = m_chat.NewRealTimeMessage(_jabberClient.Document, (string)msg.From, Color.DarkBlue);
                        rttMessage.Decoder.TextUpdated += new RealTimeText.Decoder.TextUpdatedHandler(decoder_TextDecoded);
                    }
                    // Process <rtt> element
                    rttMessage.Decoder.Decode(rttBlock);

                    // Highlight frozen text differently (stalled due to missing message)
                    rttMessage.Color = rttMessage.Decoder.InSync ? Color.DarkBlue : Color.Gray;

                    // If key press intervals are disabled, decode immediately
                    if (!encoderRTT.Delays)
                    {
                        rttMessage.Decoder.FullDecodeNow();
                        UpdateConversationWindow();
                    }
                }
            }
           
            if (msg.Body != null)
            {
                // Completed line of text
                AppendConversation(msg.From, msg.Body, Color.DarkBlue);
            }
        }
                              
        /// <summary>Event that is called when the RTT decoder decodes the next part of real time text</summary>
        void decoder_TextDecoded(RealTimeText.Decoder decoder)
        {
            if (this.Visible)
            {
                lock (convoLock)
                {
                    if (convoUpdated)
                    {
                        convoUpdated = false;
                        this.BeginInvoke(myDelegate);
                    }
                    else
                    {
                        convoUpdateTimer.Interval = 10;
                        convoUpdateTimer.Start();
                    }
                }
            }
        }

        /// <summary>Conversation update timer</summary>
        void convoUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (convoUpdated)
            {
                convoUpdateTimer.Stop();
                this.BeginInvoke(myDelegate);
            }
        }

        /// <summary>Incoming XMPP messages specifically for this chat window</summary>
        public void _jabberClient_OnMessage(object sender, jabber.protocol.client.Message msg)
        {
            if (!this.ReceiveFlag)
            {
                if (msg.From.Bare == JID.Bare)
                {
                    HandleMessage(msg);
                    msg.Body = "";
                }
            }
        }

        /// <summary>Transmit a message. Either a regular message, or real time text update, or both.</summary>
        private void JabberSendMessage(string body)
        {
            if ((!encoderRTT.Empty) || (body != null))
            {
                // Create the XMPP <message>
                jabber.protocol.client.Message reply = new jabber.protocol.client.Message(_jabberClient.Document);
                reply.To = JID.Bare;

                // Add the <rtt> element
                if (rttEnabled) reply.AppendChild(encoderRTT.GetEncodedRTT());

                // Add the <body> element
                if (body != null)
                {
                    reply.Body = body;
                    if (rttEnabled) encoderRTT.NextMsg();
                }
                // Now transmit the message
                _jabberClient.Write(reply);
            }
        }

        /// <summary>Message transmission & Real time text transmission update</summary>
        private bool SendJabberMessage(bool commit)
        {
            if (commit == false)
            {
                if (rttEnabled)
                {
                    if (!encoderRTT.Delays)
                    {
                        encoderRTT.Encode(textboxSendMessage.Text, textboxSendMessage.SelectionStart);
                    }
                    if (encoderRTT.Empty)
                    {
                        return false; // No codes to send
                    }
                    // Send just rtt update.
                    JabberSendMessage(null);
                    UpdateConversationWindow();
                    return true;
                }
            }
            else
            {
                if (rttEnabled)
                {
                    encoderRTT.Encode(textboxSendMessage.Text, textboxSendMessage.SelectionStart);
                }
                // Send both body and rtt.
                JabberSendMessage(textboxSendMessage.Text);
                AppendConversation(_jabberClient.User, textboxSendMessage.Text, Color.DarkRed);
                UpdateConversationWindow();
            }
            return false;
        }

        /// <summary>Keypress event in the Send Message text box.  
        /// Monitor for Enter keypresses for sending messages.
        /// If Shift+Enter is done, don't transmit, and just treat it as an embedded newline in the message</summary>
        private void textboxSendMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Return) && 
                (0 == (e.Modifiers & Keys.Shift)))
            {
                if (textboxSendMessage.Text.Length > 0)
                {
                    timerRTTsend.Stop();
                    SendJabberMessage(true);
                    textboxSendMessage.Text = "";
                    this.ReceiveFlag = false;
                }
                e.Handled = true;
            }
        }

        /// <summary>Text changed.</summary>
        private void rtbSendMessage_TextChanged(object sender, EventArgs e)
        {
            TextOrCursorPosChanged();
        }

        /// <summary>Cursor moved.</summary>
        private void rtbSendMessage_SelectionChanged(object sender, EventArgs e)
        {
            TextOrCursorPosChanged();
        }

        private void TextOrCursorPosChanged()
        {
            if (rttEnabled)
            {
                if (encoderRTT.Delays)
                {
                    encoderRTT.Encode(textboxSendMessage.Text, textboxSendMessage.SelectionStart);
                }
                if (!timerRTTsend.Enabled && (textboxSendMessage.Parent != null))
                {
                    timerRTTsend.Interval = (encoderRTT.Interval > 0) ? encoderRTT.Interval : 1;
                    timerRTTsend.Start();
                }
            }
        }

        /// <summary>Real Time Text transmission timer</summary>
        private void timerRTTsend_Tick(object sender, EventArgs e)
        {
            if (!SendJabberMessage(false))
            {
                timerRTTsend.Stop();
            }
        }

        /// <summary>Visual presentation of the conversation buffer and real-time-text</summary>
        private void UpdateConversationWindow()
        {
            // Render the conversation depending on which tab is selected.
            switch (tabControl.SelectedTab.Tag.ToString())
            {
                case "NORMAL": // Tab: Normal IM view
                    tempRTF.Clear();
                    if (cachedRTF1.Text.Length == 0)
                    {
                        m_chat.FormatAllLinesRTF(cachedRTF1, CHAT_LINE_FORMAT, null);
                    }
                    tempRTF.Rtf = cachedRTF1.Rtf;
                    m_chat.FormatAllRealTimeRTF(tempRTF, CHAT_LINE_REALTIME, null, cursorChar, rttTextColor);
                    textboxConversation1.Rtf = tempRTF.Rtf;
                    ScrollToBottom(textboxConversation1);
                    break;

                case "HYBRID": // Tab: Hybrid IM view
                    tempRTF.Clear();
                    if (cachedRTF1.Text.Length == 0)
                    {
                        m_chat.FormatAllLinesRTF(cachedRTF1, CHAT_LINE_FORMAT, null);
                    }
                    tempRTF.Rtf = cachedRTF1.Rtf;
                    textboxConversation2.Rtf = tempRTF.Rtf;
                    ScrollToBottom(textboxConversation2);
                    tempRTF.Clear();
                    m_chat.FormatAllRealTimeRTF(tempRTF, CHAT_LINE_REALTIME, null, cursorChar, rttTextColor);
                    textboxRealTime.Rtf = tempRTF.Rtf;
                    ScrollToTop(textboxRealTime);
                    break;

                case "SPLIT": // Tab: Splitscreen Chat view
                    tempRTF.Clear();
                    if (cachedRTF1.Text.Length == 0)
                    {
                        m_chat.FormatAllLinesRTF(cachedRTF1, "", this.JID.Bare);
                    }
                    tempRTF.Rtf = cachedRTF1.Rtf;
                    m_chat.FormatAllRealTimeRTF(tempRTF, "", this.JID.Bare, cursorChar, rttTextColor);
                    textboxParticipant1.Rtf = tempRTF.Rtf;
                    ScrollToBottom(textboxParticipant1);
                    tempRTF.Clear();
                    if (cachedRTF2.Text.Length == 0)
                    {
                        m_chat.FormatAllLinesRTF(cachedRTF2, "", _jabberClient.User);
                    }
                    tempRTF.Rtf = cachedRTF2.Rtf;
                    if (tempRTF.Text.Length > 0)
                    {
                        tempRTF.Select(tempRTF.Text.Length - 1, 1);
                        tempRTF.SelectedText = "";
                    }
                    textboxParticipantLocal.Rtf = tempRTF.Rtf;
                    ScrollToBottom(textboxParticipantLocal);
                    break;
            }
            lock (convoLock)
            {
                convoUpdated = true;
            }
        }

        /// <summary>Forces reinitialization of conversation window message history</summary>
        private void ResetConversationMessageHistoryCache()
        {
            cachedRTF1.Clear();
            cachedRTF2.Clear();
        }

        /// <summary>Switching tabs (switch between different views of chat)</summary>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetConversationMessageHistoryCache();

            // Make sure that our SendMessage textbox is moved to the correct tab (normal, hybrid, splitscreen), 
            // since we are sharing the same "Send Message" textbox in all of the tabs.
            try
            {
                textboxSendMessage.Parent.Controls.Remove(textboxSendMessage);
            }
            catch { }
            switch (tabControl.SelectedTab.Tag.ToString())
            {
                case "NORMAL":
                    // Normal / Traditional layout
                    textboxSendMessage.BorderStyle = BorderStyle.Fixed3D;
                    tabControl.SelectedTab.Controls.Add(textboxSendMessage);
                    textboxSendMessage.Top = labelSendMessage.Bottom;
                    textboxSendMessage.Width = textboxConversation1.Width;
                    break;
                case "HYBRID":
                    // Three Field Layout
                    textboxSendMessage.BorderStyle = BorderStyle.Fixed3D;
                    tabControl.SelectedTab.Controls.Add(textboxSendMessage);
                    textboxSendMessage.Top = labelSendMessage2.Bottom;
                    textboxSendMessage.Width = textboxConversation2.Width;
                    break;
                case "SPLIT":
                    // Splitscreen Layout: Reposition the chat entry box seamlessly at the bottom of our splitscreen
                    textboxSendMessage.BorderStyle = BorderStyle.None;
                    groupBoxParticipantLocal.Controls.Add(textboxSendMessage);
                    textboxSendMessage.Top = groupBoxParticipantLocal.ClientRectangle.Bottom - textboxSendMessage.Height - 5;
                    textboxSendMessage.Width = textboxParticipantLocal.Width;
                    textboxParticipantLocal.Height = textboxSendMessage.Top - textboxParticipantLocal.Top;
                    break;
            }
            textboxSendMessage.BringToFront();
            textboxSendMessage.Focus();
            UpdateConversationWindow();
        }

        // Reset the cursor to the send message box upon any repeated clicks on any tab
        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            textboxSendMessage.Focus();
        }

        // Reset the cursor to the send message box if the user attempts to start
        // typing while the cursor is not focussed in the send message box.
        private void textboxParticipantLocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            textboxSendMessage.Focus();
        }
        private void textboxParticipant1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textboxSendMessage.Focus();
        }
        private void textboxConversation1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textboxSendMessage.Focus();
        }
        private void textboxConversation2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textboxSendMessage.Focus();
        }
        private void textboxRealTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            textboxSendMessage.Focus();
        }

#if ALTERNATE_SCROLL
        // Works better on Windows
        // Helper Interop code used for ScrollToBottom().  
        // Windows doesn't let me do this reliably and using ScrollToCaret() flickers too much. This is better.
        // However, this won't work on Mono on Mac/Linux. (use ScrollToCaret instead)
        [DllImport("user32", CharSet = CharSet.Auto)]
        static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos);
        [DllImport("user32", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, POINT lParam);
        [StructLayout(LayoutKind.Sequential)]
        class POINT
        {
            public int x;
            public int y;
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        const int SB_VERT = 1;
        const int EM_SETSCROLLPOS = 0x0400 + 222;
#endif

        /// <summary>Scroll to the bottom of a textbox</summary>
        public void ScrollToBottom(RichTextBox textBox)
        {
#if !ALTERNATE_SCROLL
            if (textBox.SelectionStart != textBox.Text.Length)
            {
                this.SuspendLayout();
                textBox.SelectionLength = 0;
                textBox.SelectionStart = textBox.Text.Length;
                textBox.ScrollToCaret();
                textBox.ScrollToCaret(); // Bug requires this to be called twice in a row
                this.ResumeLayout();
            }
#else
            int min, max;
            GetScrollRange(textBox.Handle, SB_VERT, out min, out max);
            SendMessage(textBox.Handle, EM_SETSCROLLPOS, 0, new POINT(0, max - textBox.Height));
#endif
        }

        /// <summary>Scroll to the top of a textbox</summary>
        public void ScrollToTop(RichTextBox textBox)
        {
#if !ALTERNATE_SCROLL
            if (textBox.SelectionStart != 0)
            {
                textBox.SelectionStart = 0;
                textBox.SelectionLength = 0;
                textBox.ScrollToCaret();
            }
#else
            SendMessage(textBox.Handle, EM_SETSCROLLPOS, 0, new POINT(0, 0));
#endif
        }

        /// <summary>Menu item - close conversation</summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>Close window event</summary>
        private void FrmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearConversation();
        }

        /// <summary>Override the Form Close button</summary>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg != 0x0010)
            {
                base.WndProc(ref m);
            }
            else
            {
                //Windows has send the WM_CLOSE message to your form.
                //Ignore this message will make the window stay open.
                ClearConversation();
            }
        }

        /// <summary>Clear the conversation, upon close of chat</summary>
        private void ClearConversation()
        {
            // Send the last real time message to clear the real time text on remote end 
            // because it wasn't "sent" before the window closed.
            textboxSendMessage.Text = "";
            SendJabberMessage(false);
            m_chat.Clear();
            this.timerRTTsend.Stop();

            // Clear text from all buffers
            textboxConversation1.Clear();
            textboxConversation2.Clear();
            textboxRealTime.Clear();
            textboxParticipant1.Clear();
            textboxParticipantLocal.Clear();
            
            // Reset scrollbar positions in all buffers
            ScrollToTop(textboxConversation1);
            ScrollToTop(textboxConversation2);
            ScrollToTop(textboxRealTime);
            ScrollToTop(textboxParticipant1);
            ScrollToTop(textboxParticipantLocal);
            this.Hide();
            this.ReceiveFlag = false;
        }

        /// <summary>Various modes triggered by menu</summary>
        private void menuItemEnableRTT_Click(object sender, EventArgs e)
        {
            rttEnabled = !rttEnabled;
            if (!rttEnabled)
            {
                encoderRTT.Reset();
                m_chat.ClearRealTimeMessages();
                ResetConversationMessageHistoryCache();
                UpdateConversationWindow();
            }
            UpdateMenuCheckmarks();
        }
        private void menuItemSpecificationRecommended_Click(object sender, EventArgs e)
        {
            // RECOMMENDED
            encoderRTT.Interval = 1000;
            encoderRTT.Delays = true;
            cursorChar = CURSOR_CHAR;
            UpdateConversationWindow();
            UpdateMenuCheckmarks();
        }
        private void menuItemSpecificationLowLag_Click(object sender, EventArgs e)
        {
            encoderRTT.Interval = 500;
            encoderRTT.Delays = true;
            cursorChar = CURSOR_CHAR;
            UpdateConversationWindow();
            UpdateMenuCheckmarks();
        }
        private void menuItemSpecificationBadImmediateTransmit_Click(object sender, EventArgs e)
        {
            // NOT RECOMMENDED
            encoderRTT.Interval = 0;
            encoderRTT.Delays = false;
            cursorChar = CURSOR_CHAR;
            UpdateConversationWindow();
            UpdateMenuCheckmarks();
        }
        private void menuItemSpecificationBadBurstyText_Click(object sender, EventArgs e)
        {
            // NOT RECOMMENDED
            encoderRTT.Interval = 1000;
            encoderRTT.Delays = false;
            cursorChar = (char)0;
            UpdateConversationWindow();
            UpdateMenuCheckmarks();
        }

        /// <summary>Set custom RTT interval</summary>
        private void menuItem0ms_Click(object sender, EventArgs e)
        {
            // NOT RECOMMENDED due to XMPP server flooding. Okay for private/LAN use.
            encoderRTT.Interval = 0;
            UpdateMenuCheckmarks();
        }
        private void menuItem20ms_Click(object sender, EventArgs e)
        {
            // NOT RECOMMENDED due to XMPP server flooding. Okay for private/LAN use.
            encoderRTT.Interval = 20;
            UpdateMenuCheckmarks();
        }
        private void menuItem50ms_Click(object sender, EventArgs e)
        {
            // NOT RECOMMENDED due to XMPP server flooding. Okay for private/LAN use.
            encoderRTT.Interval = 50;
            UpdateMenuCheckmarks();
        }
        private void menuItem100ms_Click(object sender, EventArgs e)
        {
            // NOT RECOMMENDED due to XMPP server flooding. Okay for private/LAN use.
            encoderRTT.Interval = 100;
            UpdateMenuCheckmarks();
        }
        private void menuItem200ms_Click(object sender, EventArgs e)
        {
            encoderRTT.Interval = 200;
            UpdateMenuCheckmarks();
        }
        private void menuItem300ms_Click(object sender, EventArgs e)
        {
            encoderRTT.Interval = 300;
            UpdateMenuCheckmarks();
        }
        private void menuItem500ms_Click(object sender, EventArgs e)
        {
            encoderRTT.Interval = 500;
            UpdateMenuCheckmarks();
        }
        private void menuItem1000ms_Click(object sender, EventArgs e)
        {
            // RECOMMENDED (best compromise to balance usability, server, network, etc.)
            encoderRTT.Interval = 1000;
            UpdateMenuCheckmarks();
        }
        private void menuItem2000ms_Click(object sender, EventArgs e)
        {
            // NOT RECOMMENDED due to extreme lag
            encoderRTT.Interval = 2000;
            UpdateMenuCheckmarks();
        }
        private void menuItem3000ms_Click(object sender, EventArgs e)
        {
            // NOT RECOMMENDED due to extreme lag
            encoderRTT.Interval = 3000;
            UpdateMenuCheckmarks();
        }
        private void menuItem5000ms_Click(object sender, EventArgs e)
        {
            // NOT RECOMMENDED due to extreme lag
            encoderRTT.Interval = 5000;
            UpdateMenuCheckmarks();
        }

        /// <summary>Enable/disable embedded delays</summary>
        private void menuItemEnableKeyPressIntervals_Click(object sender, EventArgs e)
        {
            encoderRTT.Delays = !encoderRTT.Delays;
            UpdateMenuCheckmarks();
        }

        /// <summary>Enable/disable rendering of remote cursor</summary>
        private void menuItemEnableRemoteCursor_Click(object sender, EventArgs e)
        {
            cursorChar = (cursorChar == 0) ? CURSOR_CHAR : (char)0;
            UpdateConversationWindow();
            UpdateMenuCheckmarks();
        }
        /// <summary>Open RealJabber home page</summary>
        private void menuItemRealJabber_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.realjabber.org");
        }
        /// <summary>Clears the chat</summary>
        private void menuItemClear_Click(object sender, EventArgs e)
        {
            encoderRTT.Reset();
            m_chat.Clear();
            ResetConversationMessageHistoryCache();
            UpdateConversationWindow();
        }

        /// <summary>Update the checkmarks displayed next to menu items</summary>
        private void UpdateMenuCheckmarks()
        {
            menuItemEnableRTT.Checked = rttEnabled;
            menuItemResetToBaseline.Checked = ((encoderRTT.Interval == 1000) && !encoderRTT.Delays);
            menuItemNaturalTypingMode1.Checked = ((encoderRTT.Interval == 1000) && encoderRTT.Delays);
            menuItemNaturalTypingMode2.Checked = ((encoderRTT.Interval == 500)  && encoderRTT.Delays);
            menuItemNaturalTypingMode3.Checked = ((encoderRTT.Interval == 0)    && !encoderRTT.Delays);
            menuItem0ms.Checked    = (encoderRTT.Interval == 0);
            menuItem20ms.Checked   = (encoderRTT.Interval == 20);
            menuItem50ms.Checked   = (encoderRTT.Interval == 50);
            menuItem100ms.Checked  = (encoderRTT.Interval == 100);
            menuItem200ms.Checked  = (encoderRTT.Interval == 200);
            menuItem300ms.Checked  = (encoderRTT.Interval == 300);
            menuItem500ms.Checked  = (encoderRTT.Interval == 500);
            menuItem1000ms.Checked = (encoderRTT.Interval == 1000);
            menuItem2000ms.Checked = (encoderRTT.Interval == 2000);
            menuItem3000ms.Checked = (encoderRTT.Interval == 3000);
            menuItem5000ms.Checked = (encoderRTT.Interval == 5000);
            menuItemEnableKeyPressIntervals.Checked = encoderRTT.Delays;
            menuItemEnableRemoteCursor.Checked = (cursorChar != 0);
        }

        /// <summary>Launch default web browser when link is clicked</summary>
        private void textboxConversation1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
        private void textboxSendMessage_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
        private void textboxConversation2_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
        private void textboxRealTime_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
        private void textboxParticipant1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
        private void textboxParticipantLocal_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
