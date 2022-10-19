Console.Clear();
Console.CursorVisible = false;

var playerName = AskPlayerName();
var game = new Game(playerName);

game.GameOver += Game_GameOverAsync;

_ = RefreshHighScoreAsync(game);

async void Game_GameOverAsync(object? sender, EventArgs e)
{
    if (sender is Game game)
    {
        game.HighScore.DisplayUpdating();
        var service = new HighScoreService();
        await service.UpdateScore(game.Player.Name, game.Score.Value);

        game.HighScore.Scores = await service.GetScoresAsync();
        game.HighScore.Draw();
    }

}

while (true)
{
    game.Update(Input.Listen(game.CurrentDirection));
    System.Threading.Thread.Sleep(determineSpeed());
}

int determineSpeed()
{
    switch (game.CurrentDirection)
    {
        case Direction.Up:
        case Direction.Down:
            return 100;
        default:
            return 50;
    };
}

string AskPlayerName()
{
    Console.WriteLine("What is your name?");
    var playerName = Console.ReadLine()!;
    if (string.IsNullOrEmpty(playerName))
    {
        playerName = "Unknown";
    }
    Console.Clear();
    return playerName;
}

static async Task RefreshHighScoreAsync(Game game)
{
    var service = new HighScoreService();
    game.HighScore.Scores = await service.GetScoresAsync();
    game.HighScore.Draw();
}
