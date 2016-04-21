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
                //TODO: Clean up this shit hack code
                if (URL != "")
                {
                    items=repos.SearchTrackByURL(URL);
                }
                else
                {
                    items = repos.SearchTrackByURL(URL);
                }
                ViewBag.TrackName = TrackName;
                ViewBag.AlbumName = AlbumName;
                ViewBag.ArtistNamr = ArtistName;
                ViewBag.URL = URL;
                return View(items.ToPagedList(Page,50));
            }
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