namespace RealJabber
{
    partial class FrmChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.converToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.experimentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEnableRTT = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemNaturalTypingMode1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNaturalTypingMode2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemResetToBaseline = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNaturalTypingMode3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemCustomTransmitInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem0ms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem20ms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem50ms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem100ms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem200ms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem300ms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem500ms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem1000ms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem2000ms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem3000ms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem5000ms = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemEnableKeyPressIntervals = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEnableRemoteCursor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemRealJabber = new System.Windows.Forms.ToolStripMenuItem();
            this.textboxSendMessage = new System.Windows.Forms.RichTextBox();
            this.textboxConversation1 = new System.Windows.Forms.RichTextBox();
            this.timerRTTsend = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelSendMessage = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelActiveTyping2 = new System.Windows.Forms.Label();
            this.labelSendMessage2 = new System.Windows.Forms.Label();
            this.textboxRealTime = new System.Windows.Forms.RichTextBox();
            this.textboxConversation2 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBoxParticipantLocal = new System.Windows.Forms.GroupBox();
            this.textboxParticipantLocal = new System.Windows.Forms.RichTextBox();
            this.groupBoxParticipant1 = new System.Windows.Forms.GroupBox();
            this.textboxParticipant1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBoxParticipantLocal.SuspendLayout();
            this.groupBoxParticipant1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.converToolStripMenuItem,
            this.experimentationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(346, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // converToolStripMenuItem
            // 
            this.converToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClear,
            this.exitToolStripMenuItem});
            this.converToolStripMenuItem.Name = "converToolStripMenuItem";
            this.converToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.converToolStripMenuItem.Text = "Conversation";
            // 
            // menuItemClear
            // 
            this.menuItemClear.Name = "menuItemClear";
            this.menuItemClear.Size = new System.Drawing.Size(129, 22);
            this.menuItemClear.Text = "Clear";
            this.menuItemClear.Click += new System.EventHandler(this.menuItemClear_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.exitToolStripMenuItem.Text = "End Chat";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // experimentationToolStripMenuItem
            // 
            this.experimentationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEnableRTT,
            this.toolStripSeparator4,
            this.menuItemNaturalTypingMode1,
            this.menuItemNaturalTypingMode2,
            this.menuItemResetToBaseline,
            this.menuItemNaturalTypingMode3,
            this.toolStripSeparator2,
            this.menuItemCustomTransmitInterval,
            this.menuItemEnableKeyPressIntervals,
            this.menuItemEnableRemoteCursor,
            this.toolStripSeparator5,
            this.menuItemRealJabber});
            this.experimentationToolStripMenuItem.Name = "experimentationToolStripMenuItem";
            this.experimentationToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.experimentationToolStripMenuItem.Text = "RTT Research";
            // 
            // menuItemEnableRTT
            // 
            this.menuItemEnableRTT.Name = "menuItemEnableRTT";
            this.menuItemEnableRTT.Size = new System.Drawing.Size(539, 22);
            this.menuItemEnableRTT.Text = "Enable Real Time Text";
            this.menuItemEnableRTT.Click += new System.EventHandler(this.menuItemEnableRTT_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(536, 6);
            // 
            // menuItemNaturalTypingMode1
            // 
            this.menuItemNaturalTypingMode1.Name = "menuItemNaturalTypingMode1";
            this.menuItemNaturalTypingMode1.Size = new System.Drawing.Size(539, 22);
            this.menuItemNaturalTypingMode1.Text = "Recommended Spec Support (1000ms transmit interval, embedded key press intervals)" +
                "";
            this.menuItemNaturalTypingMode1.Click += new System.EventHandler(this.menuItemSpecificationRecommended_Click);
            // 
            // menuItemNaturalTypingMode2
            // 
            this.menuItemNaturalTypingMode2.Name = "menuItemNaturalTypingMode2";
            this.menuItemNaturalTypingMode2.Size = new System.Drawing.Size(539, 22);
            this.menuItemNaturalTypingMode2.Text = "Low-Lag Spec Support (500ms transmit interval, embedded key press intervals)";
            this.menuItemNaturalTypingMode2.Click += new System.EventHandler(this.menuItemSpecificationLowLag_Click);
            // 
            // menuItemResetToBaseline
            // 
            this.menuItemResetToBaseline.Name = "menuItemResetToBaseline";
            this.menuItemResetToBaseline.Size = new System.Drawing.Size(539, 22);
            this.menuItemResetToBaseline.Text = "Barebones Spec Support (1000ms transmit interval, bursty text output) - NOT RECOM" +
                "MENDED";
            this.menuItemResetToBaseline.Click += new System.EventHandler(this.menuItemSpecificationBadBurstyText_Click);
            // 
            // menuItemNaturalTypingMode3
            // 
            this.menuItemNaturalTypingMode3.Name = "menuItemNaturalTypingMode3";
            this.menuItemNaturalTypingMode3.Size = new System.Drawing.Size(539, 22);
            this.menuItemNaturalTypingMode3.Text = "Transmit All Keypresses Immediately (immediate transmit, no buffering) - NOT RECO" +
                "MMENDED";
            this.menuItemNaturalTypingMode3.Click += new System.EventHandler(this.menuItemSpecificationBadImmediateTransmit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(536, 6);
            // 
            // menuItemCustomTransmitInterval
            // 
            this.menuItemCustomTransmitInterval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem0ms,
            this.menuItem20ms,
            this.menuItem50ms,
            this.menuItem100ms,
            this.menuItem200ms,
            this.menuItem300ms,
            this.menuItem500ms,
            this.menuItem1000ms,
            this.menuItem2000ms,
            this.menuItem3000ms,
            this.menuItem5000ms,
            this.toolStripSeparator3});
            this.menuItemCustomTransmitInterval.Name = "menuItemCustomTransmitInterval";
            this.menuItemCustomTransmitInterval.Size = new System.Drawing.Size(539, 22);
            this.menuItemCustomTransmitInterval.Text = "Customize Outgoing Transmit Interval";
            // 
            // menuItem0ms
            // 
            this.menuItem0ms.Name = "menuItem0ms";
            this.menuItem0ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem0ms.Text = "0 ms";
            this.menuItem0ms.Click += new System.EventHandler(this.menuItem0ms_Click);
            // 
            // menuItem20ms
            // 
            this.menuItem20ms.Name = "menuItem20ms";
            this.menuItem20ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem20ms.Text = "20 ms";
            this.menuItem20ms.Click += new System.EventHandler(this.menuItem20ms_Click);
            // 
            // menuItem50ms
            // 
            this.menuItem50ms.Name = "menuItem50ms";
            this.menuItem50ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem50ms.Text = "50 ms";
            this.menuItem50ms.Click += new System.EventHandler(this.menuItem50ms_Click);
            // 
            // menuItem100ms
            // 
            this.menuItem100ms.Name = "menuItem100ms";
            this.menuItem100ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem100ms.Text = "100 ms";
            this.menuItem100ms.Click += new System.EventHandler(this.menuItem100ms_Click);
            // 
            // menuItem200ms
            // 
            this.menuItem200ms.Name = "menuItem200ms";
            this.menuItem200ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem200ms.Text = "200 ms";
            this.menuItem200ms.Click += new System.EventHandler(this.menuItem200ms_Click);
            // 
            // menuItem300ms
            // 
            this.menuItem300ms.Name = "menuItem300ms";
            this.menuItem300ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem300ms.Text = "300 ms";
            this.menuItem300ms.Click += new System.EventHandler(this.menuItem300ms_Click);
            // 
            // menuItem500ms
            // 
            this.menuItem500ms.Name = "menuItem500ms";
            this.menuItem500ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem500ms.Text = "500 ms";
            this.menuItem500ms.Click += new System.EventHandler(this.menuItem500ms_Click);
            // 
            // menuItem1000ms
            // 
            this.menuItem1000ms.Name = "menuItem1000ms";
            this.menuItem1000ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem1000ms.Text = "1000 ms  - RECOMMENDED by spec";
            this.menuItem1000ms.Click += new System.EventHandler(this.menuItem1000ms_Click);
            // 
            // menuItem2000ms
            // 
            this.menuItem2000ms.Name = "menuItem2000ms";
            this.menuItem2000ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem2000ms.Text = "2000 ms";
            this.menuItem2000ms.Click += new System.EventHandler(this.menuItem2000ms_Click);
            // 
            // menuItem3000ms
            // 
            this.menuItem3000ms.Name = "menuItem3000ms";
            this.menuItem3000ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem3000ms.Text = "3000 ms";
            this.menuItem3000ms.Click += new System.EventHandler(this.menuItem3000ms_Click);
            // 
            // menuItem5000ms
            // 
            this.menuItem5000ms.Name = "menuItem5000ms";
            this.menuItem5000ms.Size = new System.Drawing.Size(255, 22);
            this.menuItem5000ms.Text = "5000 ms";
            this.menuItem5000ms.Click += new System.EventHandler(this.menuItem5000ms_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(252, 6);
            // 
            // menuItemEnableKeyPressIntervals
            // 
            this.menuItemEnableKeyPressIntervals.Name = "menuItemEnableKeyPressIntervals";
            this.menuItemEnableKeyPressIntervals.Size = new System.Drawing.Size(539, 22);
            this.menuItemEnableKeyPressIntervals.Text = "Enable Key Press Intervals (Natural Typing) - RECOMMENDED";
            this.menuItemEnableKeyPressIntervals.Click += new System.EventHandler(this.menuItemEnableKeyPressIntervals_Click);
            // 
            // menuItemEnableRemoteCursor
            // 
            this.menuItemEnableRemoteCursor.Name = "menuItemEnableRemoteCursor";
            this.menuItemEnableRemoteCursor.Size = new System.Drawing.Size(539, 22);
            this.menuItemEnableRemoteCursor.Text = "Enable Remote Cursor";
            this.menuItemEnableRemoteCursor.Click += new System.EventHandler(this.menuItemEnableRemoteCursor_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(536, 6);
            // 
            // menuItemRealJabber
            // 
            this.menuItemRealJabber.Name = "menuItemRealJabber";
            this.menuItemRealJabber.Size = new System.Drawing.Size(539, 22);
            this.menuItemRealJabber.Text = "Go to www.realjabber.org";
            this.menuItemRealJabber.Click += new System.EventHandler(this.menuItemRealJabber_Click);
            // 
            // textboxSendMessage
            // 
            this.textboxSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxSendMessage.Location = new System.Drawing.Point(6, 357);
            this.textboxSendMessage.Name = "textboxSendMessage";
            this.textboxSendMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textboxSendMessage.Size = new System.Drawing.Size(326, 59);
            this.textboxSendMessage.TabIndex = 6;
            this.textboxSendMessage.Text = "";
            this.textboxSendMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxSendMessage_KeyDown);
            this.textboxSendMessage.SelectionChanged += new System.EventHandler(this.rtbSendMessage_SelectionChanged);
            this.textboxSendMessage.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textboxSendMessage_LinkClicked);
            this.textboxSendMessage.TextChanged += new System.EventHandler(this.rtbSendMessage_TextChanged);
            // 
            // textboxConversation1
            // 
            this.textboxConversation1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxConversation1.BackColor = System.Drawing.Color.White;
            this.textboxConversation1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxConversation1.Location = new System.Drawing.Point(6, 6);
            this.textboxConversation1.Name = "textboxConversation1";
            this.textboxConversation1.ReadOnly = true;
            this.textboxConversation1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textboxConversation1.Size = new System.Drawing.Size(326, 334);
            this.textboxConversation1.TabIndex = 7;
            this.textboxConversation1.Text = "";
            this.textboxConversation1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textboxConversation1_LinkClicked);
            this.textboxConversation1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxConversation1_KeyPress);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(346, 450);
            this.tabControl.TabIndex = 8;
            this.tabControl.Tag = "";
            this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseClick);
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelSendMessage);
            this.tabPage1.Controls.Add(this.textboxSendMessage);
            this.tabPage1.Controls.Add(this.textboxConversation1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(338, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "NORMAL";
            this.tabPage1.Text = "Regular Layout";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelSendMessage
            // 
            this.labelSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSendMessage.AutoSize = true;
            this.labelSendMessage.ForeColor = System.Drawing.Color.Blue;
            this.labelSendMessage.Location = new System.Drawing.Point(6, 343);
            this.labelSendMessage.Name = "labelSendMessage";
            this.labelSendMessage.Size = new System.Drawing.Size(81, 13);
            this.labelSendMessage.TabIndex = 8;
            this.labelSendMessage.Text = "Send Message:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelActiveTyping2);
            this.tabPage2.Controls.Add(this.labelSendMessage2);
            this.tabPage2.Controls.Add(this.textboxRealTime);
            this.tabPage2.Controls.Add(this.textboxConversation2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(338, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "HYBRID";
            this.tabPage2.Text = "3 Field Layout";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelActiveTyping2
            // 
            this.labelActiveTyping2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelActiveTyping2.AutoSize = true;
            this.labelActiveTyping2.ForeColor = System.Drawing.Color.Blue;
            this.labelActiveTyping2.Location = new System.Drawing.Point(6, 264);
            this.labelActiveTyping2.Name = "labelActiveTyping2";
            this.labelActiveTyping2.Size = new System.Drawing.Size(75, 13);
            this.labelActiveTyping2.TabIndex = 12;
            this.labelActiveTyping2.Text = "Active Typing:";
            // 
            // labelSendMessage2
            // 
            this.labelSendMessage2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSendMessage2.AutoSize = true;
            this.labelSendMessage2.ForeColor = System.Drawing.Color.Blue;
            this.labelSendMessage2.Location = new System.Drawing.Point(6, 343);
            this.labelSendMessage2.Name = "labelSendMessage2";
            this.labelSendMessage2.Size = new System.Drawing.Size(81, 13);
            this.labelSendMessage2.TabIndex = 11;
            this.labelSendMessage2.Text = "Send Message:";
            // 
            // textboxRealTime
            // 
            this.textboxRealTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxRealTime.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textboxRealTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxRealTime.Location = new System.Drawing.Point(6, 279);
            this.textboxRealTime.Name = "textboxRealTime";
            this.textboxRealTime.ReadOnly = true;
            this.textboxRealTime.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textboxRealTime.Size = new System.Drawing.Size(326, 59);
            this.textboxRealTime.TabIndex = 10;
            this.textboxRealTime.Text = "";
            this.textboxRealTime.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textboxRealTime_LinkClicked);
            this.textboxRealTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxRealTime_KeyPress);
            // 
            // textboxConversation2
            // 
            this.textboxConversation2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxConversation2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textboxConversation2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxConversation2.Location = new System.Drawing.Point(6, 6);
            this.textboxConversation2.Name = "textboxConversation2";
            this.textboxConversation2.ReadOnly = true;
            this.textboxConversation2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textboxConversation2.Size = new System.Drawing.Size(326, 255);
            this.textboxConversation2.TabIndex = 9;
            this.textboxConversation2.Text = "";
            this.textboxConversation2.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textboxConversation2_LinkClicked);
            this.textboxConversation2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxConversation2_KeyPress);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBoxParticipantLocal);
            this.tabPage3.Controls.Add(this.groupBoxParticipant1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(338, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "SPLIT";
            this.tabPage3.Text = "Split Screen";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBoxParticipantLocal
            // 
            this.groupBoxParticipantLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxParticipantLocal.Controls.Add(this.textboxParticipantLocal);
            this.groupBoxParticipantLocal.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxParticipantLocal.Location = new System.Drawing.Point(6, 252);
            this.groupBoxParticipantLocal.Name = "groupBoxParticipantLocal";
            this.groupBoxParticipantLocal.Size = new System.Drawing.Size(326, 166);
            this.groupBoxParticipantLocal.TabIndex = 13;
            this.groupBoxParticipantLocal.TabStop = false;
            this.groupBoxParticipantLocal.Text = "Local Participant";
            // 
            // textboxParticipantLocal
            // 
            this.textboxParticipantLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxParticipantLocal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textboxParticipantLocal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxParticipantLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxParticipantLocal.Location = new System.Drawing.Point(6, 19);
            this.textboxParticipantLocal.Name = "textboxParticipantLocal";
            this.textboxParticipantLocal.ReadOnly = true;
            this.textboxParticipantLocal.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textboxParticipantLocal.Size = new System.Drawing.Size(314, 141);
            this.textboxParticipantLocal.TabIndex = 10;
            this.textboxParticipantLocal.Text = "";
            this.textboxParticipantLocal.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textboxParticipantLocal_LinkClicked);
            this.textboxParticipantLocal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxParticipantLocal_KeyPress);
            // 
            // groupBoxParticipant1
            // 
            this.groupBoxParticipant1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxParticipant1.Controls.Add(this.textboxParticipant1);
            this.groupBoxParticipant1.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxParticipant1.Location = new System.Drawing.Point(6, 6);
            this.groupBoxParticipant1.Name = "groupBoxParticipant1";
            this.groupBoxParticipant1.Size = new System.Drawing.Size(326, 240);
            this.groupBoxParticipant1.TabIndex = 12;
            this.groupBoxParticipant1.TabStop = false;
            this.groupBoxParticipant1.Text = "Participant #1";
            // 
            // textboxParticipant1
            // 
            this.textboxParticipant1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxParticipant1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textboxParticipant1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxParticipant1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxParticipant1.Location = new System.Drawing.Point(6, 19);
            this.textboxParticipant1.Name = "textboxParticipant1";
            this.textboxParticipant1.ReadOnly = true;
            this.textboxParticipant1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textboxParticipant1.Size = new System.Drawing.Size(314, 215);
            this.textboxParticipant1.TabIndex = 10;
            this.textboxParticipant1.Text = "";
            this.textboxParticipant1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textboxParticipant1_LinkClicked);
            this.textboxParticipant1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxParticipant1_KeyPress);
            // 
            // FrmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 474);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmChat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.FrmChat_Load);
            this.Activated += new System.EventHandler(this.FrmChat_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmChat_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBoxParticipantLocal.ResumeLayout(false);
            this.groupBoxParticipant1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem converToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.RichTextBox textboxSendMessage;
        private System.Windows.Forms.RichTextBox textboxConversation1;
        private System.Windows.Forms.Timer timerRTTsend;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox textboxConversation2;
        private System.Windows.Forms.RichTextBox textboxRealTime;
        private System.Windows.Forms.Label labelSendMessage;
        private System.Windows.Forms.Label labelActiveTyping2;
        private System.Windows.Forms.Label labelSendMessage2;
        private System.Windows.Forms.GroupBox groupBoxParticipant1;
        private System.Windows.Forms.RichTextBox textboxParticipant1;
        private System.Windows.Forms.GroupBox groupBoxParticipantLocal;
        private System.Windows.Forms.RichTextBox textboxParticipantLocal;
        private System.Windows.Forms.ToolStripMenuItem experimentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemResetToBaseline;
        private System.Windows.Forms.ToolStripMenuItem menuItemCustomTransmitInterval;
        private System.Windows.Forms.ToolStripMenuItem menuItem0ms;
        private System.Windows.Forms.ToolStripMenuItem menuItem100ms;
        private System.Windows.Forms.ToolStripMenuItem menuItem300ms;
        private System.Windows.Forms.ToolStripMenuItem menuItem500ms;
        private System.Windows.Forms.ToolStripMenuItem menuItem1000ms;
        private System.Windows.Forms.ToolStripMenuItem menuItem2000ms;
        private System.Windows.Forms.ToolStripMenuItem menuItem3000ms;
        private System.Windows.Forms.ToolStripMenuItem menuItemNaturalTypingMode3;
        private System.Windows.Forms.ToolStripMenuItem menuItemNaturalTypingMode1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemNaturalTypingMode2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuItemEnableKeyPressIntervals;
        private System.Windows.Forms.ToolStripMenuItem menuItemEnableRemoteCursor;
        private System.Windows.Forms.ToolStripMenuItem menuItem200ms;
        private System.Windows.Forms.ToolStripMenuItem menuItem50ms;
        private System.Windows.Forms.ToolStripMenuItem menuItem20ms;
        private System.Windows.Forms.ToolStripMenuItem menuItem5000ms;
        private System.Windows.Forms.ToolStripMenuItem menuItemEnableRTT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuItemRealJabber;
        private System.Windows.Forms.ToolStripMenuItem menuItemClear;
    }
}