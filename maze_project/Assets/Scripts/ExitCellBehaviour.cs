using UnityEngine;
using UnityEngine.SceneManagement;

namespace maze_game
{
    public class ExitCellBehaviour : CellBehaviour
    {
        #region Unity Methods
        protected override void OnTriggerEnter2D(Collider2D collider)
        {
            SceneManager.LoadScene("Main");
        }
        #endregion
    }
}
