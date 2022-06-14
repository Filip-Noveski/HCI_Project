namespace HCI_Project.Classes;

public class SqlRemove
{
    public static void Offer(string offerId)
    {
        string query = "DELETE FROM [AvailableOffers] WHERE [Id] = @OfferId";
        Dictionary<string, string> args = new()
        {
            { "@OfferId", offerId }
        };

        SqlShared.RunQuery(query, args);
    }
}
