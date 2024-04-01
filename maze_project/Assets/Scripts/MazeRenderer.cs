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
                            GameObject wallGO = new GameObject("Wall " + i + " " + j + " " + maze[i, j].Walls[w].Dir);
                            LineRenderer lr = wallGO.AddComponent<LineRenderer>();
                            lr.startWidth = 0.1f;
                            lr.endWidth = 0.1f;

                            BoxCollider2D collider = wallGO.AddComponent<BoxCollider2D>();

                            Direction direction = maze[i, j].Walls[w].Dir;
                            switch (direction)
                            {
                                case Direction.Left:
                                    lr.SetPositions(new Vector3[] { new Vector3(j, i), new Vector3(j, i + 1) });
                                    collider.size = new Vector2(0.1f, 1.0f);
                                    collider.offset = new Vector2(j, 0.5f + i);
                                    break;
                                case Direction.Right:
                                    lr.SetPositions(new Vector3[] { new Vector3(j + 1, i), new Vector3(j + 1, i + 1) });
                                    collider.size = new Vector2(0.1f, 1.0f);
                                    collider.offset = new Vector2(j + 1, 0.5f + i);
                                    break;
                                case Direction.Top:
                                    lr.SetPositions(new Vector3[] { new Vector3(j, i), new Vector3(j + 1, i) });
                                    collider.size = new Vector2(1.0f, 0.1f);
                                    collider.offset = new Vector2(0.5f + j, i);
                                    break;
                                case Direction.Bottom:
                                    lr.SetPositions(new Vector3[] { new Vector3(j, i + 1), new Vector3(j + 1, i + 1) });
                                    collider.size = new Vector2(1.0f, 0.1f);
                                    collider.offset = new Vector2(0.5f + j, i + 1);
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
