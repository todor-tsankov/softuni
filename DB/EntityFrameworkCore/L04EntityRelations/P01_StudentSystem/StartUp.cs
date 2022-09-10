using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new StudentSystemContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
