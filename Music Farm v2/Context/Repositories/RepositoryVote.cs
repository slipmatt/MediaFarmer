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
    public class RepositoryVote
    {
        private static IUow _uow;
        private static IRepository<Vote> repo;
        public RepositoryVote(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<Vote>();
        }
        public List<VoteViewModel> GetUpVotes(int PlayHistoryId)
        {
            return repo.GetByQuery()
                .Where(i => i.VoteValue.Equals(true))
                .Where(i => i.PlayhistoryId.Equals(PlayHistoryId))
                .Select(i => i.ToModel()).ToList();
        }

        public List<VoteViewModel> GetDownVotes(int PlayHistoryId)
        {
            return repo.GetByQuery()
                .Where(i => i.VoteValue.Equals(false))
                .Where(i => i.PlayhistoryId.Equals(PlayHistoryId))
                .Select(i => i.ToModel()).ToList();
        }

        public void DownVote(int _PlayHistoryId)
        {
            var _userId = AuthHelper.setupUser();
            VoteViewModel User = new VoteViewModel
            {
                VoteValue = false,
                PlayHistoryId = _PlayHistoryId,
                UserId = _userId
            
            };
        }
    }
}