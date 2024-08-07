﻿namespace App.Forms
{
    partial class DevToolsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevToolsForm));
            ReceiverLabel = new Label();
            ReceiverCombobox = new ComboBox();
            ServiceTypeLabel = new Label();
            ServiceTypeCombobox = new ComboBox();
            ActionLabel = new Label();
            ActionCombobox = new ComboBox();
            ActionArgumentLabel = new Label();
            ActionResponseTreeView = new TreeView();
            ActionPayloadXMLContextMenu = new ContextMenuStrip(components);
            LoadXMLResponseMenuItem = new ToolStripMenuItem();
            SendRequestButton = new Button();
            ActionResponseLabel = new Label();
            ArgumentDataGridView = new DataGridView();
            ArgumentColumn = new DataGridViewTextBoxColumn();
            ValueColumn = new DataGridViewTextBoxColumn();
            SplitContainer = new SplitContainer();
            SplitContainerPayloads = new SplitContainer();
            ActionPayloadLabel = new Label();
            ActionPayloadTreeView = new TreeView();
            ActionPayloadXMLContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ArgumentDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SplitContainer).BeginInit();
            SplitContainer.Panel1.SuspendLayout();
            SplitContainer.Panel2.SuspendLayout();
            SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainerPayloads).BeginInit();
            SplitContainerPayloads.Panel1.SuspendLayout();
            SplitContainerPayloads.Panel2.SuspendLayout();
            SplitContainerPayloads.SuspendLayout();
            SuspendLayout();
            // 
            // ReceiverLabel
            // 
            ReceiverLabel.AutoSize = true;
            ReceiverLabel.Location = new Point(3, 3);
            ReceiverLabel.Name = "ReceiverLabel";
            ReceiverLabel.Size = new Size(97, 15);
            ReceiverLabel.TabIndex = 0;
            ReceiverLabel.Text = "Select a Receiver:";
            // 
            // ReceiverCombobox
            // 
            ReceiverCombobox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ReceiverCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            ReceiverCombobox.FormattingEnabled = true;
            ReceiverCombobox.Location = new Point(4, 21);
            ReceiverCombobox.Name = "ReceiverCombobox";
            ReceiverCombobox.Size = new Size(380, 23);
            ReceiverCombobox.TabIndex = 1;
            ReceiverCombobox.SelectedIndexChanged += ReceiverCombobox_SelectedIndexChanged;
            // 
            // ServiceTypeLabel
            // 
            ServiceTypeLabel.AutoSize = true;
            ServiceTypeLabel.Location = new Point(3, 47);
            ServiceTypeLabel.Name = "ServiceTypeLabel";
            ServiceTypeLabel.Size = new Size(90, 15);
            ServiceTypeLabel.TabIndex = 2;
            ServiceTypeLabel.Text = "Select a Service:";
            // 
            // ServiceTypeCombobox
            // 
            ServiceTypeCombobox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ServiceTypeCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            ServiceTypeCombobox.Enabled = false;
            ServiceTypeCombobox.FormattingEnabled = true;
            ServiceTypeCombobox.Location = new Point(4, 65);
            ServiceTypeCombobox.Name = "ServiceTypeCombobox";
            ServiceTypeCombobox.Size = new Size(380, 23);
            ServiceTypeCombobox.TabIndex = 3;
            ServiceTypeCombobox.SelectedIndexChanged += ServiceTypeCombobox_SelectedIndexChanged;
            // 
            // ActionLabel
            // 
            ActionLabel.AutoSize = true;
            ActionLabel.Location = new Point(3, 91);
            ActionLabel.Name = "ActionLabel";
            ActionLabel.Size = new Size(88, 15);
            ActionLabel.TabIndex = 4;
            ActionLabel.Text = "Select a Action:";
            // 
            // ActionCombobox
            // 
            ActionCombobox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ActionCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            ActionCombobox.Enabled = false;
            ActionCombobox.FormattingEnabled = true;
            ActionCombobox.Location = new Point(4, 109);
            ActionCombobox.Name = "ActionCombobox";
            ActionCombobox.Size = new Size(380, 23);
            ActionCombobox.TabIndex = 5;
            ActionCombobox.SelectedIndexChanged += ActionCombobox_SelectedIndexChanged;
            // 
            // ActionArgumentLabel
            // 
            ActionArgumentLabel.AutoSize = true;
            ActionArgumentLabel.Location = new Point(3, 135);
            ActionArgumentLabel.Name = "ActionArgumentLabel";
            ActionArgumentLabel.Size = new Size(107, 15);
            ActionArgumentLabel.TabIndex = 6;
            ActionArgumentLabel.Text = "Action Arguments:";
            // 
            // ActionResponseTreeView
            // 
            ActionResponseTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ActionResponseTreeView.Enabled = false;
            ActionResponseTreeView.Location = new Point(3, 21);
            ActionResponseTreeView.Name = "ActionResponseTreeView";
            ActionResponseTreeView.Size = new Size(226, 334);
            ActionResponseTreeView.TabIndex = 8;
            ActionResponseTreeView.MouseUp += ActionResponseTreeView_MouseUp;
            // 
            // ActionPayloadXMLContextMenu
            // 
            ActionPayloadXMLContextMenu.Items.AddRange(new ToolStripItem[] { LoadXMLResponseMenuItem });
            ActionPayloadXMLContextMenu.Name = "ActionPayloadXMLContextMenu";
            ActionPayloadXMLContextMenu.Size = new Size(181, 26);
            // 
            // LoadXMLResponseMenuItem
            // 
            LoadXMLResponseMenuItem.Name = "LoadXMLResponseMenuItem";
            LoadXMLResponseMenuItem.Size = new Size(180, 22);
            LoadXMLResponseMenuItem.Text = "Load XML Response";
            LoadXMLResponseMenuItem.Click += LoadXMLResponseMenuItem_Click;
            // 
            // SendRequestButton
            // 
            SendRequestButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SendRequestButton.Enabled = false;
            SendRequestButton.Location = new Point(781, 376);
            SendRequestButton.Name = "SendRequestButton";
            SendRequestButton.Size = new Size(91, 23);
            SendRequestButton.TabIndex = 9;
            SendRequestButton.Text = "Send Request";
            SendRequestButton.UseVisualStyleBackColor = true;
            SendRequestButton.Click += SendRequestButton_Click;
            // 
            // ActionResponseLabel
            // 
            ActionResponseLabel.AutoSize = true;
            ActionResponseLabel.Location = new Point(3, 3);
            ActionResponseLabel.Name = "ActionResponseLabel";
            ActionResponseLabel.Size = new Size(98, 15);
            ActionResponseLabel.TabIndex = 10;
            ActionResponseLabel.Text = "Action Response:";
            // 
            // ArgumentDataGridView
            // 
            ArgumentDataGridView.AllowUserToAddRows = false;
            ArgumentDataGridView.AllowUserToDeleteRows = false;
            ArgumentDataGridView.AllowUserToResizeRows = false;
            ArgumentDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ArgumentDataGridView.BackgroundColor = SystemColors.Control;
            ArgumentDataGridView.BorderStyle = BorderStyle.Fixed3D;
            ArgumentDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ArgumentDataGridView.Columns.AddRange(new DataGridViewColumn[] { ArgumentColumn, ValueColumn });
            ArgumentDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            ArgumentDataGridView.Location = new Point(4, 153);
            ArgumentDataGridView.MultiSelect = false;
            ArgumentDataGridView.Name = "ArgumentDataGridView";
            ArgumentDataGridView.RowHeadersVisible = false;
            ArgumentDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            ArgumentDataGridView.Size = new Size(380, 202);
            ArgumentDataGridView.TabIndex = 11;
            ArgumentDataGridView.DataSourceChanged += ArgumentDataGridView_DataSourceChanged;
            ArgumentDataGridView.CellClick += ArgumentDataGridView_CellClick;
            ArgumentDataGridView.DataError += ArgumentDataGridView_DataError;
            // 
            // ArgumentColumn
            // 
            ArgumentColumn.DataPropertyName = "Argument";
            ArgumentColumn.HeaderText = "Argument";
            ArgumentColumn.Name = "ArgumentColumn";
            ArgumentColumn.ReadOnly = true;
            ArgumentColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ValueColumn
            // 
            ValueColumn.DataPropertyName = "Value";
            ValueColumn.HeaderText = "Value";
            ValueColumn.Name = "ValueColumn";
            ValueColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            ValueColumn.Width = 150;
            // 
            // SplitContainer
            // 
            SplitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SplitContainer.Location = new Point(12, 12);
            SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            SplitContainer.Panel1.Controls.Add(ReceiverCombobox);
            SplitContainer.Panel1.Controls.Add(ArgumentDataGridView);
            SplitContainer.Panel1.Controls.Add(ReceiverLabel);
            SplitContainer.Panel1.Controls.Add(ServiceTypeLabel);
            SplitContainer.Panel1.Controls.Add(ServiceTypeCombobox);
            SplitContainer.Panel1.Controls.Add(ActionArgumentLabel);
            SplitContainer.Panel1.Controls.Add(ActionLabel);
            SplitContainer.Panel1.Controls.Add(ActionCombobox);
            SplitContainer.Panel1MinSize = 275;
            // 
            // SplitContainer.Panel2
            // 
            SplitContainer.Panel2.Controls.Add(SplitContainerPayloads);
            SplitContainer.Panel2MinSize = 275;
            SplitContainer.Size = new Size(860, 358);
            SplitContainer.SplitterDistance = 387;
            SplitContainer.TabIndex = 12;
            // 
            // SplitContainerPayloads
            // 
            SplitContainerPayloads.Dock = DockStyle.Fill;
            SplitContainerPayloads.Location = new Point(0, 0);
            SplitContainerPayloads.Name = "SplitContainerPayloads";
            // 
            // SplitContainerPayloads.Panel1
            // 
            SplitContainerPayloads.Panel1.Controls.Add(ActionPayloadLabel);
            SplitContainerPayloads.Panel1.Controls.Add(ActionPayloadTreeView);
            SplitContainerPayloads.Panel1MinSize = 230;
            // 
            // SplitContainerPayloads.Panel2
            // 
            SplitContainerPayloads.Panel2.Controls.Add(ActionResponseLabel);
            SplitContainerPayloads.Panel2.Controls.Add(ActionResponseTreeView);
            SplitContainerPayloads.Panel2MinSize = 230;
            SplitContainerPayloads.Size = new Size(469, 358);
            SplitContainerPayloads.SplitterDistance = 233;
            SplitContainerPayloads.TabIndex = 11;
            // 
            // ActionPayloadLabel
            // 
            ActionPayloadLabel.AutoSize = true;
            ActionPayloadLabel.Location = new Point(7, 3);
            ActionPayloadLabel.Name = "ActionPayloadLabel";
            ActionPayloadLabel.Size = new Size(90, 15);
            ActionPayloadLabel.TabIndex = 12;
            ActionPayloadLabel.Text = "Action Payload:";
            // 
            // ActionPayloadTreeView
            // 
            ActionPayloadTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ActionPayloadTreeView.Enabled = false;
            ActionPayloadTreeView.Location = new Point(3, 21);
            ActionPayloadTreeView.Name = "ActionPayloadTreeView";
            ActionPayloadTreeView.Size = new Size(227, 334);
            ActionPayloadTreeView.TabIndex = 11;
            // 
            // DevToolsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 411);
            Controls.Add(SplitContainer);
            Controls.Add(SendRequestButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(900, 450);
            Name = "DevToolsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Recon ReTuned - Developer Tools";
            Load += DevToolsForm_Load;
            ActionPayloadXMLContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ArgumentDataGridView).EndInit();
            SplitContainer.Panel1.ResumeLayout(false);
            SplitContainer.Panel1.PerformLayout();
            SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainer).EndInit();
            SplitContainer.ResumeLayout(false);
            SplitContainerPayloads.Panel1.ResumeLayout(false);
            SplitContainerPayloads.Panel1.PerformLayout();
            SplitContainerPayloads.Panel2.ResumeLayout(false);
            SplitContainerPayloads.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainerPayloads).EndInit();
            SplitContainerPayloads.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label ReceiverLabel;
        private ComboBox ReceiverCombobox;
        private Label ServiceTypeLabel;
        private ComboBox ServiceTypeCombobox;
        private Label ActionLabel;
        private ComboBox ActionCombobox;
        private Label ActionArgumentLabel;
        private TreeView ActionResponseTreeView;
        private Button SendRequestButton;
        private Label ActionResponseLabel;
        private DataGridView ArgumentDataGridView;
        private SplitContainer SplitContainer;
        private DataGridViewTextBoxColumn ArgumentColumn;
        private DataGridViewTextBoxColumn ValueColumn;
        private SplitContainer SplitContainerPayloads;
        private Label ActionPayloadLabel;
        private TreeView ActionPayloadTreeView;
        private ContextMenuStrip ActionPayloadXMLContextMenu;
        private ToolStripMenuItem LoadXMLResponseMenuItem;
    }
}