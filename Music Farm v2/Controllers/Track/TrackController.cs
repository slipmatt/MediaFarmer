using Music_Farm_v2.Context.Repositories;
using Music_Farm_v2.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;

namespace Music_Farm_v2.Controllers.Track
{
    public class TrackController : Controller
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        // GET: Track
        public ActionResult Index(string TrackName="",string AlbumName="",string ArtistName="")
        {
            var repos = new RepositoryTrack(new Uow(context));
            var items = repos.SearchTrackByName(TrackName);
            return View(items);
        }
        [HttpPost]
        public void Upload(IEnumerable<HttpPostedFileBase> files, string Album, String Artist)
        {
            var repos = new RepositoryTrack(new Uow(context));
            repos.Upload(files, Album, Artist);
        }
}