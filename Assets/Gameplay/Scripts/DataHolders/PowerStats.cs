using UnityEngine;
using System.Collections;

namespace Stats
{
    public struct PowerStats
    {
        public string PowerName;
        public int Cooldown;
        public int Range;
        public int Damage;
        public int NoiseLevel;
        public int BaseNumUses;

        public PowerStats(string name, int cooldown, int range, int dam, int noise, int baseNum)
        {
            PowerName = name; Cooldown = cooldown; Range = range; Damage = dam; NoiseLevel = noise; BaseNumUses = baseNum;
            if (PowerName == null) PowerName = "Default";
        }
    } 
}
