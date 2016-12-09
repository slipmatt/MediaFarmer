using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace MediaFarmer.PlayerService.Classes
{
    public class JukeBoxController
    {
        private static readonly Lazy<JukeBoxController> lazy =
 new Lazy<JukeBoxController>(() => new JukeBoxController());
        public static RepositoryJukeBox repo;
        public static List<JukeBoxViewModel> Jukebox;
        public static JukeBoxController Instance { get { return lazy.Value; } }
        public static int Position { get; set; }
        public bool IsShuttingDown { get; set; }

        private JukeBoxController()
        {
            IsShuttingDown = false;
        }

        public void InitializeJukeBox(IUow uow)
        {
            repo = new RepositoryJukeBox(uow);
            Position = 0;
        }

        public void RefreshJukeBox()
        {
            Jukebox = repo.GetJukeBoxTracks();
        }

        public JukeBoxViewModel GetNextTrack()
        {
            var jukeBoxViewModel = Jukebox.ElementAt(Position);
            return jukeBoxViewModel;
        }

        public void IncrementPosition()
        {
            if (Position <= Jukebox.Count - 1)
            {
                Position += 1;
            }
            else
            {
                Position = 0;
            }
        }
    }
}
