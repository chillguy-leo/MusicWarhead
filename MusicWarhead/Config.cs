using System.ComponentModel;
using Exiled.API.Interfaces;

namespace MusicWarhead
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Where is the audio?")]
        public string AudioLocation { get; set; } = "";

        [Description("How loud is the audio?")]
        public float AudioVolume { get; set; } = 1.1f;

        [Description("Should the audio stop after it ends or keep looping?")]
        public bool StopAfterEnd { get; set; } = true;

        [Description("Should debug messages be printed in console?")]
        public bool Debug { get; set; } = false;
    }
}
