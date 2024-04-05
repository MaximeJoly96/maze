using UnityEngine;

namespace maze_game
{
    public class GameController : MonoBehaviour
    {
        private PlayerController _playerControllerInstance;

        [SerializeField]
        private PlayerController _playerController;
        [SerializeField]
        private MazeBuilder _mazeBuilder;
        [SerializeField]
        private Camera _camera;


        #region Unity Methods
        private void Awake()
        {
            CreateLevel();
            InstantiatePlayer(new Vector2(0.5f, 0.5f));
        }
        #endregion

        #region Methods
        private void InstantiatePlayer(Vector2 startPosition)
        {
            _playerControllerInstance = Instantiate(_playerController, startPosition, Quaternion.identity);
        }

        private void CreateLevel()
        {
            int rows = 10;
            int cols = 10;

            if (_mazeBuilder != null)
                _mazeBuilder.BuildMaze(rows, cols);

            _camera.transform.Translate(new Vector3(rows / 2, cols / 2));
        }
        #endregion
    }
}
