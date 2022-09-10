using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace P05ChangeTownNamesCasing
{
    public class Program
    {
        public static void Main()
        {
            var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");
            var country = Console.ReadLine();

            using (connection)
            {
                connection.Open();

                var updateCmd = new SqlCommand(Commands.UpdateTowns, connection);
                updateCmd.Parameters.AddWithValue("@CountryName", country);

                var rowsAffected = updateCmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    Console.WriteLine("3 town names were affected.");

                    var selectTowns = new SqlCommand(Commands.SelectTowns, connection);
                    selectTowns.Parameters.AddWithValue("@CountryName", country);
                    var reader = selectTowns.ExecuteReader();

                    var towns = new List<string>();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader["Name"]);
                        }
                    }

                    Console.WriteLine($"[{string.Join(", ", towns)}]");
                }
            }
        }
    }
}
