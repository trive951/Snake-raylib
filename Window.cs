using Raylib_cs;
using System.Numerics;

namespace Snake
{
    public class Window : IDisposable
    {
        public int Width { get; init; } = 800;
        public int Height { get; init; } = 600;
        public string Title { get; init; } = "";

        public Color backgroundColour = new(63, 143, 71);
        //private Vector2 position = new(5, 5);

        public void Run()
        {
            var game = new Game();

            Raylib.InitWindow(Width, Height, Title);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(backgroundColour);

                DrawSnake(ref game.snakePositions);
                DrawFruit(ref game.fruitPosition);

                if (Raylib.IsKeyPressed(KeyboardKey.R))
                    (game.fruitPosition.X, game.fruitPosition.Y) = game.GenFruitPosition();

                Raylib.EndDrawing();
            }
        }

        static void DrawSnake(ref List<Vector2> snakePositions)
        {
            foreach (var square in snakePositions)
            {
                var rec = new Rectangle(square * 60, 60, 60);
                Raylib.DrawRectangleRounded(rec, .25f, 4, Color.Black);
            }
        }

        static void DrawFruit(ref Vector2 fruitPosition)
        {
            Raylib.DrawCircle((int)(fruitPosition.X * 60 + 30), (int)(fruitPosition.Y * 60 + 30), 30, Color.Red);
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
            Raylib.CloseWindow();
        }
    }
}
