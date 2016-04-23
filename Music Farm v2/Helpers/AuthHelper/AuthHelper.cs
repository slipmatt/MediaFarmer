using MediaFarmer.Context.Http;
using MediaFarmer.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWork;

namespace MediaFarmer.Helpers.AuthHelper
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
            string hName = HttpContextManager.Current.Request.ServerVariables["REMOTE_HOST"];
            try
            {
                System.Net.IPHostEntry host = new System.Net.IPHostEntry();
                host = System.Net.Dns.GetHostEntry(hName);

                //Split out the host name from the FQDN
                if (host.HostName.Contains("."))
                {
                    string[] sSplit = host.HostName.Split('.');
                    hName = sSplit[0].ToString();
                }
                else
                {
                    hName = host.HostName.ToString();
                }
            }
            catch (Exception) { }

            return hName.ToLower();
        }
    }
}