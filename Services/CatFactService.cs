using System.Text.Json;
using CatFactsApp.Models;

namespace CatFactsApp.Services;

public class CatFactService
{
    private readonly HttpClient _httpClient;

    public CatFactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFact?> GetFactAsync()
    {
        var response = await _httpClient.GetAsync("https://catfact.ninja/fact");

        string content = await response.Content.ReadAsStringAsync();

        CatFact? catFact = JsonSerializer.Deserialize<CatFact>(content);

        return catFact;
    }
}