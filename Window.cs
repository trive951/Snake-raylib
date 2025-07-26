using Raylib_cs;
using System.Numerics;

namespace Snake
{
    public class Window : IDisposable
    {
        public int Width { get; init; } = 800;
        public int Height { get; init; } = 600;
        public string Title { get; init; } = "";

        private const float delayTime = 0.5f;
        public Color backgroundColour = new(63, 143, 71);
        //private Vector2 position = new(5, 5);

        public void Run()
        {
            var game = new Game();
            float timeElapsed = 0;

            Raylib.InitWindow(Width, Height, Title);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(backgroundColour);
                float frameTime = Raylib.GetFrameTime();
                timeElapsed += frameTime;

                if (timeElapsed >= delayTime)
                {
                    //Console.WriteLine("moving");
                    timeElapsed = 0;
                    game.IncrementSnakePosition();
                }

                DrawSnake(ref game.snakePositions);
                DrawFruit(game.GetFruitPosition());

                // TODO move input handling into its own method
                if (Raylib.IsKeyPressed(KeyboardKey.R))
                {
                    game.Reset();
                    timeElapsed = 0;
                }

                if (Raylib.IsKeyPressed(KeyboardKey.Up))
                    game.SetDirection(new(0, -1));
                if (Raylib.IsKeyPressed(KeyboardKey.Down))
                    game.SetDirection(new(0, 1));
                if (Raylib.IsKeyPressed(KeyboardKey.Left))
                    game.SetDirection(new(-1, 0));
                if (Raylib.IsKeyPressed(KeyboardKey.Right))
                    game.SetDirection(new(1, 0));

                if (game.IsEatingFruit())
                    game.SetFruitPosition(game.SetRandomFruitPosition());

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

        static void DrawFruit(Vector2 fruitPosition)
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
