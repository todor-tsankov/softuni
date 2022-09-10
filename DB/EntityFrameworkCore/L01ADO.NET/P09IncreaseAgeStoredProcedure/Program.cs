using System;
using Microsoft.Data.SqlClient;

namespace P09IncreaseAgeStoredProcedure
{
    public class Program
    {
        public  static void Main()
        {
            var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");

            using (connection)
            {
                connection.Open();
                var minionId = int.Parse(Console.ReadLine());

                var execProcedure = new SqlCommand(Commands.UpdateAge, connection);

                execProcedure.Parameters.AddWithValue("@MinionId", minionId);
                execProcedure.ExecuteNonQuery();

                var selectNameAge = new SqlCommand(Commands.SelectMinionNameAge, connection);
                selectNameAge.Parameters.AddWithValue("@MinionId", minionId);

                var reader = selectNameAge.ExecuteReader();

                object name;
                object age;

                using (reader)
                {
                    reader.Read();

                    name = reader["Name"];
                    age = reader["Age"];
                }

                Console.WriteLine($"{name} – {age} years old");
            }
        }
    }
}
