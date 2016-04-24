using MediaFarmer.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;
using MediaFarmer.Helpers.AuthHelper;

namespace MediaFarmer.Controllers.Playhistory
{
    public class PlayHistoryController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        #region PlayHistory
        public ActionResult Index()
        {
            using (var context = new Uow(this.context))
            {
                AuthHelper _ah = new AuthHelper(context);
                var _userId = _ah.SetupUser();
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult GetCurrentlyPlaying()
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryPlayHistory(context);
                var item = repos.GetCurrentlyPlaying();
                AuthHelper _ah = new AuthHelper(context);
                ViewBag.ThisUser = _ah.GetHostName().ToLower();
                return PartialView(item);
            }
            
        }
        [ChildActionOnly]
        public ActionResult GetCurrentlyQueued()
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryPlayHistory(context);
                var item = repos.GetCurrentlyQueued();
                AuthHelper _ah = new AuthHelper(context);

                ViewBag.ThisUser = _ah.GetHostName().ToLower();
                return PartialView(item);
            }
        }

        public ActionResult Queue(int ID)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryPlayHistory(context);
                if (repos.Queue(ID))
                {
                    Success("Queued", "Track Queued.");
                }
                else
                {
                    Warning("Not Queued", "Track is in the Que");
                }
                return RedirectToAction("Index", "Track");
            }
        }

        public ActionResult StopTrack(int ID)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryPlayHistory(context);
                if (repos.SetTrackToStop(ID))
                {
                    Success("Removed", "Track Removed from Queue.");
                }
                else
                {
                    Warning("Caleb Detected", "The Caleb Detection system is active");
                }
                return RedirectToAction("Index", "PlayHistory");
            }
        }

        #endregion
    }
}