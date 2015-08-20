using UnityEngine;
using System.Collections;

namespace Stats
{
    public struct CharStats
    {
        public string CharacterName;
        public int Health;
        public int Speed;
        public EquipmentStats EquipmentLoadout;

        public CharStats(string name, int health, int speed, EquipmentStats loadout)
        {
            CharacterName = name; Health = health; Speed = speed; EquipmentLoadout = loadout;
            if (CharacterName == null) CharacterName = "Default";
        }
    } 
}
