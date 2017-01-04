// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MediaFarmer.MobileDevice.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        #region Setting Constants

        private const string HostKey = "host_key";
        private static readonly string HostKeyDefault = string.Empty;

        private const string PortKey = "port_key";
        private static readonly string PortKeyDefault = "80";

        private const string HostValidKey = "host_valid_key";
        private static readonly bool HostValidKeyDefault = false;
        #endregion


        public static string HostKeySettings
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(HostKey, HostKeyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(HostKey, value);
            }
        }

        public static string PortKeySettings
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(PortKey, PortKeyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(PortKey, value);
            }
        }

        public static bool HostValidSetting
        {
            get { return AppSettings.GetValueOrDefault(HostValidKey, HostValidKeyDefault); }
            set { AppSettings.AddOrUpdateValue(HostValidKey, value); }
        }

    }
}