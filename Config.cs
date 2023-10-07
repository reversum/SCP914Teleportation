using Exiled.API.Enums;
using Exiled.API.Interfaces;
using Scp914;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP914Teleportation
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not debug messages should be shown.")]
        public bool Debug { get; set; } = false;

        [Description("Should the player only be teleported when he has no item in his hand?")]
        public bool OnlyTeleportWhenNoItem { get; set; } = true;

        [Description("At which button setting should the teleportation happen")]
        public Dictionary<Scp914KnobSetting, bool> ButtonSettings { get; private set; } = new Dictionary<Scp914KnobSetting, bool>()
        {
            { Scp914KnobSetting.Rough, false },
            { Scp914KnobSetting.Coarse, true },
            { Scp914KnobSetting.OneToOne, false },
            { Scp914KnobSetting.Fine, false },
            { Scp914KnobSetting.VeryFine, false },
        };

        [Description("Set the time after many seconds the teleportation should take place.")]
        public float Delayed { get; set; } = 0.5f;

        [Description("Should the player be blined after teleportation?")]
        public bool Blinded { get; set; } = true;

        [Description("Set the effect duration")]
        public float EffectDuration { get; set; } = 1.5f;
    }
}
