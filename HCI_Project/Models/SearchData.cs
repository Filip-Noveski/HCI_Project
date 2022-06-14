using HCI_Project.Classes;

namespace HCI_Project.Models;

public class SearchData
{
    private static readonly string[] _currencies = new[] { "eur", "usd", "gbp" };

    public string? Brand { get; set; }
    public string? Name { get; set; }
    public SearchDataPartType Type { get; set; }
    public string? TypeString { get; set; }
    public Pair<decimal, decimal>? PriceRange { get; set; }
    public string? PriceFrom { get; set; }
    public string? PriceTo { get; set; }
    public Currency Currency { get; set; }
    public string? CurrencyString { get; set; }

    public void Format()
    {
        if (TypeString != null)
            Type = Conversion.ToPartType(TypeString);

        if (_currencies.Contains(CurrencyString))
            Currency = Conversion.ToPrice(CurrencyString + ":0").First;
        else
        {
            Currency = Currency.Euro;
            CurrencyString = "eur";
        }    

        bool resFrom = decimal.TryParse(PriceFrom, out decimal priceFrom);
        bool resTo = decimal.TryParse(PriceTo, out decimal priceTo);
        PriceRange = new Pair<decimal, decimal>(resFrom ? priceFrom : 0, resTo ? priceTo : -1);
    }
}

