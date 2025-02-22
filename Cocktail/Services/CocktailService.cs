using System.Net.Http.Json;
using Cocktail.Models;

namespace Cocktail.Services;

public class CocktailService
{
    private readonly HttpClient _httpClient;
    public CocktailService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    // Récupérer une liste de cocktails par nom
    public async Task<List<Models.Cocktail>> GetCocktailsByNameAsync(string name)
    {
        var response = await _httpClient.GetFromJsonAsync<CocktailResponse>($"search.php?s={name}");
        return response?.Drinks ?? new List<Models.Cocktail>();
    }

    // Récupérer un cocktail au hasard
    public async Task<Models.Cocktail> GetRandomCocktailAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<CocktailResponse>("random.php");
        return response?.Drinks?[0];
    }
    
    // Chercher un cocktail par sa première lettre
    public async Task<List<Models.Cocktail>> GetCocktailsByFirstLetterAsync(string name)
    {
        var response = await _httpClient.GetFromJsonAsync<CocktailResponse>($"search.php?f={name}");
        return response?.Drinks ?? new List<Models.Cocktail>();
    }
    
}
