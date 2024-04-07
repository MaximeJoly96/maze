using UnityEngine;

namespace maze_game
{
    public abstract class CellBehaviour : MonoBehaviour
    {
        #region Unity Methods
        protected abstract void OnTriggerEnter(Collider collider);
        #endregion
    }
}
