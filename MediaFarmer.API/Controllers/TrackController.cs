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
using MediaFarmer.API.Interfaces;

namespace MediaFarmer.API.Controllers
{
    [RoutePrefix("api/Track")]
    public class TrackController : ApiController, ITrackController
    {
        private RepositoryTrack _track;
        public TrackController()
        {
            _track = new RepositoryTrack(new Uow(new MusicFarmerEntities()));
        }

        // GET: api/Track
        [Route("")]
        [System.Web.Http.HttpGet]
        public string GetTracks(string q="")
        {
            List<TrackViewModel> track = new List<TrackViewModel>();
            track = _track.SearchTrack("", "", "", q);
            
            return JsonConvert.SerializeObject(track);
        }

        
    }
}