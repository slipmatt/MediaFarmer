using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MediaFarmer.MobileDevice
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //  MainPage = new MediaFarmer.MobileDevice.MainPage();
            var tabsXaml = new TabbedPage();
            tabsXaml.Children.Add(new TracksPage { Title = "Tracks", Icon = "tracks.png" });
            tabsXaml.Children.Add(new PlayHistoryPage { Title = "Queue", Icon = "queue.png" });
            tabsXaml.Children.Add(new SettingsPage { Title = "Settings", Icon = "settings.png" });

            MainPage = tabsXaml;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
