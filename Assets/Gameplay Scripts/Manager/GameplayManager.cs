using UnityEngine;
using System.Collections;

namespace Managers
{
    public class GameplayManager
    {
        #region Singleton
        internal static GameplayManager Instance
        {
            get
            {
                if (instance == null) instance = new GameplayManager();
                return instance;
            }
            private set { }
        }
        private static GameplayManager instance;
        #endregion

        public enum EndCondition
        {
            AllPlayersExited,
            AllEnemiesKilled,
            ForceLevelWin,
            TimeUp,
            AllPlayersKilled,
            Quit
        }

        public enum GmState
        {
            MainMenu,
            PreGame,
            Playing,
            Paused,
            PostGame
        }
        internal GmState GameState;

        internal GameplayManager() { GameState = GmState.Playing; }

        internal static void ConditionMet(EndCondition condition)
        {
            switch (condition)
            {
                case EndCondition.AllPlayersExited:
                    ChangeGameState(GmState.PostGame);
                    break;
                case EndCondition.AllEnemiesKilled:
                    break;
                case EndCondition.ForceLevelWin:
                    break;
                case EndCondition.TimeUp:
                    break;
                case EndCondition.AllPlayersKilled:
                    break;
                case EndCondition.Quit:
                    break;
                default:
                    break;
            }
        }

        private static void ChangeGameState(GmState newState)
        {
            if (Instance.GameState == GmState.Playing && newState == GmState.PostGame) WinLevel();
        }

        private static void WinLevel()
        {
            Debug.Log("You Win!");
        }
    }
}
