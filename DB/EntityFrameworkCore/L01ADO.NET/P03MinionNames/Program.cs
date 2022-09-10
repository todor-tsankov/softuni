using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P03MinionNames
{
    public class Program
    {
        public static void Main()
        {
            var villainId = int.Parse(Console.ReadLine());

            var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                var cmd = new SqlCommand(Commands.SelectVillainsWithMinions, connection);
                cmd.Parameters.AddWithValue("@VillainId", villainId);

                var reader = cmd.ExecuteReader();

                using (reader)
                {
                    var sb = new StringBuilder();

                    if (!reader.HasRows)
                    {
                        sb.AppendLine($"No villain with ID {villainId} exists in the database.");
                    }
                    else
                    {
                        var counter = 1;

                        while (reader.Read())
                        {
                            if (counter == 1)
                            {
                                sb.AppendLine($"Villain: {reader["VillainName"]}");
                            }

                            sb.AppendLine($"{counter}. {reader["MinionName"]} {reader["Age"]}");
                            counter++;
                        }
                    }

                    Console.WriteLine(sb.ToString().TrimEnd());
                }
            }
        }
    }
}
