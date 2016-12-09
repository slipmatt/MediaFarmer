using UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using WMPLib;
using MediaFarmer.PlayerService.Classes;

namespace MediaFarmer.PlayerService
{
    public sealed class ThreadedTimers
    {
        private static readonly Lazy<ThreadedTimers> _lazy = new Lazy<ThreadedTimers>(() => new ThreadedTimers());
        public static ThreadedTimers Instance { get { return _lazy.Value; } }

        public System.Threading.Timer RefreshTrackQueue { get; set; }
        public bool IsShuttingDown { get; set; }
        private ThreadedTimers()
        {
            IsShuttingDown = false;
        }
    }

    public class ThreadedTimerExecutions
    {
        private static List<SettingValueViewModel> _settings { get; set; }
        private static MediaPlayerController _player { get; set; }
        private static PlayListController _playList { get; set; }
        private static JukeBoxController _jukeboxAutoqueue { get; set; }

        public static void RefreshTrackQueue(object obj)
        {
            var track = new PlayHistoryViewModel();
            _playList = PlayListController.Instance;
            _player = MediaPlayerController.Instance;
            _jukeboxAutoqueue = JukeBoxController.Instance;
            using (var uow = new Uow(new MusicFarmerEntities()))
            {
                var repoVotes = new RepositoryVote(uow);
                InitializeRepos(uow);
                SetPlayerSettings();
                SetJukeBoxSettings();
                if (_player.IsMuted)
                {
                    return;
                }

                if (!_player.IsPlaying())
                {
                    ChangeTrack();
                }

                if (_playList.IsPlayingTrack() && !(_player.IsPlaying()))
                {
                    track = _playList.GetPlayingTrack();
                }
                else if ((_player.IsPlaying()) && (!(_playList.IsPlayingTrack())))
                {
                    //Trust me on this one.
                    //___________________________________________________
                    //| Stop the track to resync the DB with the Player  |
                    //|__________________________________________________|
                
                    _player.Stop();
                    _jukeboxAutoqueue.IncrementPosition();
                    return;
                }
                else if (_playList.HasTrackQueued() && !(_player.IsPlaying()))
                {
                    track = _playList.GetNextQueuedTrack();
                }
                else if (!_player.IsPlaying())
                {
                    SpinUpJukeBox();
                    return;
                }
                
                
                if (_player.IsPlaying())
                {
                    track = _playList.GetPlayingTrack();
                    SetPlayerVolumeBasedOnVotes(repoVotes.GetUpVotes(track.PlayHistoryId).Count, repoVotes.GetDownVotes(track.PlayHistoryId).Count);
                }
                else
                {
                    LoadNewTrack(track);
                }
            }
        }

        private static void LoadNewTrack(PlayHistoryViewModel track)
        {
            if (track.TrackId != 0)
            {
                PlayTrack(track.Track.TrackURL);
                _playList.SetPlayingTrack(track.PlayHistoryId);
            }
        }

        private static void InitializeRepos(Uow uow)
        {
            _playList.InitializePlaylist(uow);
            _jukeboxAutoqueue.InitializeJukeBox(uow);
            var repoSettings = new RepositorySettings(uow);
            _player.InitializePlayer();
            _playList.RefreshPlaylist();
            _settings = repoSettings.GetAllSettings();
            _jukeboxAutoqueue.RefreshJukeBox();
        }

        private static void SpinUpJukeBox()
        {
            if (!_jukeboxAutoqueue.Active)
            {
                return;
            }
            _playList.QueueTrack(_jukeboxAutoqueue.GetNextTrack().TrackId);
            _jukeboxAutoqueue.IncrementPosition();
        }

        private static void ChangeTrack()
        {
            if (_player.PlayedTrack)
            {
                _playList.RemoveFromQueue(_playList.GetPlayingTrack());
            }
            _playList.GetNextQueuedTrack();
        }

        private static void SetPlayerVolumeBasedOnVotes(int upVote, int downVote)
        {
            var initVolume = _settings.Find(s => s.SettingId == (int)MediaFarmer.Enumerators.Settings.StartVolume).SettingValue;
            var increment = _settings.Find(s => s.SettingId == (int)MediaFarmer.Enumerators.Settings.VolumeIncrements).SettingValue;
            var currentVotes = upVote - downVote;
            _player.SetVolume(initVolume + (increment * currentVotes));
        }

        private static void SetPlayerSettings()
        {
            if (_settings.Any(s => s.Active == true && s.SettingId == (int)MediaFarmer.Enumerators.Settings.Mute))
            {
                _player.Mute();
            }
            else
            {
                _player.UnMute();
                _player.SetVolume(_settings.Find(s => s.SettingId == (int)MediaFarmer.Enumerators.Settings.StartVolume).SettingValue);
            }
        }

        private static void SetJukeBoxSettings()
        {
            if (_settings.Any(s=>s.SettingId == (int)MediaFarmer.Enumerators.Settings.JukeBoxAutoQueue))
            {
                _jukeboxAutoqueue.Active = _settings.Find(s => s.SettingId == (int)MediaFarmer.Enumerators.Settings.JukeBoxAutoQueue).Active;
            }

            if (_settings.Any(s => s.SettingId == (int)MediaFarmer.Enumerators.Settings.SecondsToAutoQueue))
            {
                _jukeboxAutoqueue.TimeToWait = _settings.Find(s => s.SettingId == (int)MediaFarmer.Enumerators.Settings.SecondsToAutoQueue).SettingValue;
            }
        }

        private static void PlayTrack(string Url)
        {
            _player.PlayTrack(Url);
        }
    }
}