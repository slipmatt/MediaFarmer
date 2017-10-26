using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWork;
using MediaFarmer.ViewModels;
using MediaFarmer.Context.Extensions;
using MediaFarmer.Helpers.AuthHelper;

namespace MediaFarmer.Context.Repositories
{
    public class RepositoryFavourite
    {
        private static IUow _uow;
        private static IRepository<Favourite> repo;
        public RepositoryFavourite(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<Favourite>();
        }

        public List<FavouriteViewModel> MyFavourites()
        {
            AuthHelper _ah = new AuthHelper(_uow);
            var _UserId = _ah.SetupUser();
            return repo.GetByQuery()
                .Where(i => i.UserId == _UserId)
                .Select(i => i.ToModel()).ToList();
        }

        public bool AddFavourite(int ID)
        {
            bool _state = false;
            AuthHelper _ah = new AuthHelper(_uow);
            var _userId = _ah.SetupUser();
            if (!this.FavouriteExists(_userId, ID))
            {
                FavouriteViewModel fvm = new FavouriteViewModel
                {
                    UserId = _userId,
                    TrackId = ID
                };

                repo.Add(fvm.ToData());
                repo.SaveChanges();
                _state = true;
            }
            return _state;
        }
        public bool FavouriteExists(int UserId, int ID)
        {
            var id =repo.GetByQuery()
                .Where(i => i.UserId == UserId && i.TrackId == ID)
                .Select(i => i.FavouriteId).FirstOrDefault();
            if (id==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}