using MediaFarmer.Context.Repositories;
using MediaFarmer.Helpers.AuthHelper;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork;

namespace MediaFarmer.Controllers.Settings
{
    public class SettingsController : BaseController
    {
        MusicFarmerEntities context = new MusicFarmerEntities();
        public ActionResult ViewSettings()
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositorySettings(context);
                var items = repos.GetAllSettings();
                return View(items);
            }
        }

        [HttpGet]
        public ActionResult Edit(int SettingId)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositorySettings(context);
                var items = repos.GetFilteredSettingsById(SettingId);
                return PartialView(items);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SettingValueViewModel item)
        {
            using (var context = new Uow(this.context))
            {
                var repos = new RepositorySettings(context);
                if (ModelState.IsValid)
                {
                    repos.UpdateSetting(item);
                    Success("Setting", "Save successful.");
                    return Json(new { success = true });
                }
                return PartialView(item);
            }
        }
    }
}