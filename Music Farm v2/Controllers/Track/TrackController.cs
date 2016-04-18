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
    public class TrackController : Controller
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        // GET: Track
        public ActionResult Index(string TrackName = "", string AlbumName = "", string ArtistName = "", int Page=1)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryTrack(context);
                var items = repos.SearchTrackByName(TrackName);
                
                return View(items.ToPagedList(Page,50));
            }
        }
        public ActionResult Upload()
        {
            return PartialView();
        }
        [HttpPost]
        public void Upload(IEnumerable<HttpPostedFileBase> files, string Album, String Artist)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryTrack(context);
                repos.Upload(files, Album, Artist);
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