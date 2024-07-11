namespace App.Forms
{
    partial class RCNScheduleForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RCNScheduleForm));
            FilterGroupbox = new GroupBox();
            SearchLabel = new Label();
            FilterByCombobox = new ComboBox();
            FilterByLabel = new Label();
            SearchTextbox = new TextBox();
            RCNScheduleGroupbox = new GroupBox();
            RCNScheduleDataGridView = new DataGridView();
            ActiveRaceColumn = new DataGridViewCheckBoxColumn();
            ChannelColumn = new DataGridViewTextBoxColumn();
            EventNameColumn = new DataGridViewTextBoxColumn();
            StartTimeColumn = new DataGridViewTextBoxColumn();
            EndTimeColumn = new DataGridViewTextBoxColumn();
            DurationColumn = new DataGridViewTextBoxColumn();
            ScheduleContextMenu = new ContextMenuStrip(components);
            Tuner1SetChannelButton = new ToolStripMenuItem();
            Tuner2SetChannelButton = new ToolStripMenuItem();
            SortGroupbox = new GroupBox();
            DisableColorsCheckbox = new CheckBox();
            HideInactiveTunedRacesCheckbox = new CheckBox();
            HideInactiveRacesCheckbox = new CheckBox();
            HideActiveTunedRacesCheckbox = new CheckBox();
            HideActiveRacesCheckbox = new CheckBox();
            SortByCombobox = new ComboBox();
            label1 = new Label();
            AutoRefreshTimer = new System.Windows.Forms.Timer(components);
            GatherSimulcastingTimer = new System.Windows.Forms.Timer(components);
            FilterGroupbox.SuspendLayout();
            RCNScheduleGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RCNScheduleDataGridView).BeginInit();
            ScheduleContextMenu.SuspendLayout();
            SortGroupbox.SuspendLayout();
            SuspendLayout();
            // 
            // FilterGroupbox
            // 
            FilterGroupbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FilterGroupbox.Controls.Add(SearchLabel);
            FilterGroupbox.Controls.Add(FilterByCombobox);
            FilterGroupbox.Controls.Add(FilterByLabel);
            FilterGroupbox.Controls.Add(SearchTextbox);
            FilterGroupbox.Location = new Point(12, 12);
            FilterGroupbox.Name = "FilterGroupbox";
            FilterGroupbox.Size = new Size(610, 69);
            FilterGroupbox.TabIndex = 0;
            FilterGroupbox.TabStop = false;
            FilterGroupbox.Text = "Filter Schedule";
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.Location = new Point(140, 19);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new Size(45, 15);
            SearchLabel.TabIndex = 3;
            SearchLabel.Text = "Search:";
            // 
            // FilterByCombobox
            // 
            FilterByCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            FilterByCombobox.FormattingEnabled = true;
            FilterByCombobox.Location = new Point(6, 37);
            FilterByCombobox.Name = "FilterByCombobox";
            FilterByCombobox.Size = new Size(128, 23);
            FilterByCombobox.TabIndex = 2;
            // 
            // FilterByLabel
            // 
            FilterByLabel.AutoSize = true;
            FilterByLabel.Location = new Point(6, 19);
            FilterByLabel.Name = "FilterByLabel";
            FilterByLabel.Size = new Size(52, 15);
            FilterByLabel.TabIndex = 1;
            FilterByLabel.Text = "Filter By:";
            // 
            // SearchTextbox
            // 
            SearchTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchTextbox.Location = new Point(140, 37);
            SearchTextbox.Name = "SearchTextbox";
            SearchTextbox.Size = new Size(464, 23);
            SearchTextbox.TabIndex = 0;
            SearchTextbox.TextChanged += SearchTextbox_TextChanged;
            // 
            // RCNScheduleGroupbox
            // 
            RCNScheduleGroupbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RCNScheduleGroupbox.Controls.Add(RCNScheduleDataGridView);
            RCNScheduleGroupbox.Location = new Point(12, 162);
            RCNScheduleGroupbox.Name = "RCNScheduleGroupbox";
            RCNScheduleGroupbox.Size = new Size(610, 187);
            RCNScheduleGroupbox.TabIndex = 1;
            RCNScheduleGroupbox.TabStop = false;
            RCNScheduleGroupbox.Text = "RCN Schedule";
            // 
            // RCNScheduleDataGridView
            // 
            RCNScheduleDataGridView.AllowUserToAddRows = false;
            RCNScheduleDataGridView.AllowUserToDeleteRows = false;
            RCNScheduleDataGridView.AllowUserToResizeRows = false;
            RCNScheduleDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RCNScheduleDataGridView.BackgroundColor = SystemColors.Control;
            RCNScheduleDataGridView.BorderStyle = BorderStyle.Fixed3D;
            RCNScheduleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RCNScheduleDataGridView.Columns.AddRange(new DataGridViewColumn[] { ActiveRaceColumn, ChannelColumn, EventNameColumn, StartTimeColumn, EndTimeColumn, DurationColumn });
            RCNScheduleDataGridView.Location = new Point(6, 22);
            RCNScheduleDataGridView.MultiSelect = false;
            RCNScheduleDataGridView.Name = "RCNScheduleDataGridView";
            RCNScheduleDataGridView.ReadOnly = true;
            RCNScheduleDataGridView.RowHeadersVisible = false;
            RCNScheduleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RCNScheduleDataGridView.Size = new Size(598, 159);
            RCNScheduleDataGridView.TabIndex = 0;
            RCNScheduleDataGridView.CellFormatting += RCNScheduleDataGridView_CellFormatting;
            RCNScheduleDataGridView.MouseDown += RCNScheduleDataGridView_MouseDown;
            // 
            // ActiveRaceColumn
            // 
            ActiveRaceColumn.DataPropertyName = "IsActive";
            ActiveRaceColumn.HeaderText = "Active Race";
            ActiveRaceColumn.Name = "ActiveRaceColumn";
            ActiveRaceColumn.ReadOnly = true;
            ActiveRaceColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // ChannelColumn
            // 
            ChannelColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ChannelColumn.DataPropertyName = "DishChannel";
            ChannelColumn.HeaderText = "Channel #";
            ChannelColumn.Name = "ChannelColumn";
            ChannelColumn.ReadOnly = true;
            ChannelColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            ChannelColumn.Width = 86;
            // 
            // EventNameColumn
            // 
            EventNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            EventNameColumn.DataPropertyName = "EventName";
            EventNameColumn.HeaderText = "Event Name";
            EventNameColumn.Name = "EventNameColumn";
            EventNameColumn.ReadOnly = true;
            EventNameColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            EventNameColumn.Width = 96;
            // 
            // StartTimeColumn
            // 
            StartTimeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            StartTimeColumn.DataPropertyName = "StartTime";
            StartTimeColumn.HeaderText = "Start Time";
            StartTimeColumn.Name = "StartTimeColumn";
            StartTimeColumn.ReadOnly = true;
            StartTimeColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            StartTimeColumn.Width = 85;
            // 
            // EndTimeColumn
            // 
            EndTimeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            EndTimeColumn.DataPropertyName = "EndTime";
            EndTimeColumn.HeaderText = "End Time";
            EndTimeColumn.Name = "EndTimeColumn";
            EndTimeColumn.ReadOnly = true;
            EndTimeColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            EndTimeColumn.Width = 81;
            // 
            // DurationColumn
            // 
            DurationColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DurationColumn.DataPropertyName = "Duration";
            DurationColumn.HeaderText = "Duration";
            DurationColumn.Name = "DurationColumn";
            DurationColumn.ReadOnly = true;
            DurationColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            DurationColumn.Width = 78;
            // 
            // ScheduleContextMenu
            // 
            ScheduleContextMenu.Items.AddRange(new ToolStripItem[] { Tuner1SetChannelButton, Tuner2SetChannelButton });
            ScheduleContextMenu.Name = "ScheduleContextMenu";
            ScheduleContextMenu.Size = new Size(188, 48);
            ScheduleContextMenu.Opening += ScheduleContextMenu_Opening;
            // 
            // Tuner1SetChannelButton
            // 
            Tuner1SetChannelButton.Name = "Tuner1SetChannelButton";
            Tuner1SetChannelButton.Size = new Size(187, 22);
            Tuner1SetChannelButton.Text = "Set Channel (Tuner 1)";
            Tuner1SetChannelButton.Click += Tuner1SetChannelButton_Click;
            // 
            // Tuner2SetChannelButton
            // 
            Tuner2SetChannelButton.Name = "Tuner2SetChannelButton";
            Tuner2SetChannelButton.Size = new Size(187, 22);
            Tuner2SetChannelButton.Text = "Set Channel (Tuner 2)";
            Tuner2SetChannelButton.Click += Tuner2SetChannelButton_Click;
            // 
            // SortGroupbox
            // 
            SortGroupbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SortGroupbox.Controls.Add(DisableColorsCheckbox);
            SortGroupbox.Controls.Add(HideInactiveTunedRacesCheckbox);
            SortGroupbox.Controls.Add(HideInactiveRacesCheckbox);
            SortGroupbox.Controls.Add(HideActiveTunedRacesCheckbox);
            SortGroupbox.Controls.Add(HideActiveRacesCheckbox);
            SortGroupbox.Controls.Add(SortByCombobox);
            SortGroupbox.Controls.Add(label1);
            SortGroupbox.Location = new Point(12, 87);
            SortGroupbox.Name = "SortGroupbox";
            SortGroupbox.Size = new Size(610, 69);
            SortGroupbox.TabIndex = 2;
            SortGroupbox.TabStop = false;
            SortGroupbox.Text = "Sort Schedule";
            // 
            // DisableColorsCheckbox
            // 
            DisableColorsCheckbox.AutoSize = true;
            DisableColorsCheckbox.Cursor = Cursors.Hand;
            DisableColorsCheckbox.Location = new Point(472, 15);
            DisableColorsCheckbox.Name = "DisableColorsCheckbox";
            DisableColorsCheckbox.Size = new Size(101, 19);
            DisableColorsCheckbox.TabIndex = 10;
            DisableColorsCheckbox.Text = "Disable Colors";
            DisableColorsCheckbox.UseVisualStyleBackColor = true;
            DisableColorsCheckbox.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // HideInactiveTunedRacesCheckbox
            // 
            HideInactiveTunedRacesCheckbox.AutoSize = true;
            HideInactiveTunedRacesCheckbox.Cursor = Cursors.Hand;
            HideInactiveTunedRacesCheckbox.Location = new Point(302, 40);
            HideInactiveTunedRacesCheckbox.Name = "HideInactiveTunedRacesCheckbox";
            HideInactiveTunedRacesCheckbox.Size = new Size(164, 19);
            HideInactiveTunedRacesCheckbox.TabIndex = 8;
            HideInactiveTunedRacesCheckbox.Text = "Hide Inactive Tuned Races";
            HideInactiveTunedRacesCheckbox.UseVisualStyleBackColor = true;
            HideInactiveTunedRacesCheckbox.CheckStateChanged += Checkbox_CheckedChanged;
            // 
            // HideInactiveRacesCheckbox
            // 
            HideInactiveRacesCheckbox.AutoSize = true;
            HideInactiveRacesCheckbox.Cursor = Cursors.Hand;
            HideInactiveRacesCheckbox.Location = new Point(302, 15);
            HideInactiveRacesCheckbox.Name = "HideInactiveRacesCheckbox";
            HideInactiveRacesCheckbox.Size = new Size(128, 19);
            HideInactiveRacesCheckbox.TabIndex = 7;
            HideInactiveRacesCheckbox.Text = "Hide Inactive Races";
            HideInactiveRacesCheckbox.UseVisualStyleBackColor = true;
            HideInactiveRacesCheckbox.CheckStateChanged += Checkbox_CheckedChanged;
            // 
            // HideActiveTunedRacesCheckbox
            // 
            HideActiveTunedRacesCheckbox.AutoSize = true;
            HideActiveTunedRacesCheckbox.Cursor = Cursors.Hand;
            HideActiveTunedRacesCheckbox.Location = new Point(140, 40);
            HideActiveTunedRacesCheckbox.Name = "HideActiveTunedRacesCheckbox";
            HideActiveTunedRacesCheckbox.Size = new Size(156, 19);
            HideActiveTunedRacesCheckbox.TabIndex = 6;
            HideActiveTunedRacesCheckbox.Text = "Hide Active Tuned Races";
            HideActiveTunedRacesCheckbox.UseVisualStyleBackColor = true;
            HideActiveTunedRacesCheckbox.CheckStateChanged += Checkbox_CheckedChanged;
            // 
            // HideActiveRacesCheckbox
            // 
            HideActiveRacesCheckbox.AutoSize = true;
            HideActiveRacesCheckbox.Cursor = Cursors.Hand;
            HideActiveRacesCheckbox.Location = new Point(140, 15);
            HideActiveRacesCheckbox.Name = "HideActiveRacesCheckbox";
            HideActiveRacesCheckbox.Size = new Size(120, 19);
            HideActiveRacesCheckbox.TabIndex = 5;
            HideActiveRacesCheckbox.Text = "Hide Active Races";
            HideActiveRacesCheckbox.UseVisualStyleBackColor = true;
            HideActiveRacesCheckbox.CheckStateChanged += Checkbox_CheckedChanged;
            // 
            // SortByCombobox
            // 
            SortByCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            SortByCombobox.FormattingEnabled = true;
            SortByCombobox.Location = new Point(6, 37);
            SortByCombobox.Name = "SortByCombobox";
            SortByCombobox.Size = new Size(128, 23);
            SortByCombobox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Sort By:";
            // 
            // AutoRefreshTimer
            // 
            AutoRefreshTimer.Interval = 1000;
            AutoRefreshTimer.Tick += AutoRefreshTimer_Tick;
            // 
            // GatherSimulcastingTimer
            // 
            GatherSimulcastingTimer.Interval = 30000;
            GatherSimulcastingTimer.Tick += GatherSimulcastingTimer_Tick;
            // 
            // RCNScheduleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 361);
            Controls.Add(SortGroupbox);
            Controls.Add(RCNScheduleGroupbox);
            Controls.Add(FilterGroupbox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(650, 400);
            Name = "RCNScheduleForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Recon ReTuned - Utility - RCN Schedule";
            Load += RCNScheduleForm_Load;
            FilterGroupbox.ResumeLayout(false);
            FilterGroupbox.PerformLayout();
            RCNScheduleGroupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RCNScheduleDataGridView).EndInit();
            ScheduleContextMenu.ResumeLayout(false);
            SortGroupbox.ResumeLayout(false);
            SortGroupbox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox FilterGroupbox;
        private TextBox SearchTextbox;
        private Label FilterByLabel;
        private Label SearchLabel;
        private ComboBox FilterByCombobox;
        private GroupBox RCNScheduleGroupbox;
        private DataGridView RCNScheduleDataGridView;
        private ContextMenuStrip ScheduleContextMenu;
        private ToolStripMenuItem Tuner1SetChannelButton;
        private ToolStripMenuItem Tuner2SetChannelButton;
        private GroupBox SortGroupbox;
        private ComboBox SortByCombobox;
        private Label label1;
        private System.Windows.Forms.Timer AutoRefreshTimer;
        private System.Windows.Forms.Timer GatherSimulcastingTimer;
        private CheckBox HideActiveRacesCheckbox;
        private CheckBox HideActiveTunedRacesCheckbox;
        private CheckBox HideInactiveTunedRacesCheckbox;
        private CheckBox HideInactiveRacesCheckbox;
        private DataGridViewCheckBoxColumn ActiveRaceColumn;
        private DataGridViewTextBoxColumn ChannelColumn;
        private DataGridViewTextBoxColumn EventNameColumn;
        private DataGridViewTextBoxColumn StartTimeColumn;
        private DataGridViewTextBoxColumn EndTimeColumn;
        private DataGridViewTextBoxColumn DurationColumn;
        private CheckBox DisableColorsCheckbox;
    }
}