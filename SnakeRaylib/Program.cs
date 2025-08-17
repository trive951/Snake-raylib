namespace Snake;

class Program
{
    public static void Main()
    {
        using Window window = new()
        {
            Width = 600,
            Height = 600,
            Title = "Snake",
        };

        window.Run();
    }
}