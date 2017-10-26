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
using System.Net.Http;
using System.Net;
using MediaFarmer.API.Models;

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
        public HttpResponseMessage GetAllSettings()
        {
            List<SettingValueViewModel> settings = new List<SettingValueViewModel>();
            settings = _settings.GetAllSettings();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(settings), System.Text.Encoding.UTF8, "application/json");

            return response;
        }

        // GET: api/Settings/5
        [Route("{id}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetSetting(int id)
        {
            SettingValueViewModel settings = _settings.GetAllSettings().Find(i => i.SettingId == id);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(settings), System.Text.Encoding.UTF8, "application/json");

            return response;
        }

        // GET: api/Settings/5
        [Route("Update")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post(SettingValueViewModel setting)
        {
            SettingValueViewModel settings = new SettingValueViewModel();
            _settings.UpdateSetting(setting);
            ResponseModel Response = new ResponseModel();
            Response.Success = true;
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(Response), System.Text.Encoding.UTF8, "application/json");

            return response;
        }
    }
}