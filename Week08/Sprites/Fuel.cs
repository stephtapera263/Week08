public class Fuel : Sprite
{
    public int Value { get; set; }

    public override string Text
    {
        get => $"Fuel left: {Value.ToString("00000;00000;EMPTY")}";
        set => throw new NotImplementedException();
    }
}
