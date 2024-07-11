namespace App.Forms
{
    partial class ConfigReceiverListForm
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
            ReeiverManagerGroupbox = new GroupBox();
            OrderReceiverGroupbox = new GroupBox();
            SortButton = new Button();
            MoveDownButton = new Button();
            MoveUpButton = new Button();
            DeleteReceiverBtn = new Button();
            EditReceiverBtn = new Button();
            AddReceiverBtn = new Button();
            ReceiverMgmtDataGridView = new DataGridView();
            CancelBtn = new Button();
            SaveBtn = new Button();
            ImportBtn = new Button();
            ExportBtn = new Button();
            ReceiverTimer = new System.Windows.Forms.Timer(components);
            ReceiverNameColumn = new DataGridViewTextBoxColumn();
            ReceiverIDColumn = new DataGridViewTextBoxColumn();
            ReceiverIPColumn = new DataGridViewTextBoxColumn();
            Tuner1StatusColumn = new DataGridViewTextBoxColumn();
            Tuner2StatusColumn = new DataGridViewTextBoxColumn();
            ReeiverManagerGroupbox.SuspendLayout();
            OrderReceiverGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReceiverMgmtDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ReeiverManagerGroupbox
            // 
            ReeiverManagerGroupbox.Controls.Add(OrderReceiverGroupbox);
            ReeiverManagerGroupbox.Controls.Add(DeleteReceiverBtn);
            ReeiverManagerGroupbox.Controls.Add(EditReceiverBtn);
            ReeiverManagerGroupbox.Controls.Add(AddReceiverBtn);
            ReeiverManagerGroupbox.Controls.Add(ReceiverMgmtDataGridView);
            ReeiverManagerGroupbox.Location = new Point(12, 12);
            ReeiverManagerGroupbox.Name = "ReeiverManagerGroupbox";
            ReeiverManagerGroupbox.Size = new Size(485, 458);
            ReeiverManagerGroupbox.TabIndex = 0;
            ReeiverManagerGroupbox.TabStop = false;
            ReeiverManagerGroupbox.Text = "Receiver Manager";
            // 
            // OrderReceiverGroupbox
            // 
            OrderReceiverGroupbox.Controls.Add(SortButton);
            OrderReceiverGroupbox.Controls.Add(MoveDownButton);
            OrderReceiverGroupbox.Controls.Add(MoveUpButton);
            OrderReceiverGroupbox.Location = new Point(6, 398);
            OrderReceiverGroupbox.Name = "OrderReceiverGroupbox";
            OrderReceiverGroupbox.Size = new Size(274, 54);
            OrderReceiverGroupbox.TabIndex = 5;
            OrderReceiverGroupbox.TabStop = false;
            OrderReceiverGroupbox.Text = "Order Receivers";
            // 
            // SortButton
            // 
            SortButton.Cursor = Cursors.Hand;
            SortButton.Enabled = false;
            SortButton.Location = new Point(177, 22);
            SortButton.Name = "SortButton";
            SortButton.Size = new Size(89, 23);
            SortButton.TabIndex = 5;
            SortButton.Text = "Sort by Name";
            SortButton.UseVisualStyleBackColor = true;
            SortButton.Click += SortButton_Click;
            // 
            // MoveDownButton
            // 
            MoveDownButton.Cursor = Cursors.Hand;
            MoveDownButton.Enabled = false;
            MoveDownButton.Location = new Point(87, 22);
            MoveDownButton.Name = "MoveDownButton";
            MoveDownButton.Size = new Size(84, 23);
            MoveDownButton.TabIndex = 4;
            MoveDownButton.Text = "Move Down";
            MoveDownButton.UseVisualStyleBackColor = true;
            MoveDownButton.Click += MoveDownButton_Click;
            // 
            // MoveUpButton
            // 
            MoveUpButton.Cursor = Cursors.Hand;
            MoveUpButton.Enabled = false;
            MoveUpButton.Location = new Point(6, 22);
            MoveUpButton.Name = "MoveUpButton";
            MoveUpButton.Size = new Size(75, 23);
            MoveUpButton.TabIndex = 3;
            MoveUpButton.Text = "Move Up";
            MoveUpButton.UseVisualStyleBackColor = true;
            MoveUpButton.Click += MoveUpButton_Click;
            // 
            // DeleteReceiverBtn
            // 
            DeleteReceiverBtn.Cursor = Cursors.Hand;
            DeleteReceiverBtn.Enabled = false;
            DeleteReceiverBtn.Location = new Point(168, 369);
            DeleteReceiverBtn.Name = "DeleteReceiverBtn";
            DeleteReceiverBtn.Size = new Size(75, 23);
            DeleteReceiverBtn.TabIndex = 4;
            DeleteReceiverBtn.Text = "Delete";
            DeleteReceiverBtn.UseVisualStyleBackColor = true;
            DeleteReceiverBtn.Click += DeleteReceiverBtn_Click;
            // 
            // EditReceiverBtn
            // 
            EditReceiverBtn.Cursor = Cursors.Hand;
            EditReceiverBtn.Enabled = false;
            EditReceiverBtn.Location = new Point(87, 369);
            EditReceiverBtn.Name = "EditReceiverBtn";
            EditReceiverBtn.Size = new Size(75, 23);
            EditReceiverBtn.TabIndex = 3;
            EditReceiverBtn.Text = "Edit";
            EditReceiverBtn.UseVisualStyleBackColor = true;
            EditReceiverBtn.Click += EditReceiverBtn_Click;
            // 
            // AddReceiverBtn
            // 
            AddReceiverBtn.Cursor = Cursors.Hand;
            AddReceiverBtn.Location = new Point(6, 369);
            AddReceiverBtn.Name = "AddReceiverBtn";
            AddReceiverBtn.Size = new Size(75, 23);
            AddReceiverBtn.TabIndex = 2;
            AddReceiverBtn.Text = "Add";
            AddReceiverBtn.UseVisualStyleBackColor = true;
            AddReceiverBtn.Click += AddReceiverBtn_Click;
            // 
            // ReceiverMgmtDataGridView
            // 
            ReceiverMgmtDataGridView.AllowUserToAddRows = false;
            ReceiverMgmtDataGridView.AllowUserToDeleteRows = false;
            ReceiverMgmtDataGridView.AllowUserToResizeColumns = false;
            ReceiverMgmtDataGridView.AllowUserToResizeRows = false;
            ReceiverMgmtDataGridView.BackgroundColor = SystemColors.Control;
            ReceiverMgmtDataGridView.BorderStyle = BorderStyle.Fixed3D;
            ReceiverMgmtDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReceiverMgmtDataGridView.Columns.AddRange(new DataGridViewColumn[] { ReceiverNameColumn, ReceiverIDColumn, ReceiverIPColumn, Tuner1StatusColumn, Tuner2StatusColumn });
            ReceiverMgmtDataGridView.GridColor = SystemColors.Control;
            ReceiverMgmtDataGridView.Location = new Point(6, 22);
            ReceiverMgmtDataGridView.MultiSelect = false;
            ReceiverMgmtDataGridView.Name = "ReceiverMgmtDataGridView";
            ReceiverMgmtDataGridView.ReadOnly = true;
            ReceiverMgmtDataGridView.RowHeadersVisible = false;
            ReceiverMgmtDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReceiverMgmtDataGridView.Size = new Size(473, 341);
            ReceiverMgmtDataGridView.TabIndex = 0;
            ReceiverMgmtDataGridView.CellFormatting += ReceiverMgmtDataGridView_CellFormatting;
            ReceiverMgmtDataGridView.SelectionChanged += ReceiverMgmtDataGridView_SelectionChanged;
            // 
            // CancelBtn
            // 
            CancelBtn.Cursor = Cursors.Hand;
            CancelBtn.Location = new Point(422, 476);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(75, 23);
            CancelBtn.TabIndex = 1;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            SaveBtn.Cursor = Cursors.Hand;
            SaveBtn.Location = new Point(341, 476);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(75, 23);
            SaveBtn.TabIndex = 2;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // ImportBtn
            // 
            ImportBtn.Cursor = Cursors.Hand;
            ImportBtn.Location = new Point(12, 476);
            ImportBtn.Name = "ImportBtn";
            ImportBtn.Size = new Size(75, 23);
            ImportBtn.TabIndex = 3;
            ImportBtn.Text = "Import";
            ImportBtn.UseVisualStyleBackColor = true;
            ImportBtn.Click += ImportBtn_Click;
            // 
            // ExportBtn
            // 
            ExportBtn.Cursor = Cursors.Hand;
            ExportBtn.Enabled = false;
            ExportBtn.Location = new Point(93, 476);
            ExportBtn.Name = "ExportBtn";
            ExportBtn.Size = new Size(75, 23);
            ExportBtn.TabIndex = 4;
            ExportBtn.Text = "Export";
            ExportBtn.UseVisualStyleBackColor = true;
            ExportBtn.Click += ExportBtn_Click;
            // 
            // ReceiverTimer
            // 
            ReceiverTimer.Enabled = true;
            ReceiverTimer.Tick += ReceiverTimer_Tick;
            // 
            // ReceiverNameColumn
            // 
            ReceiverNameColumn.DataPropertyName = "ReceiverName";
            ReceiverNameColumn.Frozen = true;
            ReceiverNameColumn.HeaderText = "Name";
            ReceiverNameColumn.Name = "ReceiverNameColumn";
            ReceiverNameColumn.ReadOnly = true;
            ReceiverNameColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // ReceiverIDColumn
            // 
            ReceiverIDColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ReceiverIDColumn.DataPropertyName = "ReceiverID";
            ReceiverIDColumn.Frozen = true;
            ReceiverIDColumn.HeaderText = "Receiver ID";
            ReceiverIDColumn.Name = "ReceiverIDColumn";
            ReceiverIDColumn.ReadOnly = true;
            ReceiverIDColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            ReceiverIDColumn.Width = 71;
            // 
            // ReceiverIPColumn
            // 
            ReceiverIPColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ReceiverIPColumn.DataPropertyName = "ReceiverIP";
            ReceiverIPColumn.Frozen = true;
            ReceiverIPColumn.HeaderText = "IP Address";
            ReceiverIPColumn.Name = "ReceiverIPColumn";
            ReceiverIPColumn.ReadOnly = true;
            ReceiverIPColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            ReceiverIPColumn.Width = 68;
            // 
            // Tuner1StatusColumn
            // 
            Tuner1StatusColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Tuner1StatusColumn.HeaderText = "Tuner 1 Status";
            Tuner1StatusColumn.Name = "Tuner1StatusColumn";
            Tuner1StatusColumn.ReadOnly = true;
            Tuner1StatusColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            Tuner1StatusColumn.Width = 87;
            // 
            // Tuner2StatusColumn
            // 
            Tuner2StatusColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Tuner2StatusColumn.HeaderText = "Tuner 2 Status";
            Tuner2StatusColumn.Name = "Tuner2StatusColumn";
            Tuner2StatusColumn.ReadOnly = true;
            Tuner2StatusColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            Tuner2StatusColumn.Width = 87;
            // 
            // ConfigReceiverListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelBtn;
            ClientSize = new Size(509, 511);
            Controls.Add(ExportBtn);
            Controls.Add(ImportBtn);
            Controls.Add(SaveBtn);
            Controls.Add(CancelBtn);
            Controls.Add(ReeiverManagerGroupbox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfigReceiverListForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Receiver Configuration";
            FormClosing += ConfigReceiverListForm_FormClosing;
            ReeiverManagerGroupbox.ResumeLayout(false);
            OrderReceiverGroupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ReceiverMgmtDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox ReeiverManagerGroupbox;
        private Button CancelBtn;
        private Button SaveBtn;
        private DataGridView ReceiverMgmtDataGridView;
        private Button DeleteReceiverBtn;
        private Button EditReceiverBtn;
        private Button AddReceiverBtn;
        private Button ImportBtn;
        private Button ExportBtn;
        private System.Windows.Forms.Timer ReceiverTimer;
        private GroupBox OrderReceiverGroupbox;
        private Button SortButton;
        private Button MoveDownButton;
        private Button MoveUpButton;
        private DataGridViewTextBoxColumn ReceiverNameColumn;
        private DataGridViewTextBoxColumn ReceiverIDColumn;
        private DataGridViewTextBoxColumn ReceiverIPColumn;
        private DataGridViewTextBoxColumn Tuner1StatusColumn;
        private DataGridViewTextBoxColumn Tuner2StatusColumn;
    }
}