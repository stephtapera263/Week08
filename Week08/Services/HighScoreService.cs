using Newtonsoft.Json;

public class HighScoreService
{
    private readonly static HttpClient _http = new HttpClient();

    public async Task<HighScoreModel[]> GetScoresAsync()
    {
        var url = "https://ccu-api.azurewebsites.net/score?limit=10";
        var json = await _http.GetStringAsync(url);
        return JsonConvert.DeserializeObject<HighScoreModel[]>(json) ?? Array.Empty<HighScoreModel>();
    }
    public async Task UpdateScore(string name, int score)
    {
        var url = $"https://ccu-api.azurewebsites.net/score/{name}/{score}";
        await _http.PutAsync(url, null);
    }
    public async Task DeleteScore(string name)
    {
        var url = $"https://ccu-api.azurewebsites.net/score/{name}";
        await _http.DeleteAsync(url);
    }
}
