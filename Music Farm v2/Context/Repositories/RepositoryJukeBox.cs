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
    public class RepositoryJukeBox
    {
        private static IUow _uow;
        public RepositoryJukeBox(IUow uow)
        {
            _uow = uow;
        }
        public List<JukeBoxViewModel> GetJukeBoxTracks()
        {
            var repo = _uow.GetRepo<JukeBoxTracks_Result>();
            return repo.ExecWithStoreProcedure("JukeBoxTracks").Select(i=>i.ToModel()).ToList();
        }
    }
}