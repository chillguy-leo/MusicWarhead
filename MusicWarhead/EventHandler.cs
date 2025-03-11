using Exiled.API.Features;
using Exiled.Events.EventArgs.Warhead;

namespace MusicWarhead
{
    public class EventHandler
    {
        public void OnStarting(StartingEventArgs ev)
        {
            // establish audio player
            AudioPlayer audioPlayer = AudioPlayer.CreateOrGet("MusicWarhead", onIntialCreation: (p) =>
            { Speaker speaker = p.AddSpeaker("Main", isSpatial: false, maxDistance: 5000f); });

            Log.Debug("Audio player created/got");

            // play the sexy music that you have set
            if (Plugin.Singleton.Config.StopAfterEnd)
            {
                audioPlayer.AddClip("audio", Plugin.Singleton.Config.AudioVolume, false, true);
                Log.Debug("Added clip stopping after end");
            }
            else
            {
                audioPlayer.AddClip("audio", Plugin.Singleton.Config.AudioVolume, true, false);
                Log.Debug("Added clip loading after endd");
            }
        }

        public void OnStopping(StoppingEventArgs ev)
        {
            // get player and stop audio if stopped
            if (!AudioPlayer.TryGet("MusicWarhead", out AudioPlayer player))
            { Log.Error("Failed to get audio player"); }

            player.RemoveClipByName("audio");
            Log.Debug("Removed clip from Audio player");
        }
    }
}
