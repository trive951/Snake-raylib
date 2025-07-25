namespace Snake;

class Program
{
    public static void Main()
    {
        using Window game = new()
        {
            Width = 600,
            Height = 600,
            Title = "Snake",
        };

        game.Run();
    }
}