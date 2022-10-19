using System.Drawing;

public abstract class Sprite 
{
    public Point Location { get; set; }

    public virtual string Text { get; set; } = "";

    public virtual void Erase(ConsoleColor background = ConsoleColor.Black)
        => new String(' ', Text.Length).Write(Location.X, Location.Y, background, background);

    public virtual void Draw(ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        => Text.Write(Location.X, Location.Y, foreground, background);
}
