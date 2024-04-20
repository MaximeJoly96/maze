using maze_game.Models;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace maze_game.Engine
{
    public class DeadEndsDetector
    {
        public List<Cell> DetectDeadEnds(LevelData mazeData)
        {
            List<Cell> deadEnds = new List<Cell>();

            for(int i = 0; i < mazeData.MazeData.GetLength(0); i++)
            {
                for(int j = 0; j < mazeData.MazeData.GetLength(1); j++)
                {
                    if (mazeData.MazeData[i, j].Walls.Count(w => w.Enabled) == 3)
                    {
                        deadEnds.Add(mazeData.MazeData[i, j]);
                    }
                }
            }

            return deadEnds;
        }
    }
}
