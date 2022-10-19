using System.Drawing;

public class Reward : Sprite
{
    public int Value { get; set; }
    public int SetRandomValue() => Value = new Random().Next(1, 10);

    public override string Text
    {
        get => Value.ToString();
        set => throw new NotImplementedException();
    }
}
