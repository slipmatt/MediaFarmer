using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;
using PagedList;

namespace MediaFarmer.Controllers.Track
{
    public class TrackController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        // GET: Track
        public ActionResult Index(string TrackName = "", string AlbumName = "", string ArtistName = "", string URL="", int Page=1)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryTrack(context);
                List<TrackViewModel> items;

                    items=repos.SearchTrack(TrackName, AlbumName, ArtistName, URL);

                ViewBag.TrackName = TrackName;
                ViewBag.AlbumName = AlbumName;
                ViewBag.ArtistName = ArtistName;
                ViewBag.URL = URL;
                ViewBag.Page = Page;
                return View(items.ToPagedList(Page,50));
            }
        }

        public ActionResult PlayLocal(int ID)
        {
            using (var context = new Uow(this.context))
            {
                List<TrackViewModel> ThisTrack = new List<TrackViewModel>();
                var repos = new RepositoryTrack(context);
                ThisTrack.Add(repos.SearchTrackByName("").Find(i => i.TrackId == ID));
                return PartialView(ThisTrack);
            }
        }

        public ActionResult TrackData(int ID)
        {
            using (var context = new Uow(this.context))
            {
                TrackViewModel ThisTrack;
                var repos = new RepositoryTrack(context);
                ThisTrack=(repos.SearchTrackByName("").Find(i => i.TrackId == ID));
                return PartialView(ThisTrack);
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrackData(TrackViewModel Track)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryTrack(context);
                repos.UpdateTrackInfo(Track);
            }
            Success("Product", "Save successful.");
            return Json(new { success = true });
        }

        public ActionResult Upload()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files, string Album, String Artist)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryTrack(context);
                if (repos.Upload(files, Album, Artist))
                {
                    Success("File Upload", "Save successful.");
                    return Json(new { success = true });
                }
                else
                {
                    Warning("File Upload", "Upload Failed.");
                    return Json(new { success = true });
                }
                
            }
        }

        public void RecursiveSearch()
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryTrack(context);
                repos.RecursiveSearch();
            }
        }
    }
}