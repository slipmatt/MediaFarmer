using Music_Farm_v2.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;

namespace Music_Farm_v2.Controllers.Favourite
{
    public class FavouriteController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        [ChildActionOnly]
        public ActionResult GetFavouriteCount()
        {
            var repos = new RepositoryFavourite(new Uow(context));
            var items = repos.MyFavourites();
            ViewBag.FavouriteCount = items.Count.ToString();
            return PartialView(items);
        }

        public ActionResult AddFavourite(int ID)
        {
            var repos = new RepositoryFavourite(new Uow(context));
            repos.AddFavourite(ID);
            Success("Favourite", "Add to your favourites");
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult My()
        {
            var repos = new RepositoryFavourite(new Uow(context));
            var items = repos.MyFavourites();
            return View(items);
        }
    }
}