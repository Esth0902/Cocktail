namespace CocktailTests;

using Blazored.LocalStorage;
using Cocktail.Models;
using Cocktail.Services;
using Moq;
using Xunit;
using FluentAssertions;
using Xunit.Abstractions;


public class FavServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<ILocalStorageService> _mockLocalStorage;
    private readonly FavService _favService;

    public FavServiceTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockLocalStorage = new Mock<ILocalStorageService>();
        _favService = new FavService(_mockLocalStorage.Object);
    }

    [Fact]
    public async Task ToggleFavorite_ShouldAddCocktailToFavorites()
    {
        // Arrange
        var cocktail = new Cocktail { StrDrink = "Vodka Tonic" };

        // Act
        await _favService.ToggleFavorite(cocktail);

        // Assert
       _favService.favoriteCocktails.Should().Contain(cocktail);
       
       _testOutputHelper.WriteLine(cocktail.StrDrink);
       foreach (var fav in _favService.favoriteCocktails)
       {
           _testOutputHelper.WriteLine(fav.StrDrink);
       }
    }

    [Fact]
    public async Task ToggleFavorite_ShouldRemoveCocktailFromFavorites()
    {
        // Arrange
        var cocktail = new Cocktail { StrDrink = "Rum Coca" };
        _favService.favoriteCocktails.Add(cocktail);

        // Act
        await _favService.ToggleFavorite(cocktail);

        // Assert
        _favService.favoriteCocktails.Should().BeEmpty();
    }

    [Fact]
    public void IsFavorite_ShouldReturnTrueIfCocktailIsInFavorites()
    {
        // Arrange
        var cocktail = new Cocktail { StrDrink = "Margarita" };
        _favService.favoriteCocktails.Add(cocktail);

        // Act
        var result = _favService.IsFavorite(cocktail);

        // Assert
        result.Should().BeTrue();
    }
}