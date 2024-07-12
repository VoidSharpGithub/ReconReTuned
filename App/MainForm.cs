using App.Utils;
using App.Forms;
using App.Handlers;
using App.Objects;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Threading.Channels;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using UglyToad.PdfPig.Fonts.TrueType.Names;

namespace App
{
    public partial class MainForm : Form
    {
        private bool IsFirstTime = false;
        private bool SuppressReceiverUpdates = false;
        public ReceiverObject SelectedReceiver { get; private set; }
        private List<RCNSimulcastScheduleObject> RCNSimuls { get; set; }
        public MainForm()
        {
            InitializeComponent();
            ReceiverList.AutoGenerateColumns = false;
            ReceiverList.DataSource = Program.Receivers;
            AutoRefreshTimer.Interval = (int)Program.AutoRefresh.TotalMilliseconds;
            Tuner1ChannelTextbox.ContextMenuStrip = new ContextMenuStrip();
            Tuner2ChannelTextbox.ContextMenuStrip = new ContextMenuStrip();
        }

        public void AttemptToChangeChannel(TunerObject tuner, int channel)
        {
            if (tuner.TunerID == 0)
            {
                Tuner1ChannelTextbox.Text = channel.ToString();
                Tuner1SetChannelButton.PerformClick();
            }
            else
            {
                Tuner2ChannelTextbox.Text = channel.ToString();
                Tuner2SetChannelButton.PerformClick();
            }
        }

        private void ConfigReceiverListMenuItem_Click(object sender, EventArgs e)
        {
            ConfigReceiverListForm frm = new ConfigReceiverListForm(IsFirstTime);
            AutoRefreshTimer.Enabled = false;
            this.Hide();
            frm.ShowDialog(this);
            IsFirstTime = frm.IsFirstTime;
            this.Show();
            ReceiverList.DataSource = Program.Receivers;
            AutoRefreshTimer.Enabled = true;
        }

        private async void RCNScheduleMenuItem_Click(object sender, EventArgs e)
        {
            RCNScheduleForm frm = new RCNScheduleForm();
            if (this != null)
            {
                int centerX = this.Location.X + (this.Width - frm.Width) / 2;
                int centerY = this.Location.Y + (this.Height - frm.Height) / 2;

                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(centerX, centerY);
                frm.OwnerForm = this;
            }
            frm.Show();
        }

