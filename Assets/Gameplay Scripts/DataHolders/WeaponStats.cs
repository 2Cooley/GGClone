using UnityEngine;
using System.Collections;
using Combat;

namespace Stats
{
    public struct WeaponStats
    {
        public string WeaponName;
        public Weapons WeaponType;
        public float FireRate;
        public float Range;
        public ProjectileTypes ProjectileType;
        public int ProjectileDamage;
        public float ProjectileSpeed;
        public int NoiseLevel;

        public WeaponStats(string name, Weapons type, float fireRate, int range, ProjectileTypes projType, int damage, float projSpeed, int noise)
        {
            WeaponName = name; FireRate = fireRate; Range = range; ProjectileType = projType; ProjectileDamage = damage; NoiseLevel = noise;
            WeaponType = type; ProjectileSpeed = projSpeed;
            if (WeaponName == null) WeaponName = WeaponType.ToString();
        }
    } 
}
