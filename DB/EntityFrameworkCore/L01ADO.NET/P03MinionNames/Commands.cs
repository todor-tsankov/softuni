namespace P03MinionNames
{
    public static class Commands
    {
        public const string SelectVillainsWithMinions =
			@"SELECT v.Name AS VillainName,
				     m.Name AS MinionName,
                     m.Age AS Age
				  FROM Villains AS v
				  JOIN MinionsVillains AS mv
				  	ON v.Id = mv.VillainId
				  JOIN Minions AS m
				  	ON mv.MinionId = m.Id
				  WHERE v.Id = @VillainId
				  ORDER BY m.Name";
    }
}
