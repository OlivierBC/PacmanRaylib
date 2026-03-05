using Raylib_cs;

class Player
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Score { get; private set; } = 0;
    public bool IsPoweredUp { get; private set; } = false;
    float PoweredUpTime = 10f; // Seconds
    public Player(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Update(Map map, float frameTime)
    {
        //Movement
        int dX = 0, dY = 0;
        if (Raylib.IsKeyDown(KeyboardKey.Left)) dX = -1;
        else if (Raylib.IsKeyDown(KeyboardKey.Right)) dX = 1;
        else if (Raylib.IsKeyDown(KeyboardKey.Up)) dY = -1;
        else if (Raylib.IsKeyDown(KeyboardKey.Down)) dY = 1;

        if (map.IsWalkable(X + dX, Y + dY))
        {
            X += dX;
            Y += dY;
        }

        //pellets
        if (map.EatPelletAt(X, Y, out bool isPowerPellet))
            IncreaseScore(10);
        if (isPowerPellet)
        {
            IsPoweredUp = true;
            PoweredUpTime = 10f;
            IncreaseScore(50);
        }

        if (IsPoweredUp)
        {
            PoweredUpTime -= Raylib.GetFrameTime();
            if (PoweredUpTime < 0) IsPoweredUp = false;
        }
    }

    public void Draw(int tileSize)
    {
        Raylib.DrawCircle(X * tileSize + tileSize / 2, Y * tileSize + tileSize / 2, tileSize * .4f, Color.Yellow);

        Raylib.DrawText("Score: " + Score, 2, 2, 24, Color.White);

        if (IsPoweredUp)
            Raylib.DrawText("Powered-up: " + PoweredUpTime, 400, 2, 24, Color.White);

    }

    public void IncreaseScore(int score)
    {
        Score += score;
    }
    public void OnGhostKilled()
    {
        Score += 100;
    }
}