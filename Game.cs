using System.Numerics;

namespace Snake;

public class Game
{
    public List<Vector2> snakePositions = [
        new(7,9),
        new(8,9),
        new(9,9)
        ];

    private Vector2 direction = new(-1, 0);
    private Vector2 fruitPosition = new();
    readonly Random rnd = new();

    public Game()
    {
        Reset();
    }

    public (int, int) GetFruitPosition()
    {
        return ((int)fruitPosition.X, (int)fruitPosition.Y);
    }

    public void Reset()
    {
        (fruitPosition.X, fruitPosition.Y) = GenFruitPosition();
    }

    public void IncrementPosition()
    {
        for (int i = snakePositions.Count - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                Vector2 newPos = snakePositions[i] + direction;

                if (newPos.X == -1)
                    newPos.X = 9;
                if (newPos.X == 10)
                    newPos.X = 9;
                if (newPos.Y == -1)
                    newPos.Y = 9;
                if (newPos.Y == 10)
                    newPos.Y = 9;

                snakePositions[i] = newPos;
            }
            else
            {
                snakePositions[i] = snakePositions[i - 1];
            }
        }
    }

    (int, int) GenFruitPosition()
    {
        int x = rnd.Next(1, 10);
        int y = rnd.Next(1, 10);

        if (DoesFruitOverlap(x, y))
            return GenFruitPosition();

        return (x, y);
    }

    bool DoesFruitOverlap(int x, int y)
    {
        foreach (var square in snakePositions)
        {
            if (((int)square.X, (int)square.Y) == (x, y))
                return true;
        }
        return false;
    }

    bool DoesSnakeOverlap()
    {
        return snakePositions.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .Any();
    }
}
