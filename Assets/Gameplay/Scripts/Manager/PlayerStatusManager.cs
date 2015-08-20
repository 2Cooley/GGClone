using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Stats;

namespace Managers
{
	public class PlayerStatusManager{

        #region Singleton
        internal static PlayerStatusManager Instance
        {
            get
            {
                if (instance == null) instance = new PlayerStatusManager();
                return instance;
            }
            private set { }
        }
        private static PlayerStatusManager instance;
        #endregion

        protected struct PlayerStats { 
            public CharStats Info; 
            public float CurrentHealth;
            public bool Controlled;
            public bool Spotted;
            public bool Engaged;
            public bool CapturedOrInjured;

            public PlayerStats(CharStats info)
            {
                Info = info; CurrentHealth = Info.Health; Controlled = false; Spotted = false; Engaged = false; CapturedOrInjured = false;
            }
        }

        protected List<CharStats> CharsInReserve;
        protected Dictionary<GameObject, PlayerStats> CharsOnLevel;

        internal static void PlayerExitedLevel(ActorComponent player)
        {
            GameplayManager.ConditionMet(GameplayManager.EndCondition.AllPlayersExited);
        }
    }
 
}