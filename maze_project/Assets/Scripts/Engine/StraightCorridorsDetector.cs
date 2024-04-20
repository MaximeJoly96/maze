using System.Collections.Generic;
using System.Linq;
using maze_game.Models;

namespace maze_game.Engine
{
    public class StraightCorridorsDetector
    {
        private List<Cell> _towardsLeft;
        private List<Cell> _towardsRight;
        private List<Cell> _towardsTop;
        private List<Cell> _towardsBottom;

        /// <summary>
        /// Provides a list of corridors within a maze of a minimum length
        /// </summary>
        /// <param name="length">Minimum length of the corridor</param>
        /// <returns>The list of corridors that meet the required length</returns>
        public List<StraightCorridor> DetectCorridorsOfGivenLength(int length, LevelData mazeData)
        {
            List<StraightCorridor> corridors = new List<StraightCorridor>();

            // we need to take the maze and review each cell one by one
            // for each cell, we go in a specific direction until we reach a wall
            // at this point we measure the distance travelled between the initial cell and the wall
            // if that distance is equal or greater than the required length, we can create a corridor and add it to the list.

            for(int i = 0; i < mazeData.MazeData.GetLength(0); i++)
            {
                for(int j = 0; j < mazeData.MazeData.GetLength(1); j++)
                {
                    InitDirectionalLists(mazeData.MazeData[i, j]);
                    MoveFromCellToADirection(i, j, Direction.Left, mazeData.MazeData);
                    MoveFromCellToADirection(i, j, Direction.Right, mazeData.MazeData);
                    MoveFromCellToADirection(i, j, Direction.Top, mazeData.MazeData);
                    MoveFromCellToADirection(i, j, Direction.Bottom, mazeData.MazeData);

                    StraightCorridor topCorridor = CreateCorridor(_towardsTop, length);
                    if (topCorridor != null)
                        corridors.Add(topCorridor);

                    StraightCorridor bottomCorridor = CreateCorridor(_towardsBottom, length);
                    if (bottomCorridor != null)
                        corridors.Add(bottomCorridor);

                    StraightCorridor leftCorridor = CreateCorridor(_towardsLeft, length);
                    if (leftCorridor != null)
                        corridors.Add(leftCorridor);

                    StraightCorridor rightCorridor = CreateCorridor(_towardsRight, length);
                    if (rightCorridor != null)
                        corridors.Add(rightCorridor);
                }
            }

            return corridors;
        }

        private void MoveFromCellToADirection(int i, int j, Direction direction, Cell[,] maze)
        {
            Cell cell = maze[i, j];
            // if we have no enabled wall in that direction, then we can proceed
            if(cell.Walls.FirstOrDefault(w => w.Dir == direction && !w.Enabled) != null)
            {
                switch(direction)
                {
                    case Direction.Bottom:
                        if (i < maze.GetLength(0) - 1)
                        {
                            _towardsBottom.Add(maze[i + 1, j]);
                            MoveFromCellToADirection(i + 1, j, Direction.Bottom, maze);
                        }  
                        break;
                    case Direction.Top:
                        if (i > maze.GetLength(0))
                        {
                            _towardsTop.Add(maze[i - 1, j]);
                            MoveFromCellToADirection(i - 1, j, Direction.Top, maze);
                        }
                        break;
                    case Direction.Left:
                        if (j > maze.GetLength(1))
                        {
                            _towardsLeft.Add(maze[i, j - 1]);
                            MoveFromCellToADirection(i, j - 1, Direction.Left, maze);
                        }
                        break;
                    case Direction.Right:
                        if (j < maze.GetLength(1) - 1)
                        {
                            _towardsRight.Add(maze[i, j + 1]);
                            MoveFromCellToADirection(i, j + 1, Direction.Right, maze);
                        } 
                        break;
                }
            }
        }

        private void InitDirectionalLists(Cell initialCell)
        {
            _towardsBottom = new List<Cell> { initialCell };
            _towardsLeft = new List<Cell> { initialCell };
            _towardsRight = new List<Cell> { initialCell };
            _towardsTop = new List<Cell> { initialCell };
        }

        private StraightCorridor CreateCorridor(List<Cell> cells, int minLength)
        {
            if(cells.Count >= minLength)
            {
                StraightCorridor corridor = new StraightCorridor(cells);
                return corridor;
            }

            return null;
        }
    }
}
