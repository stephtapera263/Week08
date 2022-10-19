public class Time : Sprite
{
    public DateTime Started { get; set; } = DateTime.Now;

    public TimeSpan Duration => DateTime.Now - Started;

    public override string Text
    {
        get => $"Game time: {Duration.ToString(@"hh\:mm\:ss")}";
        set => throw new NotImplementedException();
    }
}
