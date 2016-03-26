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
    }
}