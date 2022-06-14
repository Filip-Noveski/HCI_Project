using HCI_Project.Models;

namespace HCI_Project.Classes;

public class Format
{
    private static readonly Random _random = new();

    private static decimal ExchangeCurrency(decimal value, Currency from,  Currency to)
    {
        if (from == to)
            return value;

        decimal inEuro = from switch
        {
            Currency.GBPound => value * (decimal)1.17,
            Currency.USDollar => value * (decimal)0.96,
            _ => value // Euro included
        };

        return to switch
        {
            Currency.GBPound => inEuro / (decimal)1.17,
            Currency.USDollar => inEuro / (decimal)0.96,
            _ => inEuro // Euro included
        };
    }

    public static string PartType(SearchDataPartType partType)
    {
        switch (partType)
        {
            case SearchDataPartType.CPU:
                return "Central Processing Unit";

            case SearchDataPartType.GraphicsCard:
                return "Graphics Card";

            case SearchDataPartType.RAM:
                return "Random Access Memory";

            case SearchDataPartType.HDD:
                return "Hard Disk Drive";

            case SearchDataPartType.SSD:
                return "Solid State Drive";

            default:
                return partType.ToString();
        }
    }

    public static string PriceRange(Currency currency, Pair<decimal, decimal>? range)
    {
        if (range is null)
            return string.Empty;

        string ret = currency switch
        {
            Currency.GBPound => "£",
            Currency.Euro => "€",
            Currency.USDollar => "$",
            _ => string.Empty
        };

        string second = range.Second == -1 ? "∞" : range.Second.ToString();
        ret += $"{range.First} → {second}";
        return ret;
    }

    public static string FinalPrice(List<OfferData> cart, Currency finalCurrency)
    {
        string ret = finalCurrency switch
        {
            Currency.Euro => "€ ",
            Currency.USDollar => "$ ",
            Currency.GBPound => "£ ",
            _ => ""
        };

        decimal value = 0;
        foreach (OfferData item in cart)
        {
            value += ExchangeCurrency(item.Price?.Second ?? 0, item.Price?.First ?? Currency.Euro, Currency.Euro);
        }

        ret += Math.Round(value, 2).ToString();
        return ret;
    }

    public static string GetJavascriptSearch(SearchData searchData)
    {
        if (searchData == null)
            return "location.href = '/Home/OffersSearch?page=@page";

        string ret = "location.href = '/Home/OffersSearch?";
        bool ampersand = false;

        if (searchData.Brand != null && searchData.Brand.Length > 0)
        {
            ret += $"Brand={searchData.Brand}";
            ampersand = true;
        }

        if (searchData.Name != null && searchData.Name.Length > 0)
        {
            if (ampersand)
                ret += '&';
            ret += $"Name={searchData.Name}";
            ampersand = true;
        }

        if (searchData.TypeString != null && searchData.TypeString.Length > 0)
        {
            if (ampersand)
                ret += '&';
            ret += $"TypeString={searchData.TypeString}";
            ampersand = true;
        }
        if (searchData.PriceFrom != null && searchData.PriceFrom.Length > 0)
        {
            if (ampersand)
                ret += '&';
            ret += $"PriceFrom={searchData.PriceFrom}";
            ampersand = true;
        }
        if (searchData.PriceTo != null && searchData.PriceTo.Length > 0)
        {
            if (ampersand)
                ret += '&';
            ret += $"PriceTo={searchData.PriceTo}";
            ampersand = true;
        }
        if (searchData.CurrencyString != null && searchData.CurrencyString.Length > 0)
        {
            if (ampersand)
                ret += '&';
            ret += $"CurrencyString={searchData.CurrencyString}";
            ampersand = true;
        }

        if (ampersand)
            ret += '&';
        ret += "page=@page'";
        return ret;
	}

    public static List<T> Shuffle<T>(in List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = _random.Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }

        return list;
    }
}
