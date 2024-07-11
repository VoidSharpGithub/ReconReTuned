using App.Handlers;
using App.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class RCNScheduleForm : Form
    {
        public MainForm OwnerForm;
        private List<RCNSimulcastScheduleObject> UnSortedUnFilteredSchedule;
        private BindingList<RCNSimulcastScheduleObject> SimulcastSchedule;
        public RCNScheduleForm()
        {
            InitializeComponent();
            AutoRefreshTimer.Interval = (int)Program.AutoRefresh.TotalMilliseconds;
            RCNScheduleDataGridView.AutoGenerateColumns = false;

            FilterByCombobox.Items.AddRange(new[] { "Channel #", "Event Name" });
            SortByCombobox.Items.AddRange(new[] { "Channel #", "Event Name", "Start Time", "End Time", "Duration" });
            FilterByCombobox.SelectedIndex = 0;
            SortByCombobox.SelectedIndex = 1;
        }

        private async void RCNScheduleForm_Load(object sender, EventArgs e)
        {
            UnSortedUnFilteredSchedule = await RCNSimulcastScheduleObject.GetSimulcastRaces();
            var filtered = ApplyFilters();
            var sorted = ApplySorting(filtered);
            SimulcastSchedule = new BindingList<RCNSimulcastScheduleObject>(sorted.ToList());
            RCNScheduleDataGridView.DataSource = SimulcastSchedule;
            GatherSimulcastingTimer.Start();
            AutoRefreshTimer.Start();

        }

        private void SearchTextbox_TextChanged(object sender, EventArgs e)
        {
            var filtered = ApplyFilters();
            var sorted = ApplySorting(filtered);
            SimulcastSchedule = new BindingList<RCNSimulcastScheduleObject>(sorted.ToList());
            RCNScheduleDataGridView.DataSource = SimulcastSchedule;
        }

        private IEnumerable<RCNSimulcastScheduleObject> ApplyFilters()
        {
            if (FilterByCombobox.SelectedItem == null)
                return UnSortedUnFilteredSchedule.AsEnumerable();
            var filtered = UnSortedUnFilteredSchedule.AsEnumerable();

            // Filter by ComboBox selection (Channel or Event Name)
            string searchTerm = SearchTextbox.Text.ToLower();
            if (FilterByCombobox.SelectedItem.ToString() == "Channel #")
                filtered = filtered.Where(x => x.DishChannel.ToString().Contains(searchTerm));
            else if (FilterByCombobox.SelectedItem.ToString() == "Event Name")
                filtered = filtered.Where(x => x.EventName.ToLower().Contains(searchTerm));

            // Toggle showing only Active Races
            if (HideActiveRacesCheckbox.Checked)
                filtered = filtered.Where(x => !(x.IsActive));

            if (HideActiveTunedRacesCheckbox.Checked)
                filtered = filtered.Where(x => !(x.IsActive && x.Activity.ChannelInUse));

            if (HideInactiveRacesCheckbox.Checked)
                filtered = filtered.Where(x => !(!x.IsActive));

            if (HideInactiveTunedRacesCheckbox.Checked)
                filtered = filtered.Where(x => !(!x.IsActive && x.Activity.ChannelInUse));

            return filtered;
        }

        private IEnumerable<RCNSimulcastScheduleObject> ApplySorting(IEnumerable<RCNSimulcastScheduleObject> filtered)
        {
            if (SortByCombobox.SelectedItem == null)
                return filtered;
            switch (SortByCombobox.SelectedItem.ToString())
            {
                case "Channel #":
                    return filtered.OrderBy(x => x.DishChannel);
                case "Event Name":
                    return filtered.OrderBy(x => x.EventName);
                case "Start Time":
                    return filtered.OrderBy(x => x.StartTime);
                case "End Time":
                    return filtered.OrderBy(x => x.EndTime);
                case "Duration":
                    return filtered.OrderBy(x => x.Duration);
                default:
                    return filtered;
            }
        }

        private async void AutoRefreshTimer_Tick(object sender, EventArgs e)
        {
            int selectedRowIndex = -1;
            if (RCNScheduleDataGridView.SelectedRows.Count >= 1)
                selectedRowIndex = RCNScheduleDataGridView.SelectedRows[0].Index;
            AutoRefreshTimer.Interval = (int)Program.AutoRefresh.TotalMilliseconds;
            var filtered = ApplyFilters();
            var sorted = ApplySorting(filtered).ToList();
            if (!Enumerable.SequenceEqual(sorted, SimulcastSchedule))
            {
                SimulcastSchedule = new BindingList<RCNSimulcastScheduleObject>(sorted);
                RCNScheduleDataGridView.DataSource = SimulcastSchedule;
            }
            if (selectedRowIndex >= 0 && selectedRowIndex < RCNScheduleDataGridView.Rows.Count)
                RCNScheduleDataGridView.Rows[selectedRowIndex].Selected = true;
        }

        private void RCNScheduleDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == RCNScheduleDataGridView.Columns["StartTimeColumn"].Index && e.Value is DateTime)
            {
                DateTime utcTime = (DateTime)e.Value;
                DateTime estTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, Program.TimeZone);

                // Format the DateTime to "h:mm tt" (e.g., 3:45 PM)
                e.Value = estTime.ToString("h:mm tt");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == RCNScheduleDataGridView.Columns["EndTimeColumn"].Index && e.Value is DateTime)
            {
                DateTime utcTime = (DateTime)e.Value;
                DateTime estTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, Program.TimeZone);

                // Format the DateTime to "h:mm tt" (e.g., 3:45 PM)
                e.Value = estTime.ToString("h:mm tt");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == RCNScheduleDataGridView.Columns["DurationColumn"].Index && e.Value is TimeSpan)
            {
                TimeSpan Duration = (TimeSpan)e.Value;

                if (Duration.Days > 0)
                {
                    e.Value = "All Day";
                    e.FormattingApplied = true;
                }
                else
                {
                    string formattedDuration = "";
                    if (Duration.Hours > 0)
                    {
                        formattedDuration += $"{Duration.Hours}hr ";
                    }
                    if (Duration.Minutes > 0)
                    {
                        formattedDuration += $"{Duration.Minutes}min";
                    }
                    e.Value = formattedDuration.Trim();
                    e.FormattingApplied = true;
                }
            }
            if (!DisableColorsCheckbox.Checked)
            {
                RCNSimulcastScheduleObject obj = RCNScheduleDataGridView.Rows[e.RowIndex].DataBoundItem as RCNSimulcastScheduleObject;
                var row = RCNScheduleDataGridView.Rows[e.RowIndex];
                if (obj.IsActive)
                    if (obj.Activity.ChannelInUse)
                        row.DefaultCellStyle.BackColor = Program.ActiveTunedRaceColor;
                    else
                        row.DefaultCellStyle.BackColor = Program.ActiveRaceColor;
                else
                    if (obj.Activity.ChannelInUse)
                    row.DefaultCellStyle.BackColor = Program.InactiveTunedRaceColor;
                else
                    row.DefaultCellStyle.BackColor = Program.InactiveRaceColor;
            }
            else
            {
                var row = RCNScheduleDataGridView.Rows[e.RowIndex];
                row.DefaultCellStyle.BackColor = SystemColors.Control;
            }

        }

        private async void GatherSimulcastingTimer_Tick(object sender, EventArgs e)
        {
            UnSortedUnFilteredSchedule = await RCNSimulcastScheduleObject.GetSimulcastRaces();
        }

        private void ShowActiveRacesOnlyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoRefreshTimer.Enabled)
            {
                var filtered = ApplyFilters();
                var sorted = ApplySorting(filtered).ToList();
                SimulcastSchedule = new BindingList<RCNSimulcastScheduleObject>(sorted);
                RCNScheduleDataGridView.DataSource = SimulcastSchedule;
            }
        }

        private void HideDisplayRacesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoRefreshTimer.Enabled)
            {
                var filtered = ApplyFilters();
                var sorted = ApplySorting(filtered).ToList();
                SimulcastSchedule = new BindingList<RCNSimulcastScheduleObject>(sorted);
                RCNScheduleDataGridView.DataSource = SimulcastSchedule;
            }
        }

        private void RCNScheduleDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = RCNScheduleDataGridView.HitTest(e.X, e.Y);
                if (hti.RowIndex != -1 && hti.ColumnIndex != -1)
                {
                    if (!RCNScheduleDataGridView.Rows[hti.RowIndex].Selected)
                    {
                        RCNScheduleDataGridView.ClearSelection();

                        RCNScheduleDataGridView.Rows[hti.RowIndex].Selected = true;
                    }

                    ScheduleContextMenu.Show(RCNScheduleDataGridView, new Point(e.X, e.Y));
                }
            }
        }

        private void Tuner1SetChannelButton_Click(object sender, EventArgs e)
        {
            if (RCNScheduleDataGridView.SelectedRows.Count < 1)
                return;

            RCNSimulcastScheduleObject RCNObj = RCNScheduleDataGridView.SelectedRows[0].DataBoundItem as RCNSimulcastScheduleObject;
            ReceiverObject Receiver = OwnerForm.SelectedReceiver;
            if (MessageBox.Show($"Are you sure you would like to set {Receiver.ReceiverName}, Tuner 1 to channel {RCNObj.DishChannel}?", "Recon ReTuned", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OwnerForm.AttemptToChangeChannel(Receiver.FirstTuner, RCNObj.DishChannel);
            }
        }

        private void Tuner2SetChannelButton_Click(object sender, EventArgs e)
        {
            if (RCNScheduleDataGridView.SelectedRows.Count < 1)
                return;

            RCNSimulcastScheduleObject RCNObj = RCNScheduleDataGridView.SelectedRows[0].DataBoundItem as RCNSimulcastScheduleObject;
            ReceiverObject Receiver = OwnerForm.SelectedReceiver;
            if (MessageBox.Show($"Are you sure you would like to set {Receiver.ReceiverName}, Tuner 2 to channel {RCNObj.DishChannel}?", "Recon ReTuned", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OwnerForm.AttemptToChangeChannel(Receiver.SecondTuner, RCNObj.DishChannel);
            }
        }

        private void ScheduleContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (OwnerForm.SelectedReceiver == null)
                e.Cancel = true;
        }

        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            RCNScheduleDataGridView.Invalidate();
        }
    }
}
