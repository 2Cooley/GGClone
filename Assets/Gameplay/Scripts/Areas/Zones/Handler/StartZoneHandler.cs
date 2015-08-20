using UnityEngine;
using System.Collections;

namespace Gameplay
{
    public class StartZoneHandler : IZoneHandler
    {
        protected Zone Zone { get; set; }

        ~StartZoneHandler()
        {
            Managers.ZoneManager.RemoveHandler(this);
        }

        internal StartZoneHandler(Zone zone)
        {
            this.Zone = zone;
            this.Zone.zEvents.Changed += ZoneStateChange;
        }

        public void ZoneStateChange(object sender, Gameplay.ZoneEventArgs e)
        {
            string mes = " undefined ";
            ZoneEventTypes type = e.EventType;
            if (type == ZoneEventTypes.OnDestroy || type == ZoneEventTypes.ZoneReset)
            {
                mes = (type == ZoneEventTypes.OnDestroy) ? " destroyed" : " reset";
                Debug.Log("Zone" + mes);
                return;
            }
            else if (e.EventType == ZoneEventTypes.ActorEnter) mes = " entered ";
            else if (e.EventType == ZoneEventTypes.ActorExit) mes = " exited ";
            Debug.Log(e.ActorRef.name + mes + "Start Zone: " + this.Zone.name);
        }
    }
}