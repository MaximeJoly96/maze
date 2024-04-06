using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace maze_game.DataManagement
{
    public class LevelDataLoader
    {
        #region Methods
        public List<LevelData> LoadLevels(string path)
        {
            List<LevelData> levels = new List<LevelData>();
            StreamReader reader = new StreamReader(path);
            string content = reader.ReadToEnd();
            reader.Close();

            string[] allLevels = content.Split('#');
            for(int i = 0; i < allLevels.Length; i++)
            {
                levels.Add(ParseLevel(allLevels[i]));
            }

            return levels;
        }

        private LevelData ParseLevel(string data)
        {
            LevelData level = new LevelData();

            if (data.Contains("cell"))
            {
                string[] splitData = data.Replace("\r\n", "-").Split('-');
                List<Cell> allCells = new List<Cell>();

                for(int i = 0; i < splitData.Length; i++)
                {
                    if(splitData[i].StartsWith("cell"))
                    {
                        // this indicates position
                        string content = splitData[i].Replace("cell ", "");
                        string[] split = content.Split(' ');
                        int x = int.Parse(split[0]);
                        int y = int.Parse(split[1]);

                        Cell cell = new Cell(x, y);
                        cell.DisableWalls();
                        allCells.Add(cell);
                    }
                    else if (splitData[i].StartsWith("start"))
                    {
                        string content = splitData[i].Replace("start = ", "");
                        string[] split = content.Split(' ');
                        int x = int.Parse(split[0]);
                        int y = int.Parse(split[1]);

                        level.StartCell = new Cell(x, y);
                    }
                    else if (splitData[i].StartsWith("exit"))
                    {
                        string content = splitData[i].Replace("exit = ", "");
                        string[] split = content.Split(' ');
                        int x = int.Parse(split[0]);
                        int y = int.Parse(split[1]);

                        level.EndCell = new Cell(x, y);
                    }
                    else
                    {
                        if(splitData[i] != "")
                        {
                            Direction dir = (Direction)Enum.Parse(typeof(Direction), splitData[i]);
                            Cell lastCell = allCells[allCells.Count - 1];
                            lastCell.Walls.FirstOrDefault(w => w.Dir == dir).Enabled = true;
                        }
                    }
                }

                level.MazeData = CellsListTo2DArray(allCells);
            }

            return level;
        }

        private Cell[,] CellsListTo2DArray(List<Cell> cells)
        {
            int maxX = cells.Max(c => c.X);
            int maxY = cells.Max(c => c.Y);

            Cell[,] array = new Cell[maxX + 1, maxY + 1];

            for(int i = 0; i < cells.Count; i++)
            {
                array[cells[i].X, cells[i].Y] = cells[i];
            }

            return array;
        }
        #endregion
    }
}
