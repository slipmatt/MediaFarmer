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
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;

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
        public HttpResponseMessage GetTracks(string q="")
        {
            List<TrackViewModel> track = new List<TrackViewModel>();
            track = _track.SearchTrack("", "", "", q);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(track), System.Text.Encoding.UTF8, "application/json");

            return response;
        }

        
    }
}