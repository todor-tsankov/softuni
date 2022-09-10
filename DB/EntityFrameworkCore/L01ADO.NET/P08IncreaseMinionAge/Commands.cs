namespace P08IncreaseMinionAge
{
    public static class Commands
    {
        public const string IncreaseAgeByOne =
            @"UPDATE Minions
                SET Age += 1
                WHERE Id = @ID
            ";

        public const string SetNameUpper =
            @"UPDATE Minions 
                SET Name = UPPER(LEFT(Name, 1)) + LOWER(SUBSTRING(Name, 2, LEN(Name) - 1))
	            FROM Minions
                WHERE Id = @ID";

        public const string SelectMinionNames =
            @"SELECT Name, Age
                FROM Minions";
    }
}
