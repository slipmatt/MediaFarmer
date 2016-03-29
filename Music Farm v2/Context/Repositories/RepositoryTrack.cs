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
    public class RepositoryTrack
    {
        private static IUow _uow;
        private static IRepository<Track> repo;
        public RepositoryTrack(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<Track>();
        }

        public List<TrackViewModel> SearchTrackByName(string _TrackName)
        {
            return repo.GetByQuery()
                .Where(i => i.TrackName.Contains(_TrackName))
                .Select(i=>i.ToModel()).ToList();
        }

        public List<TrackViewModel> SearchTrackByAlbumName(string _AlbumName)
        {
            return repo.GetByQuery()
                .Where(i => i.Album.AlbumName.Contains(_AlbumName))
                .Select(i => i.ToModel()).ToList();
        }

        public List<TrackViewModel> SearchTrackByArtistName(string _ArtistName)
        {
            return repo.GetByQuery()
                .Where(i => i.Artist.ArtistName.Contains(_ArtistName))
                .Select(i => i.ToModel()).ToList();
        }
    }
}