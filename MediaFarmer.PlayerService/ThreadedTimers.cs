using UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using WMPLib;

namespace MediaFarmer.PlayerService
{
    public sealed class ThreadedTimers
    {
        private static readonly Lazy<ThreadedTimers> _lazy = new Lazy<ThreadedTimers>(() => new ThreadedTimers());
        public static ThreadedTimers Instance { get { return _lazy.Value; } }

        public System.Threading.Timer RefreshTrackQueue { get; set; }
        public bool IsShuttingDown { get; set; }

        private ThreadedTimers()
        {
            IsShuttingDown = false;
        }
    }

    public class ThreadedTimerExecutions
    {
        public static void RefreshTrackQueue(object obj)
        {
            var playList = PlayListController.Instance;
            var player = MediaPlayerController.Instance;
            
            using (var uow = new Uow(new MusicFarmerEntities()))
            {
                playList.InitializePlaylist(uow);
                player.InitializePlayer();
                playList.RefreshPlaylist();
                //This check is for the case when the service shuts down unexpectedly
                //and the track is still marked as playing in the DB. play will resume from
                //this track then move over to the Queue
                if (playList.IsPlayingTrack())
                {
                    var ph = playList.GetPlayingTrack();
                    PlayTrack(playList.GetPlayingTrack().Track.TrackURL, player);
                }

                else if (playList.HasTrackQueued())
                {
                    PlayTrack(playList.GetNextQueuedTrack().Track.TrackURL, player);
                }
            }
        }

        private static void PlayTrack(string Url, MediaPlayerController mediaPlayer)
        {
            if (!(mediaPlayer.IsPlaying()))
            {
                mediaPlayer.PlayTrack(Url);
            }
        }
    }
}