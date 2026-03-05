using Raylib_cs;

class Program
{
    static void Main()
    {
        Raylib.InitWindow(Global.ScreenWidth, Global.ScreenHeight, "Pacman");
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