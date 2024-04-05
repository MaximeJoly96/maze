using System;
using UnityEngine;

namespace maze_game
{
    public class MazeBuilder : MonoBehaviour
    {
        private MazeGenerator _mazeGenerator;
        private MazeRenderer _mazeRenderer;

        [SerializeField]
        private CellBehaviour _startCell;
        [SerializeField]
        private CellBehaviour _exitCell;

        public LevelData MazeData { get; private set; }

        public void BuildMaze(int rows, int cols)
        {
            if (rows <= 1)
                throw new ArgumentException("Provided row count cannot be less than 2.");

            if (cols <= 1)
                throw new ArgumentException("Provided col count cannot be less than 2.");

            _mazeGenerator = new MazeGenerator();
            _mazeRenderer = new MazeRenderer();

            MazeData = _mazeGenerator.Generate(rows, cols);

            _mazeRenderer.DrawMaze(MazeData.MazeData);
            PlaceStartAndExit(MazeData);
        }

        public void PlaceStartAndExit(LevelData maze)
        {
            Vector2 startPos = new Vector2(maze.StartCell.Y + 0.5f, maze.StartCell.X + 0.5f);
            Vector2 endPos = new Vector2(maze.EndCell.Y + 0.5f, maze.EndCell.X + 0.5f);

            Instantiate(_startCell, startPos, Quaternion.identity);
            Instantiate(_exitCell, endPos, Quaternion.identity);
        }
    }
}
