public static class Input
{
    public static Direction Listen(Direction previous)
    {
        if (!Console.KeyAvailable)
        {
            return previous;
        }
        var key = Console.ReadKey(false).Key;
        return key switch
        {
            ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.DownArrow => Direction.Down,
            ConsoleKey.LeftArrow => Direction.Left,
            ConsoleKey.RightArrow => Direction.Right,
            _ => previous,
        };
    }
}