using Newtonsoft.Json;

public class HighScoreModel
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("score")]
    public int Score { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }
}
