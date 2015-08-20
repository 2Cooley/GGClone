using UnityEngine;
using System.Collections;

namespace Gameplay
{
    public class Zone : MonoBehaviour
    {
        public ZonesEvents zEvents;
        public ZoneType Type;

        void Awake()
        {
            zEvents = new ZonesEvents(this);
            Managers.ZoneManager.RegisterZone(this);
        }

        void OnDestroy()
        {
            zEvents.DestroyZone();
            Managers.ZoneManager.RemoveZone(this);
        }

        void OnTriggerEnter(Collider other)
        {
            ActorComponent actor = other.gameObject.GetComponent<ActorComponent>();
            zEvents.ZoneEntered(actor.Type, actor.gameObject);
        }

        void OnTriggerExit(Collider other)
        {
            ActorComponent actor = other.gameObject.GetComponent<ActorComponent>();
            zEvents.ZoneExited(actor.Type, actor.gameObject);
        }
    } 
}
