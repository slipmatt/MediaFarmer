using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace MediaFarmer.PlayerService
{
    public class MediaPlayerController
    {

        private static readonly Lazy<MediaPlayerController> lazy =
        new Lazy<MediaPlayerController>(() => new MediaPlayerController());

        public static MediaPlayerController Instance { get { return lazy.Value; } }

        public bool IsShuttingDown { get; set; }

        private static WMPLib.WindowsMediaPlayer Player;

        private MediaPlayerController()
        {
            IsShuttingDown = false;
        }

        public void InitializePlayer()
        {
            Player = new WindowsMediaPlayer();
        }

        public void PlayTrack(string Url)
        {
            Player.URL = Url;
            Player.controls.play();
        }

        public static void VolumeUp(int initVolume, int votes)
        {
            if (Player.settings.volume < 100)
            {
                Player.settings.volume = (initVolume + (10 * votes));
            }

        }

        public static void VolumeDown(int initVolume, int votes)
        {
            if (Player.settings.volume > 10)
            {
                Player.settings.volume = (initVolume + (10 * votes));
            }
        }

        public static void Mute()
        {
                Player.settings.volume = 0;
        }

        public static  WMPPlayState PlayerState()
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

        public static void Stop()
        {
            Player.controls.stop();
        }
    }
}
