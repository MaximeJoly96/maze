using System.Collections.Generic;

namespace maze_game.Models
{
    public class StraightCorridor
    {
        public List<Cell> Cells { get; private set; }

        public StraightCorridor(List<Cell> cells)
        {
            Cells = new List<Cell>();
            for (int i = 0; i < cells.Count; i++)
            {
                Cells.Add(cells[i]);
            }
        }
    }
}
