using UnityEngine;
using System.Collections;

namespace Gameplay
{
    public class EndZoneHandler : IZoneHandler
    {
        protected Zone Zone  { get; set; }

        ~EndZoneHandler()
        {
            Managers.ZoneManager.RemoveHandler(this);
        }

        internal EndZoneHandler(Zone zone)
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
            else if (e.EventType == ZoneEventTypes.ActorExit) mes = " exited ";
            else if (e.EventType == ZoneEventTypes.ActorEnter)
            {
                mes = " entered ";
                PlayerEnter(e.ActorRef.GetComponent<ActorComponent>());
            }
            Debug.Log(e.ActorRef.name + mes + "End Zone: " + this.Zone.name);
        }

        private void PlayerEnter(ActorComponent player)
        {
            Managers.PlayerStatusManager.PlayerExitedLevel(player);
        }
    } 
}
