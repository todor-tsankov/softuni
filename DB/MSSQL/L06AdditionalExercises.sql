USE Diablo

GO

SELECT RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider],
       COUNT(*) AS [Number Of Users]
	FROM Users
	GROUP BY RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
	ORDER BY COUNT(*) DESC , RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))

GO

SELECT g.[Name] AS Game,
       gt.Name AS [Game Type],
	   u.Username,
	   ug.Level,
	   ug.Cash,
	   c.Name AS Character
	FROM Games AS g
	JOIN GameTypes AS gt
		ON g.GameTypeId = gt.Id
	JOIN UsersGames AS ug
		ON g.Id = ug.GameId
	JOIN Users AS u
		ON ug.UserId = u.Id
	JOIN Characters AS c
		ON ug.CharacterId = c.Id
	ORDER BY ug.Level DESC, u.Username, g.Name

GO

SELECT u.Username,
       g.Name AS [Game],
	   COUNT(i.Id) AS [Items Count],
	   SUM(i.Price) AS [Items Price]
	FROM Users AS u
	JOIN UsersGames AS ug
		ON u.Id = ug.UserId
	JOIN Games AS g
		ON ug.GameId = g.Id
	JOIN UserGameItems AS ugi
		ON ug.Id = ugi.UserGameId
	JOIN Items AS i
		ON ugi.ItemId = i.Id
	GROUP BY u.Username, g.Name
	HAVING COUNT(i.Id) >= 10
	ORDER BY COUNT(i.Id) DESC, SUM(i.Price) DESC, u.Username

GO

SELECT * FROM
	(SELECT u.Username,
	       g.Name AS Game,
		   MAX(c.Name) AS Character,
		   SUM(its.Strength) + MAX(cs.Strength) + MAX(gts.Strength) AS Strength,
		   SUM(its.Defence) + MAX(cs.Defence) + MAX(gts.Defence)    AS Defence,
		   SUM(its.Speed) + MAX(cs.Speed) + MAX(gts.Speed)          AS Speed,
		   SUM(its.Mind) + MAX(cs.Mind) + MAX(gts.Mind)             AS Mind,
		   SUM(its.Luck) + MAX(cs.Luck) + MAX(gts.Luck)             AS Luck
		FROM Users as u
		JOIN UsersGames AS ug
			ON u.Id = ug.UserId
		JOIN Games AS g
			ON ug.GameId = g.Id
		JOIN GameTypes AS gt
			ON g.GameTypeId = gt.Id
		JOIN [Statistics] AS gts
			ON gt.BonusStatsId= gts.Id
		JOIN Characters AS c
			ON ug.CharacterId = c.Id
		JOIN [Statistics] AS cs
			ON c.StatisticId= cs.Id
		JOIN UserGameItems AS ugi
			ON ug.Id = ugi.UserGameId
		JOIN Items AS i
			ON ugi.ItemId = i.Id
		JOIN [Statistics] AS its
			ON i.StatisticId = its.Id
		GROUP BY u.Username, g.Name) AS TMP
	ORDER BY Strength DESC,
	         Defence DESC, 
			 Speed DESC, 
			 Mind DESC, 
			 Luck DESC

GO

SELECT i.Name,
	   i.Price,
	   i.MinLevel,
	   s.Strength,
	   s.Defence,
	   s.Speed,
	   s.Luck,
	   s.Mind
	FROM Items i
	JOIN [Statistics] AS s
		ON i.StatisticId = s.Id
	WHERE s.Speed > (SELECT AVG(Speed)
						FROM Items 
						JOIN [Statistics] 
							ON i.StatisticId = s.Id)
		AND s.Luck > (SELECT AVG(Luck)
						FROM Items 
						JOIN [Statistics] 
							ON i.StatisticId = s.Id)
		and s.Mind >(SELECT AVG(Mind)
						FROM Items 
						JOIN [Statistics] 
							ON i.StatisticId = s.Id)
	ORDER BY i.Name

GO

SELECT i.Name AS Item,
       i.Price,
	   i.MinLevel,
	   gt.Name AS [Forbidden Game Type]
	FROM Items AS i
	LEFT JOIN GameTypeForbiddenItems gtfi
		ON i.Id = gtfi.ItemId
	LEFT JOIN GameTypes AS gt
		ON gtfi.GameTypeId = gt.Id
	ORDER BY gt.Name DESC, i.Name

GO

SELECT  ugi.UserGameId,
        (SELECT Id 
	FROM Items
	WHERE Name = 'Blackguard'
		OR Name = 'Bottomless Potion of Amplification'
		OR Name = 'Eye of Etlich (Diablo III)'
		OR Name = 'Gem of Efficacious Toxin'
		OR Name = 'Golden Gorget of Leoric'
		OR Name = 'Hellfire Amulet')
		FROM Users AS u
		JOIN UsersGames AS ug
			ON u.Id = ug.UserId
		JOIN Games AS g
			ON ug.GameId = g.Id
		JOIN UserGameItems AS ugi
			ON ug.Id = ugi.UserGameId
		JOIN Items AS i
			ON ugi.ItemId = i.Id
		WHERE u.Username = 'Alex'
			AND g.Name = 'Edinburgh'

