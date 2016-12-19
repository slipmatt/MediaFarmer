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
        public string Que(int id)
        {
            var playHistory = _playHistory.Queue(id);
            return JsonConvert.SerializeObject(playHistory);
        }

        [Route("Eject/{id}")]
        [System.Web.Http.HttpGet]
        public string Eject(int id)
        {
            var playHistory = _playHistory.SetTrackToStop(id);
            return JsonConvert.SerializeObject(playHistory);
        }
    }
}