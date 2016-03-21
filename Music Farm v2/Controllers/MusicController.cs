using Music_Farm_v2.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;

namespace Music_Farm_v2.Controllers
{
    public class MusicController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();

        public ActionResult Album()
        {
            var item = RepositoryAlbum.GetAllItems(true, "test");
            return View(item);
        }

        //public ActionResult Artist()
        //{
        //    var item = RepositoryArtist.GetAllItems(true, "test");
        //    return View(item);
        //}

        public ActionResult Track()
        {
            var item = RepositoryTrack.GetAllItems(true, "test");
            return View(item);
        }

        //public ActionResult Comment()
        //{
        //    var item = RepositoryComment.GetAllItems(true, "test");
        //    return View(item);
        //}
        
        //public ActionResult Vote()
        //{
        //    var item = RepositoryVote.GetAllItems(true, "test");
        //    return View(item);
        //}

    }
}