using UnityEngine;

namespace maze_game
{
    public abstract class CellBehaviour : MonoBehaviour
    {
        #region Unity Methods
        protected abstract void OnTriggerEnter2D(Collider2D collider);
        #endregion
    }
}
