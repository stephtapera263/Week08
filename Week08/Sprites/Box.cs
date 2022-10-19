using System.Drawing;

public class Box : Sprite
{
    public Size Size { get; set; }

    public Rectangle InnerBoundary => new Rectangle(Location.X + 1, Location.Y + 1, Size.Width - 2, Size.Height - 2);

    public Point GetRandomPointInside(params Point[] avoid)
    {
        var random = new Random();
        var point = getPoint(random);
        while (avoid.Contains(point))
        {
            point = getPoint(random);
        }
        return point;

        Point getPoint(Random random)
        {
            var x = random.Next(InnerBoundary.Left, InnerBoundary.Right);
            var y = random.Next(InnerBoundary.Top, InnerBoundary.Bottom);
            return new Point(x, y);
        }
    }

    public override void Erase(ConsoleColor background = ConsoleColor.Black)
    {
        throw new NotImplementedException();
    }

    public override void Draw(ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
    {
        drawTop();
        drawMiddle();
        drawBottom();

        void drawTop()
        {
            var y = Location.Y;
            '┌'.Write(Location.X, y, foreground, background);
            new string('─', Size.Width).Write(Location.X + 1, y, foreground, background);
            '┐'.Write(Location.X + Size.Width + 1, y, foreground, background);
        }

        void drawBottom()
        {
            var y = Location.Y + Size.Height;
            '└'.Write(Location.X, y, foreground, background);
            new string('─', Size.Width).Write(Location.X + 1, y, foreground, background);
            '┘'.Write(Location.X + Size.Width + 1, y, foreground, background);
        }

        void drawMiddle()
        {
            for (int i = 1; i <= Size.Height; i++)
            {
                '│'.Write(Location.X, i + Location.Y, foreground, background);
                '│'.Write(Location.X + Size.Width + 1, i + Location.Y, foreground, background);
            }
        }
    }
}
