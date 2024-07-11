using App.Handlers;
using App.Objects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using UglyToad.PdfPig.Fonts.TrueType.Names;

namespace App.Forms
{
    public partial class ConfigReceiverListForm : Form
    {
        public bool IsFirstTime { get; private set; }
        public ConfigReceiverListForm(bool _IsFirstTime)
        {
            InitializeComponent();
            IsFirstTime = _IsFirstTime;
            ReceiverMgmtDataGridView.AutoGenerateColumns = false;
            ReceiverMgmtDataGridView.DataSource = Program.Receivers;
        }

        private void AddReceiverBtn_Click(object sender, EventArgs e)
        {
            AddReceiverForm frm = new AddReceiverForm();
            this.Hide();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                Program.Receivers.Add(frm.Receiver);
            }
            this.Show();
        }

        private void EditReceiverBtn_Click(object sender, EventArgs e)
        {
            if (ReceiverMgmtDataGridView.CurrentRow == null) return;
            int receiverIndex = ReceiverMgmtDataGridView.SelectedRows[0].Index;
            ReceiverObject receiver = (ReceiverObject)ReceiverMgmtDataGridView.SelectedRows[0].DataBoundItem;
            EditReceiverForm frm = new EditReceiverForm(receiver);
            this.Hide();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                Program.Receivers.RemoveAt(receiverIndex);
                Program.Receivers.Insert(receiverIndex, frm.AfterReceiver);
                ReceiverMgmtDataGridView.CurrentCell = ReceiverMgmtDataGridView.Rows[receiverIndex].Cells[ReceiverMgmtDataGridView.CurrentCell.ColumnIndex];
            }
            this.Show();
        }

        private void DeleteReceiverBtn_Click(object sender, EventArgs e)
        {
            if (ReceiverMgmtDataGridView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete receiver " + ReceiverMgmtDataGridView.SelectedRows[0].Cells[0].Value + "?", "Delete Receiver", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = ReceiverMgmtDataGridView.SelectedRows[0].Index;
                    ReceiverMgmtDataGridView.Rows.RemoveAt(rowIndex);
                }
            }
            else
            {
                MessageBox.Show("Please select a Receiver before Deleting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ExportBtn_Click(object sender, EventArgs e)
        {
            if (ReceiverMgmtDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("Please add a Receover before Exporting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "ReceiverList.cfg";
            saveFileDialog.Filter = "CFG files (*.cfg)|*.cfg|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, CypherHandler.EncryptString(JsonHandler.SerializedReceiverList()));
                MessageBox.Show($"Receiver's have now been exported to \n{saveFileDialog.FileName}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            if (ReceiverMgmtDataGridView.Rows.Count > 0)
            {
                if (MessageBox.Show("Importing a Receiver List will remove all the Receivers in your current configuration.\n\nAre you sure you would like to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CFG files (*.cfg)|*.cfg|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string EncryptedJson = File.ReadAllText(openFileDialog.FileName);
                string json = CypherHandler.DecryptString(EncryptedJson);
                Program.Receivers = JsonHandler.DeserializeReceiverList(json);
                MessageBox.Show($"Receiver's have now been imported from \n{openFileDialog.FileName}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ReceiverMgmtDataGridView.DataSource = Program.Receivers;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ReceiverMgmtDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ReceiverMgmtDataGridView.CurrentRow != null && ReceiverMgmtDataGridView.CurrentRow.Index >= 0)
            {
                EditReceiverBtn.Enabled = true;
                DeleteReceiverBtn.Enabled = true;
                MoveDownButton.Enabled = true;
                MoveUpButton.Enabled = true;
            }
            else
            {
                EditReceiverBtn.Enabled = false;
                DeleteReceiverBtn.Enabled = false;
                MoveDownButton.Enabled = false;
                MoveUpButton.Enabled = false;
            }
        }

        private void ReceiverTimer_Tick(object sender, EventArgs e)
        {
            if (ReceiverMgmtDataGridView.Rows.Count > 0)
            {
                ExportBtn.Enabled = true;
                SortButton.Enabled = true;
            }
            else
            {
                ExportBtn.Enabled = false;
                SortButton.Enabled = false;
            }
        }

        private void ConfigReceiverListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsFirstTime && DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
                return;
            }

            if (ReceiverMgmtDataGridView.Rows.Count <= 0 && DialogResult != DialogResult.OK)
            {
                BindingList<ReceiverObject> RegistryReceivers = RegistryHandler.GetReceiverObjectsFromSettings();
                if (RegistryReceivers.Count <= 0)
                {
                    MessageBox.Show("Can not continue without receivers. Please add a receiver to monitor.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    e.Cancel = true;
                }
                Program.Receivers = RegistryReceivers;
            }
            else if (ReceiverMgmtDataGridView.Rows.Count <= 0 && DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Can not save without receivers. Please add a receiver to monitor.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
            }
            else if (DialogResult == DialogResult.Cancel)
            {
                BindingList<ReceiverObject> RegistryReceivers = RegistryHandler.GetReceiverObjectsFromSettings();
                Program.Receivers = RegistryReceivers;
            }
            else
            {
                RegistryHandler.SaveSettings();
                if (Program.Receivers != null && Program.Receivers.Count > 0)
                {
                    foreach (ReceiverObject receiver in Program.Receivers)
                    {
                        receiver.UpdateReceiverObject();
                    }
                }
            }
            IsFirstTime = false;
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            var sorted = Program.Receivers.OrderBy(p => p.ReceiverName).ToList();
            Program.Receivers = new BindingList<ReceiverObject>(sorted);
            ReceiverMgmtDataGridView.DataSource = Program.Receivers;
        }

        private void MoveItem(int direction)
        {
            // Checking if there is any selected row
            if (ReceiverMgmtDataGridView.CurrentRow == null) return;

            int newIndex = ReceiverMgmtDataGridView.CurrentRow.Index + direction;

            // Checking bounds of the list
            if (newIndex < 0 || newIndex >= Program.Receivers.Count) return;

            var item = Program.Receivers[ReceiverMgmtDataGridView.CurrentRow.Index];
            Program.Receivers.RemoveAt(ReceiverMgmtDataGridView.CurrentRow.Index);
            Program.Receivers.Insert(newIndex, item);
            ReceiverMgmtDataGridView.CurrentCell = ReceiverMgmtDataGridView.Rows[newIndex].Cells[ReceiverMgmtDataGridView.CurrentCell.ColumnIndex];
        }

        private void ReceiverMgmtDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ReceiverObject Receiver = ReceiverMgmtDataGridView.Rows[e.RowIndex].DataBoundItem as ReceiverObject;
            if (e.ColumnIndex == ReceiverMgmtDataGridView.Columns["Tuner1StatusColumn"].Index)
            {
                e.Value = Receiver.FirstTuner.TunerStandby ? "Online" : "Offline";
                e.FormattingApplied = true;
            }
            if (e.ColumnIndex == ReceiverMgmtDataGridView.Columns["Tuner2StatusColumn"].Index)
            {
                e.Value = Receiver.SecondTuner.TunerStandby ? "Online" : "Offline";
                e.FormattingApplied = true;
            }
        }
    }
}
