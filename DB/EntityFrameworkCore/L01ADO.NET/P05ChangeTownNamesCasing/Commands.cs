namespace P05ChangeTownNamesCasing
{
    public static class Commands
    {
        public const string UpdateTowns =
            @"UPDATE Towns
	            SET Name = UPPER(Name)
	            WHERE CountryCode = (SELECT Id FROM Countries WHERE Name = @CountryName)";

        public const string SelectTowns =
            @"SELECT Name 
	            FROM Towns 
	               WHERE CountryCode = (SELECT Id FROM Countries WHERE Name = @CountryName)";
    }
}
