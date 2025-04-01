using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Site16Essentials.Commands.Client
{
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class InstallDependency : ICommand
    {
        public string Command { get; } = "mwinstalldepend";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Command to install MusicWarhead dependencies";

        private static readonly Dictionary<Player, float> cooldowns = new Dictionary<Player, float>();

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender playerSender)
            {
                response = "Cannot run this command!";
                return false;
            }

            bool status = UpdatePlugin();
            response = status ? "Successfully installed MusicWarhead dependencies" : "Failed to install MusicWarhead dependencies";
            return status;
        }

        public bool UpdatePlugin()
        {
            WebClient client = new WebClient();

            if (!Directory.Exists(Path.Combine(Paths.Plugins, "dependencies")))
                Directory.CreateDirectory(Path.Combine(Paths.Plugins, "dependencies"));

            string audioApiPath = Path.Combine(Paths.Plugins, "dependencies", "AudioPlayerApi.dll");
            string systemMemoryPath = Path.Combine(Paths.Plugins, "dependencies", "System.Memory.dll");
            string nVorbisPath = Path.Combine(Paths.Plugins, "dependencies", "NVorbis.dll");

            try
            {
                Log.Warn("[MusicWarhead Dependency Installer] Started download");
                client.DownloadFile("https://github.com/chillguy-leo/MusicWarhead/releases/download/depend/AudioPlayerApi.dll", audioApiPath);
                client.DownloadFile("https://github.com/chillguy-leo/MusicWarhead/releases/download/depend/System.Memory.dll", systemMemoryPath);
                client.DownloadFile("https://github.com/chillguy-leo/MusicWarhead/releases/download/depend/NVorbis.dll", nVorbisPath);
                Log.Warn("[MusicWarhead Dependency Installer] Success");
                client.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error($"[MusicWarhead Dependency Installer] Error - {ex.Message}");
                client.Dispose();
                return false;
            }
        }
    }
}