using System.Drawing;

public class Game
{
    private const int FUEL_START = 30;
    private const int FUEL_BONUS = 5;
    private const int FUEL_WARNING = 20;
    private const int FUEL_MODULUS = 5;

    public Game(string playerName)
    {
        Player.Name = playerName;
        DefaultSetup();
    }

    public void DefaultSetup()
    {
        var boxSize = new Size(50, 20);
        var boxLocation = new Point(5, 1);
        Box.Size = boxSize;
        Box.Location = boxLocation;
        Box.Draw();

        var shipLocation = Box.GetRandomPointInside();
        Ship.Location = shipLocation;
        Ship.Draw();

        var sideLocation = new Point(Box.InnerBoundary.Right + 5, Box.Location.Y);
        Player.Location = sideLocation;
        Player.Draw();

        sideLocation.Offset(0, 2);
        Score.Location = sideLocation;
        Score.Value = 0;
        Score.Draw();

        sideLocation.Offset(0, 1);
        Time.Location = sideLocation;
        Time.Started = DateTime.Now;
        Time.Draw();

        sideLocation.Offset(0, 1);
        Fuel.Location = sideLocation;
        Fuel.Value = FUEL_START;
        Fuel.Draw();

        sideLocation.Offset(0, 2);
        HighScore.Location = sideLocation;
        HighScore.DisplayUpdating();

        IsGameOver = false;
        RandomizeReward();
        CurrentDirection = Direction.Stop;
    }

    public Time Time { get; } = new Time();

    public Fuel Fuel { get; } = new Fuel();

    public Ship Ship { get; } = new Ship();

    public Box Box { get; } = new Box();

    public Score Score { get; } = new Score();

    public Reward Reward { get; } = new Reward();

    public Player Player { get; } = new Player();

    public HighScore HighScore { get; } = new HighScore();

    public event EventHandler? GameOver;

    private bool _isGameOver = false;
    public bool IsGameOver { 
        get => _isGameOver; 
        set
        {
            _isGameOver = value;  
            if (value)
            {
                GameOver?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public Direction CurrentDirection { get; private set; }

    public void Update(Direction newDirection)
    {
        if (IsGameOver)
        {
            return;
        }

        CurrentDirection = newDirection;

        if (shouldReduceFuel())
        {
            Fuel.Value--;
        }

        Fuel.Draw();

        if (isFuelEmpty())
        {
            endTheGame();
            return;
        }

        if (shouldWarnAboutLowFuel())
        {
            Box.Draw(ConsoleColor.White, ConsoleColor.DarkYellow);
        }
        else
        {
            Box.Draw();
        }

        moveShip();

        if (isShipOnReward())
        {
            addReward();
        }
        else
        {
            Score.Draw();
        }

        Time.Draw();

        bool isFuelEmpty() => Fuel.Value < 1;

        bool shouldWarnAboutLowFuel() => Fuel.Value < FUEL_WARNING;

        bool shouldReduceFuel() => CurrentDirection != Direction.Stop
            && Time.Duration.Milliseconds % FUEL_MODULUS == 0;

        bool isShipOnReward() => Ship.Location == Reward.Location;

        void endTheGame()
        {
            IsGameOver = true;
            Ship.Draw(ConsoleColor.White, ConsoleColor.Red);
            Score.Draw(ConsoleColor.Black, ConsoleColor.White);
        }

        void addReward()
        {
            Fuel.Value += FUEL_BONUS;
            Score.Value += Reward.Value;
            Score.Draw(ConsoleColor.White, ConsoleColor.Green);
            Fuel.Draw(ConsoleColor.White, ConsoleColor.Green);
            Box.Draw(ConsoleColor.White, ConsoleColor.Green);
            RandomizeReward();
        }

        void moveShip()
        {
            Ship.Erase();
            Ship.Move(newDirection, Box.InnerBoundary);
            Ship.Draw();
        }
    }

    private void RandomizeReward()
    {
        Reward.Erase();
        Reward.SetRandomValue();
        Reward.Location = Box.GetRandomPointInside(Ship.Location);
        Reward.Draw();
    }
}
