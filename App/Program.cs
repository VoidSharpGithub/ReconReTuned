using App.Handlers;
using App.Objects;
using System.ComponentModel;

namespace App
{
    internal static class Program
    {
        public static BindingList<ReceiverObject> Receivers { get; set; }
        public static TimeSpan AutoRefresh { get; set; }
        public static TimeZoneInfo TimeZone { get; set; }
        public static TimeSpan AutoAssignDuration { get; set; }
        public static TimeSpan AutoAssignOverdue { get; set; }
        public static Color ActiveRaceColor { get; set; }
        public static Color ActiveTunedRaceColor { get; set; }
        public static Color InactiveRaceColor { get; set; }
        public static Color InactiveTunedRaceColor { get; set; }
        public static bool UpdateOnLoad { get; set; }
        public static bool DeveloperMode { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegistryHandler.LoadProgramSettings();
            if (Receivers != null && Receivers.Count > 0)
            {
                foreach (ReceiverObject receiver in Receivers)
                {
                    receiver.UpdateReceiverObject();
                }
            }
            ApplicationConfiguration.Initialize();
            Application.ApplicationExit += Application_ApplicationExit;
            Application.Run(new MainForm());
        }

        private static void Application_ApplicationExit(object? sender, EventArgs e)
        {
            RegistryHandler.SaveSettings();
        }
    }
}