using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP914Teleportation
{
    public class Main : Plugin<Config>
    {
        public static Main Instance { get; set; }
        public override string Author => "Godfather Yannik";
        public override string Name => "SCP914Teleportation";
        public override string Prefix => "914TP";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 0, 0);
        private EventHandler EventHandlerManager { get; set; }

        public override void OnEnabled()
        {
            Instance = this;

            EventHandlerManager = new EventHandler(this);
            Exiled.Events.Handlers.Scp914.UpgradingPlayer += EventHandlerManager.OnScp914UpgradingPlayer;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Scp914.UpgradingPlayer -= EventHandlerManager.OnScp914UpgradingPlayer;
            EventHandlerManager = null;

            base.OnDisabled();
        }
    }
}