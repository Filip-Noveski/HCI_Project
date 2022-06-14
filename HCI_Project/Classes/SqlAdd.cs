namespace HCI_Project.Classes;

public class SqlAdd
{
	private static SqlAddFinishState OfferEntryPrivate(Dictionary<string, string> data)
    {
		if (data["brand"].Length > 64) return SqlAddFinishState.InvalidParameterBrand;
		if (data["name"].Length > 256) return SqlAddFinishState.InvalidParameterName;
		if (!double.TryParse(data["price"], out _)) return SqlAddFinishState.InvalidParameterPrice;

		string query = "INSERT INTO [AvailableOffers] " +
			"([Brand], [Name], [Price], [Type], [Age], [PublishTime], [Available], [Seller]) VALUES " +
			"(@Brand, @Name, @Price, @Type, @Age, @PublishTime, @Available, @Seller);";

		Dictionary<string, string> queryData = new()
		{
			{ "@Brand", data["brand"] },
			{ "@Name", data["name"] },
			{ "@Type", data["type"] },
			{ "@Price", $"{data["currency"]}:{data["price"]}" },
			{ "@Age", data["age"] },
			{ "@PublishTime", data["time"] },
			{ "@Available", true.ToString() },
			{ "@Seller", data["seller"] }
		};

		SqlShared.RunQuery(query, queryData);

		return SqlAddFinishState.Success;
	}

    public static Task<SqlAddFinishState> OfferEntry(Dictionary<string, string> data)
	{
		return Task.Run(() => OfferEntryPrivate(data));
	}
}

