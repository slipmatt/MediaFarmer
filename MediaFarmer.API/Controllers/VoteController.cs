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
        public List<VoteViewModel> CountUpvotes(int id)
        {
            return _vote.GetUpVotes(id);
        }

        [Route("CountDownvotes/{id}")]
        [System.Web.Http.HttpGet]
        public List<VoteViewModel> CountDownvotes(int id)
        {
            return _vote.GetDownVotes(id);
        }
    }
}