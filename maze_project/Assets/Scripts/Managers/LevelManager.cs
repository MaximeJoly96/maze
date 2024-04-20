using maze_game.Engine;
using maze_game.Models;
using UnityEngine;

namespace maze_game.Managers
{
    public class LevelManager : BaseManager
    {
        #region Private members
        private MazeBuilder _mazeBuilder;
        private MazeRenderer _mazeRenderer;

        [SerializeField]
        private GameObject _baseWall;
        [SerializeField]
        private PlayerController _playerController;
        #endregion

        #region Methods
        public override void Init()
        {
            _mazeBuilder = new MazeBuilder();
            _mazeRenderer = new MazeRenderer();
            CurrentState = State.Initialized;
        }

        public void CreateLevel(int rows, int cols)
        {
            _mazeBuilder.BuildMaze(rows, cols);
            _mazeRenderer.DrawMaze(_mazeBuilder.MazeData.MazeData, _baseWall);

            InstantiatePlayer(_playerController, _mazeBuilder.MazeData.StartCell);
        }

        private void InstantiatePlayer(PlayerController playerController, Cell startCell)
        {
            Instantiate(playerController, new Vector2(startCell.Y + 0.5f, startCell.X + 0.5f), Quaternion.identity);
        }
        #endregion
    }
}
