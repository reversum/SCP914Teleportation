using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp914;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SCP914Teleportation
{
    public class EventHandler
    {
        private readonly Main plugin;

        public EventHandler(Main plugin)
        {
            this.plugin = plugin;
        }

        internal void OnScp914UpgradingPlayer(UpgradingPlayerEventArgs e)
        {
            if (plugin.Config.ButtonSettings[e.KnobSetting])
            {

                if (plugin.Config.OnlyTeleportWhenNoItem && e.Player.CurrentItem != null) return;

                Timing.CallDelayed(plugin.Config.Delayed, () =>
                {
                    Room randRoom = Room.List.Where(x => x.Zone != ZoneType.Surface && x.Type != RoomType.EzCollapsedTunnel && x.Type != RoomType.HczTestRoom).ToList().ElementAt(new System.Random().Next(0, Room.List.Count()));
                    e.Player.Position = randRoom.Position + Vector3.up;

                    if (plugin.Config.Blinded)
                    {
                        e.Player.EnableEffect(EffectType.Blinded, plugin.Config.EffectDuration);
                        e.Player.EnableEffect(EffectType.Concussed, plugin.Config.EffectDuration);
                    }
                });
            }
        }
    }
}
