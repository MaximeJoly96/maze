﻿namespace maze_game
{
    public enum CellRole { Start, Exit }

    public class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool Visited { get; set; }
        public Wall[] Walls { get; private set; }
        public CellRole Role { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Visited = false;
            Walls = new Wall[]
            {
                new Wall { Dir = Direction.Left },
                new Wall { Dir = Direction.Right },
                new Wall { Dir = Direction.Top },
                new Wall { Dir = Direction.Bottom }
            };
        }

        public void DisableWalls()
        {
            for (int i = 0; i < Walls.Length; i++)
                Walls[i].Enabled = false;
        }

        public Cell Copy()
        {
            Cell copy = new Cell(X, Y);
            for(int i = 0; i < copy.Walls.Length; i++)
            {
                copy.Walls[i] = new Wall { Dir = Walls[i].Dir, Enabled = Walls[i].Enabled };
            }

            return copy;
        }
    }
}
