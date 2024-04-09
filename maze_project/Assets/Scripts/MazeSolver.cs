using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    public class MazeSolver
    {
        private Random _rng;

        #region ctor
        public MazeSolver()
        {
            _rng = new Random();
        }
        #endregion

        #region Methods
        public List<Cell> SolveMaze(Cell[,] maze, Cell startCell, Cell endCell)
        {
            Cell[,] copy = CopyMaze(maze);
            Stack<Cell> stack = new Stack<Cell>();

            Cell currentPosition = copy[startCell.X, startCell.Y];
            currentPosition.Visited = true; // the cell was visited
            stack.Push(currentPosition);

            while(currentPosition.X != endCell.X || currentPosition.Y != endCell.Y)
            {
                List<Cell> adjacentCells = GetAdjacentCellsNotVisited(copy, currentPosition);
                if(adjacentCells.Count > 0)
                {
                    Cell randomAdjacentCell = adjacentCells[_rng.Next(adjacentCells.Count)];
                    randomAdjacentCell.Visited = true;
                    stack.Push(randomAdjacentCell);
                    currentPosition = randomAdjacentCell;
                }
                else
                {
                    stack.Pop();
                    currentPosition = stack.Peek();
                }
            }

            return stack.Reverse().ToList();
        }

        private Cell[,] CopyMaze(Cell[,] original)
        {
            Cell[,] copy = new Cell[original.GetLength(0), original.GetLength(1)];

            for(int i = 0; i < copy.GetLength(0); i++)
            {
                for(int j = 0; j < copy.GetLength(1); j++)
                {
                    copy[i, j] = original[i, j].Copy(); // Deep copy to prevent sharing references
                }
            }

            return copy;
        }

        private List<Cell> GetAdjacentCellsNotVisited(Cell[,] maze, Cell cell)
        {
            List<Cell> adjacentCells = new List<Cell>();

            for(int i = 0; i < cell.Walls.Length; i++)
            {
                if(!cell.Walls[i].Enabled)
                {
                    switch(cell.Walls[i].Dir)
                    {
                        case Direction.Left:
                            if (cell.Y > 0 && !maze[cell.X, cell.Y - 1].Visited)
                                adjacentCells.Add(maze[cell.X, cell.Y - 1]);
                            break;
                        case Direction.Right:
                            if (cell.Y < maze.GetLength(1) - 1 && !maze[cell.X, cell.Y + 1].Visited)
                                adjacentCells.Add(maze[cell.X, cell.Y + 1]);
                            break;
                        case Direction.Top:
                            if (cell.X > 0 && !maze[cell.X - 1, cell.Y].Visited)
                                adjacentCells.Add(maze[cell.X - 1, cell.Y]);
                            break;
                        case Direction.Bottom:
                            if (cell.X < maze.GetLength(0) - 1 && !maze[cell.X + 1, cell.Y].Visited)
                                adjacentCells.Add(maze[cell.X + 1, cell.Y]);
                            break;
                    }
                }
            }

            return adjacentCells;
        }
        #endregion
    }
}
