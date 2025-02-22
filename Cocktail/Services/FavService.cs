using Blazored.LocalStorage;
using Cocktail.Models;
namespace Cocktail.Services;

public class FavService
{
    private readonly ILocalStorageService _localStorage; // Gestion du Local Storage
    public List<Models.Cocktail> favoriteCocktails { get; set; } = [];

    public FavService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }
    
    public async Task ToggleFavorite(Models.Cocktail cocktail)
    {
        if (favoriteCocktails.Any(c => c.StrDrink == cocktail.StrDrink))
        {
            favoriteCocktails.RemoveAll(c => c.StrDrink == cocktail.StrDrink);
        }
        else
        {
            favoriteCocktails.Add(cocktail);
        }

        await SaveFavorites();
    }
    
    private async Task SaveFavorites()
    {
        await _localStorage.SetItemAsync("favoriteCocktails", favoriteCocktails);
    }

    public async Task LoadFavorites()
    {
        var storedFavorites = await _localStorage.GetItemAsync<List<Models.Cocktail>>("favoriteCocktails");
        if (storedFavorites != null)
        {
            favoriteCocktails = storedFavorites;
        }
    }
    
    public bool IsFavorite(Models.Cocktail cocktail)
    {
        return favoriteCocktails.Any(c => c.StrDrink == cocktail.StrDrink);
    }
}
