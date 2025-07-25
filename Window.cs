using Raylib_cs;
using System.Numerics;

namespace Snake
{
    public class Window : IDisposable
    {
        public int Width { get; init; }
        public int Height { get; init; }
        public string Title { get; init; } = "";

        public Color backgroundColour = new(63, 143, 71);
        private Vector2 position = new(5, 5);

        public void Run()
        {
            Raylib.InitWindow(Width, Height, Title);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(backgroundColour);

                var rec = new Rectangle(position * 60, 60, 60);
                Raylib.DrawRectangleRounded(rec, 0.25f, 4, Color.Black);

                Raylib.DrawText($"X: {position.X} Y: {position.Y}", 15, 15, 20, Color.White);

                Raylib.EndDrawing();
            }
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
            Raylib.CloseWindow();
        }
    }
}
