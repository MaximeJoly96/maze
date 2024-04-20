using UnityEngine;

namespace maze_game.Managers
{
    public abstract class BaseManager : MonoBehaviour
    {
        #region Enums
        public enum State { NotInitialized, Initialized }
        #endregion

        #region Properties
        public State CurrentState { get; set; }
        #endregion

        #region Methods
        public abstract void Init();
        #endregion
    }
}
