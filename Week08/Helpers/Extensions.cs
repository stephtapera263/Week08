public static class Extensions
{
        public static void Write(this char text, int x, int y, ConsoleColor foreground, ConsoleColor background)
    {
        text.ToString().Write(x, y, foreground, background);

    }
         public static void Write(this string text, int x, int y, ConsoleColor foreground, ConsoleColor background)
    {
        Console.ForegroundColor = foreground;
        Console.BackgroundColor = background;
        Console.SetCursorPosition(x, y);
        Console.Write(text);
        Console.ResetColor();
    }
}
