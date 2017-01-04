using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MediaFarmer.MobileDevice.Helpers;
using Plugin.Connectivity;
using MediaFarmer.MobileDevice.Models;
using System.Collections.ObjectModel;

namespace MediaFarmer.MobileDevice
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
    }
    [ImplementPropertyChanged]
    public class SettingsPageModel : FreshBasePageModel
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string SettingsButtonText { get; set; }
        public ICommand ExecuteChangeHostCommand { private set; get; }
        public ICommand SettingDetail { private set; get; }
        public ObservableCollection<SettingsViewModel> SettingsList { get; set; }

        public SettingsPageModel()
        {
            Host = string.Empty;
            SettingsButtonText = "Connect";
            if (Settings.HostValidSetting)
            {
                Host = Settings.HostKeySettings.ToString();
                Port = Settings.PortKeySettings.ToString();
            }
            ExecuteChangeHostCommand = new Command(ExecuteChangeHost);
         //   SettingDetail = new Command<SettingsViewModel>(SettingDetailCommand);
        }

        public async void ExecuteChangeHost()
        {
            var IsHostValid = await PingHost();
            if (!IsHostValid) return;

            Settings.HostKeySettings = Host;
            Settings.PortKeySettings = Port;

            var api = new MediaFarmerApi();
            ResponseModel res = await api.Ping();
            if (res.Success)
            {
                Settings.HostValidSetting = true;
                SettingsButtonText = "Connected!!!";
                PopulateSettingsList();
            }
        }

        public void SettingDetailCommand(SettingsViewModel SettingDetail)
        {

        }

        private async void PopulateSettingsList()
        {
            var api = new MediaFarmerApi();
            List<SettingsViewModel> settings = await api.GetSettings();
            if (settings.Count > 0)
            {
                SettingsList = new ObservableCollection<SettingsViewModel>(settings);
            }
        }

        private async Task<bool> PingHost()
        {
            var currentPort = 80;
            int.TryParse(Port, out currentPort);
            return await CrossConnectivity.Current.IsRemoteReachable(Host, currentPort);
        }

    }
}
