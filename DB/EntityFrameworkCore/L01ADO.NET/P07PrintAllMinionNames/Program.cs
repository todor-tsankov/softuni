using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace P07PrintAllMinionNames
{
    public class Program
    {
        public static void Main()
        {
            var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");

            using (connection)
            {
                connection.Open();

                var getMinionNames = new SqlCommand(Commands.GetMinionNames, connection);
                var reader = getMinionNames.ExecuteReader();

                var minionNames = new List<string>();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = (string)reader["Name"];

                        minionNames.Add(name);
                    }
                }

                var count = minionNames.Count;

                for (int i = 0; i < count / 2; i++)
                {
                    Console.WriteLine(minionNames[i]);
                    Console.WriteLine(minionNames[count - i - 1]);
                }

                if (count % 2 != 0)
                {
                    Console.WriteLine(minionNames[count / 2]);
                }
            }
        }
    }
}
