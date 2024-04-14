using UnityEngine;
using maze_game.DataManagement;
using System.Collections.Generic;
using maze_game.Models;

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
            //LoadLevel();
            InstantiatePlayer(_mazeBuilder.MazeData.StartCell);
        }
        #endregion

        #region Methods
        private void InstantiatePlayer(Cell startCell)
        {
            _playerControllerInstance = Instantiate(_playerController, new Vector3(startCell.Y + 0.5f, startCell.X + 0.5f), Quaternion.identity);
        }

        private void CreateLevel()
        {
            int rows = 100;
            int cols = 100;

            if (_mazeBuilder != null)
                _mazeBuilder.BuildMaze(rows, cols);

            _camera.transform.Translate(new Vector3(rows / 2, cols / 2));
        }

        private void LoadLevel()
        {
            LevelDataLoader loader = new LevelDataLoader();
            List<LevelData> levels = loader.LoadLevels(Application.persistentDataPath + "/Saves/save.mz");

            _mazeBuilder.BuildMaze(levels[1]);
        }
        #endregion
    }
}
