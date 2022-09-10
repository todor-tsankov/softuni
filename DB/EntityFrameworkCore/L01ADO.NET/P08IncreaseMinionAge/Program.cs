using Microsoft.Data.SqlClient;
using System;

namespace P08IncreaseMinionAge
{
    public class Program
    {
        public static void Main()
        {
            var parameterName = "@ID";
            var connectionStr = "Server=.;Database=MinionsDB;Integrated Security=true";
            var connection = new SqlConnection(connectionStr);

            using (connection)
            {
                connection.Open();

                var ids = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var id in ids)
                {
                    ExecuteCommand(connection, Commands.IncreaseAgeByOne, id, parameterName);
                    ExecuteCommand(connection, Commands.SetNameUpper, id, parameterName);
                }

                var selectNamesAges = new SqlCommand(Commands.SelectMinionNames, connection);
                var reader = selectNamesAges.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }

        private static void ExecuteCommand(SqlConnection connection, string command, string parameter, string paramterName)
        {
            var cmd = new SqlCommand(command, connection);
            cmd.Parameters.AddWithValue(paramterName, parameter);

            cmd.ExecuteNonQuery();
        }
    }
}
