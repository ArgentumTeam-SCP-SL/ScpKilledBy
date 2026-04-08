using System;
using LabApi.Events.Handlers;
using LabApi.Features;
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
            if (ev.Player.Team != Team.SCPs || ev.Player.Role == RoleTypeId.Scp0492)
                return;
            
            string text;
            ushort time;
            
            if (ev.Attacker == null || ev.Attacker == ev.Player)
            {
                text = Config.SelfDestructed
                    .Replace("%Scp%", ev.Player.Role.ToString());
                time = Config.SelfDestructedTime;
            }
            else
            {
                text = Config.DestructedByPlayer
                    .Replace("%Scp%", ev.Player.Role.ToString())
                    .Replace("%Attacker%", ev.Attacker.Nickname);
                time = Config.DestructedByPlayerTime;
            }
            foreach (var p in Player.List)
            {
                p.SendBroadcast(text, time);
            }
        }

        public override string Name { get; } = "ScpKilledBy";
        public override string Description { get; } = "ScpKilledBy";
        public override string Author { get; } = "AgTeam";
        public override Version Version { get; } = new Version(1, 0, 1);
        public override Version RequiredApiVersion { get; } = LabApiProperties.CurrentVersion;
    }
}