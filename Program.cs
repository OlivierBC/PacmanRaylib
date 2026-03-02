using Raylib_cs;

class Program
{
    static void Main()
    {
        const int tileSize = 24;
        const int mapWidth = 28;
        const int mapHeight = 31;

        int screenWidth = mapWidth * tileSize;
        int screenHeight = mapHeight * tileSize;

        Raylib.InitWindow(screenWidth, screenHeight, "Pacman Grid");
        Raylib.SetTargetFPS(60);

        Game game = new Game();

        while (!Raylib.WindowShouldClose())
        {
            game.Update();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            game.Draw();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}