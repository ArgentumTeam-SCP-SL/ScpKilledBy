using System;
using LabApi.Events.Handlers;
using LabApi.Features;
using LabApi.Features.Console;
using LabApi.Features.Wrappers;
using LabApi.Loader.Features.Plugins;
using PlayerRoles;

namespace ScpKilledBy
{
    public class Main : Plugin<Config>
    {
        public override void Enable()
        {
            PlayerEvents.Dying += OnDying;
        }

        public override void Disable()
        {
            PlayerEvents.Dying -= OnDying;
        }

        private void OnDying(LabApi.Events.Arguments.PlayerEvents.PlayerDyingEventArgs ev)
        {
            if (ev.Player.Team != Team.SCPs)
                return;
            
            if (ev.Player.Role == RoleTypeId.Scp0492)
                return;
            
            string Text;
            ushort Time;
            
            if (ev.Attacker == null || ev.Attacker == ev.Player)
            {
                Text = Config.selfDestructed
                    .Replace("{Scp}", ev.Player.Role.ToString());
                Time = Config.selfDestructedTime;
            }
            else
            {
                Text = Config.DestructedByPlayer
                    .Replace("{Scp}", ev.Player.Role.ToString())
                    .Replace("{Attacker}", ev.Attacker.Nickname);
                Time = Config.DestructedByPlayerTime;
            }
            foreach (var p in Player.List)
            {
                Logger.Info($"SendBroadcast to {p.Nickname}");
                p.SendBroadcast(Text, Time);
            }
        }

        public override string Name { get; } = "ScpKilledBy";
        public override string Description { get; } = "ScpKilledBy";
        public override string Author { get; } = "AgTeam";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredApiVersion { get; } = LabApiProperties.CurrentVersion;
    }
}