
namespace DataAccess;

public class ApiReader : IApiReader
{
    public async Task<string> ReadAsync(int limit, int page)
    {
        using HttpClient client = new();

        HttpResponseMessage response = await client.GetAsync($"https://quote-garden.onrender.com/api/v3/quotes?limit={limit}&page={page}");

        response.EnsureSuccessStatusCode();

        string quotes = await response.Content.ReadAsStringAsync();

        return quotes;
    }
}



