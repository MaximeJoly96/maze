using UnityEngine;

namespace maze_game
{
    public class StartCellBehaviour : CellBehaviour
    {
        #region Unity Methods
        protected override void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("Hit start");
        }
        #endregion
    }
}
