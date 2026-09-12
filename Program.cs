using Microsoft.Extensions.DependencyInjection;
using CatFactsApp.Services;

var services = new ServiceCollection();

services.AddSingleton<HttpClient>();
services.AddSingleton<CatFactService>();
services.AddSingleton<FileService>();

var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetRequiredService<CatFactService>();
var catFact = await service.GetFactAsync();

Console.WriteLine($"Fact: {catFact?.Fact}");
Console.WriteLine($"Length: {catFact?.Length}");

var fileService = serviceProvider.GetRequiredService<FileService>();
if (catFact != null)
    fileService.SaveFact(catFact.Fact);