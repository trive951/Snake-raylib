using System.Numerics;

namespace Snake;

public class Game
{
    public List<Vector2> snakePositions = [
        new(7,9),
        new(8,9),
        new(9,9)
        ];

    Vector2 direction = new(-1, 0);
    Vector2 fruitPosition;
    Vector2 freeSquare;
    int score;

    readonly Random rnd = new();

    public Game()
    {
        Reset();
    }

    public Vector2 GetFruitPosition() => fruitPosition;
    public Vector2 GetDirection() => direction;

    public void SetDirection(Vector2 newDirection)
    {
        // Prevent movement in opposite direction
        if (direction + newDirection == new Vector2(0, 0))
            return;
        else direction = newDirection;
    }

    public void Reset()
    {
        direction = new(-1, 0);
        snakePositions.Clear();
        snakePositions.Add(new(7, 9));
        snakePositions.Add(new(8, 9));
        snakePositions.Add(new(9, 9));

        SetRandomFruitPosition();
    }

    public void IncrementSnakePosition()
    {
        for (int i = snakePositions.Count - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                Vector2 newPos = snakePositions[i] + direction;

                if (newPos.X == -1)
                    newPos.X = 9;
                if (newPos.X == 10)
                    newPos.X = 0;
                if (newPos.Y == -1)
                    newPos.Y = 9;
                if (newPos.Y == 10)
                    newPos.Y = 0;

                snakePositions[i] = newPos;
            }
            else if (i == snakePositions.Count - 1)
            {
                freeSquare = snakePositions[i];
                snakePositions[i] = snakePositions[i - 1];
            }
            else
            {
                snakePositions[i] = snakePositions[i - 1];
            }
        }
    }

    public void SetFruitPosition(Vector2 newPosition)
    {
        fruitPosition = newPosition;
    }

    public void SetRandomFruitPosition()
    {
        int x, y;

        do
        {
            x = rnd.Next(1, 10);
            y = rnd.Next(1, 10);
        }
        while (DoesFruitOverlap(x, y));

        fruitPosition = new Vector2(x, y);
    }

    public bool IsEatingFruit() => snakePositions[0] == fruitPosition;

    bool DoesFruitOverlap(int x, int y)
    {
        foreach (var square in snakePositions)
        {
            if (((int)square.X, (int)square.Y) == (x, y))
                return true;
        }
        return false;
    }

    public bool DoesSnakeOverlap() => snakePositions.Count != snakePositions.Distinct().Count();

    public void GrowSnake()
    {
        snakePositions.Add(freeSquare);
    }
}
