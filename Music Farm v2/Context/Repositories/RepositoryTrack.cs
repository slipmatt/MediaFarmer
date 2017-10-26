using MediaFarmer.Context.Extensions;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using UnitOfWork;

namespace MediaFarmer.Context.Repositories
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

        public void AddMetaData(string Album, String Artist)
        {

        }

        public List<TrackViewModel> SearchTrackByName(string _TrackName)
        {
            return repo.GetByQuery(i => i.TrackName.ToLower().Contains(_TrackName.ToLower()) || (_TrackName==""))
                .Select(i=>i.ToModel()).ToList();
        }

        public List<TrackViewModel> SearchTrackByURL(string _TrackURL)
        {
            return repo.GetByQuery(i => i.TrackURL.ToLower().Contains(_TrackURL.ToLower()) || (_TrackURL == ""))
                .Select(i => i.ToModel()).ToList();
        }

        public List<TrackViewModel> SearchTrackByAlbumName(string _AlbumName)
        {
            return repo.GetByQuery(i => i.Album.AlbumName.ToLower().Contains(_AlbumName.ToLower()))
                .Select(i => i.ToModel()).ToList();
        }

        public List<TrackViewModel> SearchTrackByArtistName(string _ArtistName)
        {
            return repo.GetByQuery(i => i.Artist.ArtistName.ToLower().Contains(_ArtistName.ToLower()))
                .Select(i => i.ToModel()).ToList();
        }

        public List<TrackViewModel> SearchTrack(string trackName, string albumName, string artistName, string URL)
        {
            List<TrackViewModel> searchMash = new List<TrackViewModel>();
            if (!String.IsNullOrEmpty(trackName))
            {
                searchMash.AddRange(SearchTrackByName(trackName));
            }

            if (!String.IsNullOrEmpty(albumName))
            {
                searchMash.AddRange(SearchTrackByAlbumName(albumName));
            }

            if (!String.IsNullOrEmpty(artistName))
            {
                searchMash.AddRange(SearchTrackByArtistName(artistName));
            }

            if (!String.IsNullOrEmpty(URL) || searchMash.Count==0)
            {
                searchMash.AddRange(SearchTrackByURL(URL));
            }

            return searchMash;
        }

        public bool Upload(IEnumerable<HttpPostedFileBase> files, string Album, String Artist)
        {
            bool _state = false;
           // var _RootDir = "~/Content/Media/Music";
            var _RootDir = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(System.Web.HttpRuntime.AppDomainAppVirtualPath), "Content","Media","Music");
            if (!System.IO.Directory.Exists(_RootDir))
            {
                System.IO.Directory.CreateDirectory(_RootDir);
            }
            foreach (var file in files)
            {
                if (!(file == null))
                {
                    if (!
                            (
                                file.FileName.Contains(".mp3") ||
                                file.FileName.Contains(".wmv") ||
                                file.FileName.Contains(".wav")
                            )
                        )
                        return false;

                    if (file.ContentLength > 0)
                    {
                        var _fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(_RootDir, Album, Artist);
                        if (!System.IO.Directory.Exists(path))
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        file.SaveAs(Path.Combine(path, _fileName));

                        AlbumViewModel ThisAlbum = AddAlbum(Album);
                        ArtistViewModel ThisArtist = AddArtist(Artist);
                        TrackViewModel Track = new TrackViewModel
                        {
                            TrackName = _fileName,
                            AlbumId = ThisAlbum.AlbumId,
                            ArtistId = ThisArtist.ArtistId,
                            TrackURL = Path.Combine(path, _fileName)
                        };

                        repo.Add(Track.ToData());
                        repo.SaveChanges();
                        _state = true;
                    }
                }
            }
            return _state;
        }

        public void UpdateTrackInfo(TrackViewModel _Track)
        { 
            var existingTrack = repo.GetByQuery(i => i.TrackId == _Track.TrackId).FirstOrDefault();
            
            AlbumViewModel ThisAlbum = AddAlbum(_Track.AlbumName);
            ArtistViewModel ThisArtist = AddArtist(_Track.ArtistName);

            existingTrack.TrackName = _Track.TrackName;
            existingTrack.AlbumId = ThisAlbum.AlbumId;
            existingTrack.ArtistId = ThisArtist.ArtistId;
            existingTrack.TrackURL = _Track.TrackURL;
            repo.Update(existingTrack.UpdateData(existingTrack.ToModel()));
            repo.SaveChanges();
        }

        private AlbumViewModel AddAlbum(string Album)
        {
            AlbumViewModel ThisAlbum;
            var repoAlbum = new RepositoryAlbum(_uow);
            ThisAlbum = repoAlbum.GetFilteredAlbums(Album).FirstOrDefault();
            if (ThisAlbum == null)
            {
                ThisAlbum = new AlbumViewModel
                {
                    AlbumName = Album
                };
                repoAlbum.AddAlbum(ThisAlbum);
                ThisAlbum = repoAlbum.GetFilteredAlbums(Album).FirstOrDefault();
            }
            return ThisAlbum;
        }

        private ArtistViewModel AddArtist(string Artist)
        {
            ArtistViewModel ThisArtist;
            var repoArtist = new RepositoryArtist(_uow);
            ThisArtist = repoArtist.GetFilteredArtists(Artist).FirstOrDefault();
            if (ThisArtist == null)
            {
                ThisArtist = new ArtistViewModel
                {
                    ArtistName = Artist
                };
                repoArtist.AddArtist(ThisArtist);
                ThisArtist = repoArtist.GetFilteredArtists(Artist).FirstOrDefault();
            }
            return ThisArtist;
        }

        public void RecursiveSearch(string dir= "Content\\Media\\")
        {
            List<TrackViewModel> tvm = new List<TrackViewModel>();
        dir=Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir);
            SearchFilesInDirectory(dir);
            foreach (string d in Directory.EnumerateDirectories(dir))
            {
                RecursiveSearch(d);
            }
        }

        public void SearchFilesInDirectory(string SourceDirectory)
        {
            foreach (string file in Directory.EnumerateFiles(SourceDirectory, "*.*", SearchOption.AllDirectories)
            .Where(s => s.ToLower().EndsWith(".mp3")
            || s.ToLower().EndsWith(".wma")
            || s.ToLower().EndsWith(".wav")))
            {
                if (!(file == null))
                {
                    var _filePath = file;
                    var _fileName = Path.GetFileNameWithoutExtension(_filePath);
                    if (_fileName.Length>100)
                    {
                        _fileName= string.Concat(_fileName.Remove(96), "...");
                    }

                    var repoAlbum = new RepositoryAlbum(_uow);
                    TrackViewModel Track = new TrackViewModel
                    {
                        TrackName = _fileName,
                        AlbumId = null,
                        ArtistId = null,
                        TrackURL = _filePath
                    };

                    if (this.SearchTrackByName(_fileName).Count==0)
                    {
                        repo.Add(Track.ToData());
                        try
                        {
                            repo.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            
                        }

                    }
                }
            }
        }



        public List<TrackViewModel> ListFilesInDirectory(string SourceDirectory)
        {
            List<TrackViewModel> tvm = new List<TrackViewModel>();

            foreach (string file in Directory.EnumerateFiles(SourceDirectory, "*.*", SearchOption.AllDirectories)
             .Where(s => s.ToLower().EndsWith(".mp3")
             || s.ToLower().EndsWith(".wma")
             || s.ToLower().EndsWith(".wav")))
            { 
                if (!(file == null))
                {
                    var _filePath = file;
                    var _fileName = Path.GetFileNameWithoutExtension(_filePath);
                    var repoAlbum = new RepositoryAlbum(_uow);
                    TrackViewModel Track = new TrackViewModel
                    {
                        TrackName = _fileName,
                        AlbumId = null,
                        ArtistId = null,
                        TrackURL = _filePath
                    };

                    tvm.Add(Track);
                }
            }
            return tvm;
        }
    }
}