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
using MediaFarmer.Context.Extensions;
using System.Net.Http;
using System.Net;
using MediaFarmer.API.Models;

namespace MediaFarmer.API.Controllers
{
    [RoutePrefix("api/PlayHistory")]
    public class PlayHistoryController : ApiController
    {
        private RepositoryPlayHistory _playHistory;
        public PlayHistoryController()
        {
            _playHistory = new RepositoryPlayHistory(new Uow(new MusicFarmerEntities()));
        }

        [Route("GetQueued")]
        [System.Web.Http.HttpGet]
        public string GetQueued()
        {
            IEnumerable<PlayHistoryViewModel> playHistory;
            playHistory = _playHistory.GetCurrentlyQueued().Select(i => i.ToAPIModel());
            return JsonConvert.SerializeObject(playHistory);
        }

        [Route("GetPlaying")]
        [System.Web.Http.HttpGet]
        public string GetPlaying()
        {
            IEnumerable<PlayHistoryViewModel> playHistory;
            playHistory = _playHistory.GetCurrentlyPlaying().Select(i=>i.ToAPIModel());
            return JsonConvert.SerializeObject(playHistory);
        }

        [Route("Que/{id}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Que(int id)
        {
            ResponseModel queResponse = new ResponseModel();
            queResponse.Success = _playHistory.Queue(id);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(queResponse), System.Text.Encoding.UTF8, "application/json");

            return response;
        }

        [Route("Eject/{id}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Eject(int id)
        {
            ResponseModel queResponse = new ResponseModel();
            queResponse.Success = _playHistory.SetTrackToStop(id);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(queResponse), System.Text.Encoding.UTF8, "application/json");

            return response;
        }
    }
}