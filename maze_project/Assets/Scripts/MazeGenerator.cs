using System.Collections.Generic;
using System;

namespace maze_game
{
    public class MazeGenerator
    {
        private Stack<Cell> _currentStack;
        private Random _rng;

        private Cell[,] _maze;

        public MazeGenerator()
        {
            _currentStack = new Stack<Cell>();
            _rng = new Random();
        }

        #region Methods
        // Based on https://en.wikipedia.org/wiki/Maze_generation_algorithm
        public void Generate(int rows, int cols)
        {
            _maze = CreateDefaultMaze(rows, cols);

            // Choose the initial cell, mark it as visited and push it to the stack
            Cell start = PickRandomCell(_maze);
            _currentStack.Push(start);

            while(_currentStack.Count > 0)
            {
                Cell current = _currentStack.Pop();
                current.Visited = true;

                List<Cell> nonVisitedNeighours = GetNonVisitedNeighbours(_maze, current);
            }
        }

        private Cell PickRandomCell(Cell[,] maze)
        {
            return maze[_rng.Next(0, maze.GetLength(0)), _rng.Next(0, maze.GetLength(1))];
        }

        private Cell[,] CreateDefaultMaze(int rows, int cols)
        {
            Cell[,] maze = new Cell[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    maze[i, j] = new Cell(i, j);

            return maze;
        }

        private List<Cell> GetNonVisitedNeighbours(Cell[,] maze, Cell currentCell)
        {
            List<Cell> neighbours = new List<Cell>();

            if(currentCell.X >= 0 && currentCell.X + 1 < maze.GetLength(0) && !maze[currentCell.X + 1, currentCell.Y].Visited)
            {
                neighbours.Add(maze[currentCell.X + 1, currentCell.Y]);
            }

            if(currentCell.X - 1 >= 0 && !maze[currentCell.X - 1, currentCell.Y].Visited)
            {
                neighbours.Add(maze[currentCell.X - 1, currentCell.Y]);
            }

            if(currentCell.Y >= 0 && currentCell.Y + 1 < maze.GetLength(1) && !maze[currentCell.X, currentCell.Y + 1].Visited)
            {
                neighbours.Add(maze[currentCell.X, currentCell.Y + 1]);
            }

            if(currentCell.Y - 1 >= 0 && !maze[currentCell.X, currentCell.Y - 1].Visited)
            {
                neighbours.Add(maze[currentCell.X, currentCell.Y - 1]);
            }

            return neighbours;
        }
        #endregion
    }
}
