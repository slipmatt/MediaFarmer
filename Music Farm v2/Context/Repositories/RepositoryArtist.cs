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
    public class RepositoryArtist
    {
        private static IUow _uow;
        private static IRepository<Artist> repo;
        public RepositoryArtist(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<Artist>();
        }

        public static List<ArtistViewModel> GetAllItems(string filterString)
        {
            List<ArtistViewModel> items = new List<ArtistViewModel>();

            //if (!string.IsNullOrEmpty(filterString))
            //{
            //    items = GetContext().artists
            //    .Where(i => i.artist_name.Contains(filterString)).ToList()
            //    .Select(i => i.ToModel()).ToList();
            //}
            //else
            //{
            //    items = GetContext().artists
            //    .Select(i => i.ToModel()).ToList();
            //}
            return items;
        }


    }
}