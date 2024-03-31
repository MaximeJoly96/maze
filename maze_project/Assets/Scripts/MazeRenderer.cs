using UnityEngine;

namespace maze_game
{
    public class MazeRenderer
    {
        #region Methods
        public void DrawMaze(Cell[,] maze)
        {
            for(int i = 0; i < maze.GetLength(0); i++)
            {
                for(int j = 0; j < maze.GetLength(1); j++)
                {
                    for(int w = 0; w < maze[i, j].Walls.Length; w++)
                    {
                        if(maze[i, j].Walls[w].Enabled)
                        {
                            GameObject wallGO = new GameObject("Wall " + i + " " + j);
                            LineRenderer lr = wallGO.AddComponent<LineRenderer>();
                            lr.startWidth = 0.1f;
                            lr.endWidth = 0.1f;

                            Direction direction = maze[i, j].Walls[w].Dir;
                            switch (direction)
                            {
                                case Direction.Left:
                                    lr.SetPositions(new Vector3[] { new Vector3(j, i), new Vector3(j, i + 1) });
                                    break;
                                case Direction.Right:
                                    lr.SetPositions(new Vector3[] { new Vector3(j + 1, i), new Vector3(j +1, i + 1) });
                                    break;
                                case Direction.Top:
                                    lr.SetPositions(new Vector3[] { new Vector3(j, i), new Vector3(j + 1, i) });
                                    break;
                                case Direction.Bottom:
                                    lr.SetPositions(new Vector3[] { new Vector3(j, i + 1), new Vector3(j + 1, i + 1) });
                                    break;
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
