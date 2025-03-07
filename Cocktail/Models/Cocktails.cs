namespace Cocktail.Models;

public class Cocktail
{
    public string IdDrink { get; set; }
    public string StrDrink { get; set; }
    public string StrCategory { get; set; }
    public string StrAlcoholic { get; set; }
    public string StrGlass { get; set; }
    public string StrInstructions { get; set; }
    public string StrDrinkThumb { get; set; }
    public string StrIngredient1 { get; set; }
    public string StrIngredient2 { get; set; }
    public string StrIngredient3 { get; set; }
    public string StrIngredient4 { get; set; }
    public string StrIngredient5 { get; set; }
    public string StrIngredient6 { get; set; }
    public string StrIngredient7 { get; set; }
    public string StrIngredient8 { get; set; }
    public string StrIngredient9 { get; set; }
    public string StrIngredient10 { get; set; }
    public string StrIngredient11 { get; set; }
    public string StrIngredient12 { get; set; }
    public string StrIngredient13 { get; set; }
    public string StrIngredient14 { get; set; }
    public string StrIngredient15 { get; set; }
    
    public string StrMeasure1 { get; set; }
    public string StrMeasure2 { get; set; }
    public string StrMeasure3 { get; set; }
    public string StrMeasure4 { get; set; }
    public string StrMeasure5 { get; set; }
    public string StrMeasure6 { get; set; }
    public string StrMeasure7 { get; set; }
    public string StrMeasure8 { get; set; }
    public string StrMeasure9 { get; set; }
    public string StrMeasure10 { get; set; }
    public string StrMeasure11 { get; set; }
    public string StrMeasure12 { get; set; }
    public string StrMeasure13 { get; set; }
    public string StrMeasure14 { get; set; }
    public string StrMeasure15 { get; set; }
    public List<string> Ingredients
    {
        get => new List<string>
            {
                StrIngredient1, StrMeasure1, StrIngredient2, StrMeasure2, StrIngredient3, StrMeasure3, StrIngredient4,
                StrMeasure4, StrIngredient5, StrMeasure5,
                StrIngredient6, StrMeasure6, StrIngredient7, StrMeasure7, StrIngredient8, StrMeasure8, StrIngredient9,
                StrMeasure9, StrIngredient10, StrMeasure10,
                StrIngredient11, StrMeasure11, StrIngredient12, StrMeasure12, StrIngredient13, StrMeasure13,
                StrIngredient14, StrMeasure14, StrIngredient15, StrMeasure15
            }
            .Where(i => !string.IsNullOrEmpty(i)) // Supprime les valeurs nulles ou vides
            .ToList();
    }
}

public class CocktailResponse
{
    public List<Cocktail> Drinks { get; set; }
}

