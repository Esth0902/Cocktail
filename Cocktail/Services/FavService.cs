using Blazored.LocalStorage;
using Cocktail.Models;
namespace Cocktail.Services;

public interface IFavService
{
    List<Models.Cocktail> FavoriteCocktails { get; }
    
    Task ToggleFavorite(Models.Cocktail cocktail);
    Task LoadFavorites();
    bool IsFavorite(Models.Cocktail cocktail);
}

public class FavService : IFavService
{
    private readonly ILocalStorageService _localStorage; // Gestion du Local Storage
    public List<Models.Cocktail> FavoriteCocktails { get; set; } = new List<Models.Cocktail>();

    public FavService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }
    
    public async Task ToggleFavorite(Models.Cocktail cocktail)
    {
        if (FavoriteCocktails.Any(c => c.StrDrink == cocktail.StrDrink))
        {
            FavoriteCocktails.RemoveAll(c => c.StrDrink == cocktail.StrDrink);
        }
        else
        {
            FavoriteCocktails.Add(cocktail);
        }

        await SaveFavorites();
    }
    
    private async Task SaveFavorites()
    {
        await _localStorage.SetItemAsync("favoriteCocktails", FavoriteCocktails);
    }

    public async Task LoadFavorites()
    {
        var storedFavorites = await _localStorage.GetItemAsync<List<Models.Cocktail>>("favoriteCocktails");
        FavoriteCocktails = storedFavorites ?? new List<Models.Cocktail>();
    }
    
    public bool IsFavorite(Models.Cocktail cocktail)
    {
        return FavoriteCocktails.Any(c => c.StrDrink == cocktail.StrDrink);
    }
}
