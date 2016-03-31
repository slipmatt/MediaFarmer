using Music_Farm_v2.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWork;

namespace Music_Farm_v2.Helpers.AuthHelper
{
    public class AuthHelper
    {
        private static IUow _uow;
        private static IRepository<User> repo;
        public AuthHelper(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<User>();
        }
        public int SetupUser()
        {
            var repos = new RepositoryUser(_uow);
            if (!repos.CheckIfUserExists(this.GetHostName()))
            {
                repos.CreatUser(this.GetHostName());
            }
            return repos.GetUserId(this.GetHostName());
        }

        public string GetHostName()
        {
            return String.Concat(Environment.UserDomainName, "/", Environment.UserName);
        }
    }
}