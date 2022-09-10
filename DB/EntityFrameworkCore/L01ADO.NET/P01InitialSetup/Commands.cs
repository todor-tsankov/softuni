namespace P01InitialSetup
{
    public static class Commands
    {
        public const string CreateDatabase = "CREATE DATABASE MinionsDB";

        public const string CreateTables =
			@"CREATE TABLE Countries(
				Id int IDENTITY PRIMARY KEY,
				Name nvarchar(50) NOT NULL,
			)

			CREATE TABLE Towns(
				Id int IDENTITY PRIMARY KEY,
				Name nvarchar(50) NOT NULL,
				CountryCode int REFERENCES Countries(Id)
			)

			CREATE TABLE Minions(
				Id int IDENTITY PRIMARY KEY,
				Name nvarchar(50) NOT NULL,
				Age tinyint NOT NULL CHECK(Age >= 0),
				TownId int REFERENCES Towns(Id) NOT NULL
			)
			
			CREATE TABLE EvilnessFactors(
				Id int IDENTITY PRIMARY KEY,
				Name nvarchar(10) NOT NULL CHECK(Name IN('super good', 'good', 'bad', 'evil', 'super evil'))
			)
			
			CREATE TABLE Villains(
				Id int IDENTITY PRIMARY KEY,
				Name nvarchar(50) NOT NULL,
				EvilnessFactorId int REFERENCES EvilnessFactors(Id)
			)
			
			CREATE TABLE MinionsVillains(
				MinionId int REFERENCES Minions(Id) NOT NULL,
				VillainId int REFERENCES Villains(Id) NOT NULL,
				PRIMARY KEY(MinionId, VillainId)
			)";

		public const string InsertValues =
			@"INSERT INTO Countries(Name)
				VALUES('Bulgaria'),
				      ('USA'),
					  ('France'),
					  ('Germany'),
					  ('Spain')

			INSERT INTO Towns(Name, CountryCode)
				VALUES('Sofia', 1),
				      ('New York', 2),
					  ('Paris', 3),
					  ('Berlin', 4),
					  ('Oliana', 5)
			
			INSERT INTO Minions(Name, Age, TownId)
				VALUES('Toshko', 20, 1),
				      ('Richard', 15, 2),
					  ('Rene', 69, 3),
					  ('Peter', 50, 4),
					  ('Miguel', 22, 5)
			
			INSERT INTO EvilnessFactors(Name)
				VALUES('super good'), 
				      ('good'), 
					  ('bad'), 
					  ('evil'), 
					  ('super evil')
			
			INSERT INTO Villains(Name, EvilnessFactorId)
				VALUES('Gosho', 1),
				      ('Pesho', 2),
					  ('Zamcho', 3),
					  ('Zamfircho', 4),
					  ('Kircho', 5)
			
			INSERT INTO MinionsVillains(MinionId, VillainId)
				VALUES(1, 1),
				      (2, 1),
					  (3, 2),
					  (4, 2),
					  (5, 3)";
    }
}
