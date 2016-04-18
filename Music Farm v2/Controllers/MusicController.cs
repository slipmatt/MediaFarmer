using MediaFarmer.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;

namespace MediaFarmer.Controllers
{
    public class MusicController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();

        public ActionResult Album()
        {
            return View();
        }

        //public ActionResult Artist()
        //{
        //    var item = RepositoryArtist.GetAllItems(true, "test");
        //    return View(item);
        //}

        public ActionResult Track()
        {
            return View();
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