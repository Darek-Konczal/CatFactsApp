using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CatFactsApp.Services;
using CatFactsApp.Interfaces;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddSingleton<HttpClient>();
services.AddSingleton<IConfiguration>(configuration);
services.AddSingleton<ICatFactService, CatFactService>();
services.AddSingleton<IFileService, FileService>();

var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetRequiredService<ICatFactService>();
var catFact = await service.GetFactAsync();

if (catFact != null)
{
    Console.WriteLine($"Fact: {catFact.Fact}");
    Console.WriteLine($"Length: {catFact.Length}");
}
else
    Console.WriteLine("Failed to retrieve a cat fact. Check your internet connection or try later.");

var fileService = serviceProvider.GetRequiredService<IFileService>();
if (catFact != null)
    fileService.SaveFact(catFact.Fact);