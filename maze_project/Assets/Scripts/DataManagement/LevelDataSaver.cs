using System.IO;
using UnityEngine;

namespace maze_game.DataManagement
{
    public class LevelDataSaver
    {
        #region Methods
        public void SaveLevel(LevelData data)
        {
            if (!Directory.Exists(Application.persistentDataPath + "/Saves/"))
                Directory.CreateDirectory(Application.persistentDataPath + "/Saves/");

            StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/Saves/save.mz");
            writer.WriteLine("#");
            for(int i = 0; i < data.MazeData.GetLength(0); i++)
            {
                for(int j = 0; j < data.MazeData.GetLength(1); j++)
                {
                    writer.WriteLine("cell " + i + " " + j);
                    for(int w = 0; w < data.MazeData[i, j].Walls.Length; w++)
                    {
                        if(data.MazeData[i, j].Walls[w].Enabled)
                            writer.WriteLine(data.MazeData[i, j].Walls[w].Dir);
                    }
                }
            }

            writer.WriteLine("start = " + data.StartCell.X + " " + data.StartCell.Y);
            writer.WriteLine("exit = " + data.EndCell.X + " " + data.EndCell.Y);
            writer.Close();
        }
        #endregion
    }
}
