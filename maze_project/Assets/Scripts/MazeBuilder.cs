using System;
using UnityEngine;
using maze_game.DataManagement;
using maze_game.Engine;
using maze_game.Models;
using maze_game.Behaviours;

namespace maze_game
{
    public class MazeBuilder : MonoBehaviour
    {
        private MazeGenerator _mazeGenerator;
        private MazeRenderer _mazeRenderer;
        private LevelDataSaver _dataSaver;
        private MazeSolver _solver;
        private StraightCorridorsDetector _straightCorridorsDetector;

        [SerializeField]
        private CellBehaviour _startCell;
        [SerializeField]
        private CellBehaviour _exitCell;
        [SerializeField]
        private GameObject _baseWall;

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

            _mazeRenderer.DrawMaze(MazeData.MazeData, _baseWall);
            PlaceStartAndExit(MazeData);

            _dataSaver = new LevelDataSaver();
            _dataSaver.SaveLevel(MazeData);

            SolveMaze(MazeData);

            _straightCorridorsDetector = new StraightCorridorsDetector();
            _straightCorridorsDetector.DetectCorridorsOfGivenLength(5, MazeData);
        }

        public void BuildMaze(LevelData data)
        {
            _mazeRenderer = new MazeRenderer();
            _mazeRenderer.DrawMaze(data.MazeData, _baseWall);
            PlaceStartAndExit(data);
            SolveMaze(data);
        }

        public void PlaceStartAndExit(LevelData maze)
        {
            Vector2 startPos = new Vector2(maze.StartCell.Y + 0.5f, maze.StartCell.X + 0.5f);
            Vector2 endPos = new Vector2(maze.EndCell.Y + 0.5f, maze.EndCell.X + 0.5f);

            Instantiate(_startCell, startPos, Quaternion.identity);
            Instantiate(_exitCell, endPos, Quaternion.identity);
        }

        public void SolveMaze(LevelData levelData)
        {
            _solver = new MazeSolver();
            _solver.SolveMaze(levelData.MazeData, levelData.StartCell, levelData.EndCell);
        }
    }
}
