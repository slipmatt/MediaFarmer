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
    [RoutePrefix("api/Vote")]
    public class VoteController : ApiController
    {
        private RepositoryVote _vote;
        public VoteController()
        {
            _vote = new RepositoryVote(new Uow(new MusicFarmerEntities()));
        }

        // GET: api/Vote
        [Route("Up/{id}")]
        [System.Web.Http.HttpGet]
        public void Up(int id)
        {
            _vote.UpVote(id);
        }

        [Route("Down/{id}")]
        [System.Web.Http.HttpGet]
        public void Down(int id)
        {
            _vote.DownVote(id);
        }

        [Route("CountUpvotes/{id}")]
        [System.Web.Http.HttpGet]
        public string CountUpvotes(int id)
        {
            var vvm = _vote.GetUpVotes(id);
            return JsonConvert.SerializeObject(vvm);
        }

        [Route("CountDownvotes/{id}")]
        [System.Web.Http.HttpGet]
        public string CountDownvotes(int id)
        {
            var vvm = _vote.GetDownVotes(id);
            return JsonConvert.SerializeObject(vvm);
        }
    }
}