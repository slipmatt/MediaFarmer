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
        //Does not work on Test
        public static int setupUser()
        {
            MusicFarmerEntities context = new MusicFarmerEntities();
            int _userId;
            var repos = new RepositoryUser(new Uow(context));
            if (!repos.CheckIfUserExists(AuthHelper.getHostName()))
            {
                repos.CreatUser(getHostName());
            }
            _userId = repos.GetUserId(getHostName());
            return _userId;
        }

        public static string getHostName()
        {
            string hName = String.Concat(Environment.UserDomainName,"/", Environment.UserName);

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