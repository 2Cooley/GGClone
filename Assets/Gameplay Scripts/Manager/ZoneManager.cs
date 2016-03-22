using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gameplay;

namespace Managers
{
    public class ZoneManager
    {
        #region Singleton
        internal static ZoneManager Instance
        {
            get
            {
                if (instance == null) instance = new ZoneManager();
                return instance;
            }
            private set { }
        }
        private static ZoneManager instance; 
        #endregion

        protected List<Zone> ZonesInLevel;
        protected List<IZoneHandler> Handlers;

        private ZoneManager() { InitializeZones(); }

        internal void InitializeZones()
        {
            ZonesInLevel = new List<Zone>();
            Handlers = new List<IZoneHandler>();
        }

        internal static bool RegisterZone(Zone zone)
        {
            if(!Instance.ZonesInLevel.Contains(zone))
            {
                Instance.ZonesInLevel.Add(zone);
                Instance.Handlers.Add(MakeZoneHandler(zone));
                return true;
            }
            return false;
        }

        internal static IZoneHandler MakeZoneHandler(Zone zone)
        {
            switch (zone.Type)
            {
                case ZoneType.Start:
                    return new StartZoneHandler(zone);
                case ZoneType.Goal:
                    return new EndZoneHandler(zone);
                case ZoneType.FriendlyPickup:
                    return new PickupZoneHandler(zone);
                default:
                    return null;
            }
        }

        internal static void RemoveZone(Zone zone)
        {
            Instance.ZonesInLevel.Remove(zone);
        }

        internal static void RemoveHandler(IZoneHandler handler)
        {
            Instance.Handlers.Remove(handler);
        }
    }
}