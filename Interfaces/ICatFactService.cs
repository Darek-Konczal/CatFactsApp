using CatFactsApp.Models;

namespace CatFactsApp.Interfaces;

public interface ICatFactService
{
    Task<CatFact?> GetFactAsync();
}