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

        protected override void OnStart(string[] args)
        {
            this.EventLog.WriteEntry("MediaFarmer Service Starting.");
            stopping = false;
            ThreadPool.QueueUserWorkItem(new WaitCallback(TrackSniffer));
            // Thread thread = new Thread(MediaFarmerPlayerService.TrackSniffer);
        }

        protected override void OnStop()
        {
            this.EventLog.WriteEntry("MediaFarmer Service Stopping.");
            // Indicate that the service is stopping and wait for the finish  
            // of the main service function (ServiceWorkerThread). 
            stopping = true;
        }

        public static void TrackSniffer(object state)
        {
            int JukeBoxWakeUp = 8;
            int JukeBoxSleep = 18;
            Player = new WindowsMediaPlayer();
            Player.settings.volume = 50;
            var sleepTimer = 0;
            var jukeBoxOffset = 0;
            using (var _uow = new Uow(new MusicFarmerEntities()))
            {
                RepositoryPlayHistory repo;
                RepositoryVote repoVote;
                while (!stopping)
                {

                    repo = new RepositoryPlayHistory(_uow);
                    repoVote = new RepositoryVote(_uow);
                    var currentList = repo.GetCurrentlyPlaying();
                    PlayHistoryViewModel _CurrentTrack = currentList.FirstOrDefault();

                    if (!currentList.Any())
                    {
                        if (repo.GetCurrentlyQueued().Any())
                        {
                            _CurrentTrack = repo.GetCurrentlyQueued().FirstOrDefault();
                            repo.SetTrackToPlay(_CurrentTrack.PlayHistoryId);
                        }
                        else
                        {
                            Thread.Sleep(1000);

                            if (DateTime.Now.Hour >= JukeBoxWakeUp && DateTime.Now.Hour <= JukeBoxSleep)
                            {
                                sleepTimer += 1;
                                if (sleepTimer >= 20)
                                {
                                    var jukeBoxRepo = new RepositoryJukeBox(_uow);
                                    List<JukeBoxViewModel> items = jukeBoxRepo.GetJukeBoxTracks();
                                    JukeBoxViewModel jbvm = items.ElementAt(jukeBoxOffset);
                                    repo.Queue(jbvm.TrackId);
                                    jukeBoxOffset += 1;
                                    if (jukeBoxOffset > items.Count())
                                    {
                                        jukeBoxOffset = 0;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        RepositoryTrack repoTrack = new RepositoryTrack(_uow);
                        var nextSong = repoTrack.SearchTrackByName("").Find(i => i.TrackId == _CurrentTrack.TrackId).TrackURL;
                        Uri songUri = new Uri(nextSong);

                        Player.URL = nextSong;
                        Player.controls.play();
                        while (Player.playState == WMPPlayState.wmppsPlaying || Player.playState == WMPPlayState.wmppsBuffering || Player.playState == WMPPlayState.wmppsTransitioning)
                        {
                            sleepTimer = 0;
                            _CurrentTrack = repo.GetCurrentlyPlaying().FirstOrDefault();
                            Thread.Sleep(500);
                            //Console.WriteLine("{0}", _CurrentTrack == null ? "" : _CurrentTrack.TrackName);

                            DJDrop(Player.controls.currentPosition, Player.currentMedia.duration);
                            try
                            {
                                if ((_CurrentTrack.PlayCompleted == true) || (_CurrentTrack == null))
                                {
                                    break;
                                }
                            }
                            catch
                            {
                                Player.controls.stop();
                                break;
                            }

                            var currentVotes = repoVote.GetUpVotes(_CurrentTrack.PlayHistoryId).Count - repoVote.GetDownVotes(_CurrentTrack.PlayHistoryId).Count;
                            if (currentVotes < 0)
                            {
                                VolumeDown(50, currentVotes);
                            }
                            else if (currentVotes > 0)
                            {
                                VolumeUp(50, currentVotes);
                            }
                            else
                            {
                                Player.settings.volume = 50;
                            }
                        }
                        if (_CurrentTrack != null)
                        {
                            repo.AnonSetTrackToStop(_CurrentTrack.PlayHistoryId);
                        }
                    }
                }
            }
            stopping = true;
        }
        private static void DJDrop(double CurrentTime, double TotalTime)
        {
            //Drop a random DJ drop halfway through a track
        }

        private static void QueueAJukeBoxTrack()
        {

        }

    }
}
