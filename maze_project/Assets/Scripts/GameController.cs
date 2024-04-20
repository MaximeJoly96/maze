using UnityEngine;
using maze_game.Managers;

namespace maze_game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private EnvironmentManager _environmentManager;
        [SerializeField]
        private LevelManager _levelManager;

        [SerializeField]
        private int _rows;
        [SerializeField]
        private int _cols;

        #region Unity Methods
        private void Awake()
        {
            Init();
            CreateLevel();
        }
        #endregion

        #region Methods
        private void Init()
        {
            _levelManager.Init();
            _environmentManager.Init();
        }

        private void CreateLevel()
        {
            _levelManager.CreateLevel(_rows, _cols);
            _environmentManager.CenterMazeOnCamera(_rows, _cols);
        }
        #endregion
    }
}
