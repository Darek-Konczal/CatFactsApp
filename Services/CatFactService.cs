using System.Text.Json;
using CatFactsApp.Models;
using CatFactsApp.Interfaces;

namespace CatFactsApp.Services;

public class CatFactService : ICatFactService
{
    private readonly HttpClient _httpClient;

    public CatFactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFact?> GetFactAsync()
    {
        HttpResponseMessage response;

        try
        {
            response = await _httpClient.GetAsync("https://catfact.ninja/fact");
        }
        catch (HttpRequestException)
        {
            return null;
        }

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await response.Content.ReadAsStringAsync();

        CatFact? catFact = JsonSerializer.Deserialize<CatFact>(content);

        return catFact;
    }
}