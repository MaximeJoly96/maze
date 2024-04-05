using System.Collections.Generic;
using System;
using System.Linq;

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
        public LevelData Generate(int rows, int cols)
        {
            _maze = CreateDefaultMaze(rows, cols);

            // Choose the initial cell, mark it as visited and push it to the stack
            Cell start = PickRandomCell(_maze);
            _currentStack.Push(start);

            while(_currentStack.Count > 0)
            {
                Cell current = _currentStack.Peek();
                current.Visited = true;

                List<Cell> nonVisitedNeighours = GetNonVisitedNeighbours(_maze, current);
                if (nonVisitedNeighours.Count > 0)
                {
                    _currentStack.Push(current);
                    Cell randomNeighbour = nonVisitedNeighours[_rng.Next(nonVisitedNeighours.Count)];
                    Direction direction = GetDirection(current, randomNeighbour);

                    switch (direction)
                    {
                        case Direction.Left:
                            randomNeighbour.Walls.FirstOrDefault(w => w.Dir == Direction.Right).Enabled = false;
                            current.Walls.FirstOrDefault(w => w.Dir == Direction.Left).Enabled = false;
                            break;
                        case Direction.Right:
                            randomNeighbour.Walls.FirstOrDefault(w => w.Dir == Direction.Left).Enabled = false;
                            current.Walls.FirstOrDefault(w => w.Dir == Direction.Right).Enabled = false;
                            break;
                        case Direction.Top:
                            randomNeighbour.Walls.FirstOrDefault(w => w.Dir == Direction.Bottom).Enabled = false;
                            current.Walls.FirstOrDefault(w => w.Dir == Direction.Top).Enabled = false;
                            break;
                        case Direction.Bottom:
                            randomNeighbour.Walls.FirstOrDefault(w => w.Dir == Direction.Top).Enabled = false;
                            current.Walls.FirstOrDefault(w => w.Dir == Direction.Bottom).Enabled = false;
                            break;
                        case Direction.Undefined:
                            break;
                    }

                    _currentStack.Push(randomNeighbour);
                }
                else
                    _currentStack.Pop();
            }

            return DefineEntranceAndExit();
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

        private Direction GetDirection(Cell current, Cell destination)
        {
            if (current.X < destination.X)
                return Direction.Bottom;

            if (current.X > destination.X)
                return Direction.Top;

            if (current.Y < destination.Y)
                return Direction.Right;

            if (current.Y > destination.Y)
                return Direction.Left;

            return Direction.Undefined;
        }

        private LevelData DefineEntranceAndExit()
        {
            int randomSide = _rng.Next(0, 4);
            Direction randomDirection = (Direction)randomSide;
            Direction oppositeDirection = Direction.Undefined;

            switch(randomDirection)
            {
                case Direction.Bottom:
                    oppositeDirection = Direction.Top;
                    break;
                case Direction.Top:
                    oppositeDirection = Direction.Bottom;
                    break;
                case Direction.Left:
                    oppositeDirection = Direction.Right;
                    break;
                case Direction.Right:
                    oppositeDirection = Direction.Left;
                    break;
            }

            return MarkEntranceAndExit(_maze, randomDirection, oppositeDirection);
        }

        private LevelData MarkEntranceAndExit(Cell[,] maze, Direction startSide, Direction exitSide)
        {
            int xEntrance = 0;
            int xExit = 0;

            int yEntrance = 0;
            int yExit = 0;

            switch(startSide)
            {
                case Direction.Left:
                    xEntrance = _rng.Next(_maze.GetLength(0));
                    xExit = _rng.Next(_maze.GetLength(0));
                    yEntrance = 0;
                    yExit = _maze.GetLength(1) - 1;
                    break;
                case Direction.Right:
                    xEntrance = _rng.Next(_maze.GetLength(0));
                    xExit = _rng.Next(_maze.GetLength(0));
                    yEntrance = _maze.GetLength(1) - 1;
                    yExit = 0;
                    break;
                case Direction.Bottom:
                    xEntrance = 0;
                    xExit = _maze.GetLength(1) - 1;
                    yEntrance = _rng.Next(_maze.GetLength(1));
                    yExit = _rng.Next(_maze.GetLength(1));
                    break;
                case Direction.Top:
                    xEntrance = _maze.GetLength(1) - 1;
                    xExit = 0;
                    yEntrance = _rng.Next(_maze.GetLength(1));
                    yExit = _rng.Next(_maze.GetLength(1));
                    break;
            }

            _maze[xEntrance, yEntrance].Role = CellRole.Start;
            _maze[xExit, yExit].Role = CellRole.Exit;

            return new LevelData { MazeData = maze, StartCell = _maze[xEntrance, yEntrance], EndCell = _maze[xExit, yExit] };
        }
        #endregion
    }
}
