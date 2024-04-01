using UnityEngine;

namespace maze_game
{
    public class MazeBuilder : MonoBehaviour
    {
        private MazeGenerator _mazeGenerator;
        private MazeRenderer _mazeRenderer;

        private void Awake()
        {
            _mazeGenerator = new MazeGenerator();
            _mazeRenderer = new MazeRenderer();

            _mazeRenderer.DrawMaze(_mazeGenerator.Generate(10, 10));
        }
    }
}
