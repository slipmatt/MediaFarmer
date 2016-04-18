using MediaFarmer.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;

namespace MediaFarmer.Controllers.Favourite
{
    public class FavouriteController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        [ChildActionOnly]
        public ActionResult GetFavouriteCount()
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryFavourite(context);
                var items = repos.MyFavourites();
                ViewBag.FavouriteCount = items.Count.ToString();
                return PartialView(items);
            }
        }

        public ActionResult AddFavourite(int ID)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryFavourite(context);
                repos.AddFavourite(ID);
                Success("Favourite", "Add to your favourites");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult My()
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositoryFavourite(context);
                var items = repos.MyFavourites();
                return View(items);
            }
        }
    }
}