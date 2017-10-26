using MediaFarmer.Context.Extensions;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWork;

namespace MediaFarmer.Context.Repositories
{
    public class RepositoryArtist
    {
        private static IUow _uow;
        private static IRepository<Artist> repo;
        public RepositoryArtist(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<Artist>();
        }

        public List<ArtistViewModel> GetFilteredArtists(string filter)
        {
            return repo.GetByQuery(i => i.ArtistName.Contains(filter)).Select(i => i.ToModel()).ToList();
        }

        public void AddArtist(ArtistViewModel _Artist)
        {
            repo.Add(_Artist.ToData());
            repo.SaveChanges();
        }


    }
}