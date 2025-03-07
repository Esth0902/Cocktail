using System.Data;

namespace CocktailTests;
using Cocktail.Services;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

public class CocktailServiceIntegrationTests
{
    private readonly HttpClient _httpClient;
    private readonly CocktailService _cocktailService;

    public CocktailServiceIntegrationTests()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
        };
        _cocktailService = new CocktailService(_httpClient);
    }

    [Fact]
    public async Task Get_retrieves_cocktailDB()
        {
            // Act
            var response = await _httpClient.GetAsync("https://www.thecocktaildb.com");
            
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    
    
    [Fact]
    public async Task GetCocktailsByNameAsync_ShouldReturnResults()
    {
        // Act
        var result = await _cocktailService.GetCocktailsByNameAsync("Vodka");
        
        // Assert
        result.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GetRandomCocktailAsync_ShouldReturnResults()
    {
        // Act
        var result = await _cocktailService.GetRandomCocktailAsync();
        var drink = result.StrDrink;
        
        // Assert
        drink.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task GetCocktailsByFirsLetterAsync_ShouldReturnResults()
    {
        // Act
        var result = await _cocktailService.GetCocktailsByFirstLetterAsync("V");
        
        // Assert
        result.Should().NotBeNullOrEmpty();
    }
    
}