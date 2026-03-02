using Raylib_cs;

Raylib.InitWindow(800, 600, "Raylib CS");
Raylib.SetTargetFPS(60);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    Raylib.DrawText("Raylib Base Project", 20, 20, 20, Color.White);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();