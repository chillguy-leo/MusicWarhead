using Exiled.API.Features;
using Exiled.Events.EventArgs.Warhead;
using System;

namespace MusicWarhead
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "MusicWarhead";
        public override string Author => "chillguy-leo";
        public override Version Version => new Version(1, 0, 0);
        public static Plugin Singleton { get; private set; }
        private EventHandler eventHandler;

        public override void OnEnabled()
        {
            Singleton = this;
            eventHandler = new EventHandler();
            Exiled.Events.Handlers.Warhead.Starting += eventHandler.OnStarting;
            Exiled.Events.Handlers.Warhead.Stopping += eventHandler.OnStopping;

            // audio loading into cache
            AudioClipStorage.LoadClip($"{Plugin.Singleton.Config.AudioLocation}", "audio");
            if (Plugin.Singleton.Config.AudioLocation == "")
            {
                Log.Error("Audio location is not set in config");
                return;
            }

            Log.Debug("Loaded succesfully");

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Warhead.Stopping -= eventHandler.OnStopping;
            Exiled.Events.Handlers.Warhead.Starting += eventHandler.OnStarting;
            eventHandler = null;
            Singleton = null;

            Log.Debug("Disabled");

            base.OnDisabled();
        }
    }
}