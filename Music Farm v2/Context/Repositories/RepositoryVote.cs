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
            return repo.GetByQuery(i => i.VoteValue.Equals(true))
                .Where(i => i.PlayHistoryId.Equals(PlayHistoryId))
                .Select(i => i.ToModel()).ToList();
        }

        public List<VoteViewModel> GetDownVotes(int PlayHistoryId)
        {
            return repo.GetByQuery(i => i.VoteValue.Equals(false))
                .Where(i => i.PlayHistoryId.Equals(PlayHistoryId))
                .Select(i => i.ToModel()).ToList();
        }

        public List<VoteViewModel> GetVotes(int PlayHistoryId)
        {
            return repo.GetByQuery(i => i.PlayHistoryId.Equals(PlayHistoryId))
                .Select(i => i.ToModel()).ToList();
        }

        public void DownVote(int _PlayHistoryId)
        {
            AuthHelper _ah = new AuthHelper(_uow);
            var _userId = _ah.SetupUser();
            List<VoteViewModel> _vvm;
            Vote _vote = new Vote
            {
                VoteId=0,
                VoteValue = false,
                PlayHistoryId = _PlayHistoryId,
                UserId = _userId
            };

            _vvm = this.GetVotes(_PlayHistoryId);
            if (_vvm != null)
            {
                if (_vvm.Find(i => i.UserId == _userId) == null)
                {
                    repo.Add(_vote);
                }
                else
                {
                    if (_vvm.Find
                        (i => (i.UserId == _userId) &&
                        (i.VoteValue == true)) != null)
                    {
                        _vote = repo.GetById(_vvm.Find
                           (i => (i.UserId == _userId) &&
                           (i.VoteValue == true))
                           .VoteId);
                        _vote.VoteValue = false;
                        repo.Update(_vote);
                    }
                    else if (_vvm.Find
                        (i => (i.UserId == _userId) &&
                        (i.VoteValue == false)) != null)
                    {
                        _vote = repo.GetById(_vvm.Find
                           (i => (i.UserId == _userId) &&
                           (i.VoteValue == false))
                           .VoteId);
                        repo.Delete(_vote);
                    }
                }
            }
            else
            {
                repo.Add(_vote);
            }
            repo.SaveChanges();
        }

        public void UpVote(int _PlayHistoryId)
        {
            AuthHelper _ah = new AuthHelper(_uow);
            var _userId = _ah.SetupUser();
            List<VoteViewModel> _vvm;
            Vote _vote = new Vote
            {
                VoteValue = true,
                PlayHistoryId = _PlayHistoryId,
                UserId = _userId
            };
            _vvm = this.GetVotes(_PlayHistoryId);
            if (_vvm != null)
            {
                if (_vvm.Find(i => i.UserId == _userId) == null)
                {
                    repo.Add(_vote);
                }
                else
                {
                    if (_vvm.Find
                            (i => (i.UserId == _userId) &&
                            (i.VoteValue == false)) != null)
                    {
                        _vote = repo.GetById(_vvm.Find
                            (i => (i.UserId == _userId) &&
                            (i.VoteValue == false))
                            .VoteId);
                        _vote.VoteValue = true;
                        repo.Update(_vote);
                    }
                    else if (_vvm.Find
                        (i => (i.UserId == _userId) &&
                        (i.VoteValue == true)) != null)
                    {
                        _vote = repo.GetById(_vvm.Find
                           (i => (i.UserId == _userId) &&
                           (i.VoteValue == true))
                           .VoteId);
                        repo.Delete(_vote);
                    }
                }
            }
            else
            {
                repo.Add(_vote);
            }
            repo.SaveChanges();
        }
    }
}