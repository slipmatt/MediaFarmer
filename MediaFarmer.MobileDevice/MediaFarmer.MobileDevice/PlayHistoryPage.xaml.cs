using FreshMvvm;
using MediaFarmer.MobileDevice.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MediaFarmer.MobileDevice.Helpers;
using System.Windows.Input;

namespace MediaFarmer.MobileDevice
{
    public partial class PlayHistoryPage : ContentPage
    {
        public PlayHistoryPage()
        {
            InitializeComponent();
        }
    }

    [ImplementPropertyChanged]
    public class PlayHistoryPageModel : FreshBasePageModel
    {
        public ObservableCollection<QueModel> CurrentlyPlaying { get; set; }
        public ObservableCollection<QueModel> CurrentlyQueued { get; set; }
        public ICommand ExecuteRefreshCommand { private set; get; }
        public PlayHistoryPageModel()
        {
            if (!Settings.HostValidSetting)
            {
                CoreMethods.DisplayAlert("Invalid Host", "Please check your Host and Port settings on the Settings Tab", "Ok");
                return;
            }
            ExecuteRefreshCommand = new Command(RefreshTracks);
           
            
        }

        public void RefreshTracks()
        {
            ExecuteGetPlaying();
            ExecuteGetQueued();
        }
        public async void ExecuteGetPlaying()
        {
            var api = new MediaFarmerApi();
            List<QueModel> res = await api.GetPlaying();
            if (res.Count > 0)
            {
                CurrentlyPlaying = new ObservableCollection<QueModel>(res);
            }
        }
        public async void ExecuteGetQueued()
        {
            var api = new MediaFarmerApi();
            List<QueModel> res = await api.GetQueued();
            if (res.Count > 0)
            {
                CurrentlyQueued = new ObservableCollection<QueModel>(res);
            }
        }
    }
}
