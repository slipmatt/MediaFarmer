using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace MediaFarmer.PlayerService
{
    public class PlayListController
    {
        private static readonly Lazy<PlayListController> lazy =
 new Lazy<PlayListController>(() => new PlayListController());
        public static RepositoryPlayHistory repo;
        public static List<PlayHistoryViewModel> Playlist;
        public static PlayListController Instance { get { return lazy.Value; } }

        public bool IsShuttingDown { get; set; }

        private PlayListController()
        {
            IsShuttingDown = false;
        }

        public void InitializePlaylist(IUow uow)
        {
            repo = new RepositoryPlayHistory(uow);
        }

        public void RefreshPlaylist()
        {
            Playlist= repo.GetCurrentlyQueued();
        }

        public bool HasTrackQueued()
        {
            return Playlist.Any();
        }

        public bool IsPlayingTrack()
        {
            return repo.GetCurrentlyPlaying().Any();
        }

        public PlayHistoryViewModel GetPlayingTrack()
        {
            return repo.GetCurrentlyPlaying().FirstOrDefault();
        }

        public PlayHistoryViewModel GetNextQueuedTrack()
        {
            return Playlist.FirstOrDefault();
        }

        public static void RemoveFromQueue(int Id)
        {
            repo.AnonSetTrackToStop(Id);
        }
    }
}
