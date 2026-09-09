using System.Text.Json;
using CatFactsApp.Models;

using HttpClient client = new HttpClient();

var response = await client.GetAsync("https://catfact.ninja/fact");

string content = await response.Content.ReadAsStringAsync();

CatFact? catFact = JsonSerializer.Deserialize<CatFact>(content);

Console.WriteLine($"Fact: {catFact?.Fact}");
Console.WriteLine($"Length: {catFact?.Length}");
File.AppendAllText("catfacts.txt", $"{catFact?.Fact}{Environment.NewLine}");