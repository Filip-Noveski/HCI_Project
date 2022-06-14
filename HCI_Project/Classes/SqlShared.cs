using System.Data;
using Microsoft.Data.SqlClient;

namespace HCI_Project.Classes;

public class SqlShared
{
	private static readonly WebApplicationBuilder _builder = 
		WebApplication.CreateBuilder();
	private static readonly string _conString = 
		_builder.Configuration.GetConnectionString("DefaultConnection");

    public static string RunStoredProcedure(string procedureName, Dictionary<string, string> args)
    {
        SqlConnection connection = new(_conString);
        SqlCommand command = new()
		{
            Connection = connection,
            CommandType = CommandType.StoredProcedure,
            CommandText = procedureName
        };
        connection.Open();

        foreach (KeyValuePair<string, string> arg in args)
        {
            command.Parameters.AddWithValue(arg.Key, arg.Value);
        }

        var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
        returnParameter.Direction = ParameterDirection.ReturnValue;

        command.ExecuteNonQuery();
        connection.Close();

        return returnParameter?.ToString()!;
    }

    public static void RunQuery(string query, Dictionary<string, string> args)
    {
        if (args == null)
            args = new Dictionary<string, string>();

		using SqlConnection connection = new(_conString);
		using SqlCommand command = new(query, connection);

		connection.Open();
		foreach (var arg in args)
		{
			command.Parameters.AddWithValue(arg.Key, arg.Value);
		}

		command.ExecuteNonQuery();
	}

    public static DataTable GetData(string query, Dictionary<string, string> args)
    {
        DataTable dt = new();
        if (args == null)
            args = new Dictionary<string, string>();

        using (SqlConnection connection = new(_conString))
        using (SqlCommand command = new(query, connection))
        using (SqlDataAdapter adapter = new(command))
        {
            connection.Open();
            foreach (var arg in args)
            {
                command.Parameters.AddWithValue(arg.Key, arg.Value);
            }
            adapter.Fill(dt);
        }

        return dt;
    }
}

