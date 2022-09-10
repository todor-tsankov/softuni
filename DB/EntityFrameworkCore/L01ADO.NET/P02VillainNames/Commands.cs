namespace P02VillainNames
{
    public static class Commands
    {
        public const string SelectVillainsWithMinionsCount =
            @"SELECT v.Name,
                     COUNT(mv.MinionId) AS MinionsCount
	              FROM Villains AS v
	              JOIN MinionsVillains AS mv
	              	ON v.Id = mv.VillainId
	              GROUP BY v.Id, v.Name
	              HAVING COUNT(mv.MinionId) > 3
	              ORDER BY COUNT(mv.MinionId) DESC";
    }
}
