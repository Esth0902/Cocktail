﻿using System.Net.Http.Json;
using Cocktail.Models;

namespace Cocktail.Services;
public interface ICocktailService
{
    Task<List<Models.Cocktail>> GetCocktailsByNameAsync(string name);
    Task<List<Models.Cocktail>> GetCocktailsByFirstLetterAsync(string letter);
    Task<Models.Cocktail> GetRandomCocktailAsync();
}
public class CocktailService : ICocktailService
{
    private readonly HttpClient _httpClient;
    public CocktailService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<Models.Cocktail>> GetCocktailsByNameAsync(string name)
    {
        var response = await _httpClient.GetFromJsonAsync<CocktailResponse>($"search.php?s={name}"); 
        return response?.Drinks ?? new List<Models.Cocktail>();
    }
    
    public async Task<Models.Cocktail> GetRandomCocktailAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<CocktailResponse>("random.php");
        return response?.Drinks?[0];
    }
    public async Task<List<Models.Cocktail>> GetCocktailsByFirstLetterAsync(string name)
    {
        var response = await _httpClient.GetFromJsonAsync<CocktailResponse>($"search.php?f={name}");
        return response?.Drinks ?? new List<Models.Cocktail>();
    }
    
}
