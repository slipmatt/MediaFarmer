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

namespace Music_Farm_v2.Controllers.Vote
{
    public class VoteController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        [ChildActionOnly]
        public ActionResult GetUpVoteCount(int PlayHistoryId)
        {
            var repos = new RepositoryVote(new Uow(context));
            var items = repos.GetUpVotes(PlayHistoryId);
            ViewBag.UpCount = items.Count.ToString();
            return PartialView(items);
        }
        [ChildActionOnly]
        public ActionResult GetDownVoteCount(int PlayHistoryId)
        {
            var repos = new RepositoryVote(new Uow(context));
            var items = repos.GetDownVotes(PlayHistoryId);
            ViewBag.DownCount = items.Count.ToString();
            return PartialView(items);
        }
        #region UpVote
        public ActionResult AddUpVote(int PlayHistoryId)
        {
            var repos = new RepositoryVote(new Uow(context));
            var _userId = AuthHelper.setupUser();

            repos.UpVote(PlayHistoryId);
            Success("Vote", "Save successful.");
            return View("../PlayHistory/Index");
        }
        #endregion

        #region DownVote
        public ActionResult AddDownVote(int PlayHistoryId)
        {
            var repos = new RepositoryVote(new Uow(context));
            var _userId = AuthHelper.setupUser();
            
            repos.DownVote(PlayHistoryId);
            Success("Vote", "Save successful.");
            return View("../PlayHistory/Index");
        }
        #endregion
    }
}