namespace P09IncreaseAgeStoredProcedure
{
    public static class Commands
    {
        public const string UpdateAge =
            @"EXEC usp_GetOlder @MinionId";

        public const string SelectMinionNameAge =
            @"SELECT Name, Age
                FROM Minions
                WHERE Id = @MinionId";
    }
}
