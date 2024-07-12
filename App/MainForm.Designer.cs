namespace App
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MenuStrip = new MenuStrip();
            FileMenuItem = new ToolStripMenuItem();
            ExitMenuItem = new ToolStripMenuItem();
            SettingsMenuItem = new ToolStripMenuItem();
            ConfigReceiverListMenuItem = new ToolStripMenuItem();
            GlobalReceiverSettings = new ToolStripMenuItem();
            GeneralSettingMenuItem = new ToolStripMenuItem();
            HelpMenuItem = new ToolStripMenuItem();
            CheckUpdatesMenuItem = new ToolStripMenuItem();
            AboutMenuItem = new ToolStripMenuItem();
            UtilitiesMenuItem = new ToolStripMenuItem();
            RCNScheduleMenuItem = new ToolStripMenuItem();
            AutoAssignAllMenuItem = new ToolStripMenuItem();
            DevToolsMenuItem = new ToolStripMenuItem();
            ReceiverSplitContainer = new SplitContainer();
            ReceiverList = new DataGridView();
            NameColumn = new DataGridViewTextBoxColumn();
            IPAddressColumn = new DataGridViewTextBoxColumn();
            ReceiverListLabel = new Label();
            SelectedReceiverGroupbox = new GroupBox();
            SelectedReceiverSplitContainer = new SplitContainer();
            TunerSplitContainer = new SplitContainer();
            Tuner1Groupbox = new GroupBox();
            Tuner1OpenEventButton = new Button();
            Tuner1EventLabel = new Label();
            Tuner1ActiveChannelTextbox = new TextBox();
            Tuner1ChannelLabel = new Label();
            Tuner1ActiveChannelTitleTextbox = new TextBox();
            Tuner1ControlGroupbox = new GroupBox();
            Tuner1AutoAssignButton = new Button();
            Tuner1InactivityToggleButton = new Button();
            Tuner1SetChannelButton = new Button();
            Tuner1ChannelTextbox = new TextBox();
            Tuner1ChannelTitleLabel = new Label();
            Tuner2Groupbox = new GroupBox();
            Tuner2OpenEventButton = new Button();
            Tuner2EventLabel = new Label();
            Tuner2ActiveChannelTextbox = new TextBox();
            Tuner2ChannelLabel = new Label();
            Tuner2ActiveChannelTitleTextbox = new TextBox();
            Tuner2ChannelTitleLabel = new Label();
            Tuner2ControlGroupbox = new GroupBox();
            Tuner2AutoAssignButton = new Button();
            Tuner2InactivityToggleButton = new Button();
            Tuner2SetChannelButton = new Button();
            Tuner2ChannelTextbox = new TextBox();
            groupBox1 = new GroupBox();
            FlowLayoutInformation = new FlowLayoutPanel();
            ReceiverInfoPanel1 = new Panel();
            ReceiverNameTextbox = new TextBox();
            ReceiverNameLabel = new Label();
            ReceiverInfoPanel2 = new Panel();
            ReceiverIDTextbox = new TextBox();
            ReceiverIDLabel = new Label();
            ReceiverInfoPanel3 = new Panel();
            ReceiverIPAddressTextbox = new TextBox();
            ReceiverIPAddressLabel = new Label();
            ReceiverInfoPanel4 = new Panel();
            ReceiverUpdateTextbox = new TextBox();
            ReceiverUpdateLabel = new Label();
            ReceiverInfoPanel5 = new Panel();
            ReceiverModelTextbox = new TextBox();
            ReceiverModelLabel = new Label();
            ReceiverInfoPanel6 = new Panel();
            ReceiverVersionTextbox = new TextBox();
            ReceiverVersionLabel = new Label();
            ReceiverInfoPanel7 = new Panel();
            ReceiverInactivityTextbox = new TextBox();
            ReceiverInactivityLabel = new Label();
            AutoRefreshTimer = new System.Windows.Forms.Timer(components);
            toolTip1 = new ToolTip(components);
            LoadingSplitContainer = new SplitContainer();
            LoadingProgressBar = new ProgressBar();
            MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReceiverSplitContainer).BeginInit();
            ReceiverSplitContainer.Panel1.SuspendLayout();
            ReceiverSplitContainer.Panel2.SuspendLayout();
            ReceiverSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReceiverList).BeginInit();
            SelectedReceiverGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedReceiverSplitContainer).BeginInit();
            SelectedReceiverSplitContainer.Panel1.SuspendLayout();
            SelectedReceiverSplitContainer.Panel2.SuspendLayout();
            SelectedReceiverSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TunerSplitContainer).BeginInit();
            TunerSplitContainer.Panel1.SuspendLayout();
            TunerSplitContainer.Panel2.SuspendLayout();
            TunerSplitContainer.SuspendLayout();
            Tuner1Groupbox.SuspendLayout();
            Tuner1ControlGroupbox.SuspendLayout();
            Tuner2Groupbox.SuspendLayout();
            Tuner2ControlGroupbox.SuspendLayout();
            groupBox1.SuspendLayout();
            FlowLayoutInformation.SuspendLayout();
            ReceiverInfoPanel1.SuspendLayout();
            ReceiverInfoPanel2.SuspendLayout();
            ReceiverInfoPanel3.SuspendLayout();
            ReceiverInfoPanel4.SuspendLayout();
            ReceiverInfoPanel5.SuspendLayout();
            ReceiverInfoPanel6.SuspendLayout();
            ReceiverInfoPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LoadingSplitContainer).BeginInit();
            LoadingSplitContainer.Panel1.SuspendLayout();
            LoadingSplitContainer.Panel2.SuspendLayout();
            LoadingSplitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { FileMenuItem, SettingsMenuItem, HelpMenuItem, UtilitiesMenuItem });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(994, 24);
            MenuStrip.TabIndex = 0;
            MenuStrip.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            FileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ExitMenuItem });
            FileMenuItem.Name = "FileMenuItem";
            FileMenuItem.Size = new Size(37, 20);
            FileMenuItem.Text = "File";
            // 
            // ExitMenuItem
            // 
            ExitMenuItem.Name = "ExitMenuItem";
            ExitMenuItem.Size = new Size(93, 22);
            ExitMenuItem.Text = "Exit";
            ExitMenuItem.Click += ExitMenuItem_Click;
            // 
            // SettingsMenuItem
            // 
            SettingsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ConfigReceiverListMenuItem, GlobalReceiverSettings, GeneralSettingMenuItem });
            SettingsMenuItem.Name = "SettingsMenuItem";
            SettingsMenuItem.Size = new Size(61, 20);
            SettingsMenuItem.Text = "Settings";
            // 
            // ConfigReceiverListMenuItem
            // 
            ConfigReceiverListMenuItem.Name = "ConfigReceiverListMenuItem";
            ConfigReceiverListMenuItem.Size = new Size(200, 22);
            ConfigReceiverListMenuItem.Text = "Configure Receiver List";
            ConfigReceiverListMenuItem.Click += ConfigReceiverListMenuItem_Click;
            // 
            // GlobalReceiverSettings
            // 
            GlobalReceiverSettings.Name = "GlobalReceiverSettings";
            GlobalReceiverSettings.Size = new Size(200, 22);
            GlobalReceiverSettings.Text = "Global Receiver Settings";
            // 
            // GeneralSettingMenuItem
            // 
            GeneralSettingMenuItem.Name = "GeneralSettingMenuItem";
            GeneralSettingMenuItem.Size = new Size(200, 22);
            GeneralSettingMenuItem.Text = "General Settings";
            GeneralSettingMenuItem.Click += GeneralSettingMenuItem_Click;
            // 
            // HelpMenuItem
            // 
            HelpMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CheckUpdatesMenuItem, AboutMenuItem });
            HelpMenuItem.Name = "HelpMenuItem";
            HelpMenuItem.Size = new Size(44, 20);
            HelpMenuItem.Text = "Help";
            // 
            // CheckUpdatesMenuItem
            // 
            CheckUpdatesMenuItem.Name = "CheckUpdatesMenuItem";
            CheckUpdatesMenuItem.Size = new Size(180, 22);
            CheckUpdatesMenuItem.Text = "Check for Updates...";
            CheckUpdatesMenuItem.Click += CheckUpdatesMenuItem_Click;
            // 
            // AboutMenuItem
            // 
            AboutMenuItem.Name = "AboutMenuItem";
            AboutMenuItem.Size = new Size(180, 22);
            AboutMenuItem.Text = "About";
            AboutMenuItem.Click += AboutMenuItem_Click;
            // 
            // UtilitiesMenuItem
            // 
            UtilitiesMenuItem.DropDownItems.AddRange(new ToolStripItem[] { RCNScheduleMenuItem, AutoAssignAllMenuItem, DevToolsMenuItem });
            UtilitiesMenuItem.Name = "UtilitiesMenuItem";
            UtilitiesMenuItem.Size = new Size(58, 20);
            UtilitiesMenuItem.Text = "Utilities";
            // 
            // RCNScheduleMenuItem
            // 
            RCNScheduleMenuItem.Name = "RCNScheduleMenuItem";
            RCNScheduleMenuItem.Size = new Size(157, 22);
            RCNScheduleMenuItem.Text = "RCN Schedule";
            RCNScheduleMenuItem.Click += RCNScheduleMenuItem_Click;
            // 
            // AutoAssignAllMenuItem
            // 
            AutoAssignAllMenuItem.Name = "AutoAssignAllMenuItem";
            AutoAssignAllMenuItem.Size = new Size(157, 22);
            AutoAssignAllMenuItem.Text = "Auto Assign All";
            AutoAssignAllMenuItem.Click += AutoAssignAllMenuItem_Click;
            // 
            // DevToolsMenuItem
            // 
            DevToolsMenuItem.Name = "DevToolsMenuItem";
            DevToolsMenuItem.Size = new Size(157, 22);
            DevToolsMenuItem.Text = "Developer Tools";
            DevToolsMenuItem.Click += DevToolsMenuItem_Click;
            // 
            // ReceiverSplitContainer
            // 
            ReceiverSplitContainer.Dock = DockStyle.Fill;
            ReceiverSplitContainer.Location = new Point(0, 0);
            ReceiverSplitContainer.Name = "ReceiverSplitContainer";
            // 
            // ReceiverSplitContainer.Panel1
            // 
            ReceiverSplitContainer.Panel1.Controls.Add(ReceiverList);
            ReceiverSplitContainer.Panel1.Controls.Add(ReceiverListLabel);
            ReceiverSplitContainer.Panel1.Padding = new Padding(5);
            ReceiverSplitContainer.Panel1MinSize = 250;
            // 
            // ReceiverSplitContainer.Panel2
            // 
            ReceiverSplitContainer.Panel2.Controls.Add(SelectedReceiverGroupbox);
            ReceiverSplitContainer.Panel2.Padding = new Padding(5);
            ReceiverSplitContainer.Panel2MinSize = 725;
            ReceiverSplitContainer.Size = new Size(994, 437);
            ReceiverSplitContainer.SplitterDistance = 265;
            ReceiverSplitContainer.TabIndex = 1;
            ReceiverSplitContainer.Paint += Splitter_Paint;
            ReceiverSplitContainer.Resize += Splitter_Resize;
            // 
            // ReceiverList
            // 
            ReceiverList.AllowUserToAddRows = false;
            ReceiverList.AllowUserToDeleteRows = false;
            ReceiverList.AllowUserToResizeRows = false;
            ReceiverList.BackgroundColor = SystemColors.Control;
            ReceiverList.BorderStyle = BorderStyle.Fixed3D;
            ReceiverList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReceiverList.Columns.AddRange(new DataGridViewColumn[] { NameColumn, IPAddressColumn });
            ReceiverList.Dock = DockStyle.Fill;
            ReceiverList.Location = new Point(5, 25);
            ReceiverList.MultiSelect = false;
            ReceiverList.Name = "ReceiverList";
            ReceiverList.ReadOnly = true;
            ReceiverList.RowHeadersVisible = false;
            ReceiverList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReceiverList.Size = new Size(255, 407);
            ReceiverList.TabIndex = 1;
            ReceiverList.SelectionChanged += ReceiverList_SelectionChanged;
            // 
            // NameColumn
            // 
            NameColumn.DataPropertyName = "ReceiverName";
            NameColumn.HeaderText = "Name";
            NameColumn.Name = "NameColumn";
            NameColumn.ReadOnly = true;
            NameColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // IPAddressColumn
            // 
            IPAddressColumn.DataPropertyName = "ReceiverIP";
            IPAddressColumn.HeaderText = "IP Address";
            IPAddressColumn.Name = "IPAddressColumn";
            IPAddressColumn.ReadOnly = true;
            IPAddressColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ReceiverListLabel
            // 
            ReceiverListLabel.Dock = DockStyle.Top;
            ReceiverListLabel.Location = new Point(5, 5);
            ReceiverListLabel.Name = "ReceiverListLabel";
            ReceiverListLabel.Padding = new Padding(5, 0, 0, 0);
            ReceiverListLabel.Size = new Size(255, 20);
            ReceiverListLabel.TabIndex = 0;
            ReceiverListLabel.Text = "Receivers:";
            ReceiverListLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SelectedReceiverGroupbox
            // 
            SelectedReceiverGroupbox.Controls.Add(SelectedReceiverSplitContainer);
            SelectedReceiverGroupbox.Dock = DockStyle.Fill;
            SelectedReceiverGroupbox.Location = new Point(5, 5);
            SelectedReceiverGroupbox.Name = "SelectedReceiverGroupbox";
            SelectedReceiverGroupbox.Padding = new Padding(5);
            SelectedReceiverGroupbox.Size = new Size(715, 427);
            SelectedReceiverGroupbox.TabIndex = 0;
            SelectedReceiverGroupbox.TabStop = false;
            SelectedReceiverGroupbox.Text = "Receiver A";
            // 
            // SelectedReceiverSplitContainer
            // 
            SelectedReceiverSplitContainer.Dock = DockStyle.Fill;
            SelectedReceiverSplitContainer.Location = new Point(5, 21);
            SelectedReceiverSplitContainer.Name = "SelectedReceiverSplitContainer";
            SelectedReceiverSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // SelectedReceiverSplitContainer.Panel1
            // 
            SelectedReceiverSplitContainer.Panel1.Controls.Add(TunerSplitContainer);
            SelectedReceiverSplitContainer.Panel1MinSize = 200;
            // 
            // SelectedReceiverSplitContainer.Panel2
            // 
            SelectedReceiverSplitContainer.Panel2.Controls.Add(groupBox1);
            SelectedReceiverSplitContainer.Panel2.Padding = new Padding(5);
            SelectedReceiverSplitContainer.Panel2MinSize = 180;
            SelectedReceiverSplitContainer.Size = new Size(705, 401);
            SelectedReceiverSplitContainer.SplitterDistance = 200;
            SelectedReceiverSplitContainer.TabIndex = 0;
            SelectedReceiverSplitContainer.Paint += Splitter_Paint;
            SelectedReceiverSplitContainer.Resize += Splitter_Resize;
            // 
            // TunerSplitContainer
            // 
            TunerSplitContainer.Dock = DockStyle.Fill;
            TunerSplitContainer.Location = new Point(0, 0);
            TunerSplitContainer.Name = "TunerSplitContainer";
            // 
            // TunerSplitContainer.Panel1
            // 
            TunerSplitContainer.Panel1.Controls.Add(Tuner1Groupbox);
            TunerSplitContainer.Panel1.Padding = new Padding(5);
            TunerSplitContainer.Panel1MinSize = 348;
            // 
            // TunerSplitContainer.Panel2
            // 
            TunerSplitContainer.Panel2.Controls.Add(Tuner2Groupbox);
            TunerSplitContainer.Panel2.Padding = new Padding(5);
            TunerSplitContainer.Panel2MinSize = 348;
            TunerSplitContainer.Size = new Size(705, 200);
            TunerSplitContainer.SplitterDistance = 351;
            TunerSplitContainer.TabIndex = 0;
            TunerSplitContainer.Paint += Splitter_Paint;
            TunerSplitContainer.Resize += Splitter_Resize;
            // 
            // Tuner1Groupbox
            // 
            Tuner1Groupbox.Controls.Add(Tuner1OpenEventButton);
            Tuner1Groupbox.Controls.Add(Tuner1EventLabel);
            Tuner1Groupbox.Controls.Add(Tuner1ActiveChannelTextbox);
            Tuner1Groupbox.Controls.Add(Tuner1ChannelLabel);
            Tuner1Groupbox.Controls.Add(Tuner1ActiveChannelTitleTextbox);
            Tuner1Groupbox.Controls.Add(Tuner1ControlGroupbox);
            Tuner1Groupbox.Controls.Add(Tuner1ChannelTitleLabel);
            Tuner1Groupbox.Dock = DockStyle.Fill;
            Tuner1Groupbox.Location = new Point(5, 5);
            Tuner1Groupbox.Name = "Tuner1Groupbox";
            Tuner1Groupbox.Size = new Size(341, 190);
            Tuner1Groupbox.TabIndex = 0;
            Tuner1Groupbox.TabStop = false;
            Tuner1Groupbox.Text = "Tuner 1";
            Tuner1Groupbox.Paint += TunerGroupbox_Paint;
            // 
            // Tuner1OpenEventButton
            // 
            Tuner1OpenEventButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Tuner1OpenEventButton.Cursor = Cursors.Hand;
            Tuner1OpenEventButton.Enabled = false;
            Tuner1OpenEventButton.Location = new Point(118, 74);
            Tuner1OpenEventButton.Name = "Tuner1OpenEventButton";
            Tuner1OpenEventButton.Size = new Size(217, 23);
            Tuner1OpenEventButton.TabIndex = 7;
            Tuner1OpenEventButton.Text = "Open Event";
            Tuner1OpenEventButton.UseVisualStyleBackColor = true;
            // 
            // Tuner1EventLabel
            // 
            Tuner1EventLabel.AutoSize = true;
            Tuner1EventLabel.Location = new Point(8, 77);
            Tuner1EventLabel.Name = "Tuner1EventLabel";
            Tuner1EventLabel.Size = new Size(105, 15);
            Tuner1EventLabel.TabIndex = 6;
            Tuner1EventLabel.Text = "Event Information:";
            // 
            // Tuner1ActiveChannelTextbox
            // 
            Tuner1ActiveChannelTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Tuner1ActiveChannelTextbox.Location = new Point(118, 45);
            Tuner1ActiveChannelTextbox.Name = "Tuner1ActiveChannelTextbox";
            Tuner1ActiveChannelTextbox.ReadOnly = true;
            Tuner1ActiveChannelTextbox.Size = new Size(217, 23);
            Tuner1ActiveChannelTextbox.TabIndex = 5;
            // 
            // Tuner1ChannelLabel
            // 
            Tuner1ChannelLabel.AutoSize = true;
            Tuner1ChannelLabel.Location = new Point(8, 48);
            Tuner1ChannelLabel.Name = "Tuner1ChannelLabel";
            Tuner1ChannelLabel.Size = new Size(54, 15);
            Tuner1ChannelLabel.TabIndex = 4;
            Tuner1ChannelLabel.Text = "Channel:";
            // 
            // Tuner1ActiveChannelTitleTextbox
            // 
            Tuner1ActiveChannelTitleTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Tuner1ActiveChannelTitleTextbox.Location = new Point(118, 16);
            Tuner1ActiveChannelTitleTextbox.Name = "Tuner1ActiveChannelTitleTextbox";
            Tuner1ActiveChannelTitleTextbox.ReadOnly = true;
            Tuner1ActiveChannelTitleTextbox.Size = new Size(217, 23);
            Tuner1ActiveChannelTitleTextbox.TabIndex = 3;
            // 
            // Tuner1ControlGroupbox
            // 
            Tuner1ControlGroupbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Tuner1ControlGroupbox.Controls.Add(Tuner1AutoAssignButton);
            Tuner1ControlGroupbox.Controls.Add(Tuner1InactivityToggleButton);
            Tuner1ControlGroupbox.Controls.Add(Tuner1SetChannelButton);
            Tuner1ControlGroupbox.Controls.Add(Tuner1ChannelTextbox);
            Tuner1ControlGroupbox.Location = new Point(6, 133);
            Tuner1ControlGroupbox.Name = "Tuner1ControlGroupbox";
            Tuner1ControlGroupbox.Size = new Size(329, 51);
            Tuner1ControlGroupbox.TabIndex = 1;
            Tuner1ControlGroupbox.TabStop = false;
            Tuner1ControlGroupbox.Text = "Tuner Control";
            // 
            // Tuner1AutoAssignButton
            // 
            Tuner1AutoAssignButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Tuner1AutoAssignButton.Cursor = Cursors.Hand;
            Tuner1AutoAssignButton.Location = new Point(155, 21);
            Tuner1AutoAssignButton.Name = "Tuner1AutoAssignButton";
            Tuner1AutoAssignButton.Size = new Size(85, 23);
            Tuner1AutoAssignButton.TabIndex = 3;
            Tuner1AutoAssignButton.Text = "Auto Assign";
            Tuner1AutoAssignButton.UseVisualStyleBackColor = true;
            Tuner1AutoAssignButton.Click += Tuner1AutoAssignButton_Click;
            // 
            // Tuner1InactivityToggleButton
            // 
            Tuner1InactivityToggleButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Tuner1InactivityToggleButton.Cursor = Cursors.Hand;
            Tuner1InactivityToggleButton.Location = new Point(246, 21);
            Tuner1InactivityToggleButton.Name = "Tuner1InactivityToggleButton";
            Tuner1InactivityToggleButton.Size = new Size(77, 23);
            Tuner1InactivityToggleButton.TabIndex = 2;
            Tuner1InactivityToggleButton.Text = "Wake Up";
            Tuner1InactivityToggleButton.UseVisualStyleBackColor = true;
            Tuner1InactivityToggleButton.Click += Tuner1InactivityToggleButton_Click;
            // 
            // Tuner1SetChannelButton
            // 
            Tuner1SetChannelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Tuner1SetChannelButton.Cursor = Cursors.Hand;
            Tuner1SetChannelButton.Enabled = false;
            Tuner1SetChannelButton.Location = new Point(69, 21);
            Tuner1SetChannelButton.Name = "Tuner1SetChannelButton";
            Tuner1SetChannelButton.Size = new Size(80, 23);
            Tuner1SetChannelButton.TabIndex = 1;
            Tuner1SetChannelButton.Text = "Set Channel";
            Tuner1SetChannelButton.UseVisualStyleBackColor = true;
            Tuner1SetChannelButton.Click += Tuner1SetChannelButton_Click;
            // 
            // Tuner1ChannelTextbox
            // 
            Tuner1ChannelTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Tuner1ChannelTextbox.Location = new Point(6, 22);
            Tuner1ChannelTextbox.MaxLength = 4;
            Tuner1ChannelTextbox.Name = "Tuner1ChannelTextbox";
            Tuner1ChannelTextbox.PlaceholderText = "####";
            Tuner1ChannelTextbox.Size = new Size(57, 23);
            Tuner1ChannelTextbox.TabIndex = 0;
            Tuner1ChannelTextbox.TextChanged += Tuner1ChannelTextbox_TextChanged;
            Tuner1ChannelTextbox.KeyDown += Tuner1ChannelTextbox_KeyDown;
            // 
            // Tuner1ChannelTitleLabel
            // 
            Tuner1ChannelTitleLabel.AutoSize = true;
            Tuner1ChannelTitleLabel.Location = new Point(8, 19);
            Tuner1ChannelTitleLabel.Name = "Tuner1ChannelTitleLabel";
            Tuner1ChannelTitleLabel.Size = new Size(79, 15);
            Tuner1ChannelTitleLabel.TabIndex = 0;
            Tuner1ChannelTitleLabel.Text = "Channel Title:";
            // 
            // Tuner2Groupbox
            // 
            Tuner2Groupbox.Controls.Add(Tuner2OpenEventButton);
            Tuner2Groupbox.Controls.Add(Tuner2EventLabel);
            Tuner2Groupbox.Controls.Add(Tuner2ActiveChannelTextbox);
            Tuner2Groupbox.Controls.Add(Tuner2ChannelLabel);
            Tuner2Groupbox.Controls.Add(Tuner2ActiveChannelTitleTextbox);
            Tuner2Groupbox.Controls.Add(Tuner2ChannelTitleLabel);
            Tuner2Groupbox.Controls.Add(Tuner2ControlGroupbox);
            Tuner2Groupbox.Dock = DockStyle.Fill;
            Tuner2Groupbox.Location = new Point(5, 5);
            Tuner2Groupbox.Name = "Tuner2Groupbox";
            Tuner2Groupbox.Size = new Size(340, 190);
            Tuner2Groupbox.TabIndex = 0;
            Tuner2Groupbox.TabStop = false;
            Tuner2Groupbox.Text = "Tuner 2";
            Tuner2Groupbox.Paint += TunerGroupbox_Paint;
            // 
            // Tuner2OpenEventButton
            // 
            Tuner2OpenEventButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Tuner2OpenEventButton.Cursor = Cursors.Hand;
            Tuner2OpenEventButton.Enabled = false;
            Tuner2OpenEventButton.Location = new Point(116, 74);
            Tuner2OpenEventButton.Name = "Tuner2OpenEventButton";
            Tuner2OpenEventButton.Size = new Size(211, 23);
            Tuner2OpenEventButton.TabIndex = 13;
            Tuner2OpenEventButton.Text = "Open Event";
            Tuner2OpenEventButton.UseVisualStyleBackColor = true;
            // 
            // Tuner2EventLabel
            // 
            Tuner2EventLabel.AutoSize = true;
            Tuner2EventLabel.Location = new Point(6, 77);
            Tuner2EventLabel.Name = "Tuner2EventLabel";
            Tuner2EventLabel.Size = new Size(105, 15);
            Tuner2EventLabel.TabIndex = 12;
            Tuner2EventLabel.Text = "Event Information:";
            // 
            // Tuner2ActiveChannelTextbox
            // 
            Tuner2ActiveChannelTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Tuner2ActiveChannelTextbox.Location = new Point(116, 45);
            Tuner2ActiveChannelTextbox.Name = "Tuner2ActiveChannelTextbox";
            Tuner2ActiveChannelTextbox.ReadOnly = true;
            Tuner2ActiveChannelTextbox.Size = new Size(211, 23);
            Tuner2ActiveChannelTextbox.TabIndex = 11;
            // 
            // Tuner2ChannelLabel
            // 
            Tuner2ChannelLabel.AutoSize = true;
            Tuner2ChannelLabel.Location = new Point(6, 48);
            Tuner2ChannelLabel.Name = "Tuner2ChannelLabel";
            Tuner2ChannelLabel.Size = new Size(54, 15);
            Tuner2ChannelLabel.TabIndex = 10;
            Tuner2ChannelLabel.Text = "Channel:";
            // 
            // Tuner2ActiveChannelTitleTextbox
            // 
            Tuner2ActiveChannelTitleTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Tuner2ActiveChannelTitleTextbox.Location = new Point(116, 16);
            Tuner2ActiveChannelTitleTextbox.Name = "Tuner2ActiveChannelTitleTextbox";
            Tuner2ActiveChannelTitleTextbox.ReadOnly = true;
            Tuner2ActiveChannelTitleTextbox.Size = new Size(211, 23);
            Tuner2ActiveChannelTitleTextbox.TabIndex = 9;
            // 
            // Tuner2ChannelTitleLabel
            // 
            Tuner2ChannelTitleLabel.AutoSize = true;
            Tuner2ChannelTitleLabel.Location = new Point(6, 19);
            Tuner2ChannelTitleLabel.Name = "Tuner2ChannelTitleLabel";
            Tuner2ChannelTitleLabel.Size = new Size(79, 15);
            Tuner2ChannelTitleLabel.TabIndex = 8;
            Tuner2ChannelTitleLabel.Text = "Channel Title:";
            // 
            // Tuner2ControlGroupbox
            // 
            Tuner2ControlGroupbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Tuner2ControlGroupbox.Controls.Add(Tuner2AutoAssignButton);
            Tuner2ControlGroupbox.Controls.Add(Tuner2InactivityToggleButton);
            Tuner2ControlGroupbox.Controls.Add(Tuner2SetChannelButton);
            Tuner2ControlGroupbox.Controls.Add(Tuner2ChannelTextbox);
            Tuner2ControlGroupbox.Location = new Point(6, 133);
            Tuner2ControlGroupbox.Name = "Tuner2ControlGroupbox";
            Tuner2ControlGroupbox.Size = new Size(328, 51);
            Tuner2ControlGroupbox.TabIndex = 2;
            Tuner2ControlGroupbox.TabStop = false;
            Tuner2ControlGroupbox.Text = "Tuner Control";
            // 
            // Tuner2AutoAssignButton
            // 
            Tuner2AutoAssignButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Tuner2AutoAssignButton.Cursor = Cursors.Hand;
            Tuner2AutoAssignButton.Location = new Point(154, 22);
            Tuner2AutoAssignButton.Name = "Tuner2AutoAssignButton";
            Tuner2AutoAssignButton.Size = new Size(85, 23);
            Tuner2AutoAssignButton.TabIndex = 3;
            Tuner2AutoAssignButton.Text = "Auto Assign";
            Tuner2AutoAssignButton.UseVisualStyleBackColor = true;
            Tuner2AutoAssignButton.Click += Tuner2AutoAssignButton_Click;
            // 
            // Tuner2InactivityToggleButton
            // 
            Tuner2InactivityToggleButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Tuner2InactivityToggleButton.Cursor = Cursors.Hand;
            Tuner2InactivityToggleButton.Location = new Point(245, 22);
            Tuner2InactivityToggleButton.Name = "Tuner2InactivityToggleButton";
            Tuner2InactivityToggleButton.Size = new Size(77, 23);
            Tuner2InactivityToggleButton.TabIndex = 2;
            Tuner2InactivityToggleButton.Text = "Wake Up";
            Tuner2InactivityToggleButton.UseVisualStyleBackColor = true;
            Tuner2InactivityToggleButton.Click += Tuner2InactivityToggleButton_Click;
            // 
            // Tuner2SetChannelButton
            // 
            Tuner2SetChannelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Tuner2SetChannelButton.Cursor = Cursors.Hand;
            Tuner2SetChannelButton.Enabled = false;
            Tuner2SetChannelButton.Location = new Point(68, 22);
            Tuner2SetChannelButton.Name = "Tuner2SetChannelButton";
            Tuner2SetChannelButton.Size = new Size(80, 23);
            Tuner2SetChannelButton.TabIndex = 1;
            Tuner2SetChannelButton.Text = "Set Channel";
            Tuner2SetChannelButton.UseVisualStyleBackColor = true;
            Tuner2SetChannelButton.Click += Tuner2SetChannelButton_Click;
            // 
            // Tuner2ChannelTextbox
            // 
            Tuner2ChannelTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Tuner2ChannelTextbox.Location = new Point(6, 22);
            Tuner2ChannelTextbox.MaxLength = 4;
            Tuner2ChannelTextbox.Name = "Tuner2ChannelTextbox";
            Tuner2ChannelTextbox.PlaceholderText = "####";
            Tuner2ChannelTextbox.Size = new Size(56, 23);
            Tuner2ChannelTextbox.TabIndex = 0;
            Tuner2ChannelTextbox.TextChanged += Tuner2ChannelTextbox_TextChanged;
            Tuner2ChannelTextbox.KeyDown += Tuner2ChannelTextbox_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(FlowLayoutInformation);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(5, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(695, 187);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Receiver Information";
            // 
            // FlowLayoutInformation
            // 
            FlowLayoutInformation.Controls.Add(ReceiverInfoPanel1);
            FlowLayoutInformation.Controls.Add(ReceiverInfoPanel2);
            FlowLayoutInformation.Controls.Add(ReceiverInfoPanel3);
            FlowLayoutInformation.Controls.Add(ReceiverInfoPanel4);
            FlowLayoutInformation.Controls.Add(ReceiverInfoPanel5);
            FlowLayoutInformation.Controls.Add(ReceiverInfoPanel6);
            FlowLayoutInformation.Controls.Add(ReceiverInfoPanel7);
            FlowLayoutInformation.Dock = DockStyle.Fill;
            FlowLayoutInformation.FlowDirection = FlowDirection.TopDown;
            FlowLayoutInformation.Location = new Point(3, 19);
            FlowLayoutInformation.Margin = new Padding(0);
            FlowLayoutInformation.Name = "FlowLayoutInformation";
            FlowLayoutInformation.Size = new Size(689, 165);
            FlowLayoutInformation.TabIndex = 0;
            // 
            // ReceiverInfoPanel1
            // 
            ReceiverInfoPanel1.Controls.Add(ReceiverNameTextbox);
            ReceiverInfoPanel1.Controls.Add(ReceiverNameLabel);
            ReceiverInfoPanel1.Location = new Point(0, 0);
            ReceiverInfoPanel1.Margin = new Padding(0);
            ReceiverInfoPanel1.Name = "ReceiverInfoPanel1";
            ReceiverInfoPanel1.Size = new Size(200, 54);
            ReceiverInfoPanel1.TabIndex = 0;
            // 
            // ReceiverNameTextbox
            // 
            ReceiverNameTextbox.Location = new Point(5, 23);
            ReceiverNameTextbox.Name = "ReceiverNameTextbox";
            ReceiverNameTextbox.PlaceholderText = "Loading...";
            ReceiverNameTextbox.ReadOnly = true;
            ReceiverNameTextbox.Size = new Size(190, 23);
            ReceiverNameTextbox.TabIndex = 1;
            // 
            // ReceiverNameLabel
            // 
            ReceiverNameLabel.AutoSize = true;
            ReceiverNameLabel.Location = new Point(5, 5);
            ReceiverNameLabel.Name = "ReceiverNameLabel";
            ReceiverNameLabel.Size = new Size(89, 15);
            ReceiverNameLabel.TabIndex = 0;
            ReceiverNameLabel.Text = "Receiver Name:";
            // 
            // ReceiverInfoPanel2
            // 
            ReceiverInfoPanel2.Controls.Add(ReceiverIDTextbox);
            ReceiverInfoPanel2.Controls.Add(ReceiverIDLabel);
            ReceiverInfoPanel2.Location = new Point(0, 54);
            ReceiverInfoPanel2.Margin = new Padding(0);
            ReceiverInfoPanel2.Name = "ReceiverInfoPanel2";
            ReceiverInfoPanel2.Size = new Size(200, 54);
            ReceiverInfoPanel2.TabIndex = 1;
            // 
            // ReceiverIDTextbox
            // 
            ReceiverIDTextbox.Location = new Point(5, 23);
            ReceiverIDTextbox.Name = "ReceiverIDTextbox";
            ReceiverIDTextbox.PlaceholderText = "Loading...";
            ReceiverIDTextbox.ReadOnly = true;
            ReceiverIDTextbox.Size = new Size(190, 23);
            ReceiverIDTextbox.TabIndex = 1;
            // 
            // ReceiverIDLabel
            // 
            ReceiverIDLabel.AutoSize = true;
            ReceiverIDLabel.Location = new Point(5, 5);
            ReceiverIDLabel.Name = "ReceiverIDLabel";
            ReceiverIDLabel.Size = new Size(68, 15);
            ReceiverIDLabel.TabIndex = 0;
            ReceiverIDLabel.Text = "Receiver ID:";
            // 
            // ReceiverInfoPanel3
            // 
            ReceiverInfoPanel3.Controls.Add(ReceiverIPAddressTextbox);
            ReceiverInfoPanel3.Controls.Add(ReceiverIPAddressLabel);
            ReceiverInfoPanel3.Location = new Point(0, 108);
            ReceiverInfoPanel3.Margin = new Padding(0);
            ReceiverInfoPanel3.Name = "ReceiverInfoPanel3";
            ReceiverInfoPanel3.Size = new Size(200, 54);
            ReceiverInfoPanel3.TabIndex = 2;
            // 
            // ReceiverIPAddressTextbox
            // 
            ReceiverIPAddressTextbox.Location = new Point(5, 23);
            ReceiverIPAddressTextbox.Name = "ReceiverIPAddressTextbox";
            ReceiverIPAddressTextbox.PlaceholderText = "Loading...";
            ReceiverIPAddressTextbox.ReadOnly = true;
            ReceiverIPAddressTextbox.Size = new Size(190, 23);
            ReceiverIPAddressTextbox.TabIndex = 1;
            // 
            // ReceiverIPAddressLabel
            // 
            ReceiverIPAddressLabel.AutoSize = true;
            ReceiverIPAddressLabel.Location = new Point(5, 5);
            ReceiverIPAddressLabel.Name = "ReceiverIPAddressLabel";
            ReceiverIPAddressLabel.Size = new Size(112, 15);
            ReceiverIPAddressLabel.TabIndex = 0;
            ReceiverIPAddressLabel.Text = "Receiver IP Address:";
            // 
            // ReceiverInfoPanel4
            // 
            ReceiverInfoPanel4.Controls.Add(ReceiverUpdateTextbox);
            ReceiverInfoPanel4.Controls.Add(ReceiverUpdateLabel);
            ReceiverInfoPanel4.Location = new Point(200, 0);
            ReceiverInfoPanel4.Margin = new Padding(0);
            ReceiverInfoPanel4.Name = "ReceiverInfoPanel4";
            ReceiverInfoPanel4.Size = new Size(200, 54);
            ReceiverInfoPanel4.TabIndex = 3;
            // 
            // ReceiverUpdateTextbox
            // 
            ReceiverUpdateTextbox.Location = new Point(5, 23);
            ReceiverUpdateTextbox.Name = "ReceiverUpdateTextbox";
            ReceiverUpdateTextbox.PlaceholderText = "Loading...";
            ReceiverUpdateTextbox.ReadOnly = true;
            ReceiverUpdateTextbox.Size = new Size(190, 23);
            ReceiverUpdateTextbox.TabIndex = 1;
            // 
            // ReceiverUpdateLabel
            // 
            ReceiverUpdateLabel.AutoSize = true;
            ReceiverUpdateLabel.Location = new Point(5, 5);
            ReceiverUpdateLabel.Name = "ReceiverUpdateLabel";
            ReceiverUpdateLabel.Size = new Size(100, 15);
            ReceiverUpdateLabel.TabIndex = 0;
            ReceiverUpdateLabel.Text = "Receiver Updates:";
            // 
            // ReceiverInfoPanel5
            // 
            ReceiverInfoPanel5.Controls.Add(ReceiverModelTextbox);
            ReceiverInfoPanel5.Controls.Add(ReceiverModelLabel);
            ReceiverInfoPanel5.Location = new Point(200, 54);
            ReceiverInfoPanel5.Margin = new Padding(0);
            ReceiverInfoPanel5.Name = "ReceiverInfoPanel5";
            ReceiverInfoPanel5.Size = new Size(200, 54);
            ReceiverInfoPanel5.TabIndex = 4;
            // 
            // ReceiverModelTextbox
            // 
            ReceiverModelTextbox.Location = new Point(5, 23);
            ReceiverModelTextbox.Name = "ReceiverModelTextbox";
            ReceiverModelTextbox.PlaceholderText = "Loading...";
            ReceiverModelTextbox.ReadOnly = true;
            ReceiverModelTextbox.Size = new Size(190, 23);
            ReceiverModelTextbox.TabIndex = 1;
            // 
            // ReceiverModelLabel
            // 
            ReceiverModelLabel.AutoSize = true;
            ReceiverModelLabel.Location = new Point(5, 5);
            ReceiverModelLabel.Name = "ReceiverModelLabel";
            ReceiverModelLabel.Size = new Size(91, 15);
            ReceiverModelLabel.TabIndex = 0;
            ReceiverModelLabel.Text = "Receiver Model:";
            // 
            // ReceiverInfoPanel6
            // 
            ReceiverInfoPanel6.Controls.Add(ReceiverVersionTextbox);
            ReceiverInfoPanel6.Controls.Add(ReceiverVersionLabel);
            ReceiverInfoPanel6.Location = new Point(200, 108);
            ReceiverInfoPanel6.Margin = new Padding(0);
            ReceiverInfoPanel6.Name = "ReceiverInfoPanel6";
            ReceiverInfoPanel6.Size = new Size(200, 54);
            ReceiverInfoPanel6.TabIndex = 5;
            // 
            // ReceiverVersionTextbox
            // 
            ReceiverVersionTextbox.Location = new Point(5, 23);
            ReceiverVersionTextbox.Name = "ReceiverVersionTextbox";
            ReceiverVersionTextbox.PlaceholderText = "Loading...";
            ReceiverVersionTextbox.ReadOnly = true;
            ReceiverVersionTextbox.Size = new Size(190, 23);
            ReceiverVersionTextbox.TabIndex = 1;
            // 
            // ReceiverVersionLabel
            // 
            ReceiverVersionLabel.AutoSize = true;
            ReceiverVersionLabel.Location = new Point(5, 5);
            ReceiverVersionLabel.Name = "ReceiverVersionLabel";
            ReceiverVersionLabel.Size = new Size(95, 15);
            ReceiverVersionLabel.TabIndex = 0;
            ReceiverVersionLabel.Text = "Receiver Version:";
            // 
            // ReceiverInfoPanel7
            // 
            ReceiverInfoPanel7.Controls.Add(ReceiverInactivityTextbox);
            ReceiverInfoPanel7.Controls.Add(ReceiverInactivityLabel);
            ReceiverInfoPanel7.Location = new Point(400, 0);
            ReceiverInfoPanel7.Margin = new Padding(0);
            ReceiverInfoPanel7.Name = "ReceiverInfoPanel7";
            ReceiverInfoPanel7.Size = new Size(200, 54);
            ReceiverInfoPanel7.TabIndex = 6;
            // 
            // ReceiverInactivityTextbox
            // 
            ReceiverInactivityTextbox.Location = new Point(5, 23);
            ReceiverInactivityTextbox.Name = "ReceiverInactivityTextbox";
            ReceiverInactivityTextbox.PlaceholderText = "Loading...";
            ReceiverInactivityTextbox.ReadOnly = true;
            ReceiverInactivityTextbox.Size = new Size(190, 23);
            ReceiverInactivityTextbox.TabIndex = 1;
            // 
            // ReceiverInactivityLabel
            // 
            ReceiverInactivityLabel.AutoSize = true;
            ReceiverInactivityLabel.Location = new Point(5, 5);
            ReceiverInactivityLabel.Name = "ReceiverInactivityLabel";
            ReceiverInactivityLabel.Size = new Size(105, 15);
            ReceiverInactivityLabel.TabIndex = 0;
            ReceiverInactivityLabel.Text = "Receiver Inactivity:";
            // 
            // AutoRefreshTimer
            // 
            AutoRefreshTimer.Enabled = true;
            AutoRefreshTimer.Interval = 5000;
            AutoRefreshTimer.Tick += AutoRefreshTimer_Tick;
            // 
            // LoadingSplitContainer
            // 
            LoadingSplitContainer.Dock = DockStyle.Fill;
            LoadingSplitContainer.IsSplitterFixed = true;
            LoadingSplitContainer.Location = new Point(0, 24);
            LoadingSplitContainer.Name = "LoadingSplitContainer";
            LoadingSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // LoadingSplitContainer.Panel1
            // 
            LoadingSplitContainer.Panel1.Controls.Add(ReceiverSplitContainer);
            LoadingSplitContainer.Panel1MinSize = 20;
            // 
            // LoadingSplitContainer.Panel2
            // 
            LoadingSplitContainer.Panel2.Controls.Add(LoadingProgressBar);
            LoadingSplitContainer.Panel2Collapsed = true;
            LoadingSplitContainer.Panel2MinSize = 20;
            LoadingSplitContainer.Size = new Size(994, 437);
            LoadingSplitContainer.SplitterDistance = 20;
            LoadingSplitContainer.TabIndex = 2;
            // 
            // LoadingProgressBar
            // 
            LoadingProgressBar.Dock = DockStyle.Fill;
            LoadingProgressBar.Location = new Point(0, 0);
            LoadingProgressBar.Name = "LoadingProgressBar";
            LoadingProgressBar.Size = new Size(150, 46);
            LoadingProgressBar.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 461);
            Controls.Add(LoadingSplitContainer);
            Controls.Add(MenuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuStrip;
            MinimumSize = new Size(1010, 500);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recon ReTuned";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            ReceiverSplitContainer.Panel1.ResumeLayout(false);
            ReceiverSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ReceiverSplitContainer).EndInit();
            ReceiverSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ReceiverList).EndInit();
            SelectedReceiverGroupbox.ResumeLayout(false);
            SelectedReceiverSplitContainer.Panel1.ResumeLayout(false);
            SelectedReceiverSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SelectedReceiverSplitContainer).EndInit();
            SelectedReceiverSplitContainer.ResumeLayout(false);
            TunerSplitContainer.Panel1.ResumeLayout(false);
            TunerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TunerSplitContainer).EndInit();
            TunerSplitContainer.ResumeLayout(false);
            Tuner1Groupbox.ResumeLayout(false);
            Tuner1Groupbox.PerformLayout();
            Tuner1ControlGroupbox.ResumeLayout(false);
            Tuner1ControlGroupbox.PerformLayout();
            Tuner2Groupbox.ResumeLayout(false);
            Tuner2Groupbox.PerformLayout();
            Tuner2ControlGroupbox.ResumeLayout(false);
            Tuner2ControlGroupbox.PerformLayout();
            groupBox1.ResumeLayout(false);
            FlowLayoutInformation.ResumeLayout(false);
            ReceiverInfoPanel1.ResumeLayout(false);
            ReceiverInfoPanel1.PerformLayout();
            ReceiverInfoPanel2.ResumeLayout(false);
            ReceiverInfoPanel2.PerformLayout();
            ReceiverInfoPanel3.ResumeLayout(false);
            ReceiverInfoPanel3.PerformLayout();
            ReceiverInfoPanel4.ResumeLayout(false);
            ReceiverInfoPanel4.PerformLayout();
            ReceiverInfoPanel5.ResumeLayout(false);
            ReceiverInfoPanel5.PerformLayout();
            ReceiverInfoPanel6.ResumeLayout(false);
            ReceiverInfoPanel6.PerformLayout();
            ReceiverInfoPanel7.ResumeLayout(false);
            ReceiverInfoPanel7.PerformLayout();
            LoadingSplitContainer.Panel1.ResumeLayout(false);
            LoadingSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LoadingSplitContainer).EndInit();
            LoadingSplitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MenuStrip;
        private SplitContainer ReceiverSplitContainer;
        private Label ReceiverListLabel;
        private DataGridView ReceiverList;
        private ToolStripMenuItem FileMenuItem;
        private ToolStripMenuItem ExitMenuItem;
        private ToolStripMenuItem SettingsMenuItem;
        private ToolStripMenuItem ConfigReceiverListMenuItem;
        private ToolStripMenuItem HelpMenuItem;
        private ToolStripMenuItem CheckUpdatesMenuItem;
        private ToolStripMenuItem AboutMenuItem;
        private GroupBox SelectedReceiverGroupbox;
        private SplitContainer SelectedReceiverSplitContainer;
        private SplitContainer TunerSplitContainer;
        private GroupBox Tuner1Groupbox;
        private GroupBox Tuner2Groupbox;
        private GroupBox groupBox1;
        private ToolStripMenuItem UtilitiesMenuItem;
        private ToolStripMenuItem RCNScheduleMenuItem;
        private ToolStripMenuItem GlobalReceiverSettings;
        private ToolStripMenuItem DevToolsMenuItem;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn IPAddressColumn;
        private System.Windows.Forms.Timer AutoRefreshTimer;
        private FlowLayoutPanel FlowLayoutInformation;
        private Panel ReceiverInfoPanel1;
        private Label ReceiverNameLabel;
        private TextBox ReceiverNameTextbox;
        private Panel ReceiverInfoPanel2;
        private TextBox ReceiverIDTextbox;
        private Label ReceiverIDLabel;
        private Panel ReceiverInfoPanel3;
        private TextBox ReceiverIPAddressTextbox;
        private Label ReceiverIPAddressLabel;
        private Panel ReceiverInfoPanel4;
        private TextBox ReceiverUpdateTextbox;
        private Label ReceiverUpdateLabel;
        private Panel ReceiverInfoPanel5;
        private TextBox ReceiverModelTextbox;
        private Label ReceiverModelLabel;
        private Panel ReceiverInfoPanel6;
        private TextBox ReceiverVersionTextbox;
        private Label ReceiverVersionLabel;
        private Panel ReceiverInfoPanel7;
        private TextBox ReceiverInactivityTextbox;
        private Label ReceiverInactivityLabel;
        private Label Tuner1ChannelTitleLabel;
        private GroupBox Tuner1ControlGroupbox;
        private TextBox Tuner1ChannelTextbox;
        private Button Tuner1InactivityToggleButton;
        private Button Tuner1SetChannelButton;
        private GroupBox Tuner2ControlGroupbox;
        private Button Tuner2InactivityToggleButton;
        private Button Tuner2SetChannelButton;
        private TextBox Tuner2ChannelTextbox;
        private TextBox Tuner1ActiveChannelTextbox;
        private Label Tuner1ChannelLabel;
        private TextBox Tuner1ActiveChannelTitleTextbox;
        private Button Tuner1OpenEventButton;
        private Label Tuner1EventLabel;
        private Button Tuner2OpenEventButton;
        private Label Tuner2EventLabel;
        private TextBox Tuner2ActiveChannelTextbox;
        private Label Tuner2ChannelLabel;
        private TextBox Tuner2ActiveChannelTitleTextbox;
        private Label Tuner2ChannelTitleLabel;
        private ToolTip toolTip1;
        private Button Tuner1AutoAssignButton;
        private Button Tuner2AutoAssignButton;
        private SplitContainer LoadingSplitContainer;
        private ProgressBar LoadingProgressBar;
        private ToolStripMenuItem GeneralSettingMenuItem;
        private ToolStripMenuItem AutoAssignAllMenuItem;
    }
}