SELECT Id 
	FROM Items
	WHERE Name = 'Blackguard'
		OR Name = 'Bottomless Potion of Amplification'
		OR Name = 'Eye of Etlich (Diablo III)'
		OR Name = 'Gem of Efficacious Toxin'
		OR Name = 'Golden Gorget of Leoric'
		OR Name = 'Hellfire Amulet'

INSERT INTO UserGameItems(UserGameId, ItemId)
	VALUES(235, 51),
	      (235, 71),
		  (235, 157),
		  (235, 184),
		  (235, 197),
		  (235, 223)

UPDATE UsersGames
	SET Cash -= (SELECT SUM(Price) 
					FROM Items 
					WHERE Id IN (51, 71, 157, 184, 197, 223))
	WHERE GameId = 235

SELECT u.Username,
      g.Name,
	  REPLICATE('*', CHARINDEX('.', ug.Cash) - 1) + '.**'  AS Cash,
	  Cash,
	  i.Name AS [Item Name]
	FROM Users AS u
	LEFT JOIN UsersGames AS ug
		ON u.Id = ug.UserId
	LEFT JOIN Games AS g
		ON ug.GameId = g.Id
	LEFT JOIN UserGameItems AS ugi
		ON ug.Id = ugi.UserGameId
	LEFT JOIN Items AS i
		ON ugi.ItemId = i.Id
	WHERE g.Name = 'Edinburgh'
	ORDER BY i.Name

GO

USE Geography

GO

SELECT p.PeakName,
       m.MountainRange AS Mountain,
	   p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m
		ON p.MountainId = m.Id
	ORDER BY p.Elevation DESC, p.PeakName

GO

SELECT p.PeakName,
       m.MountainRange AS Mountain,
	   c.CountryName,
	   con.ContinentName
	FROM Peaks AS p
	JOIN Mountains AS m
		ON p.MountainId = m.Id
	JOIN MountainsCountries AS mc
		ON m.Id = mc.MountainId
	JOIN Countries AS c
		ON mc.CountryCode = c.CountryCode
	JOIN Continents AS con
		ON c.ContinentCode = con.ContinentCode
	ORDER BY p.PeakName, c.CountryName

GO

SELECT c.CountryName,
       con.ContinentName,
	   COUNT(r.Id) AS RiversCount,
	   ISNULL(SUM(r.Length), 0) AS TotalLength
	FROM Countries AS c
	LEFT JOIN Continents AS con
		ON c.ContinentCode = con.ContinentCode
	LEFT JOIN CountriesRivers AS cr
		ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r
		ON cr.RiverId = r.Id
	GROUP BY c.CountryName, con.ContinentName
	ORDER BY  COUNT(*) DESC, SUM(r.Length) DESC, c.CountryName

GO

SELECT cu.CurrencyCode,
       cu.Description AS Currency,
	   COUNT(co.CountryCode) AS NumberOfCountries
	FROM Currencies cu
	LEFT JOIN Countries AS co
		ON cu.CurrencyCode = co.CurrencyCode
	GROUP BY cu.CurrencyCode, cu.Description
	ORDER BY COUNT(co.CountryCode) DESC, cu.Description

GO

SELECT con.ContinentName,
       SUM(CONVERT(BIGINT, cou.AreaInSqKm)) AS CountriesArea,
       SUM(CONVERT(BIGINT,cou.Population)) AS CountriesPopulation
	FROM Continents AS con
	JOIN Countries AS cou
		ON con.ContinentCode = cou.ContinentCode
	GROUP BY con.ContinentName
	ORDER BY SUM(CONVERT(BIGINT, cou.Population)) DESC

GO

CREATE TABLE Monasteries(
	Id INT PRIMARY KEY IDENTITY, 
	Name NVARCHAR(50) NOT NULL, 
	CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode) NOT NULL
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')


--ALTER TABLE Countries
--	ADD IsDeleted BIT DEFAULT 0 NOT NULL

UPDATE Countries
	SET IsDeleted = 1
	WHERE (SELECT COUNT(*)
				FROM CountriesRivers AS cr
				JOIN Rivers AS r
					ON cr.RiverId = r.Id
				WHERE cr.CountryCode = Countries.CountryCode) > 3

SELECT m.Name AS Monastery,
       c.CountryName AS Country
	FROM Monasteries AS m
	JOIN Countries AS c
		ON m.CountryCode = c.CountryCode
	WHERE c.IsDeleted = 0
	ORDER BY m.Name

GO

UPDATE Countries
	SET CountryName = 'Burma'
	WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode)
	VALUES ('Hanga Abbey', (SELECT CountryCode 
								FROM Countries 
								WHERE CountryName = 'Tanzania'))

INSERT INTO Monasteries(Name, CountryCode)
	VALUES('Myin-Tin-Daik', (SELECT CountryCode 
								FROM Countries 
								WHERE CountryName IN('Myanmar', 'Burma')))

SELECT con.ContinentName,
       cou.CountryName,
	   COUNT(m.Id) AS MonasteriesCount
	FROM Continents AS con
		LEFT JOIN Countries AS cou
			ON con.ContinentCode = cou.ContinentCode
		LEFT JOIN Monasteries AS m
			ON cou.CountryCode = m.CountryCode
		WHERE cou.IsDeleted = 0
	GROUP BY con.ContinentName, cou.CountryName
	ORDER BY COUNT(m.Id) DESC, cou.CountryName