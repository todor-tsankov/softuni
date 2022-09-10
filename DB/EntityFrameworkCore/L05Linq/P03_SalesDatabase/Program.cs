using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System;

namespace P03_SalesDatabase
{
    public class Program
    {
        public static void Main()
        {
            var db = new SalesContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
        }
    }
}
