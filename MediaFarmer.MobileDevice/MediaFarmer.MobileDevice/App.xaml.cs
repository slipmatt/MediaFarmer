using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaFarmer.MobileDevice.Helpers;

using Xamarin.Forms;

namespace MediaFarmer.MobileDevice
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //var tabsXaml = new TabbedPage();
            //tabsXaml.Children.Add(new TracksPage { Title = "Tracks", Icon = "tracks.png" });
            //tabsXaml.Children.Add(new PlayHistoryPage { Title = "Queue", Icon = "queue.png" });
            //tabsXaml.Children.Add(new SettingsPage { Title = "Settings", Icon = "settings.png" });
            //MainPage = FreshPageModelResolver.ResolvePageModel<TracksPageModel>();
            ////MainPage = tabsXaml;

            //FreshMvvm Tabbed Page
            //https://forums.xamarin.com/discussion/65571/freshmvvm-nagivation-with-tabbedpage
            Settings.HostValidSetting = false;
            var tabbedNavigation = new FreshTabbedNavigationContainer("MediaFarmer Mobile");
            tabbedNavigation.AddTab<TracksPageModel>("Track Search", "tracks.png");
            tabbedNavigation.AddTab<SettingsPageModel>("Settings", "settings.png");
            MainPage = Settings.HostValidSetting ? tabbedNavigation : FreshPageModelResolver.ResolvePageModel<SettingsPageModel>();
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
