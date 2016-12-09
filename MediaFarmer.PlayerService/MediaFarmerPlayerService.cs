using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System.Threading;
using UnitOfWork;
using WMPLib;
using MediaFarmer.Enumerators;

namespace MediaFarmer.PlayerService
{
    public partial class MediaFarmerPlayerService : ServiceBase
    {
        private static WMPLib.WindowsMediaPlayer Player;
        private static bool stopping;
        public static void VolumeUp(int initVolume, int votes)
        {
            if (Player.settings.volume < 100)
            {
                Player.settings.volume = (initVolume + (10 * votes));
            }

        }

        public static void VolumeDown(int initVolume, int votes)
        {
            if (Player.settings.volume > 10)
            {
                Player.settings.volume = (initVolume + (10 * votes));
            }
        }

        public MediaFarmerPlayerService()
        {
            InitializeComponent();
        }

        public void StartDebug()
        {
            this.EventLog.WriteEntry("MediaFarmer Service Starting. (DEBUG)");
            stopping = false;
            MediaFarmerStartService();
        }

        protected override void OnStart(string[] args)
        {
            this.EventLog.WriteEntry("MediaFarmer Service Starting.");
            stopping = false;
            MediaFarmerStartService();
        }

        protected override void OnStop()
        {
            this.EventLog.WriteEntry("MediaFarmer Service Stopping.");
            // Indicate that the service is stopping and wait for the finish  
            // of the main service function (ServiceWorkerThread). 
            stopping = true;
        }

        public static void MediaFarmerStartService()
        {
            var threadedTimers = ThreadedTimers.Instance;
            threadedTimers.IsShuttingDown = false;
            threadedTimers.RefreshTrackQueue = new System.Threading.Timer(ThreadedTimerExecutions.RefreshTrackQueue, null,
                5000, 5000);
        }
    }
}