        private void DevToolsMenuItem_Click(object sender, EventArgs e)
        {
            using (DevPasswordForm passwordForm = new DevPasswordForm())
            {
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    DevToolsForm frm = new DevToolsForm();
                    AutoRefreshTimer.Enabled = false;
                    this.Hide();
                    frm.ShowDialog(this);
                    this.Show();
                    AutoRefreshTimer.Enabled = true;
                }
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (Program.Receivers.Count <= 0)
            {
                MessageBox.Show("It appears that you have yet to configure your receiver list.\n\nIn order to continue, please add atleast one receiver to monitor.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                IsFirstTime = true;
                ConfigReceiverListMenuItem.PerformClick();
            }
            else
            {
                ReceiverList.Rows[0].Selected = true;
                SelectedReceiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
            }

            if (Program.DeveloperMode)
                DevToolsMenuItem.Visible = true;
            else
                DevToolsMenuItem.Visible = false;

            if (!await GithubHandler.IsLatestVersion())
            {
                if (MessageBox.Show("A new update was found!\n\nDo you wish to update now?", "Update Checker", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GithubHandler.UpdateApp();
                }
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            if (this != null)
            {
                int centerX = this.Location.X + (this.Width - frm.Width) / 2;
                int centerY = this.Location.Y + (this.Height - frm.Height) / 2;

                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(centerX, centerY);
            }
            frm.Show(this);
        }

        private void ReceiverList_SelectionChanged(object sender, EventArgs e)
        {
            if (ReceiverList.SelectedRows.Count <= 0)
                return;
            Tuner1ChannelTextbox.Text = string.Empty;
            Tuner2ChannelTextbox.Text = string.Empty;
            SelectedReceiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
            UpdateReceiverDisplayInformation();
        }

        private async void UpdateReceiverDisplayInformation()
        {
            if (ReceiverList.SelectedRows.Count <= 0)
                return;

            ReceiverObject Receiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
            ReceiverNameTextbox.Text = Receiver.ReceiverName;
            SelectedReceiverGroupbox.Text = Receiver.ReceiverName;
            ReceiverIDTextbox.Text = Receiver.ReceiverID;
            ReceiverIPAddressTextbox.Text = Receiver.ReceiverIP.ToString();
            if (Receiver.ReceiverUpdates.UpdatesEnabled)
                ReceiverUpdateTextbox.Text = $"Enabled, {DateTime.Today.Add(Receiver.ReceiverUpdates.UpdateTime.Value).ToString("hh:mmtt")}";
            else
                ReceiverUpdateTextbox.Text = $"Disabled";
            ReceiverModelTextbox.Text = Receiver.ReceiverModel;
            ReceiverVersionTextbox.Text = Receiver.ReceiverVersion;
            if (Receiver.ReceiverInactivity.StandbyEnabled)
                ReceiverInactivityTextbox.Text = $"Enabled, {Receiver.ReceiverInactivity.InactivityTime.Value.ToString("hh")} Hours";
            else
                ReceiverInactivityTextbox.Text = $"Disabled";

            //Tuner1 Info
            if (!Receiver.FirstTuner.TunerStandby)
            {
                if (Tuner1ActiveChannelTitleTextbox.Text != "Standby")
                    Tuner1InactivityToggleButton.Enabled = true;
                Tuner1ActiveChannelTitleTextbox.Text = "Standby";
                Tuner1ActiveChannelTextbox.Text = "Standby";
                Tuner1ActiveChannelTitleTextbox.Enabled = false;
                Tuner1ActiveChannelTextbox.Enabled = false;
                Tuner1ChannelTextbox.Enabled = false;
                Tuner1InactivityToggleButton.Text = "Wake Up";
            }
            else
            {
                if (Tuner1ActiveChannelTitleTextbox.Text != Receiver.FirstTuner.TunerChannel.EventName)
                    Tuner1InactivityToggleButton.Enabled = true;
                Tuner1ActiveChannelTitleTextbox.Text = Receiver.FirstTuner.TunerChannel.EventName;
                Tuner1ActiveChannelTextbox.Text = Receiver.FirstTuner.TunerChannel.DishChannel.ToString();
                Tuner1ActiveChannelTitleTextbox.Enabled = true;
                Tuner1ActiveChannelTextbox.Enabled = true;
                Tuner1ChannelTextbox.Enabled = true;
                Tuner1InactivityToggleButton.Text = "Standby";
            }
            //Tuner2 Info
            if (!Receiver.SecondTuner.TunerStandby)
            {
                if (Tuner2ActiveChannelTitleTextbox.Text != "Standby")
                    Tuner2InactivityToggleButton.Enabled = true;
                Tuner2ActiveChannelTitleTextbox.Text = "Standby";
                Tuner2ActiveChannelTextbox.Text = "Standby";
                Tuner2ActiveChannelTitleTextbox.Enabled = false;
                Tuner2ActiveChannelTextbox.Enabled = false;
                Tuner2ChannelTextbox.Enabled = false;
                Tuner2InactivityToggleButton.Text = "Wake Up";
            }
            else
            {
                if (Tuner2ActiveChannelTitleTextbox.Text != Receiver.SecondTuner.TunerChannel.EventName)
                    Tuner2InactivityToggleButton.Enabled = true;
                Tuner2ActiveChannelTitleTextbox.Text = Receiver.SecondTuner.TunerChannel.EventName;
                Tuner2ActiveChannelTextbox.Text = Receiver.SecondTuner.TunerChannel.DishChannel.ToString();
                Tuner2ActiveChannelTitleTextbox.Enabled = true;
                Tuner2ActiveChannelTextbox.Enabled = true;
                Tuner2ChannelTextbox.Enabled = true;
                Tuner2InactivityToggleButton.Text = "Standby";
            }
        }

        private async void AutoRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (Program.DeveloperMode)
                DevToolsMenuItem.Visible = true;
            else
                DevToolsMenuItem.Visible = false;

            if (ReceiverList.SelectedRows.Count <= 0)
                return;

            ReceiverObject Receiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
            if (!SuppressReceiverUpdates)
                await Receiver.UpdateReceiverObject();
            UpdateReceiverDisplayInformation();
            RCNSimuls = await RCNSimulcastScheduleObject.GetSimulcastRaces();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryHandler.SaveSettings();
        }

        private void Tuner1ChannelTextbox_TextChanged(object sender, EventArgs e)
        {
            if (Tuner1ChannelTextbox.Text != string.Empty)
                Tuner1SetChannelButton.Enabled = true;
            else
                Tuner1SetChannelButton.Enabled = false;
        }

        private void Tuner2ChannelTextbox_TextChanged(object sender, EventArgs e)
        {
            if (Tuner2ChannelTextbox.Text != string.Empty)
                Tuner2SetChannelButton.Enabled = true;
            else
                Tuner2SetChannelButton.Enabled = false;
        }

        private async void Tuner1InactivityToggleButton_Click(object sender, EventArgs e)
        {
            if (ReceiverList.SelectedRows.Count <= 0)
                return;

            ReceiverObject Receiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
            if (await Receiver.ToggleStandby(Receiver.FirstTuner))
            {
                Tuner1InactivityToggleButton.Enabled = false;
            }
        }

        private async void Tuner2InactivityToggleButton_Click(object sender, EventArgs e)
        {
            if (ReceiverList.SelectedRows.Count <= 0)
                return;

            ReceiverObject Receiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
            if (await Receiver.ToggleStandby(Receiver.SecondTuner))
            {
                Tuner2InactivityToggleButton.Enabled = false;
            }
        }

        private void CustomPaste(TextBox txtbox)
        {
            if (Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                if (clipboardText.All(char.IsDigit))
                {
                    txtbox.Paste(clipboardText);
                }
                else
                {
                    clipboardText = clipboardText.Replace(" ", "");
                    if (clipboardText.All(char.IsDigit))
                    {
                        txtbox.Paste(clipboardText);
                        return;
                    }
                    toolTip1.ToolTipTitle = "Invalid Input";
                    toolTip1.ToolTipIcon = ToolTipIcon.Error;
                    toolTip1.Show("Numbers only allowed", txtbox, 0, txtbox.Height, 2000);
                }
            }
        }

        private void Tuner1ChannelTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                CustomPaste(Tuner1ChannelTextbox);
            }
            else if (!char.IsControl((char)e.KeyCode) && !char.IsDigit((char)e.KeyCode) && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
                toolTip1.ToolTipTitle = "Invalid Input";
                toolTip1.ToolTipIcon = ToolTipIcon.Error;
                toolTip1.Show("Numbers only allowed", Tuner1ChannelTextbox, 0, Tuner1ChannelTextbox.Height, 2000);

            }
        }

