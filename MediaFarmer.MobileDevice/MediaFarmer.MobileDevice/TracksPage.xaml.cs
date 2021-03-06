﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MediaFarmer.MobileDevice.Models;
using FreshMvvm;
using System.Windows.Input;
using PropertyChanged;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using MediaFarmer.MobileDevice.Helpers;

namespace MediaFarmer.MobileDevice
{
    public partial class TracksPage : ContentPage
    {
        public TracksPage()
        {
            InitializeComponent();
        }
    }

    [ImplementPropertyChanged]
    public class TracksPageModel : FreshBasePageModel
    {
        public ICommand ExecuteSearchCommand { private set; get; }
        // public ICommand QueSelected { private set; get; }
        public Command<TrackViewModel> QueSelected { get; set; }
        public string TrackSearch
        {
            get { return _trackSearch; }
            set { _trackSearch = value; }
        }

        public ObservableCollection<TrackViewModel> Tracks { get; set; }
        private string _trackSearch;
        public TracksPageModel()
        {
            ExecuteSearchCommand = new Command(ExecuteSearch);
            QueSelected = new Command<TrackViewModel>(QueSelectedTrack);
            //  QueSelected = new Command<int>(QueSelectedTrack);
        }
        public async void ExecuteSearch()
        {
            if (!Settings.HostValidSetting)
            {
                await CoreMethods.DisplayAlert("Invalid Host", "Please check your Host and Port settings on the Settings Tab", "Ok");
                return;
            }
           
            var trackSearch = TrackSearch ?? "";
            var api = new MediaFarmerApi();
            List<TrackViewModel> res = await api.GetTracks(trackSearch);
            if (res.Count > 0)
            {
                Tracks = new ObservableCollection<TrackViewModel>(res);
            }
        }

        public async void QueSelectedTrack(TrackViewModel Track)
        {
            var confirmed = await CoreMethods.DisplayAlert("Queue this track?", "Would you like to queue this track", "Yes", "No");
            if (!confirmed) return;

            var api = new MediaFarmerApi();
            ResponseModel QueResponse = await api.QueTrack(Track.TrackId);
            if (QueResponse.Success)
            {
                await CoreMethods.DisplayAlert("Success", "Track has been successfully Queued", "Ok");
            }
            else
            {
                await CoreMethods.DisplayAlert("Failed", "Track has not been queued", "Ok");
            }
        }
    }
}