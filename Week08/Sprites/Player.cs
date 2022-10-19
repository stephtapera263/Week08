public class Player : Sprite
{
    public string Name { get; set; } = "Unknown";

    public override string Text
    {
        get => $"Hello, {Name}";
        set => throw new NotImplementedException();
    }
}
