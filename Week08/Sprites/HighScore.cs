using Newtonsoft.Json;

public class HighScore : Sprite
{
    public HighScoreModel[]? Scores { get; set; }

    public void DisplayUpdating(ConsoleColor forground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
    {
        Erase();
        var y = 0;
        "HIGH SCORES".Write(Location.X, Location.Y + y++, forground, background);
        "-----------".Write(Location.X, Location.Y + y++, forground, background);
        "Updating...".Write(Location.X, Location.Y + y++, forground, background);

    }

    public override void Draw(ConsoleColor forground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
    {
        Erase();
        var y = 0;
        "HIGH SCORES".Write(Location.X, Location.Y + y++, forground, background);
        "-----------".Write(Location.X, Location.Y + y++, forground, background);
        foreach (var item in Scores.OrderByDescending(x => x.Score))
        {
            $"{item.Name} {item.Score:#,###}".Write(Location.X, Location.Y + y++, forground, background);
        }
    }

    public override void Erase(ConsoleColor background = ConsoleColor.Black)
    {
        var y = 0;
        "HIGH SCORES".Write(Location.X, Location.Y + y++, background, background);
        "-----------".Write(Location.X, Location.Y + y++, background, background);
        for (int i = 0; i < 10; i++)
        {
            new string(' ', 30).Write(Location.X, Location.Y + y++, background, background);
        }
    }
}
