namespace CocktailTests;

using Blazored.LocalStorage;
using System.Threading.Tasks;
using Bunit;
using Cocktail.Pages;
using Cocktail.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using FluentAssertions;

public class HomeDisplayTests : TestContext
{
    private readonly HttpClient _httpClient;
    private readonly ICocktailService _cocktailService;
    private readonly IFavService _favService;
    private readonly Mock<ILocalStorageService> _mockLocalStorage;

    public HomeDisplayTests()
    {
        // Arrange
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
        };
        _cocktailService = new CocktailService(_httpClient);
        _mockLocalStorage = new Mock<ILocalStorageService>();
        _favService = new FavService(_mockLocalStorage.Object);
        Services.AddSingleton<IFavService>(_favService);
        Services.AddSingleton<ICocktailService>(_cocktailService);
    }

    [Fact]
    public void HomePage_Should_Render_Buttons_And_Input()
    {
        // Act
        var component = RenderComponent<Home>();
        
        // Assert
        component.Find("input[type='search']");
        component.Find("button:nth-of-type(1)").MarkupMatches("<button>Search by name</button>");
        component.Find("button:nth-of-type(2)").MarkupMatches("<button>Search by first letter</button>");
        component.Find("button:nth-of-type(3)").MarkupMatches("<button>Random Cocktail</button>");
    }

    [Fact]
    public async Task HomePage_Should_Display_No_Cocktail_Found_When_List_Is_Empty()
    {
        // Arrange
        var component = RenderComponent<Home>();
        component.Find("input").Change("Blabla");
        
        // Act
        component.Find("button:nth-of-type(1)").Click();
        await Task.Delay(500);
        
        // Assert
        component.Markup.Should().Contain("No cocktail found.");
    }

    [Fact]
    public async Task SearchCocktails_Should_Fetch_And_Display_Data()
    {
        // Arrange
        var component = RenderComponent<Home>();
        
        // Act
        component.Find("input").Change("Cuba Libre");
        component.Find("button:nth-of-type(1)").Click();
        await Task.Delay(500);
        
        // Assert
        component.Markup.Should().ContainEquivalentOf("Rum");
    }
}

