using UnityEngine;

namespace maze_game
{
    public class MazeRenderer
    {
        #region Methods
        public void DrawMaze(Cell[,] maze, GameObject baseWall)
        {
            for(int i = 0; i < maze.GetLength(0); i++)
            {
                for(int j = 0; j < maze.GetLength(1); j++)
                {
                    for(int w = 0; w < maze[i, j].Walls.Length; w++)
                    {
                        if(maze[i, j].Walls[w].Enabled)
                        {
                            GameObject wallGO = Object.Instantiate(baseWall);
                            wallGO.name = "Wall " + i + " " + j + " " + maze[i, j].Walls[w].Dir;
                            wallGO.transform.position = new Vector3(j + 0.5f, i + 0.5f);
                            wallGO.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));

                            Direction direction = maze[i, j].Walls[w].Dir;
                            switch (direction)
                            {
                                case Direction.Left:
                                    wallGO.transform.localScale = new Vector3(0.2f, 1.0f, 1.0f);
                                    wallGO.transform.position = new Vector3(wallGO.transform.position.x - 0.5f, wallGO.transform.position.y);
                                    break;
                                case Direction.Right:
                                    wallGO.transform.localScale = new Vector3(0.2f, 1.0f, 1.0f);
                                    wallGO.transform.position = new Vector3(wallGO.transform.position.x + 0.5f, wallGO.transform.position.y);
                                    break;
                                case Direction.Top:
                                    wallGO.transform.localScale = new Vector3(1.0f, 1.0f, 0.2f);
                                    wallGO.transform.position = new Vector3(wallGO.transform.position.x, wallGO.transform.position.y - 0.5f);
                                    break;
                                case Direction.Bottom:
                                    wallGO.transform.localScale = new Vector3(1.0f, 1.0f, 0.2f);
                                    wallGO.transform.position = new Vector3(wallGO.transform.position.x, wallGO.transform.position.y + 0.5f);
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
