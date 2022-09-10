using System;
using Microsoft.Data.SqlClient;

namespace P02VillainNames
{
    public class Program
    {
        public static void Main()
        {
            var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                var selectCommand = new SqlCommand(Commands.SelectVillainsWithMinionsCount, connection);
                var reader = selectCommand.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var result = $"{reader["Name"]} - {reader["MinionsCount"]}";

                        Console.WriteLine(result);
                    }
                }
            }
        }
    }
}
