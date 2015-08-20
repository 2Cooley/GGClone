using UnityEngine;
using Gameplay;
using System.Collections;
using System.Collections.Generic;

namespace Managers
{
    public class LevelManager
    {
        #region Singleton
        internal static LevelManager Instance
        {
            get
            {
                if (instance == null) instance = new LevelManager();
                return instance;
            }
            private set { }
        }
        private static LevelManager instance;
        #endregion

        internal ZoneManager ZoneMan = ZoneManager.Instance;

    }
}