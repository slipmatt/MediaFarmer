using Music_Farm_v2.Context.Extensions;
using Music_Farm_v2.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWork;

namespace Music_Farm_v2.Context.Repositories
{
    public class RepositoryPlayHistory
    {
        private static IUow _uow;

        public RepositoryPlayHistory(IUow uow)
        {
            _uow = uow;
        }
        public static List<PlayHistoryViewModel> GetAllItems(bool showCompleted=false)
        {
            List<PlayHistoryViewModel> items = new List<PlayHistoryViewModel>();

                //items = GetContext().play_history
                //.Where(i => i.play_completed.Equals(showCompleted)).ToList()
                //.Select(i => i.ToModel()).ToList();
            return items;
        }

        public List<PlayHistoryViewModel> GetCurrentlyQueued()
        {
            var repo = _uow.GetRepo<PlayHistory>();
            return repo.GetByQuery()
                .Where(i => i.PlayCompleted.Equals(false))
                .Where(i=>i.IsPlaying.Equals(false))
                .Select(i=>i.ToModel()).ToList();
        }

        public List<PlayHistoryViewModel> GetCurrentlyPlaying()
        {
            var repo = _uow.GetRepo<PlayHistory>();
            return repo.GetByQuery()
                .Where(i => i.IsPlaying.Equals(true))
                .Where(i => i.PlayCompleted.Equals(false))
                .Select(i => i.ToModel()).ToList();
        }

        public List<PlayHistoryViewModel> GetPlayCount(int TrackId)
        {
            var repo = _uow.GetRepo<PlayHistory>();
            return repo.GetByQuery()
                .Where(i => i.TrackId.Equals(TrackId))
                .Select(i => i.ToModel()).ToList();
                
        }
    }
}