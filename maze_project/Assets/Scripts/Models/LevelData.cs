namespace maze_game.Models
{
    public class LevelData
    {
        public Cell[,] MazeData { get; set; }
        public Cell StartCell { get; set; }
        public Cell EndCell { get; set; }
    }
}
