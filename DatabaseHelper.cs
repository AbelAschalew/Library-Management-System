
using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace MiniProjectApp;

public class DatabaseHelper {
	private string connectionString = "Server=localhost;Database=dbvpcruiselibrary;Uid=AbelAschalew;Pwd=0112135990;";

	public void ExecuteNonQuery (string query) {
		using (MySqlConnection connection = new MySqlConnection(connectionString)) {
			MySqlCommand command = new MySqlCommand(query, connection);
			connection.Open();
			command.ExecuteNonQuery();
		}
	}

	public DataTable ExecuteQuery (string query) {
		DataTable dataTable = new DataTable();
		using (MySqlConnection connection = new MySqlConnection(connectionString)) {
			MySqlCommand command = new MySqlCommand(query, connection);
			MySqlDataAdapter adapter = new MySqlDataAdapter(command);
			adapter.Fill(dataTable);
		}
		return dataTable;
	}




	public (string userid, string username, string passwordHash, string userrole) GetUserCredentials(string query, string username)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@username", username);

        connection.Open();
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                return (reader["user_id"].ToString(), reader["username"].ToString(), reader["password_hash"].ToString(), reader["role"].ToString());
            }
        }
    }
    return (null, null, null, null); // Return null tuple if no match found
}



}
