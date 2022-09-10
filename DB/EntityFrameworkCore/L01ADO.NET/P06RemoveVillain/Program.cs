using System;
using Microsoft.Data.SqlClient;

namespace P06RemoveVillain
{
    public class Program
    {
        public static void Main()
        {
            var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true");

            using (connection)
            {

                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {
                    var villainId = int.Parse(Console.ReadLine());
                    var name = TakeVillainName(connection, transaction, villainId);

                    if (name == null)
                    {
                        Console.WriteLine("No such villain was found.");
                    }
                    else
                    {
                        Console.WriteLine($"{name} was deleted.");

                        var countMinionsFreed = FreeMinions(connection, transaction, villainId);
                        DeleteVillain(connection, transaction, villainId);

                        Console.WriteLine($"{countMinionsFreed} minions were released.");
                    }

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

        private static object TakeVillainName(SqlConnection connection, SqlTransaction transaction, int villainId)
        {
            var takeVillainName = new SqlCommand(Commands.TakeVillainName, connection);
            takeVillainName.Transaction = transaction;
            takeVillainName.Parameters.AddWithValue("@VillainId", villainId);

            var name = takeVillainName.ExecuteScalar();
            return name;
        }

        private static int FreeMinions(SqlConnection connection, SqlTransaction transaction, int villainId)
        {
            var freeMinions = new SqlCommand(Commands.FreeMinions, connection);
            freeMinions.Transaction = transaction;
            freeMinions.Parameters.AddWithValue("@VillainId", villainId);

            return freeMinions.ExecuteNonQuery();
        }

        private static void DeleteVillain(SqlConnection connection, SqlTransaction transaction, int villainId)
        {
            var deleteVillain = new SqlCommand(Commands.DeleteVillain, connection);

            deleteVillain.Transaction = transaction;
            deleteVillain.Parameters.AddWithValue("@VillainId", villainId);

            deleteVillain.ExecuteNonQuery();
        }
    }
}
