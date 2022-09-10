namespace P04AddMinion
{
    public static class Commands
    {
        public const string TownsCheck =
            @"SELECT *
	            FROM Towns
	            WHERE Name = @TownName";

        public const string AddTown =
            @"INSERT INTO Towns(Name)
	            VALUES(@TownName)";

        public const string VillainsCheck =
            @"SELECT *
	            FROM Villains
	            WHERE Name = @VillainName";

        public const string AddVillain =
            @"INSERT INTO Villains(Name)
	            VALUES(@VillainName)";

        public const string AddMinion =
            @"INSERT INTO Minions(Name, Age, TownId)
	            VALUES(@Name, @Age, (SELECT Id FROM Towns WHERE Name = @TownName))

              INSERT INTO MinionsVillains(MinionId, VillainId)
              	VALUES((SELECT COUNT(*) FROM Minions),
              	       (SELECT COUNT(*) FROM Villains))";
    }
}
