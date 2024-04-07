using UnityEngine;
using UnityEngine.SceneManagement;

namespace maze_game
{
    public class ExitCellBehaviour : CellBehaviour
    {
        #region Unity Methods
        protected override void OnTriggerEnter(Collider collider)
        {
            SceneManager.LoadScene("Main");
        }
        #endregion
    }
}
