namespace App.Forms
{
    partial class GeneralSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralSettingsForm));
            GeneralSettingsGroupbox = new GroupBox();
            label20 = new Label();
            label19 = new Label();
            AutoAssignOverdueCombobox = new ComboBox();
            label18 = new Label();
            panel1 = new Panel();
            DeveloperYesRadioButton = new RadioButton();
            DeveloperNoRadioButton = new RadioButton();
            UpdateRadioPanel = new Panel();
            UpdatesYesRadioButton = new RadioButton();
            UpdatesNoRadioButton = new RadioButton();
            label17 = new Label();
            label16 = new Label();
            label14 = new Label();
            ActiveTunedRaceColorPanel = new Panel();
            ActiveTunedRaceColorButton = new Button();
            label15 = new Label();
            label12 = new Label();
            InactiveTunedRaceColorPanel = new Panel();
            InactiveTunedRaceColorButton = new Button();
            label13 = new Label();
            label10 = new Label();
            InactiveRaceColorPanel = new Panel();
            InactiveRaceColorButton = new Button();
            label11 = new Label();
            label9 = new Label();
            ActiveRaceColorPanel = new Panel();
            ActiveRaceColorButton = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            AutoAssignDurationCombobox = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            TimezoneCombobox = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            AutoRefreshCombobox = new ComboBox();
            label1 = new Label();
            CancelButton = new Button();
            SaveButton = new Button();
            ActiveRaceColorDialog = new ColorDialog();
            ActiveTunedRaceColorDialog = new ColorDialog();
            InactiveRaceColorDialog = new ColorDialog();
            InactiveTunedRaceColorDialog = new ColorDialog();
            GeneralSettingsGroupbox.SuspendLayout();
            panel1.SuspendLayout();
            UpdateRadioPanel.SuspendLayout();
            SuspendLayout();
            // 
            // GeneralSettingsGroupbox
            // 
            GeneralSettingsGroupbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GeneralSettingsGroupbox.Controls.Add(label20);
            GeneralSettingsGroupbox.Controls.Add(label19);
            GeneralSettingsGroupbox.Controls.Add(AutoAssignOverdueCombobox);
            GeneralSettingsGroupbox.Controls.Add(label18);
            GeneralSettingsGroupbox.Controls.Add(panel1);
            GeneralSettingsGroupbox.Controls.Add(UpdateRadioPanel);
            GeneralSettingsGroupbox.Controls.Add(label17);
            GeneralSettingsGroupbox.Controls.Add(label16);
            GeneralSettingsGroupbox.Controls.Add(label14);
            GeneralSettingsGroupbox.Controls.Add(ActiveTunedRaceColorPanel);
            GeneralSettingsGroupbox.Controls.Add(ActiveTunedRaceColorButton);
            GeneralSettingsGroupbox.Controls.Add(label15);
            GeneralSettingsGroupbox.Controls.Add(label12);
            GeneralSettingsGroupbox.Controls.Add(InactiveTunedRaceColorPanel);
            GeneralSettingsGroupbox.Controls.Add(InactiveTunedRaceColorButton);
            GeneralSettingsGroupbox.Controls.Add(label13);
            GeneralSettingsGroupbox.Controls.Add(label10);
            GeneralSettingsGroupbox.Controls.Add(InactiveRaceColorPanel);
            GeneralSettingsGroupbox.Controls.Add(InactiveRaceColorButton);
            GeneralSettingsGroupbox.Controls.Add(label11);
            GeneralSettingsGroupbox.Controls.Add(label9);
            GeneralSettingsGroupbox.Controls.Add(ActiveRaceColorPanel);
            GeneralSettingsGroupbox.Controls.Add(ActiveRaceColorButton);
            GeneralSettingsGroupbox.Controls.Add(label8);
            GeneralSettingsGroupbox.Controls.Add(label7);
            GeneralSettingsGroupbox.Controls.Add(label6);
            GeneralSettingsGroupbox.Controls.Add(AutoAssignDurationCombobox);
            GeneralSettingsGroupbox.Controls.Add(label5);
            GeneralSettingsGroupbox.Controls.Add(label4);
            GeneralSettingsGroupbox.Controls.Add(TimezoneCombobox);
            GeneralSettingsGroupbox.Controls.Add(label3);
            GeneralSettingsGroupbox.Controls.Add(label2);
            GeneralSettingsGroupbox.Controls.Add(AutoRefreshCombobox);
            GeneralSettingsGroupbox.Controls.Add(label1);
            GeneralSettingsGroupbox.Location = new Point(12, 12);
            GeneralSettingsGroupbox.Name = "GeneralSettingsGroupbox";
            GeneralSettingsGroupbox.Size = new Size(776, 397);
            GeneralSettingsGroupbox.TabIndex = 0;
            GeneralSettingsGroupbox.TabStop = false;
            GeneralSettingsGroupbox.Text = "General Settings";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 7F);
            label20.Location = new Point(212, 366);
            label20.Name = "label20";
            label20.Size = new Size(449, 12);
            label20.TabIndex = 37;
            label20.Text = "Ex. If the End Time is 5:00pm, and this is set to 5 Minutes, It will only Auto-Assign a race if it is 5:05pm.";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 7F);
            label19.Location = new Point(212, 354);
            label19.Name = "label19";
            label19.Size = new Size(436, 12);
            label19.TabIndex = 36;
            label19.Text = "When Auto-Assigning all receivers, this defines how long the estimated end time must be overdue.";
            // 
            // AutoAssignOverdueCombobox
            // 
            AutoAssignOverdueCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoAssignOverdueCombobox.FormattingEnabled = true;
            AutoAssignOverdueCombobox.Location = new Point(212, 329);
            AutoAssignOverdueCombobox.Name = "AutoAssignOverdueCombobox";
            AutoAssignOverdueCombobox.Size = new Size(174, 23);
            AutoAssignOverdueCombobox.TabIndex = 35;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(212, 311);
            label18.Name = "label18";
            label18.Size = new Size(122, 15);
            label18.TabIndex = 34;
            label18.Text = "Auto Assign Overdue:";
            // 
            // panel1
            // 
            panel1.Controls.Add(DeveloperYesRadioButton);
            panel1.Controls.Add(DeveloperNoRadioButton);
            panel1.Location = new Point(6, 369);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 20);
            panel1.TabIndex = 33;
            // 
            // DeveloperYesRadioButton
            // 
            DeveloperYesRadioButton.AutoSize = true;
            DeveloperYesRadioButton.Location = new Point(4, 3);
            DeveloperYesRadioButton.Name = "DeveloperYesRadioButton";
            DeveloperYesRadioButton.Size = new Size(42, 19);
            DeveloperYesRadioButton.TabIndex = 30;
            DeveloperYesRadioButton.Text = "Yes";
            DeveloperYesRadioButton.UseVisualStyleBackColor = true;
            // 
            // DeveloperNoRadioButton
            // 
            DeveloperNoRadioButton.AutoSize = true;
            DeveloperNoRadioButton.Location = new Point(52, 3);
            DeveloperNoRadioButton.Name = "DeveloperNoRadioButton";
            DeveloperNoRadioButton.Size = new Size(41, 19);
            DeveloperNoRadioButton.TabIndex = 31;
            DeveloperNoRadioButton.Text = "No";
            DeveloperNoRadioButton.UseVisualStyleBackColor = true;
            // 
            // UpdateRadioPanel
            // 
            UpdateRadioPanel.Controls.Add(UpdatesYesRadioButton);
            UpdateRadioPanel.Controls.Add(UpdatesNoRadioButton);
            UpdateRadioPanel.Location = new Point(6, 329);
            UpdateRadioPanel.Name = "UpdateRadioPanel";
            UpdateRadioPanel.Size = new Size(200, 20);
            UpdateRadioPanel.TabIndex = 32;
            // 
            // UpdatesYesRadioButton
            // 
            UpdatesYesRadioButton.AutoSize = true;
            UpdatesYesRadioButton.Location = new Point(3, 3);
            UpdatesYesRadioButton.Name = "UpdatesYesRadioButton";
            UpdatesYesRadioButton.Size = new Size(42, 19);
            UpdatesYesRadioButton.TabIndex = 26;
            UpdatesYesRadioButton.Text = "Yes";
            UpdatesYesRadioButton.UseVisualStyleBackColor = true;
            // 
            // UpdatesNoRadioButton
            // 
            UpdatesNoRadioButton.AutoSize = true;
            UpdatesNoRadioButton.Location = new Point(51, 3);
            UpdatesNoRadioButton.Name = "UpdatesNoRadioButton";
            UpdatesNoRadioButton.Size = new Size(41, 19);
            UpdatesNoRadioButton.TabIndex = 28;
            UpdatesNoRadioButton.Text = "No";
            UpdatesNoRadioButton.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(6, 351);
            label17.Name = "label17";
            label17.Size = new Size(135, 15);
            label17.TabIndex = 29;
            label17.Text = "Enable Developer Mode:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 311);
            label16.Name = "label16";
            label16.Size = new Size(153, 15);
            label16.TabIndex = 27;
            label16.Text = "Check for Updates on Load:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 7F);
            label14.Location = new Point(180, 243);
            label14.Name = "label14";
            label14.Size = new Size(272, 12);
            label14.TabIndex = 25;
            label14.Text = "Color to display races that are active and tuned on a receiver.";
            // 
            // ActiveTunedRaceColorPanel
            // 
            ActiveTunedRaceColorPanel.Location = new Point(283, 217);
            ActiveTunedRaceColorPanel.Name = "ActiveTunedRaceColorPanel";
            ActiveTunedRaceColorPanel.Size = new Size(23, 23);
            ActiveTunedRaceColorPanel.TabIndex = 24;
            // 
            // ActiveTunedRaceColorButton
            // 
            ActiveTunedRaceColorButton.Cursor = Cursors.Hand;
            ActiveTunedRaceColorButton.Location = new Point(180, 217);
            ActiveTunedRaceColorButton.Name = "ActiveTunedRaceColorButton";
            ActiveTunedRaceColorButton.Size = new Size(97, 23);
            ActiveTunedRaceColorButton.TabIndex = 23;
            ActiveTunedRaceColorButton.Text = "Select a Color";
            ActiveTunedRaceColorButton.UseVisualStyleBackColor = true;
            ActiveTunedRaceColorButton.Click += ActiveTunedRaceColorButton_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(180, 199);
            label15.Name = "label15";
            label15.Size = new Size(158, 15);
            label15.TabIndex = 22;
            label15.Text = "Color of Active Tuned Races:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 7F);
            label12.Location = new Point(178, 299);
            label12.Name = "label12";
            label12.Size = new Size(280, 12);
            label12.TabIndex = 21;
            label12.Text = "Color to display races that are inactive and tuned on a receiver.";
            // 
            // InactiveTunedRaceColorPanel
            // 
            InactiveTunedRaceColorPanel.Location = new Point(281, 273);
            InactiveTunedRaceColorPanel.Name = "InactiveTunedRaceColorPanel";
            InactiveTunedRaceColorPanel.Size = new Size(23, 23);
            InactiveTunedRaceColorPanel.TabIndex = 20;
            // 
            // InactiveTunedRaceColorButton
            // 
            InactiveTunedRaceColorButton.Cursor = Cursors.Hand;
            InactiveTunedRaceColorButton.Location = new Point(178, 273);
            InactiveTunedRaceColorButton.Name = "InactiveTunedRaceColorButton";
            InactiveTunedRaceColorButton.Size = new Size(97, 23);
            InactiveTunedRaceColorButton.TabIndex = 19;
            InactiveTunedRaceColorButton.Text = "Select a Color";
            InactiveTunedRaceColorButton.UseVisualStyleBackColor = true;
            InactiveTunedRaceColorButton.Click += InactiveTunedRaceColorButton_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(178, 255);
            label13.Name = "label13";
            label13.Size = new Size(166, 15);
            label13.TabIndex = 18;
            label13.Text = "Color of Inactive Tuned Races:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 7F);
            label10.Location = new Point(6, 299);
            label10.Name = "label10";
            label10.Size = new Size(172, 12);
            label10.TabIndex = 17;
            label10.Text = "Color to display races that are inactive.";
            // 
            // InactiveRaceColorPanel
            // 
            InactiveRaceColorPanel.Location = new Point(109, 273);
            InactiveRaceColorPanel.Name = "InactiveRaceColorPanel";
            InactiveRaceColorPanel.Size = new Size(23, 23);
            InactiveRaceColorPanel.TabIndex = 16;
            // 
            // InactiveRaceColorButton
            // 
            InactiveRaceColorButton.Cursor = Cursors.Hand;
            InactiveRaceColorButton.Location = new Point(6, 273);
            InactiveRaceColorButton.Name = "InactiveRaceColorButton";
            InactiveRaceColorButton.Size = new Size(97, 23);
            InactiveRaceColorButton.TabIndex = 15;
            InactiveRaceColorButton.Text = "Select a Color";
            InactiveRaceColorButton.UseVisualStyleBackColor = true;
            InactiveRaceColorButton.Click += InactiveRaceColorButton_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 255);
            label11.Name = "label11";
            label11.Size = new Size(130, 15);
            label11.TabIndex = 14;
            label11.Text = "Color of Inactive Races:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 7F);
            label9.Location = new Point(6, 243);
            label9.Name = "label9";
            label9.Size = new Size(164, 12);
            label9.TabIndex = 13;
            label9.Text = "Color to display races that are active.";
            // 
            // ActiveRaceColorPanel
            // 
            ActiveRaceColorPanel.Location = new Point(109, 217);
            ActiveRaceColorPanel.Name = "ActiveRaceColorPanel";
            ActiveRaceColorPanel.Size = new Size(23, 23);
            ActiveRaceColorPanel.TabIndex = 12;
            // 
            // ActiveRaceColorButton
            // 
            ActiveRaceColorButton.Cursor = Cursors.Hand;
            ActiveRaceColorButton.Location = new Point(6, 217);
            ActiveRaceColorButton.Name = "ActiveRaceColorButton";
            ActiveRaceColorButton.Size = new Size(97, 23);
            ActiveRaceColorButton.TabIndex = 11;
            ActiveRaceColorButton.Text = "Select a Color";
            ActiveRaceColorButton.UseVisualStyleBackColor = true;
            ActiveRaceColorButton.Click += ActiveRaceColorButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 199);
            label8.Name = "label8";
            label8.Size = new Size(122, 15);
            label8.TabIndex = 10;
            label8.Text = "Color of Active Races:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F);
            label7.Location = new Point(6, 187);
            label7.Name = "label7";
            label7.Size = new Size(526, 12);
            label7.TabIndex = 9;
            label7.Text = "Ex. If it is 5:00pm, and this is set to 30 Minutes, It will only look for active races that will NOT end in the next 30 Minutes.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7F);
            label6.Location = new Point(6, 175);
            label6.Name = "label6";
            label6.Size = new Size(332, 12);
            label6.TabIndex = 8;
            label6.Text = "When Auto-Assigning a channel, this defines how long until the race ends.";
            // 
            // AutoAssignDurationCombobox
            // 
            AutoAssignDurationCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoAssignDurationCombobox.FormattingEnabled = true;
            AutoAssignDurationCombobox.Location = new Point(6, 149);
            AutoAssignDurationCombobox.Name = "AutoAssignDurationCombobox";
            AutoAssignDurationCombobox.Size = new Size(174, 23);
            AutoAssignDurationCombobox.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 131);
            label5.Name = "label5";
            label5.Size = new Size(123, 15);
            label5.TabIndex = 6;
            label5.Text = "Auto Assign Duration:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7F);
            label4.Location = new Point(6, 119);
            label4.Name = "label4";
            label4.Size = new Size(226, 12);
            label4.TabIndex = 5;
            label4.Text = "The timezone to display all time in this application.";
            // 
            // TimezoneCombobox
            // 
            TimezoneCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            TimezoneCombobox.FormattingEnabled = true;
            TimezoneCombobox.Location = new Point(6, 93);
            TimezoneCombobox.Name = "TimezoneCombobox";
            TimezoneCombobox.Size = new Size(321, 23);
            TimezoneCombobox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 75);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 3;
            label3.Text = "Timezone:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F);
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(290, 12);
            label2.TabIndex = 2;
            label2.Text = "How quickly a refresh of the Receivers information will take place.";
            // 
            // AutoRefreshCombobox
            // 
            AutoRefreshCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoRefreshCombobox.FormattingEnabled = true;
            AutoRefreshCombobox.Location = new Point(6, 37);
            AutoRefreshCombobox.Name = "AutoRefreshCombobox";
            AutoRefreshCombobox.Size = new Size(174, 23);
            AutoRefreshCombobox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 0;
            label1.Text = "Auto Refresh Interval:";
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.Cursor = Cursors.Hand;
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(713, 415);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.Cursor = Cursors.Hand;
            SaveButton.Location = new Point(632, 415);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // GeneralSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SaveButton);
            Controls.Add(CancelButton);
            Controls.Add(GeneralSettingsGroupbox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 489);
            Name = "GeneralSettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Recon ReTuned - General Settings";
            Load += GeneralSettingsForm_Load;
            GeneralSettingsGroupbox.ResumeLayout(false);
            GeneralSettingsGroupbox.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            UpdateRadioPanel.ResumeLayout(false);
            UpdateRadioPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GeneralSettingsGroupbox;
        private Label label1;
        private ComboBox AutoRefreshCombobox;
        private Label label2;
        private Button CancelButton;
        private Button SaveButton;
        private Label label3;
        private ComboBox TimezoneCombobox;
        private Label label4;
        private Label label5;
        private ComboBox AutoAssignDurationCombobox;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button ActiveRaceColorButton;
        private Panel ActiveRaceColorPanel;
        private Label label9;
        private Label label14;
        private Panel ActiveTunedRaceColorPanel;
        private Button ActiveTunedRaceColorButton;
        private Label label15;
        private Label label12;
        private Panel InactiveTunedRaceColorPanel;
        private Button InactiveTunedRaceColorButton;
        private Label label13;
        private Label label10;
        private Panel InactiveRaceColorPanel;
        private Button InactiveRaceColorButton;
        private Label label11;
        private Label label16;
        private RadioButton UpdatesYesRadioButton;
        private RadioButton UpdatesNoRadioButton;
        private Label label17;
        private RadioButton DeveloperNoRadioButton;
        private RadioButton DeveloperYesRadioButton;
        private Panel UpdateRadioPanel;
        private Panel panel1;
        private ColorDialog ActiveRaceColorDialog;
        private ColorDialog ActiveTunedRaceColorDialog;
        private ColorDialog InactiveRaceColorDialog;
        private ColorDialog InactiveTunedRaceColorDialog;
        private ComboBox AutoAssignOverdueCombobox;
        private Label label18;
        private Label label19;
        private Label label20;
    }
}