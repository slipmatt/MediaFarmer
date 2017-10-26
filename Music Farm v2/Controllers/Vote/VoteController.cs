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

namespace MediaFarmer.Controllers.Vote
{
    public class VoteController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        [ChildActionOnly]
        public ActionResult GetUpVoteCount(int PlayHistoryId)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryVote(context);
                var items = repos.GetUpVotes(PlayHistoryId);
                ViewBag.UpCount = items.Count.ToString();
                return PartialView(items);
            }
        }
        [ChildActionOnly]
        public ActionResult GetDownVoteCount(int PlayHistoryId)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryVote(context);
                var items = repos.GetDownVotes(PlayHistoryId);
                ViewBag.DownCount = items.Count.ToString();
                return PartialView(items);
            }
        }
        #region UpVote
        public ActionResult AddUpVote(int PlayHistoryId)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryVote(context);
                AuthHelper _ah = new AuthHelper(context);
                var _userId = _ah.SetupUser();
                repos.UpVote(PlayHistoryId);
                Success("Vote", "Save successful.");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        #endregion

        #region DownVote
        public ActionResult AddDownVote(int PlayHistoryId)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryVote(context);
                AuthHelper _ah = new AuthHelper(context);
                var _userId = _ah.SetupUser();
                repos.DownVote(PlayHistoryId);
                Success("Vote", "Save successful.");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        #endregion
    }
}