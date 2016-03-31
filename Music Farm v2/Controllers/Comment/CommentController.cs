using Music_Farm_v2.Context.Repositories;
using Music_Farm_v2.Helpers.AuthHelper;
using Music_Farm_v2.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;

namespace Music_Farm_v2.Controllers.Comment
{
    public class CommentController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        [ChildActionOnly]
        public ActionResult GetCommentCount(int PlayHistoryId)
        {
            var repos = new RepositoryComment(new Uow(context));
            var items = repos.GetComments(PlayHistoryId);
            ViewBag.CommentCount = items.Count.ToString();
            ViewBag.PlayHistoryId = PlayHistoryId;
            return PartialView(items);
        }

        public ActionResult AddComment(int PlayHistoryId)
        {
            var repos = new RepositoryComment(new Uow(context));
            AuthHelper _ah = new AuthHelper(new Uow(context));
            var _userId = _ah.SetupUser();
            CommentViewModel item = new CommentViewModel {
                CommentId = 0,
                PlayHistoryId = PlayHistoryId,
                UserId = _userId
            };
            return PartialView(item);
        }

        public ActionResult CommentsView(int PlayHistoryId)
        {
            var repos = new RepositoryComment(new Uow(context));
            AuthHelper _ah = new AuthHelper(new Uow(context));
            var _userId = _ah.SetupUser();
            var item = repos.ViewComments(PlayHistoryId);
            return PartialView(item);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentViewModel item)
        {
            var repos = new RepositoryComment(new Uow(context));
            if (ModelState.IsValid)
            {
                repos.AddComment(item);
                Success("Comment", "Save successful.");
                return Json(new { success = true });
            }
            return PartialView(item);
        }
    }
}