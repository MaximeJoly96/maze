namespace maze_game
{
    public struct Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool Visited { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Visited = false;
        }
    }
}
