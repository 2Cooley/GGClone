using UnityEngine;
using System.Collections;

namespace Gameplay
{
    public class PickupZoneHandler : IZoneHandler
    {
        protected Zone Zone { get; set; }
        private PickupZone PZone { get { return (PickupZone)(this.Zone); } set { } }

        ~PickupZoneHandler()
        {
            Managers.ZoneManager.RemoveHandler(this);
        }

        internal PickupZoneHandler(Zone zone)
        {
            this.Zone = zone;
            this.Zone.zEvents.Changed += ZoneStateChange;
        }

        public void ZoneStateChange(object sender, Gameplay.ZoneEventArgs e)
        {
            if (e.EventType == ZoneEventTypes.ActorEnter
                && e.ActorType == ActorType.Player)
            {
                PZone.AttachedRef.GetComponent<EnemyMovement>().ActivateMovement();
                Object.Destroy(this.Zone.gameObject);
            }
        }
    } 
}
