using UnityEngine;
using System.Collections;

namespace Stats
{
    public struct EquipmentStats
    {
        public WeaponStats MainWeaponStats;
        public PowerStats Power1Stats;
        public PowerStats Power2Stats;

        public EquipmentStats(WeaponStats mainWeapon, PowerStats pow1, PowerStats pow2)
        {
            MainWeaponStats = mainWeapon; Power1Stats = pow1; Power2Stats = pow2;
        }
    } 
}
