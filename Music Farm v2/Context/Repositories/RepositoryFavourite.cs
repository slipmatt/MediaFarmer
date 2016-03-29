using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWork;
using Music_Farm_v2.ViewModels;
using Music_Farm_v2.Context.Extensions;
using Music_Farm_v2.Helpers.AuthHelper;

namespace Music_Farm_v2.Context.Repositories
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
            var _UserId= AuthHelper.setupUser();
            return repo.GetByQuery()
                .Where(i => i.UserId == _UserId)
                .Select(i => i.ToModel()).ToList();
        }

        public void AddFavourite(int ID)
        {
            var _userId = AuthHelper.setupUser();
           FavouriteViewModel fvm = new FavouriteViewModel
           {
                UserId = _userId,
                TrackId = ID
            };
            repo.Add(fvm.ToData());
            repo.SaveChanges();
        }
    }
}