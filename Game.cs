using Raylib_cs;

class Game
{
    public GameState State { get; private set; }

    Map map;
    Player player;
    List<Ghost> ghosts;

    int tileSize = Global.TileSize;
    int halfScreenW = Global.ScreenWidth / 2;
    int halfScreenH = Global.ScreenHeight / 2;

    public Game() => ResetGame();
    void ResetGame()
    {
        this.map = new Map();
        this.player = new Player(1, 1);
        this.ghosts = new List<Ghost>();
        this.State = GameState.Title;
        PopulateGhosts(
            new Ghost[] {
                new Ghost(14, 14, Color.Red),
                new Ghost(13, 15, Color.Pink),
                new Ghost(14, 15, Color.Orange),
                new Ghost(15, 15, Color.SkyBlue),
            }
        );
    }
    void PopulateGhosts(Ghost[] ghosts)
    {
        this.ghosts.Clear();
        this.ghosts.AddRange(ghosts);
    }
    bool OnPlayerGhostOverlap(Ghost ghost)
    {
        if (player.IsPoweredUp)
        {
            player.IncreaseScore(100);
            return true;
        }
        else
        {
            State = GameState.GameOver;
            return false;
        }
    }
    void OnEnterPressed(Action action) // Action = delegate func with no params and void return
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
            action();
    }
    void DrawMenu(string title, Color titleColor, string score, string blinkingText)
    {
        Raylib.DrawText(score, halfScreenW - (Raylib.MeasureText(score, 28) / 2), halfScreenH - (int)(halfScreenH * 0.08f), 28, Color.White);
        DrawMenu(title, titleColor, blinkingText);
    }
    void DrawMenu(string title, Color titleColor, string blinkingText)
    {
        Raylib.DrawText(title, halfScreenW - (Raylib.MeasureText(title, 60) / 2), halfScreenH - (int)(halfScreenH * 0.24f), 60, titleColor);
        DrawBlinkingText(blinkingText);
    }
    void DrawBlinkingText(string txt)
    {
        if (Raylib.GetTime() % 1 < 0.5) // very ugly but simple way to change state every .5 seconds; state as in show text or not
            Raylib.DrawText(txt, halfScreenW - (Raylib.MeasureText(txt, 28) / 2), halfScreenH, 28, Color.White);
    }

    public void Draw()
    {
        switch (this.State)
        {
            case GameState.Playing:
                map.Draw(tileSize);
                player.Draw(tileSize);
                foreach (Ghost g in ghosts)
                    g.Draw(tileSize);
                break;
            case GameState.Title:
                DrawMenu("Pacman", Color.Yellow, "-- Press Enter --");
                break;
            case GameState.GameOver:
                DrawMenu("Game Over", Color.Red, "Score: " + player.Score, "-- Press Enter --");
                break;
            case GameState.Win:
                DrawMenu("Game Won", Color.Green, "Score: " + player.Score, "-- Press Enter --");
                break;
        }
    }
    public void Update()
    {
        switch (this.State)
        {
            case GameState.Playing:
                player.Update(map, Raylib.GetFrameTime());
                foreach (Ghost g in ghosts)
                    g.Update(map, player);

                // Check for player ghost overlap
                List<Ghost> ghostToKill = new List<Ghost>();
                bool isDead;
                foreach (Ghost g in ghosts)
                {
                    isDead = false;
                    if (g.X == player.X && g.Y == player.Y)
                    {
                        isDead = OnPlayerGhostOverlap(g);
                        if (isDead)
                            ghostToKill.Add(g);
                    }
                }
                ghosts.RemoveAll(g => ghostToKill.Contains(g));

                // Check for victory
                if (!map.AnyPelletsLeft())
                    State = GameState.Win;

                Thread.Sleep(100);
                break;
            case GameState.Title:
                OnEnterPressed(() => State = GameState.Playing);
                break;
            case GameState.GameOver:
                OnEnterPressed(ResetGame);
                break;
            case GameState.Win:
                OnEnterPressed(ResetGame);
                break;
        }
    }
}