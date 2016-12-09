using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace MediaFarmer.PlayerService.Classes
{
    public class MediaPlayerController
    {

        private static readonly Lazy<MediaPlayerController> lazy =
        new Lazy<MediaPlayerController>(() => new MediaPlayerController());

        public static MediaPlayerController Instance { get { return lazy.Value; } }

        public bool IsShuttingDown { get; set; }

        public bool IsInitialized { get; set; }
        public bool IsMuted { get; set; }
        public bool PlayedTrack { get; set; }

        private static WMPLib.WindowsMediaPlayer Player;

        private MediaPlayerController()
        {
            IsShuttingDown = false;
        }

        public void InitializePlayer()
        {
            if (!IsInitialized)
            {
                Player = new WindowsMediaPlayer();
                IsInitialized = true;
                PlayedTrack = false;
            }
        }

        public double? GetDuration()
        {
            return Player.currentMedia?.duration;
        }
        public double? GetElapsed()
        {
            return Player.controls?.currentPosition;
        }

        public void PlayTrack(string Url)
        {
            Player.URL = Url;
            Player.controls.play();
            PlayedTrack = true;
        }

        public void SetVolume(int volume)
        {
            Player.settings.volume = volume;
        }

        public void VolumeUp(int initVolume, int votes)
        {
            if (Player.settings.volume < 100)
            {
                Player.settings.volume = (initVolume + (10 * votes));
            }

        }

        public void VolumeDown(int initVolume, int votes)
        {
            if (Player.settings.volume > 10)
            {
                Player.settings.volume = (initVolume + (10 * votes));
            }
        }

        public void Mute()
        {
            Player.settings.volume = 0;
            IsMuted = true;
        }

        public void UnMute()
        {
            IsMuted = false;
        }

        public static WMPPlayState PlayerState()
        {
            return Player.playState;
        }

        public bool IsPlaying()
        {
            if (Player.playState == WMPPlayState.wmppsPlaying || Player.playState == WMPPlayState.wmppsBuffering || Player.playState == WMPPlayState.wmppsTransitioning)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Stop()
        {
            Player.controls.stop();
        }
    }
}
