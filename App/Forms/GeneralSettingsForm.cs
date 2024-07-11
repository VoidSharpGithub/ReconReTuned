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
    public partial class GeneralSettingsForm : Form
    {

        public GeneralSettingsForm()
        {
            InitializeComponent();
        }

        private void GeneralSettingsForm_Load(object sender, EventArgs e)
        {
            AutoRefreshCombobox.Items.AddRange(AutoRefreshObject.DefaultAutoRefreshIntervals.ToArray());
            AutoRefreshCombobox.SelectedItem = AutoRefreshObject.DefaultAutoRefreshIntervals.Cast<AutoRefreshObject>().FirstOrDefault(obj => obj.AutoRefreshTimeSpan == Program.AutoRefresh);
            TimezoneCombobox.Items.AddRange(TimeZoneInfo.GetSystemTimeZones().ToArray());
            TimezoneCombobox.SelectedItem = TimezoneCombobox.Items.Cast<TimeZoneInfo>().FirstOrDefault(obj => obj.Id == Program.TimeZone.Id);
            AutoAssignDurationCombobox.Items.AddRange(AutoAssignObject.DefaultAutoAssignIntervals.ToArray());
            AutoAssignDurationCombobox.SelectedItem = AutoAssignObject.DefaultAutoAssignIntervals.Cast<AutoAssignObject>().FirstOrDefault(obj => obj.AutoAssignTimeSpan == Program.AutoAssignDuration);
            AutoAssignOverdueCombobox.Items.AddRange(AutoAssignObject.DefaultAutoAssignOverdueIntervals.ToArray());
            AutoAssignOverdueCombobox.SelectedItem = AutoAssignObject.DefaultAutoAssignOverdueIntervals.Cast<AutoAssignObject>().FirstOrDefault(obj => obj.AutoAssignTimeSpan == Program.AutoAssignOverdue);

            if (Program.UpdateOnLoad)
                UpdatesYesRadioButton.Checked = true;
            else
                UpdatesNoRadioButton.Checked = true;
            if (Program.DeveloperMode)
                DeveloperYesRadioButton.Checked = true;
            else
                DeveloperNoRadioButton.Checked = true;

            ActiveRaceColorPanel.BackColor = Program.ActiveRaceColor;
            ActiveTunedRaceColorPanel.BackColor = Program.ActiveTunedRaceColor;
            InactiveRaceColorPanel.BackColor = Program.InactiveRaceColor;
            InactiveTunedRaceColorPanel.BackColor = Program.InactiveTunedRaceColor;

            ActiveRaceColorDialog.Color = Program.ActiveRaceColor;
            ActiveTunedRaceColorDialog.Color = Program.ActiveTunedRaceColor;
            InactiveRaceColorDialog.Color = Program.InactiveRaceColor;
            InactiveTunedRaceColorDialog.Color = Program.InactiveTunedRaceColor;
        }

        private void ActiveRaceColorButton_Click(object sender, EventArgs e)
        {
            if (ActiveRaceColorDialog.ShowDialog() == DialogResult.OK)
            {
                ActiveRaceColorPanel.BackColor = ActiveRaceColorDialog.Color;
            }
        }

        private void InactiveRaceColorButton_Click(object sender, EventArgs e)
        {
            if (InactiveRaceColorDialog.ShowDialog() == DialogResult.OK)
            {
                InactiveRaceColorPanel.BackColor = InactiveRaceColorDialog.Color;
            }
        }

        private void ActiveTunedRaceColorButton_Click(object sender, EventArgs e)
        {
            if (ActiveTunedRaceColorDialog.ShowDialog() == DialogResult.OK)
            {
                ActiveTunedRaceColorPanel.BackColor = ActiveTunedRaceColorDialog.Color;
            }
        }

        private void InactiveTunedRaceColorButton_Click(object sender, EventArgs e)
        {
            if (InactiveTunedRaceColorDialog.ShowDialog() == DialogResult.OK)
            {
                InactiveTunedRaceColorPanel.BackColor = InactiveTunedRaceColorDialog.Color;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Program.AutoRefresh = (AutoRefreshCombobox.SelectedItem as AutoRefreshObject).AutoRefreshTimeSpan;
            Program.AutoAssignDuration = (AutoAssignDurationCombobox.SelectedItem as AutoAssignObject).AutoAssignTimeSpan;
            Program.AutoAssignOverdue = (AutoAssignOverdueCombobox.SelectedItem as AutoAssignObject).AutoAssignTimeSpan;
            Program.TimeZone = (TimezoneCombobox.SelectedItem as TimeZoneInfo);
            Program.ActiveRaceColor = ActiveRaceColorPanel.BackColor;
            Program.ActiveTunedRaceColor = ActiveTunedRaceColorPanel.BackColor;
            Program.InactiveRaceColor = InactiveRaceColorPanel.BackColor;
            Program.InactiveTunedRaceColor = InactiveTunedRaceColorPanel.BackColor;
            Program.DeveloperMode = DeveloperYesRadioButton.Checked;
            Program.UpdateOnLoad = UpdatesYesRadioButton.Checked;
            RegistryHandler.SaveSettings();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
