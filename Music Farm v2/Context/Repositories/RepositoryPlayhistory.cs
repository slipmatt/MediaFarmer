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
        public RepositoryPlayHistory(IUow uow)
        {
            _uow = uow;
        }

        public List<PlayHistoryViewModel> GetCurrentlyQueued()
        {
            var repo = _uow.GetRepo<PlayHistory>();
            return repo.GetByQuery(i => !i.PlayCompleted)
                .Where(i => i.IsPlaying.Equals(false))
                .Select(i => i.ToModel()).ToList();
        }

        public List<PlayHistoryViewModel> GetCurrentlyPlaying()
        {
            var repo = _uow.GetRepo<PlayHistory>();
            return repo.GetByQuery(i => i.IsPlaying)
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

        public void SetTrackToPlay(int PlayHistoryId)
        {
            var repo = _uow.GetRepo<PlayHistory>();
            PlayHistory ph = repo.GetByQuery()
                .ToList()
                .Find(i => i.PlayHistoryId == PlayHistoryId);
            ph.IsPlaying = true;
            repo.Update(ph);
            repo.SaveChanges();
        }
        public void SetTrackToStop(int PlayHistoryId)
        {
            var repo = _uow.GetRepo<PlayHistory>();
            PlayHistory ph = repo.GetByQuery()
                .ToList()
                .Find(i => i.PlayHistoryId == PlayHistoryId);
            ph.IsPlaying = false;
            ph.PlayCompleted = true;
            repo.Update(ph);
            repo.SaveChanges();
        }

        public void Queue(int _TrackId)
        {
            var repo = _uow.GetRepo<PlayHistory>();
            AuthHelper _ah = new AuthHelper(_uow);
            var _userId = _ah.SetupUser();
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