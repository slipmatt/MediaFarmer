using Music_Farm_v2.Context.Extensions;
using Music_Farm_v2.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWork;

namespace Music_Farm_v2.Context.Repositories
{
    public class RepositoryUser
    {
        private static IUow _uow;
        private static IRepository<User> repo;
        public RepositoryUser(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<User>();
        }

        public int GetUserId(string _UserName)
        {
            return repo.GetByQuery()
               .Where(i => i.UserName.Equals(_UserName))
               .Select(i => i.ToModel()).ToList()
               .Find(i => i.UserName == _UserName)
               .UserId;
        }

        public bool CheckIfUserExists(string _UserName)
        {
            UserViewModel uvm = repo.GetByQuery()
               .Where(i => i.UserName.Equals(_UserName))
               .Select(i => i.ToModel()).ToList()
               .Find(i => i.UserName == _UserName);
            if (uvm== null)
            {
                return false;
            }
               else
            {
                return true;
            }
        }

        public void CreatUser(string _UserName)
        {
            UserViewModel User = new UserViewModel
            {
                UserName = _UserName,
                Active = true
            };
            repo.Add(User.ToData());
            repo.SaveChanges();
        }
    }
}