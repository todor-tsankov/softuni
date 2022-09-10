namespace P06RemoveVillain
{
    public static class Commands
    {
        public const string TakeVillainName =
            @"SELECT Name
                FROM Villains
                WHERE Id = @VillainId";

        public const string DeleteVillain =
            @"DELETE
	            FROM Villains
	            WHERE Id = @VillainId";

        public const string FreeMinions =
            @"DELETE
	            FROM MinionsVillains
	               WHERE VillainId = @VillainId";
    }
}
