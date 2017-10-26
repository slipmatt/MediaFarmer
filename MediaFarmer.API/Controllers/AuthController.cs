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
using MediaFarmer.API.Models;

namespace MediaFarmer.API.Controllers
{
    [RoutePrefix("api/Auth")]
    public class AuthController : ApiController
    {
        public AuthController()
        {

        }

        // GET: api/Track
        [Route("Ping")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Ping()
        {
            ResponseModel Response = new ResponseModel
            {
                Success = true,
                Message = "MF Auth Success"
            };

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(Response), System.Text.Encoding.UTF8, "application/json");

            return response;
        }

        
    }
}