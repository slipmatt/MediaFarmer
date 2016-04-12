using Music_Farm_v2.Context.Repositories;
using Music_Farm_v2.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWork;
using WMPLib;

namespace Music_Farm_v2.Player
{
    class Program
    {
        //TODO: This entire thing needs to be refactored...

        private static WMPLib.WindowsMediaPlayer Player;

        public static void VolumeUp(int initVolume, int votes)
        {
            if (Player.settings.volume < 100)
            {
                Player.settings.volume = (initVolume + (10* votes));
            }
           
        }

        public static void VolumeDown(int initVolume, int votes)
        {
            if (Player.settings.volume > 10)
            {
                Player.settings.volume = (initVolume + (10 * votes));
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Player = new WMPLib.WindowsMediaPlayer();
            Player.settings.volume = 70;
            var _uow = new Uow(new MusicFarmerEntities());
            var currentVolume=0;
            RepositoryPlayHistory repo;
            RepositoryVote repoVote;

            var spin = new ConsoleSpinner();
            while (true)
            {
                repo = new RepositoryPlayHistory(_uow);
                repoVote = new RepositoryVote(_uow);
                var currentList = repo.GetCurrentlyPlaying();
                PlayHistoryViewModel _CurrentTrack = currentList.FirstOrDefault();
                
                if (!currentList.Any())
                {
                    if (repo.GetCurrentlyQueued().Any())
                    {
                        _CurrentTrack = repo.GetCurrentlyQueued().FirstOrDefault();
                        repo.SetTrackToPlay(_CurrentTrack.PlayHistoryId);
                    }
                    else
                    {
                        Console.Write("\rThe DJ has left the building... ");
                        spin.SleepTurn();
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    RepositoryTrack repoTrack = new RepositoryTrack(_uow);
                    var nextSong = repoTrack.SearchTrackByName("").Find(i => i.TrackId == _CurrentTrack.TrackId).TrackURL;
                    Uri songUri = new Uri(nextSong);

                    Player.URL = nextSong;
                    Player.controls.play();
                    while (Player.playState == WMPPlayState.wmppsPlaying || Player.playState == WMPPlayState.wmppsBuffering || Player.playState == WMPPlayState.wmppsTransitioning)
                    {
                        _CurrentTrack = repo.GetCurrentlyPlaying().FirstOrDefault();
                        Thread.Sleep(500);
                        //Console.WriteLine("{0}", _CurrentTrack == null ? "" : _CurrentTrack.TrackName);

                        Console.Write("\r{0} / {1} Volume level: ({3})", Player.controls.currentPositionString, Player.currentMedia.durationString, _CurrentTrack == null ? "" :  _CurrentTrack.TrackName, Player.settings.volume.ToString());
                        spin.Turn();
                        try
                        {
                            if ((_CurrentTrack.PlayCompleted == true) || (_CurrentTrack == null))
                            {
                                Console.Clear();
                                break;
                            }
                        }
                        catch
                        {
                            Player.controls.stop();
                            Console.Clear();
                            break;
                        }

                        var currentVotes = repoVote.GetUpVotes(_CurrentTrack.PlayHistoryId).Count - repoVote.GetDownVotes(_CurrentTrack.PlayHistoryId).Count;
                        if (currentVotes<0)
                        {
                            VolumeDown(70, currentVotes);
                        }
                        else if (currentVotes > 0)
                        {
                            VolumeUp(70, currentVotes);
                        }
                        else
                        {
                            Player.settings.volume = 70;
                        }
                    }
                    if (_CurrentTrack != null)
                    {
                        repo.SetTrackToStop(_CurrentTrack.PlayHistoryId);
                        Console.Clear();
                    }
                }
            }
        }
    }

    public class ConsoleSpinner
    {
        int counter;

        public void Turn()
        {
            counter++;
            switch (counter % 4)
            {
                case 0: Console.Write(" /"); counter = 0; break;
                case 1: Console.Write(" -"); break;
                case 2: Console.Write(" \\"); break;
                case 3: Console.Write(" |"); break;
            }
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
        }
        public void SleepTurn()
        {
            counter++;
            switch (counter % 8)
            {
                case 0: Console.Write("z   "); counter = 0; break;
                case 1: Console.Write("zz  "); break;
                case 2: Console.Write("zzz "); break;
                case 3: Console.Write("zzzz"); break;
                case 4: Console.Write("zzz "); break;
                case 5: Console.Write("zz  "); break;
                case 6: Console.Write("z   "); break;
                case 7: Console.Write("    "); break;
            }
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
        }
    }
}
