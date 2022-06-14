using System.Data;
using HCI_Project.Models;

namespace HCI_Project.Classes;

public class Conversion
{
    public static Pair<Currency, decimal> ToPrice(string row)
    {
        string[] split = row.Split(':');
        Currency currency = split[0] switch
        {
            "eur" => Currency.Euro,
            "usd" => Currency.USDollar,
            "gbp" => Currency.GBPound,
            _ => throw new Exception("Invalid currency type.")
        };
        decimal price = decimal.Parse(split[1]);
        return new Pair<Currency, decimal>(currency, price);
    }

    public static SearchDataPartType ToPartType(string row)
    {
        return row switch
        {
            "none" => SearchDataPartType.None,
            "cpu" => SearchDataPartType.CPU,
            "graphicsCard" => SearchDataPartType.GraphicsCard,
            "ram" => SearchDataPartType.RAM,
            "hdd" => SearchDataPartType.HDD,
            "ssd" => SearchDataPartType.SSD,
            "keyboard" => SearchDataPartType.Keyboard,
            "monitor" => SearchDataPartType.Monitor,
            "mouse" => SearchDataPartType.Mouse,
            "speakers" => SearchDataPartType.Speakers,
            _ => throw new Exception("Invalid part type.")
        };
    }

    public static string FromPartType(SearchDataPartType partType)
    {
        return partType switch
        {
            SearchDataPartType.None => "none",
            SearchDataPartType.CPU => "cpu",
            SearchDataPartType.GraphicsCard => "graphicsCard",
            SearchDataPartType.RAM => "ram",
            SearchDataPartType.HDD => "hdd",
            SearchDataPartType.SSD => "ssd",
            SearchDataPartType.Keyboard => "keyboard",
            SearchDataPartType.Monitor => "monitor",
            SearchDataPartType.Mouse => "mouse",
            SearchDataPartType.Speakers => "speakers",
            _ => throw new Exception("Invalid part type.")
        };
    }

    public static SearchDataAge ToAge(string row)
    {
        return row switch
        {
            "new" => SearchDataAge.New,
            "new " => SearchDataAge.New,
            "lt6m" => SearchDataAge.LessThan6Months,
            "lt1y" => SearchDataAge.LessThan1Year,
            "lt2y" => SearchDataAge.LessThan2Years,
            "mt2y" => SearchDataAge.MoreThan2Years,
            _ => throw new Exception("Invalid age setting.")
        };
    }

    public static OfferData ToOfferData(DataRow dataRow)
    {
        return new OfferData()
        {
            Id = Convert.ToInt64(dataRow[0]),
            Brand = Convert.ToString(dataRow[1]) ?? string.Empty,
            Name = Convert.ToString(dataRow[2]) ?? string.Empty,
            Price = ToPrice(dataRow[3].ToString() ?? ":"),
            PartType = ToPartType(dataRow[4].ToString() ?? "none"),
            Age = ToAge(dataRow[5].ToString() ?? ""),
            PublishTime = Convert.ToDateTime(dataRow[6].ToString()),
            Available = Convert.ToBoolean(dataRow[7]),
            UserId = Convert.ToString(dataRow[8]) ?? string.Empty
        };
    }
    
    public static List<OfferData> ToOfferDataList(DataTable dataTable)
    {
        List<OfferData> list = new();
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            list.Add(ToOfferData(dataTable.Rows[i]));
        }
        return list;
    }
}
