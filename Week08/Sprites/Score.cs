public class Score : Sprite
{
    public int Value { get; set; }

    public override string Text
    {
        get => $"Score: {Value:#,##0} points";
        set => throw new NotImplementedException();
    }
}
