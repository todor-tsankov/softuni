using System;
using Microsoft.Data.SqlClient;

namespace P01InitialSetup
{
    public class Program
    {
        public static void Main()
        {
            var connection = new SqlConnection("Server=.;Database=master;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                var createDb = new SqlCommand(Commands.CreateDatabase, connection);

                createDb.ExecuteNonQuery();
            }

            connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                var createTables = new SqlCommand(Commands.CreateTables, connection);
                createTables.ExecuteNonQuery();

                var insertData = new SqlCommand(Commands.InsertValues, connection);
                insertData.ExecuteNonQuery();
            }
        }
    }
}
