using Music_Farm_v2.Context.Extensions;
using Music_Farm_v2.ViewModels;
using UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Music_Farm_v2.Data;

namespace Music_Farm_v2.Context.Repositories
{
    public class RepositoryAlbum
    {
        private IUow _uow;

        public RepositoryAlbum(IUow uow)
        {
            _uow = uow;
        }

        public static List<AlbumViewModel> GetAllItems(bool showInactive, string filterString)
        {
            List<AlbumViewModel> items = new List<AlbumViewModel>();

            //if (!string.IsNullOrEmpty(filterString))
            //{
            //    items = GetContext().albums
            //    .Where(i => i.album_name.Contains(filterString)).ToList()
            //    .Select(i=>i.ToModel()).ToList(); 
            //}
            //else
            //{
            //    items = GetContext().albums
            //    .Select(i => i.ToModel()).ToList();
            //}
            return items;
        }

        public List<AlbumViewModel> GetFilteredAlbums(string filter)
        {
            var repo = _uow.GetRepo<album>();
            return repo.GetByQuery(i => i.album_name.Contains(filter)).Select(i => i.ToModel()).ToList();
        }

        public List<AlbumViewModel> GetAllAlbums()
        {
            var repo = _uow.GetRepo<album>();

            return repo.GetByQuery().Select(i => i.ToModel()).ToList();
        }
    }
}