using System.IO;
using maze_game.Models;

namespace maze_game.DataManagement
{
    public class LevelDataSaver
    {
        #region Methods
        public void SaveLevel(LevelData data)
        {
            if (!Directory.Exists(LevelDataManager.SAVES_PATH))
                Directory.CreateDirectory(LevelDataManager.SAVES_PATH);

            StreamWriter writer = new StreamWriter(LevelDataManager.SAVES_PATH + LevelDataManager.SAVE_FILE_NAME);
            writer.WriteLine(LevelDataManager.SEPARATOR);
            for(int i = 0; i < data.MazeData.GetLength(0); i++)
            {
                for(int j = 0; j < data.MazeData.GetLength(1); j++)
                {
                    writer.WriteLine(LevelDataManager.CELL_KEYWORD + " " + i + " " + j);
                    for(int w = 0; w < data.MazeData[i, j].Walls.Length; w++)
                    {
                        if(data.MazeData[i, j].Walls[w].Enabled)
                            writer.WriteLine(data.MazeData[i, j].Walls[w].Dir);
                    }
                }
            }

            writer.WriteLine(LevelDataManager.START_KEYWORD + " = " + data.StartCell.X + " " + data.StartCell.Y);
            writer.WriteLine(LevelDataManager.EXIT_KEYWORD + " = " + data.EndCell.X + " " + data.EndCell.Y);
            writer.Close();
        }
        #endregion
    }
}
