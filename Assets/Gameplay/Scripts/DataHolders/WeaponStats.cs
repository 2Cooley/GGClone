using UnityEngine;
using System.Collections;

namespace Stats
{
    public struct WeaponStats
    {
        public string WeaponName;
        public int FireRate;
        public int Range;
        public int ProjectileDamage;
        public int NoiseLevel;

        public WeaponStats(string name, int fireRate, int range, int damage, int noise)
        {
            WeaponName = name; FireRate = fireRate; Range = range; ProjectileDamage = damage; NoiseLevel = noise;
            if (WeaponName == null) WeaponName = "Default";
        }
    } 
}
