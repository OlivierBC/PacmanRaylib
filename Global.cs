public static class Global
{
    public const int TileSize = 24;
    public const int MapWidth = 29;
    public const int MapHeight = 31;

    public static int ScreenWidth => MapWidth * TileSize;
    public static int ScreenHeight => MapHeight * TileSize;

    public static Direction InverseDirection(Direction direction)
    {
        if ((int)direction % 2 == 0)
            return direction + 1;
        else
            return direction - 1;
    }
}
public enum Direction { Left, Right, Up, Down }
public enum GameState { Title, Playing, GameOver, Win }