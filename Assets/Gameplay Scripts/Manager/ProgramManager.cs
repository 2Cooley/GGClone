using UnityEngine;
using System.Collections;

namespace Managers
{
    public class ProgramManager : MonoBehaviour
    {
        #region Singleton
        internal static ProgramManager Instance
        {
            get
            {
                if (instance == null) instance = new ProgramManager();
                return instance;
            }
            private set { }
        }
        private static ProgramManager instance;
        #endregion

        #region ClassVariables
        protected GameplayManager GameManager;
        protected LevelManager LevelManager;
        #endregion

        void Awake()
        {
            InitializeGame();
        }

        void Update()
        {

        }

        protected virtual void InitializeGame()
        {
            GameManager = new GameplayManager();
            this.LevelManager = new LevelManager();
        }


    } 
}
