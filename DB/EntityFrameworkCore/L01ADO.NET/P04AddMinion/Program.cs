using System;
using System.Linq;

using Microsoft.Data.SqlClient;

namespace P04AddMinion
{
    public class Program
    {
        public static void Main()
        {
            var minionInfo = ReadInfo();

            var minionName = minionInfo[1];
            var minionAge = int.Parse(minionInfo[2]);
            var minionTown = minionInfo[3];

            var villainInfo = ReadInfo();
            var villainName = villainInfo[1];

            var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");

            using (connection)
            {
                connection.Open();

                var transaction = connection.BeginTransaction();

                try
                {
                    var message = AddTownIfNeeded(minionTown, connection, transaction);
                    PrintMessage(message);

                    message = AddVillainIfNeeded(villainName, connection, transaction);
                    PrintMessage(message);

                    message = AddMinion(minionName, minionAge, minionTown, villainName, connection, transaction);
                    PrintMessage(message);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        private static void PrintMessage(string message)
        {
            if (message != null)
            {
                Console.WriteLine(message);
            }
        }

        private static string AddMinion(string minionName, int minionAge, string minionTown, string villainName, SqlConnection connection, SqlTransaction transaction)
        {
            var addMinion = new SqlCommand(Commands.AddMinion, connection);
            addMinion.Transaction = transaction;

            addMinion.Parameters.AddWithValue("@Name", minionName);
            addMinion.Parameters.AddWithValue("@Age", minionAge);
            addMinion.Parameters.AddWithValue("@TownName", minionTown);
            addMinion.Parameters.AddWithValue("@VillainName", villainName);

            addMinion.ExecuteNonQuery();

            return $"Successfully added {minionName} to be minion of {villainName}.";
        }

        private static string AddVillainIfNeeded(string villainName, SqlConnection connection, SqlTransaction transaction)
        {
            var villainsCheck = new SqlCommand(Commands.VillainsCheck, connection);
            villainsCheck.Transaction = transaction;
            villainsCheck.Parameters.AddWithValue("@VillainName", villainName);

            var villainReader = villainsCheck.ExecuteReader();

            using (villainReader)
            {
                if (!villainReader.HasRows)
                {
                    villainReader.Close();

                    var addVillain = new SqlCommand(Commands.AddVillain, connection);
                    addVillain.Transaction = transaction;
                    addVillain.Parameters.AddWithValue("@VillainName", villainName);

                    addVillain.ExecuteNonQuery();
                    return $"Villain {villainName} was added to the database.";
                }
            }

            return null;
        }

        private static string AddTownIfNeeded(string minionTown, SqlConnection connection, SqlTransaction transaction)
        {
            var townsCheck = new SqlCommand(Commands.TownsCheck, connection);
            townsCheck.Transaction = transaction;

            townsCheck.Parameters.AddWithValue("@TownName", minionTown);
            var townReader = townsCheck.ExecuteReader();

            using (townReader)
            {
                if (!townReader.HasRows)
                {
                    townReader.Close();

                    var addTown = new SqlCommand(Commands.AddTown, connection);
                    addTown.Transaction = transaction;
                    addTown.Parameters.AddWithValue("@TownName", minionTown);

                    addTown.ExecuteNonQuery();
                    return $"Town {minionTown} was added to the database.";
                }
            }

            return null;
        }

        private static string[] ReadInfo()
        {
            return Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();
        }
    }
}
