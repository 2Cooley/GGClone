using UnityEngine;
using System.Collections;
using Combat;

namespace Stats
{
    public struct PowerStats
    {
        public string PowerName;
        public Powers PowerType;
        public int Cooldown;
        public int Range;
        public int Damage;
        public int NoiseLevel;
        public int BaseNumUses;

        public PowerStats(string name, Powers type, int cooldown, int range, int dam, int noise, int baseNum)
        {
            PowerName = name; Cooldown = cooldown; Range = range; Damage = dam; NoiseLevel = noise; BaseNumUses = baseNum; PowerType = type;
            if (PowerName == null) PowerName = PowerType.ToString();
        }
    } 
}
