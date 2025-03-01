namespace Cocktail.Models;

public class Cocktail
{
    public string StrDrink { get; }
    public string StrAlcoholic { get; }
    public string StrGlass { get; }
    public string StrInstructions { get; }
    public string StrDrinkThumb { get; }
    public string StrIngredient1 { get; }
    public string StrIngredient2 { get; }
    public string StrIngredient3 { get; }
    public string StrIngredient4 { get; }
    public string StrIngredient5 { get; }
    public string StrIngredient6 { get; }
    public string StrIngredient7 { get; }
    public string StrIngredient8 { get; }
    public string StrIngredient9 { get; }
    public string StrIngredient10 { get; }
    public string StrIngredient11 { get; }
    public string StrIngredient12 { get; }
    public string StrIngredient13 { get; }
    public string StrIngredient14 { get; }
    public string StrIngredient15 { get; }
    
    public string StrMeasure1 { get; }
    public string StrMeasure2 { get; }
    public string StrMeasure3 { get; }
    public string StrMeasure4 { get; }
    public string StrMeasure5 { get; }
    public string StrMeasure6 { get; }
    public string StrMeasure7 { get; }
    public string StrMeasure8 { get; }
    public string StrMeasure9 { get; }
    public string StrMeasure10 { get; }
    public string StrMeasure11 { get; }
    public string StrMeasure12 { get; }
    public string StrMeasure13 { get; }
    public string StrMeasure14 { get; }
    public string StrMeasure15 { get; }
    public List<string> Ingredients => new List<string>
        {
            StrIngredient1, StrMeasure1, StrIngredient2, StrMeasure2, StrIngredient3, StrMeasure3, StrIngredient4, StrMeasure4, StrIngredient5, StrMeasure5,
            StrIngredient6, StrMeasure6, StrIngredient7, StrMeasure7, StrIngredient8, StrMeasure8, StrIngredient9, StrMeasure9, StrIngredient10, StrMeasure10,
            StrIngredient11, StrMeasure11, StrIngredient12, StrMeasure12, StrIngredient13, StrMeasure13, StrIngredient14, StrMeasure14, StrIngredient15, StrMeasure15
        }
        .Where(i => !string.IsNullOrEmpty(i))
        .ToList();
}

public class CocktailResponse
{
    public List<Cocktail> Drinks { get; }
}

