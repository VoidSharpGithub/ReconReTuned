using App.Objects;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Handlers
{
    public static class RegistryHandler
    {
        private static string RegKeyPath = @"Software\DCGReconReTuned\Settings";
        private static string RegKeyReceivers = "Receivers";
        private static string RegKeyPathGeneral = @"Software\DCGReconReTuned\Settings\General";
        private static string RegKeyAutoRefresh = "AutoRefresh";
        private static string RegKeyTimeZone = "TimeZone";
        private static string RegKeyAutoAssign = "AutoAssign";
        private static string RegKeyAutoAssignOverdue = "AutoAssignOverdue";
        private static string RegKeyActiveRaceColor = "ActiveRaceColor";
        private static string RegKeyActiveTunedRaceColor = "ActiveTunedRaceColor";
        private static string RegKeyInactiveRaceColor = "InactiveRaceColor";
        private static string RegKeyInactiveTunedRaceColor = "InactiveTunedRaceColor";
        private static string RegKeyUpdateOnLoad = "UpdateOnLoad";
        private static string RegKeyDeveloperMode = "DeveloperMode";
        public static bool SaveSettings()
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(RegKeyPath))
                {
                    string EncryptedReceiverList = CypherHandler.EncryptString(JsonHandler.SerializedReceiverList());
                    key.SetValue(RegKeyReceivers, EncryptedReceiverList);
                }
                using (var key = Registry.CurrentUser.CreateSubKey(RegKeyPathGeneral))
                {
                    key.SetValue(RegKeyAutoRefresh, Program.AutoRefresh.Ticks);
                    key.SetValue(RegKeyTimeZone, Program.TimeZone.Id);
                    key.SetValue(RegKeyAutoAssign, Program.AutoAssignDuration.Ticks);
                    key.SetValue(RegKeyAutoAssignOverdue, Program.AutoAssignOverdue.Ticks);
                    key.SetValue(RegKeyActiveRaceColor, Program.ActiveRaceColor.ToArgb());
                    key.SetValue(RegKeyActiveTunedRaceColor, Program.ActiveTunedRaceColor.ToArgb());
                    key.SetValue(RegKeyInactiveRaceColor, Program.InactiveRaceColor.ToArgb());
                    key.SetValue(RegKeyInactiveTunedRaceColor, Program.InactiveTunedRaceColor.ToArgb());
                    key.SetValue(RegKeyUpdateOnLoad, Program.UpdateOnLoad);
                    key.SetValue(RegKeyDeveloperMode, Program.DeveloperMode);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHandler.LogMessage(typeof(RegistryHandler).FullName + ex.Message); 
                return false;
            }
        }

        public static BindingList<ReceiverObject> GetReceiverObjectsFromSettings()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(RegKeyPath))
                {
                    if (key != null)
                    {
                        string encryptedReceiverList = key.GetValue(RegKeyReceivers) as string;
                        string decryptedReceiverList = CypherHandler.DecryptString(encryptedReceiverList);
                        return JsonHandler.DeserializeReceiverList(decryptedReceiverList);
                    }
                    return new BindingList<ReceiverObject>();
                }
            }
            catch (Exception ex)
            {
                LogHandler.LogMessage(typeof(RegistryHandler).FullName + ex.Message);
                return new BindingList<ReceiverObject>();
            }
        }

        public static void LoadProgramSettings()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(RegKeyPath))
                {
                    if (key != null)
                    {
                        string encryptedReceiverList = key.GetValue(RegKeyReceivers) as string;
                        string decryptedReceiverList = CypherHandler.DecryptString(encryptedReceiverList);
                        Program.Receivers =  JsonHandler.DeserializeReceiverList(decryptedReceiverList);
                    }
                    else
                    {
                        Program.Receivers = new BindingList<ReceiverObject>();
                    }
                }
                using (var key = Registry.CurrentUser.OpenSubKey(RegKeyPathGeneral))
                {
                    if (key != null)
                    {
                        long ticks1 = Convert.ToInt64(key.GetValue(RegKeyAutoRefresh, TimeSpan.FromSeconds(1)));
                        Program.AutoRefresh = TimeSpan.FromTicks(ticks1);
                        string timeZoneId = key.GetValue(RegKeyTimeZone, TimeZoneInfo.Local.Id) as string;
                        Program.TimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                        long ticks2 = Convert.ToInt64(key.GetValue(RegKeyAutoAssign, TimeSpan.FromMinutes(30)));
                        Program.AutoAssignDuration = TimeSpan.FromTicks(ticks2);
                        long ticks3 = Convert.ToInt64(key.GetValue(RegKeyAutoAssignOverdue, TimeSpan.FromMinutes(5)));
                        Program.AutoAssignOverdue = TimeSpan.FromTicks(ticks3);
                        int argbActive = (int)key.GetValue(RegKeyActiveRaceColor, Color.Green.ToArgb());
                        Program.ActiveRaceColor = Color.FromArgb(argbActive);
                        argbActive = (int)key.GetValue(RegKeyActiveTunedRaceColor, Color.Lime.ToArgb());
                        Program.ActiveTunedRaceColor = Color.FromArgb(argbActive);
                        argbActive = (int)key.GetValue(RegKeyInactiveRaceColor, Color.Orange.ToArgb());
                        Program.InactiveRaceColor = Color.FromArgb(argbActive);
                        argbActive = (int)key.GetValue(RegKeyInactiveTunedRaceColor, Color.Red.ToArgb());
                        Program.InactiveTunedRaceColor = Color.FromArgb(argbActive);
                        Program.UpdateOnLoad = Convert.ToBoolean(key.GetValue(RegKeyUpdateOnLoad, true));
                        Program.DeveloperMode = Convert.ToBoolean(key.GetValue(RegKeyDeveloperMode, false));
                    }
                    else
                    {
                        Program.AutoRefresh = TimeSpan.FromSeconds(1);
                        Program.TimeZone = TimeZoneInfo.Local;
                        Program.AutoAssignDuration = TimeSpan.FromMinutes(30);
                        Program.AutoAssignOverdue = TimeSpan.FromMinutes(5);
                        Program.ActiveRaceColor = Color.Green;
                        Program.ActiveTunedRaceColor = Color.Lime;
                        Program.InactiveRaceColor = Color.Orange;
                        Program.InactiveTunedRaceColor = Color.Red;
                        Program.UpdateOnLoad = true;
                        Program.DeveloperMode = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load a setting.");
            }
        }
    }
}