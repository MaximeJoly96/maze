using UnityEngine;

namespace maze_game
{
    public class MazeBuilder : MonoBehaviour
    {
        private MazeGenerator _mazeGenerator;

        private void Awake()
        {
            _mazeGenerator = new MazeGenerator();

            _mazeGenerator.Generate(5, 4);
        }
    }
}
