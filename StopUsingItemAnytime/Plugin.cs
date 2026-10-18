using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace StopUseItemAnytime
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "StopUseItemAnytime";
        public override string Author => "Naleśnior";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 9, 11);

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.UsingItem += OnUsingItem;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.UsingItem -= OnUsingItem;
            base.OnDisabled();
        }

        private void OnUsingItem(UsingItemEventArgs ev)
        {
            ev.Usable.MaxCancellableTime = ev.Usable.UseTime;
        }
    }
}