        private void Tuner2ChannelTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                CustomPaste(Tuner2ChannelTextbox);
            }
            else if (!char.IsControl((char)e.KeyCode) && !char.IsDigit((char)e.KeyCode) && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
                toolTip1.ToolTipTitle = "Invalid Input";
                toolTip1.ToolTipIcon = ToolTipIcon.Error;
                toolTip1.Show("Numbers only allowed", Tuner2ChannelTextbox, 0, Tuner2ChannelTextbox.Height, 2000);
            }
        }

        private async void Tuner1SetChannelButton_Click(object sender, EventArgs e)
        {
            if (ReceiverList.SelectedRows.Count <= 0)
                return;

            ReceiverObject Receiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
            List<int> AuthChannel = await SOAPHandler.GetAuthChannelList(Receiver.ReceiverIP, ServiceType.EchoSTB2);
            if (!AuthChannel.Contains(int.Parse(Tuner1ChannelTextbox.Text)))
            {
                MessageBox.Show($"Channel {Tuner1ChannelTextbox.Text} does not exist. Please try another channel.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XmlDocument env = SOAPHandler.GenerateSoapEnvelope("SetChannel", new Dictionary<string, string> {
                { "Tuner", Receiver.FirstTuner.TunerID.ToString() },
                { "Channel", Tuner1ChannelTextbox.Text }
            });
            XmlDocument response = await SOAPHandler.PostSoapRequest(Receiver.ReceiverIP, env, ServiceType.EchoSTB2);
            if (response == null)
            {
                MessageBox.Show($"Channel {Tuner1ChannelTextbox.Text} exists, but is not authorized at this time. Please try another channel.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            toolTip1.ToolTipTitle = "Channel Set";
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.Show($"Channel set to {Tuner1ChannelTextbox.Text}", Tuner1ChannelTextbox, 0, Tuner1ChannelTextbox.Height, 2000);
            Tuner1ChannelTextbox.Text = "";
            Tuner1InactivityToggleButton.Enabled = false;
            await Task.Delay(5000);
            Tuner1InactivityToggleButton.Enabled = true;
        }

        private async void Tuner2SetChannelButton_Click(object sender, EventArgs e)
        {
            if (ReceiverList.SelectedRows.Count <= 0)
                return;

            ReceiverObject Receiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
            List<int> AuthChannel = await SOAPHandler.GetAuthChannelList(Receiver.ReceiverIP, ServiceType.EchoSTB2);
            if (!AuthChannel.Contains(int.Parse(Tuner2ChannelTextbox.Text)))
            {
                MessageBox.Show($"Channel {Tuner2ChannelTextbox.Text} does not exist. Please try another channel.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XmlDocument env = SOAPHandler.GenerateSoapEnvelope("SetChannel", new Dictionary<string, string> {
                { "Tuner", Receiver.SecondTuner.TunerID.ToString() },
                { "Channel", Tuner2ChannelTextbox.Text }
            });
            XmlDocument response = await SOAPHandler.PostSoapRequest(Receiver.ReceiverIP, env, ServiceType.EchoSTB2);
            if (response == null)
            {
                MessageBox.Show($"Channel {Tuner2ChannelTextbox.Text} exists, but is not authorized at this time. Please try another channel.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            toolTip1.ToolTipTitle = "Channel Set";
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.Show($"Channel set to {Tuner2ChannelTextbox.Text}", Tuner2ChannelTextbox, 0, Tuner2ChannelTextbox.Height, 2000);
            Tuner2ChannelTextbox.Text = "";
            Tuner2InactivityToggleButton.Enabled = false;
            await Task.Delay(5000);
            Tuner2InactivityToggleButton.Enabled = true;
        }

        private void Splitter_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Control);

            SplitContainer splitContainer = sender as SplitContainer;

            Rectangle splitterRect = splitContainer.SplitterRectangle;

            // Use a solid brush with a custom color for the splitter
            using (Brush brush = new SolidBrush(SystemColors.ControlDark)) // Change "Red" to any color you prefer
            {
                e.Graphics.FillRectangle(brush, splitterRect);
            }
        }

        private void Splitter_Resize(object sender, EventArgs e)
        {
            SplitContainer splitContainer = sender as SplitContainer;
            splitContainer.Invalidate();
        }

        private async void Tuner1AutoAssignButton_Click(object sender, EventArgs e)
        {
            if (!Program.EnableAutoAssign)
            {
                MessageBox.Show("This feature is currently disabled.", "Feature Disabled");
                return;
            }
            if (MessageBox.Show("Are you sure you would like to Auto-Assign a channel? This can take a while.\n\nNote: You will not be able to continue until it is complete.", "Recon ReTuned", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                foreach (Control con in this.Controls)
                {
                    con.Enabled = false;
                }
                foreach (ReceiverObject rec in Program.Receivers)
                {
                    await rec.UpdateReceiverObject();
                }
                List<RCNSimulcastScheduleObject> Races = await RCNSimulcastScheduleObject.GetSimulcastRaces();
                var filtered = Races.AsEnumerable();
                filtered = filtered.Where(x => x.IsActive);
                filtered = filtered.Where(x => !x.Activity.ChannelInUse);
                filtered = filtered.Where(x => x.EndTime >= TimeZoneInfo.ConvertTimeToUtc((DateTime.Now + Program.AutoAssignDuration)));
                LoadingSplitContainer.Panel2Collapsed = false;
                LoadingSplitContainer.SplitterDistance = 1000;
                LoadingProgressBar.Maximum = filtered.Count();
                ReceiverObject Receiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
                bool WasChannelChanged = false;
                int channel = 0;
                SuppressReceiverUpdates = true;
                int i = 0;
                foreach (RCNSimulcastScheduleObject race in filtered)
                {
                    LoadingProgressBar.Value = i++;
                    //Attempt to assign race
                    XmlDocument env = SOAPHandler.GenerateSoapEnvelope("SetChannel", new Dictionary<string, string> {
                        { "Tuner", Receiver.FirstTuner.TunerID.ToString() },
                        { "Channel", race.DishChannel.ToString() }
                    });
                    XmlDocument response = await SOAPHandler.PostSoapRequest(Receiver.ReceiverIP, env, ServiceType.EchoSTB2, TimeSpan.FromHours(1));
                    if (response != null)
                    {
                        WasChannelChanged = true;
                        channel = race.DishChannel;
                        break;
                    }
                }
                if (WasChannelChanged)
                {
                    LoadingProgressBar.Value = filtered.Count();
                    MessageBox.Show($"Auto-Assigned channel {channel} to Tuner 1, {Receiver.ReceiverName}", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    LoadingProgressBar.Value = filtered.Count();
                    MessageBox.Show($"No channel available to assign. Please try again later.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadingSplitContainer.Panel2Collapsed = true;
                SuppressReceiverUpdates = false;
                foreach (Control con in this.Controls)
                {
                    con.Enabled = true;
                }
            }
        }

        private async void Tuner2AutoAssignButton_Click(object sender, EventArgs e)
        {
            if (!Program.EnableAutoAssign)
            {
                MessageBox.Show("This feature is currently disabled.", "Feature Disabled");
                return;
            }
            if (MessageBox.Show("Are you sure you would like to Auto-Assign a channel? This can take a while.\n\nNote: You will not be able to continue until it is complete.", "Recon ReTuned", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                foreach (Control con in this.Controls)
                {
                    con.Enabled = false;
                }
                foreach (ReceiverObject rec in Program.Receivers)
                {
                    await rec.UpdateReceiverObject();
                }
                List<RCNSimulcastScheduleObject> Races = await RCNSimulcastScheduleObject.GetSimulcastRaces();
                var filtered = Races.AsEnumerable();
                filtered = filtered.Where(x => x.IsActive);
                filtered = filtered.Where(x => !x.Activity.ChannelInUse);
                filtered = filtered.Where(x => x.EndTime >= TimeZoneInfo.ConvertTimeToUtc((DateTime.Now + Program.AutoAssignDuration)));
                LoadingSplitContainer.Panel2Collapsed = false;
                LoadingSplitContainer.SplitterDistance = 1000;
                LoadingProgressBar.Maximum = filtered.Count();
                ReceiverObject Receiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
                bool WasChannelChanged = false;
                int channel = 0;
                SuppressReceiverUpdates = true;
                int i = 0;
                foreach (RCNSimulcastScheduleObject race in filtered)
                {
                    LoadingProgressBar.Value = i++;
                    //Attempt to assign race
                    XmlDocument env = SOAPHandler.GenerateSoapEnvelope("SetChannel", new Dictionary<string, string> {
                        { "Tuner", Receiver.SecondTuner.TunerID.ToString() },
                        { "Channel", race.DishChannel.ToString() }
                    });
                    XmlDocument response = await SOAPHandler.PostSoapRequest(Receiver.ReceiverIP, env, ServiceType.EchoSTB2, TimeSpan.FromHours(1));
                    if (response != null)
                    {
                        WasChannelChanged = true;
                        channel = race.DishChannel;
                        break;
                    }
                }
                if (WasChannelChanged)
                {
                    LoadingProgressBar.Value = filtered.Count();
                    MessageBox.Show($"Auto-Assigned channel {channel} to Tuner 2, {Receiver.ReceiverName}", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    LoadingProgressBar.Value = filtered.Count();
                    MessageBox.Show($"No channel available to assign. Please try again later.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadingSplitContainer.Panel2Collapsed = true;
                SuppressReceiverUpdates = false;
                foreach (Control con in this.Controls)
                {
                    con.Enabled = true;
                }
            }
        }

        private void GeneralSettingMenuItem_Click(object sender, EventArgs e)
        {
            GeneralSettingsForm frm = new GeneralSettingsForm();
            AutoRefreshTimer.Enabled = false;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
            AutoRefreshTimer.Interval = (int)Program.AutoRefresh.TotalMilliseconds;
            if (Program.DeveloperMode)
                DevToolsMenuItem.Visible = true;
            else
                DevToolsMenuItem.Visible = false;
            AutoRefreshTimer.Enabled = true;
        }

        private async void TunerGroupbox_Paint(object sender, PaintEventArgs e)
        {
            if (ReceiverList.SelectedRows.Count <= 0)
                return;

            ReceiverObject Receiver = (ReceiverObject)ReceiverList.SelectedRows[0].DataBoundItem;
            GroupBox ActiveGroupbox = sender as GroupBox;
            TunerObject Tuner;
            if (ActiveGroupbox.Text == "Tuner 1")
                Tuner = Receiver.FirstTuner;
            else
                Tuner = Receiver.SecondTuner;

            Color lineColor;

            if (RCNSimuls == null)
                return;

            RCNSimulcastScheduleObject TunerSimulObj = RCNSimuls.Find(x =>
                x.DishChannel == Tuner.TunerChannel.DishChannel &&
                x.Activity.Receiver?.ReceiverID == Receiver.ReceiverID &&
                x.Activity.Tuner?.TunerID == Tuner.TunerID &&
                x.EventName == Tuner.TunerChannel.EventName
            );

            if (TunerSimulObj == null)
            {
                lineColor = Program.InactiveTunedRaceColor;
            }
            else
            {
                DateTime TimezoneEndTime = TimeZoneInfo.ConvertTimeFromUtc(TunerSimulObj.EndTime, TimeZoneInfo.Local);
                DateTime AdjustedNow = DateTime.Now.AddMinutes(30); // Account for Error* Est.

                if (TimezoneEndTime < AdjustedNow || Tuner.TunerChannel.EventName == "Simulcast Guide" || !TunerSimulObj.IsActive)
                    lineColor = Program.InactiveTunedRaceColor;
                else
                    lineColor = Program.ActiveTunedRaceColor;
            }
            Size tSize = TextRenderer.MeasureText(e.Graphics, ActiveGroupbox.Text, ActiveGroupbox.Font);

            Rectangle borderRect = e.ClipRectangle;
            borderRect.Y = (borderRect.Y + (tSize.Height / 2));
            borderRect.Height = (borderRect.Height - (tSize.Height / 2));
            ControlPaint.DrawBorder(e.Graphics, borderRect, lineColor, ButtonBorderStyle.Solid);

            Rectangle textRect = e.ClipRectangle;
            textRect.X = (textRect.X + 6);
            textRect.Width = tSize.Width + 5;
            textRect.Height = tSize.Height;
            e.Graphics.FillRectangle(new SolidBrush(ActiveGroupbox.BackColor), textRect);
            TextRenderer.DrawText(e.Graphics, ActiveGroupbox.Text, ActiveGroupbox.Font, textRect, lineColor);
        }

        private async void AutoAssignAllMenuItem_Click(object sender, EventArgs e)
        {
            if (!Program.EnableAutoAssign)
            {
                MessageBox.Show("This feature is currently disabled.", "Feature Disabled");
                return;
            }
            if (MessageBox.Show("Are you sure you would like to Auto-Assign ALL Receivers a channel? This can take a while.\n\nNote: You will not be able to continue until it is complete.", "Recon ReTuned", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                foreach (Control con in this.Controls)
                {
                    con.Enabled = false;
                }

                List<RCNSimulcastScheduleObject> Races = await RCNSimulcastScheduleObject.GetSimulcastRaces();
                var filteredstatic = Races.AsEnumerable();
                var filtered = Races.AsEnumerable();
                filtered = filtered.Where(x => x.IsActive);
                filtered = filtered.Where(x => !x.Activity.ChannelInUse);
                filtered = filtered.Where(x => x.EndTime >= TimeZoneInfo.ConvertTimeToUtc((DateTime.Now + Program.AutoAssignDuration)));
                var listfiltered = filtered.ToList();
                var listfilterednew = new List<RCNSimulcastScheduleObject>();
                LoadingSplitContainer.Panel2Collapsed = false;
                LoadingSplitContainer.SplitterDistance = 1000;
                LoadingProgressBar.Maximum = Program.Receivers.Count * 2;
                int i = 0;
                SuppressReceiverUpdates = true;
                foreach (ReceiverObject rec in Program.Receivers)
                {
                    await rec.UpdateReceiverObject();

                    var tuner1channel = filteredstatic.Where(x => x.DishChannel == rec.FirstTuner.TunerChannel.DishChannel && x.IsActive).OrderByDescending(x => x.EndTime).FirstOrDefault();
                    var tuner2channel = filteredstatic.Where(x => x.DishChannel == rec.SecondTuner.TunerChannel.DishChannel && x.IsActive).OrderByDescending(x => x.EndTime).FirstOrDefault();
                    if (tuner1channel == null || tuner1channel.EndTime < (DateTime.Now + Program.AutoAssignOverdue) || rec.FirstTuner.TunerChannel.EndTime < (DateTime.Now + Program.AutoAssignOverdue))
                    {
                        foreach (RCNSimulcastScheduleObject race in listfiltered)
                        {
                            XmlDocument env = SOAPHandler.GenerateSoapEnvelope("SetChannel", new Dictionary<string, string> {
                                { "Tuner", rec.FirstTuner.TunerID.ToString() },
                                { "Channel", race.DishChannel.ToString() }
                            });
                            XmlDocument response = await SOAPHandler.PostSoapRequest(rec.ReceiverIP, env, ServiceType.EchoSTB2, TimeSpan.FromHours(1));
                            if (response == null)
                            {
                                listfilterednew.Add(race);
                            }
                            else
                            {
                                LoadingProgressBar.Value = i++;
                                break;
                            }
                        }
                    }
                    foreach (RCNSimulcastScheduleObject obj in listfilterednew)
                    {
                        if (listfiltered.Contains(obj))
                            listfiltered.Remove(obj);
                    }
                    if (tuner2channel == null || tuner2channel.EndTime < (DateTime.Now + Program.AutoAssignOverdue) || rec.SecondTuner.TunerChannel.EndTime < (DateTime.Now + Program.AutoAssignOverdue))
                    {
                        foreach (RCNSimulcastScheduleObject race in listfiltered)
                        {
                            XmlDocument env = SOAPHandler.GenerateSoapEnvelope("SetChannel", new Dictionary<string, string> {
                                { "Tuner", rec.SecondTuner.TunerID.ToString() },
                                { "Channel", race.DishChannel.ToString() }
                            });
                            XmlDocument response = await SOAPHandler.PostSoapRequest(rec.ReceiverIP, env, ServiceType.EchoSTB2, TimeSpan.FromHours(1));
                            if (response == null)
                            {
                                listfilterednew.Add(race);
                            }
                            else
                            {
                                LoadingProgressBar.Value = i++;
                                break;
                            }
                        }
                    }
                    foreach (RCNSimulcastScheduleObject obj in listfilterednew)
                    {
                        if (listfiltered.Contains(obj))
                            listfiltered.Remove(obj);
                    }
                    await rec.UpdateReceiverObject();
                }
                LoadingSplitContainer.Panel2Collapsed = true;
                SuppressReceiverUpdates = false;
                foreach (Control con in this.Controls)
                {
                    con.Enabled = true;
                }
            }
        }

        private async void CheckUpdatesMenuItem_Click(object sender, EventArgs e)
        {
            if(!await GithubHandler.IsLatestVersion())
            {
                if(MessageBox.Show("A new update was found!\n\nDo you wish to update now?", "Update Checker", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GithubHandler.UpdateApp();
                }
            }
            else
            {
                MessageBox.Show("You are on the lastest version!");
            }
        }
    }
}
