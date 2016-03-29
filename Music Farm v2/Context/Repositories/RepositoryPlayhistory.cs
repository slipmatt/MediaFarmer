using Music_Farm_v2.Context.Extensions;
using Music_Farm_v2.Helpers.AuthHelper;
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
        private static IRepository<PlayHistory> repo;
        public RepositoryPlayHistory(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<PlayHistory>();
        }

        public List<PlayHistoryViewModel> GetCurrentlyQueued()
        {
            return repo.GetByQuery()
                .Where(i => i.PlayCompleted.Equals(false))
                .Where(i=>i.IsPlaying.Equals(false))
                .Select(i=>i.ToModel()).ToList();
        }

        public List<PlayHistoryViewModel> GetCurrentlyPlaying()
        {
            return repo.GetByQuery()
                .Where(i => i.IsPlaying.Equals(true))
                .Where(i => i.PlayCompleted.Equals(false))
                .Select(i => i.ToModel()).ToList();
        }

        

        public List<PlayHistoryViewModel> GetPlayCount(int TrackId)
        {
            return repo.GetByQuery()
                .Where(i => i.TrackId.Equals(TrackId))
                .Select(i => i.ToModel()).ToList();
        }

        public void Queue(int _TrackId)
        {
            var _userId = AuthHelper.setupUser();
            PlayHistoryViewModel pvm = new PlayHistoryViewModel
            {
                TrackId = _TrackId,
                UserId = _userId,
            };

            repo.Add(pvm.ToData());
            repo.SaveChanges();
        }
    }
}