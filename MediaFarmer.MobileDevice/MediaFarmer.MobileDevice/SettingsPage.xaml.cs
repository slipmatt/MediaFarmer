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

        public ICommand ExecuteChangeHostCommand;

        public SettingsPageModel()
        {
            Host = string.Empty;
            if (Settings.HostValidSetting)
            {
                Host = Settings.HostKeySettings.ToString();
            }
            ExecuteChangeHostCommand = new Command(ExecuteChangeHost);
        }

        public void ExecuteChangeHost()
        {
            Settings.HostKeySettings = Host;
        }

    }
}
