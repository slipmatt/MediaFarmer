using Music_Farm_v2.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;

namespace Music_Farm_v2.Controllers.Vote
{
    public class VoteController : Controller
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        [ChildActionOnly]
        public ActionResult GetUpVoteCount(int PlayHistoryId)
        {
            var repos = new RepositoryVote(new Uow(context));
            var items = repos.GetUpVotes(PlayHistoryId);
            ViewBag.UpCount = items.Count;
            return PartialView(items);
        }
        [ChildActionOnly]
        public ActionResult GetDownVoteCount(int PlayHistoryId)
        {
            var repos = new RepositoryVote(new Uow(context));
            var items = repos.GetDownVotes(PlayHistoryId);
            ViewBag.DownCount = items.Count;
            return PartialView(items);
        }
    }
}