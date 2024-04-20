using System;
using maze_game.Models;

namespace maze_game.Engine
{
    public class MazeBuilder
    {
        private readonly MazeGenerator _mazeGenerator;
        private readonly MazeSolver _solver;

        public LevelData MazeData { get; private set; }

        public MazeBuilder()
        {
            _mazeGenerator = new MazeGenerator();
            _solver = new MazeSolver();
        }

        public void BuildMaze(int rows, int cols)
        {
            if (rows <= 1)
                throw new ArgumentException("Provided row count cannot be less than 2.");

            if (cols <= 1)
                throw new ArgumentException("Provided col count cannot be less than 2.");

            MazeData = _mazeGenerator.Generate(rows, cols);
            SolveMaze(MazeData);
        }

        public void SolveMaze(LevelData levelData)
        {
            _solver.SolveMaze(levelData.MazeData, levelData.StartCell, levelData.EndCell);
        }
    }
}
