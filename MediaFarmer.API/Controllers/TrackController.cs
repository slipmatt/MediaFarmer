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
using AttributeRouting;
using System.Web.Mvc;
using System.Web.Http.Results;

namespace MediaFarmer.API.Controllers
{
    public class TrackController : ApiController
    {
        private RepositoryTrack _track;
        public TrackController()
        {
            _track = new RepositoryTrack(new Uow(new MusicFarmerEntities()));
        }

        // GET: api/Track
        [AttributeRouting.Web.Mvc.Route("api/Track")]
        [System.Web.Http.HttpGet]
        public string GetTracks(string q="")
        {
            List<TrackViewModel> track = new List<TrackViewModel>();
            track = _track.SearchTrack("", "", "", q);
            
            return JsonConvert.SerializeObject(track);
        }

        
    }
}