using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace SnakeGame
{
    public class Sounds
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        private string pathToMedia;

        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;
        }

        public void Play(int level)
        {
            player.URL = pathToMedia + "back" + level + ".mp3";
            player.settings.volume = 30;
            player.controls.play();
            player.settings.setMode("loop", true);
        }

        public void Play(string songName)
        {
            player.URL = pathToMedia + songName + ".mp3";
            player.controls.play();
        }

        public void Stop(int level)
        {
            player.URL = pathToMedia + "back" + level + ".mp3";
            player.controls.stop();
        }

        public void Stop(string songName)
        {
            player.URL = pathToMedia + songName + ".mp3";
            player.controls.stop();
        }
    }
}
