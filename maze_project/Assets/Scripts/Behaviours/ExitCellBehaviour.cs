using UnityEngine;
using UnityEngine.SceneManagement;

namespace maze_game.Behaviours
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
