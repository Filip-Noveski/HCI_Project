using System.Data;
using HCI_Project.Models;

namespace HCI_Project.Classes;

public class SqlGet
{
    public static int OfferId(DateTime publishTime, string sellerId)
    {
        string query = "SELECT [Id] FROM [AvailableOffers] " +
            "WHERE [PublishTime] = @PublishTime AND [Seller] = @Seller";

        Dictionary<string, string> data = new()
        {
            { "@PublishTime", publishTime.ToString() },
            { "@Seller", sellerId }
        };

        if (int.TryParse(SqlShared.GetData(query, data).Rows[0][0].ToString(), out int value))
            return value;
        else
            return -1;
    }

    public static OfferData OfferData(int offerId)
    {
        string query = "SELECT * FROM [AvailableOffers] WHERE [Id] = @Id";
        Dictionary<string, string> args = new()
        {
            { "@Id", offerId.ToString() }
        };

        DataTable table = SqlShared.GetData(query, args);

        return Conversion.ToOfferData(table.Rows[0]);
    }

    public static List<OfferData> OfferData(int[] offerIds)
    {
        List<OfferData> offers = new();

        foreach (int offerId in offerIds)
        {
            offers.Add(OfferData(offerId));
        }

        return offers;
    }

    public static List<OfferData> OfferData()
    {
        string query = "SELECT * FROM [AvailableOffers]";
        Dictionary<string, string> args = new();

        DataTable table = SqlShared.GetData(query, args);

        return Conversion.ToOfferDataList(table);
    }

    private static bool IsInPriceRange(decimal price, Pair<decimal, decimal> range)
    {
        return price >= range.First && (price <= range.Second || range.Second == -1);
    }

    public static List<OfferData> OfferData(SearchData searchData)
    {
        string type = searchData.Type == SearchDataPartType.None 
            ? string.Empty 
            : searchData.Type.ToString();
        string query = "SELECT * FROM [AvailableOffers]" +
            $"WHERE [Brand] LIKE @Brand AND [Name] LIKE @Name " +
            $"AND [Type] LIKE @Type";
        Dictionary<string, string> args = new()
        {
            { "@Brand", $"%{searchData.Brand}%" },
            { "@Name", $"%{searchData.Name}%" },
            { "@Type", $"%{type}%" }
        };

        DataTable table = SqlShared.GetData(query, args);

        List<OfferData> ret = Conversion.ToOfferDataList(table);
        if (searchData.PriceRange is null)
            return ret;

        for (int i = 0; i <= ret.Count - 1; i++)
        {
            if (IsInPriceRange(ret[i].Price!.Second, searchData.PriceRange))
                continue;

            ret.RemoveAt(i--);
        }
        return ret;
    }
}
