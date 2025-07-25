namespace Snake;

class Program
{
    public static void Main()
    {
        using Game game = new()
        {
            Width = 600,
            Height = 600,
            Title = "Snake",
        };

        game.Run();
    }
}