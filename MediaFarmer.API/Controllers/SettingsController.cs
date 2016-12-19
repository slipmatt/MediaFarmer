using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UnitOfWork;
using Newtonsoft.Json;
using System.Web.Http.Results;

namespace MediaFarmer.API.Controllers
{
    [RoutePrefix("api/Settings")]
    public class SettingsController : ApiController
    {
        private RepositorySettings _settings;
        public SettingsController()
        {
            _settings = new RepositorySettings(new Uow(new MusicFarmerEntities()));
        }

        // GET: api/Settings
        [Route("")]
        [System.Web.Http.HttpGet]
        public string GetAllSettings()
        {
            List<SettingValueViewModel> settings = new List<SettingValueViewModel>();
            settings = _settings.GetAllSettings();
            return JsonConvert.SerializeObject(settings);
        }

        // GET: api/Settings/5
        [Route("{id}")]
        [System.Web.Http.HttpGet]
        public string GetSetting(int id)
        {
            SettingValueViewModel settings = _settings.GetAllSettings().Find(i => i.SettingId == id);
            return JsonConvert.SerializeObject(settings);
        }

        // GET: api/Settings/5
        [Route("Update")]
        [System.Web.Http.HttpPost]
        public OkResult Post(SettingValueViewModel setting)
        {
            SettingValueViewModel settings = new SettingValueViewModel();
            _settings.UpdateSetting(setting);
            return Ok();
        }
    }
}