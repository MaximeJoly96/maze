namespace maze_game
{
    public enum Direction { Left, Right, Top, Bottom, Undefined }

    public class Wall
    {
        public bool Enabled { get; set; } = true;
        public Direction Dir { get; set; }
    }
}
