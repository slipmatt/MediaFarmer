using MediaFarmer.Context.Extensions;
using MediaFarmer.Helpers.AuthHelper;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWork;

namespace MediaFarmer.Context.Repositories
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