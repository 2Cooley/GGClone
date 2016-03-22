using System;

namespace Gameplay
{
    // A delegate type for hooking up change notifications.
    public delegate void ChangedZoneHandler(object sender, ZoneEventArgs e);

    public class ZoneEventArgs : EventArgs
    {
        public ZoneEventTypes EventType;
        public ActorType ActorType;
        public UnityEngine.GameObject ActorRef;

        #region Constructors
        public ZoneEventArgs(ZoneEventTypes type, ActorType actor, UnityEngine.GameObject aRef)
        { 
            EventType = type; ActorType = actor; ActorRef = aRef; 
        }
        public ZoneEventArgs(ZoneEventTypes type)
        { 
            EventType = type;
        } 
        #endregion
    }

    public class ZonesEvents
    {
        // An event that clients can use to be notified whenever the
        // handler changes
        public event ChangedZoneHandler Changed;
        public Zone Parent;

        public ZonesEvents(Zone parent) { Parent = parent; }

        // Invoke the Changed event;
        protected virtual void OnChanged(ZoneEventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
            if (e.EventType == ZoneEventTypes.ZoneReset) Changed = null;
        }

        internal virtual void ZoneEntered(ActorType type, UnityEngine.GameObject actorRef)
        {
            OnChanged(new ZoneEventArgs(ZoneEventTypes.ActorEnter, type, actorRef));
        }

        internal virtual void ZoneExited(ActorType type, UnityEngine.GameObject actorRef)
        {
            OnChanged(new ZoneEventArgs(ZoneEventTypes.ActorExit, type, actorRef));
        }

        internal virtual void ResetZone()
        {
            OnChanged(new ZoneEventArgs(ZoneEventTypes.ZoneReset));
        }

        internal virtual void DestroyZone()
        {
            OnChanged(new ZoneEventArgs(ZoneEventTypes.OnDestroy));
        }
    }
    
}