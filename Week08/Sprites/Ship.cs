using System.Drawing;

public class Ship : Sprite
{
    public Point PreviousLocation { get; set; }

    public void Move(Direction direction, Rectangle box)
    {
        PreviousLocation = Location;

        updateLocation(direction);

        updateCharacter(direction);

        void updateLocation(Direction direction)
        {
            Location = direction switch
            {
                Direction.Left => updateLocation(x: -1),
                Direction.Right => updateLocation(x: +1),
                Direction.Up => updateLocation(y: -1),
                Direction.Down => updateLocation(y: +1),
                _ => Location,
            };

            wrapX(box);

            wrapY(box);

            Point updateLocation(int x = 0, int y = 0) => new Point(Location.X + x, Location.Y + y);

            void wrapX(Rectangle box)
            {
                if (Location.X < box.Left)
                {
                    Location = new Point(box.Right, Location.Y);
                }
                else if (Location.X > box.Right)
                {
                    Location = new Point(box.Left, Location.Y);
                }
            }

            void wrapY(Rectangle box)
            {
                if (Location.Y < box.Top)
                {
                    Location = new Point(Location.X, box.Bottom);
                }
                else if (Location.Y > box.Bottom)
                {
                    Location = new Point(Location.X, box.Top);
                }
            }
        }

        void updateCharacter(Direction direction)
        {
            Text = direction switch
            {
                Direction.Up => "▲",
                Direction.Down => "▼",
                Direction.Left => "◄",
                Direction.Right => "►",
                _ => "■",
            };
        }
    }
}
