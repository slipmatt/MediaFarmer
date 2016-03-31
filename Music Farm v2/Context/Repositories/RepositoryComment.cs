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
    public class RepositoryComment
    {
        private static IUow _uow;
        private static IRepository<Comment> repo;
        public RepositoryComment(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<Comment>();
        }

        public List<CommentViewModel> GetComments(int PlayHistoryId)
        {
            return repo.GetByQuery()
                .Where(i => i.PlayHistoryId == PlayHistoryId)
                .Select(i => i.ToModel()).ToList();
        }

        public void AddComment(CommentViewModel item)
        {
            AuthHelper _ah = new AuthHelper(_uow);
            var _userId = _ah.SetupUser();
            item.UserId = _userId;
            repo.Add(item.ToData());
            repo.SaveChanges();
        }

        public List<CommentViewModel> ViewComments(int PlayHistoryId)
        {
            return repo.GetByQuery(i => i.PlayHistoryId == PlayHistoryId)
                .Select(i => i.ToModel()).ToList();
        }
    }
}