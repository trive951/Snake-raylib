using System.Numerics;

namespace Snake;

public class Game
{
    public List<Vector2> snakePositions = [
        new(7,9),
        new(8,9),
        new(9,9)
        ];

    public Vector2 fruitPosition = new();
    Random rnd = new();

    public Game()
    {
        (fruitPosition.X, fruitPosition.Y) = GenFruitPosition();
    }

    public (int, int) GenFruitPosition()
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
}
