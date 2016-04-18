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

        public List<TrackViewModel> SearchTrackByName(string _TrackName)
        {
            return repo.GetByQuery(i => i.TrackName.ToLower().Contains(_TrackName.ToLower()) || (_TrackName==""))
                .Select(i=>i.ToModel()).ToList();
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
        
        public void Upload(IEnumerable<HttpPostedFileBase> files, string Album, String Artist)
        {
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
                    if (file.ContentLength > 0)
                    {
                        var _fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(_RootDir, Album, Artist);
                        if (!System.IO.Directory.Exists(path))
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        file.SaveAs(Path.Combine(path, _fileName));

                        var repoAlbum = new RepositoryAlbum(_uow);
                        var _Album = repoAlbum.GetAlbumId(Album).Find(i => i.AlbumName == Album);
                        int? _AlbumId = _Album == null ? 0 : _Album.AlbumId;
                        TrackViewModel Track = new TrackViewModel
                        {
                            TrackName = _fileName,
                            AlbumId = _AlbumId == 0 ? null : _AlbumId,
                            ArtistId = null,
                            TrackURL = Path.Combine(path, _fileName)
                        };
                        repo.Add(Track.ToData());
                        repo.SaveChanges();
                    }
                }
            }
        }

        public void RecursiveSearch(string dir= "")
        {
        dir=Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content\\Media\\");
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
                        catch
                        {
                            
                        }

                    }
                }
            }
        }
    }
}