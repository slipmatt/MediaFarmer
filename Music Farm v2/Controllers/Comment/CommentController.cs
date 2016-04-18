using MediaFarmer.Context.Repositories;
using MediaFarmer.Helpers.AuthHelper;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;

namespace MediaFarmer.Controllers.Comment
{
    public class CommentController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        [ChildActionOnly]
        public ActionResult GetCommentCount(int PlayHistoryId)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryComment(context);
                var items = repos.GetComments(PlayHistoryId);
                ViewBag.CommentCount = items.Count.ToString();
                ViewBag.PlayHistoryId = PlayHistoryId;
                return PartialView(items);
            }
        }

        public ActionResult AddComment(int PlayHistoryId)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryComment(context);
                AuthHelper _ah = new AuthHelper(context);
                var _userId = _ah.SetupUser();
                CommentViewModel item = new CommentViewModel
                {
                    CommentId = 0,
                    PlayHistoryId = PlayHistoryId,
                    UserId = _userId
                };
                return PartialView(item);
            }
        }

        public ActionResult CommentsView(int PlayHistoryId)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryComment(context);
                AuthHelper _ah = new AuthHelper(context);
                var _userId = _ah.SetupUser();
                var item = repos.ViewComments(PlayHistoryId);
                return PartialView(item);
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentViewModel item)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryComment(context);
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
}