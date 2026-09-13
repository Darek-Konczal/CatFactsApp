using Microsoft.Extensions.Configuration;
using System.Text.Json;
using CatFactsApp.Models;
using CatFactsApp.Interfaces;

namespace CatFactsApp.Services;

public class CatFactService : ICatFactService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public CatFactService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["CatFactApi:BaseUrl"]
            ?? throw new InvalidOperationException("CatFactApi:BaseUrl is not configured.");
    }

    public async Task<CatFact?> GetFactAsync()
    {
        HttpResponseMessage response;

        try
        {
            response = await _httpClient.GetAsync(_baseUrl);
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