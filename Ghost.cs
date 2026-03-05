using Raylib_cs;

class Ghost
{
    public int X { get; private set; }
    public int Y { get; private set; }
    Color color;
    Direction current;

    public Ghost(int x, int y, Color _color)
    {
        X = x;
        Y = y;
        color = _color;
    }
    public void Update(Map map, Player player)
    {
        List<Direction> available = new();

        if (map.IsWalkable(X - 1, Y)) available.Add(Direction.Left);
        if (map.IsWalkable(X + 1, Y)) available.Add(Direction.Right);
        if (map.IsWalkable(X, Y - 1)) available.Add(Direction.Up);
        if (map.IsWalkable(X, Y + 1)) available.Add(Direction.Down);

        if (available.Count > 1)
            available.Remove(Global.InverseDirection(current));

        current = available[new Random().Next(available.Count())];
        switch (current)
        {
            case Direction.Left: X -= 1; break;
            case Direction.Right: X += 1; break;
            case Direction.Up: Y -= 1; break;
            case Direction.Down: Y += 1; break;
        }
    }
    public void Draw(int tileSize)
    {
        Raylib.DrawCircle(X * tileSize + tileSize / 2, Y * tileSize + tileSize / 2, tileSize * .4f, color);
    }
}