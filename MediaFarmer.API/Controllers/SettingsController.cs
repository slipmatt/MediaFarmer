using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UnitOfWork;
using Newtonsoft.Json;

namespace MediaFarmer.API.Controllers
{
    public class SettingsController : ApiController
    {
        private RepositorySettings _settings;
        public SettingsController()
        {
            _settings = new RepositorySettings(new Uow(new MusicFarmerEntities()));
        }

        // GET: api/Settings
        public string GetSettings()
        {
            List<SettingValueViewModel> settings = new List<SettingValueViewModel>();
            settings = _settings.GetAllSettings();
            return JsonConvert.SerializeObject(settings);
        }

        // GET: api/Settings/5
        public string Get(int id)
        {
           SettingValueViewModel settings = new SettingValueViewModel();
            settings = _settings.GetAllSettings().Find(i=>i.SettingId==id);
            return JsonConvert.SerializeObject(settings);
        }
    }
}