using Exiled.API.Features;
using Exiled.Events.EventArgs.Warhead;
using System;

namespace MusicWarhead
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "MusicWarhead";
        public override string Author => "Leo D / 76561198968919551@steam";
        public override Version Version => new Version(1, 0, 0);
        public static Plugin Singleton { get; private set; }

        public override void OnEnabled()
        {
            Singleton = this;
            Exiled.Events.Handlers.Warhead.Starting += OnStarting;
            Exiled.Events.Handlers.Warhead.Stopping += OnStopping;

            // audio
            AudioClipStorage.LoadClip($"{Plugin.Singleton.Config.AudioLocation}", "audio");
            if (Plugin.Singleton.Config.AudioLocation == "")
            {
                Log.Error("Audio location is not set in config");
                return;
            }

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Warhead.Stopping -= OnStopping;
            Exiled.Events.Handlers.Warhead.Starting += OnStarting;
            Singleton = null;
            base.OnDisabled();
        }

        private void OnStarting(StartingEventArgs ev)
        {
            // start audio
            AudioPlayer audioPlayer = AudioPlayer.CreateOrGet($"GlobalAudio", onIntialCreation: (p) =>
            { Speaker speaker = p.AddSpeaker("Main", isSpatial: false, maxDistance: 5000f); });

            if (Plugin.Singleton.Config.StopAfterEnd)
            {
                audioPlayer.AddClip("audio", Plugin.Singleton.Config.AudioVolume, false, true);
            }
            else
            {
                audioPlayer.AddClip("audio", Plugin.Singleton.Config.AudioVolume, true, false);
            }
        }

        private void OnStopping(StoppingEventArgs ev)
        {
            // stop audio if stopped
            if (!AudioPlayer.TryGet("GlobalAudio", out AudioPlayer player))
            { Log.Error("Failed to get audio player"); }

            player.RemoveClipByName("frank");
        }
    }
}