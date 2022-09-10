USE SoftUni

GO

SELECT TOP(5)
       e.EmployeeID,
       e.JobTitle,
	   e.AddressID,
	   a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	ORDER BY e.AddressID

GO

SELECT TOP(50)
       e.FirstName,
	   e.LastName,
	   t.[Name] AS Town,
	   a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a
		ON e.AddressID = a.AddressID
	JOIN Towns AS t
		ON a.TownID = t.TownID
	ORDER BY e.FirstName, e.LastName

GO

SELECT e.EmployeeID,
       e.FirstName,
       e.LastName,
	   d.Name
	FROM Employees AS e
	JOIN Departments AS d
		ON E.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	ORDER BY e.EmployeeID

GO

SELECT TOP(5)
       e.EmployeeID,
	   e.FirstName,
	   e.Salary,
	   d.Name AS DepartmentName
	FROM Employees AS e
	JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY e.DepartmentID

GO

SELECT TOP(3)
       e.EmployeeID,
       e.FirstName
	FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep
		ON e.EmployeeID = ep.EmployeeID
	WHERE ep.ProjectID IS NULL 
	ORDER BY e.EmployeeID

GO

SELECT e.FirstName,
       e.LastName,
	   e.HireDate,
	   d.Name AS DeptName
	FROM Employees AS e
	JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1999-1-1'
		AND (d.Name = 'Sales' OR d.Name = 'Finance')
	ORDER BY e.HireDate

GO

SELECT TOP(5)
       e.EmployeeID,
	   e.FirstName,
	   p.Name AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep
		ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p
		ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

GO

SELECT e.EmployeeID,
       e.FirstName,
	   (CASE
			WHEN DATEPART(YEAR, p.StartDate) >= 2005
				THEN NULL
			ELSE p.Name
		END) AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep
		ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p
		ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

GO

SELECT e.EmployeeID,
       e.FirstName,
	   e.ManagerID,
	   m.FirstName
	FROM Employees AS e
	JOIN Employees AS m
		ON e.ManagerID = m.EmployeeID
	WHERE e.ManagerID IN(3, 7)
	ORDER BY e.EmployeeID

GO

SELECT TOP(50)
       e.EmployeeID,
	   e.FirstName + ' ' + e.LastName AS EmployeeName,
	   m.FirstName + ' ' + m.LastName AS ManagerName,
	   d.Name AS DepartmentName
	FROM Employees AS e
	JOIN Employees AS m
		ON e.ManagerID = m.EmployeeID
	JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID

GO

SELECT TOP(1)
       AVG(e.Salary) AS MinAverageSalary
	FROM Employees AS E
	GROUP BY DepartmentID
	ORDER BY AVG(e.Salary)

GO

USE Geography

GO

SELECT mc.CountryCode,
       m.MountainRange,
       p.PeakName,
       p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m
		ON p.MountainId = m.Id
	JOIN MountainsCountries AS mc
		ON m.Id = mc.MountainId
	WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC

GO

SELECT mc.CountryCode,
       COUNT(mc.MountainId) AS MountainRanges
	FROM MountainsCountries AS mc
	JOIN Countries AS c
		ON mc.CountryCode = c.CountryCode
	WHERE c.CountryName IN('United States', 'Russia', 'Bulgaria')
	GROUP BY mc.CountryCode

GO

SELECT TOP(5)
       c.CountryName,
	   r.RiverName
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS rc
		ON c.CountryCode = rc.CountryCode
	LEFT JOIN Rivers AS r
		ON rc.RiverId = r.Id
	LEFT JOIN Continents AS con
		ON c.ContinentCode = con.ContinentCode
    WHERE con.ContinentName = 'Africa'
	ORDER BY c.CountryName

GO

SELECT TMP.ContinentCode,
       MAX(TMP.CurrencyCode) AS CurrencyCode,
	   (SELECT * FROM TMP WHERE TMP.CurrencyUsage = MAX(TMP.CurrencyUsage)) AS CurrencyUsage
	FROM
	(SELECT con.ContinentCode,
		   cou.CurrencyCode,
		   COUNT(*) AS CurrencyUsage
		FROM Continents AS con
		JOIN Countries AS cou
			ON con.ContinentCode = cou.ContinentCode
		GROUP BY con.ContinentCode, cou.CurrencyCode) AS TMP
	WHERE TMP.CurrencyUsage > 1
	GROUP BY TMP.ContinentCode
	ORDER BY TMP.ContinentCode

GO

SELECT TMP.ContinentCode,
       TMP.CurrencyCode,
	   TMP.CurrencyUsage
	FROM
	(SELECT con.ContinentCode,
	        cou.CurrencyCode,
		    COUNT(cou.CurrencyCode) AS CurrencyUsage,
	        DENSE_RANK() OVER (PARTITION BY con.ContinentCode ORDER BY COUNT(cou.CurrencyCode) DESC) AS [Rank]
		FROM Continents AS con
		JOIN Countries AS cou
			ON con.ContinentCode = cou.ContinentCode
		GROUP BY con.ContinentCode, cou.CurrencyCode
		HAVING COUNT(cou.CurrencyCode) > 1) AS TMP
	WHERE [TMP].Rank = 1
	ORDER BY TMP.ContinentCode

GO

SELECT COUNT(*) AS [Count]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode
	WHERE mc.CountryCode IS NULL

GO

SELECT TOP(5)
       c.CountryName,
	   MAX(p.Elevation) AS HighestPeakElevation,
	   MAX(r.Length) AS LongestRiverLength
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m
		ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p
		ON m.Id = p.MountainId
	LEFT JOIN CountriesRivers AS cr
		ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r
		ON cr.RiverId = r.Id
	GROUP BY c.CountryName
	ORDER BY MAX(p.Elevation) DESC, 
	         MAX(r.Length) DESC, 
			 c.CountryName
GO

SELECT 
       c.CountryName AS Country,
	   ISNULL((SELECT [PeakName] FROM Peaks WHERE Elevation = MAX(p.Elevation)), '(no highest peak)') AS [Highest Peak Name],
	   ISNULL(MAX(p.Elevation),  0) AS [Highest Peak Elevation],
	   ISNULL((SELECT MountainRange FROM Mountains WHERE Id = (SELECT [MountainId] FROM Peaks WHERE Elevation = MAX(p.Elevation))), '(no mountain)') AS [Mountain]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m
		ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p
		ON mc.MountainId = p.MountainId
	GROUP BY c.CountryName
	ORDER BY c.CountryName, (SELECT [PeakName] FROM Peaks WHERE Elevation = MAX(p.Elevation))

GO

SELECT  Ranked.ContinentCode,
        Ranked.CurrencyCode,
		Ranked.CurrencyUsage
	FROM
	(SELECT c.ContinentCode,
	        c.CurrencyCode,
		   COUNT(*) AS CurrencyUsage,
		   DENSE_RANK() 
			OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(*) DESC) AS [Rank]
		FROM Countries AS c
		GROUP BY c.ContinentCode, c.CurrencyCode
		HAVING COUNT(*) > 1) AS Ranked
	WHERE Ranked.[Rank] = 1

GO

SELECT COUNT(*) 
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON  c.CountryCode = mc.CountryCode
	WHERE mc.MountainId IS NULL

GO

SELECT TOP(5)
       c.CountryName,
       MAX(p.Elevation) AS HighestPeakElevation,
	   MAX(r.Length) AS LongestRiverLength
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m
		ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p
		ON m.Id = p.MountainId
	LEFT JOIN CountriesRivers AS cr
		ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r
		ON cr.RiverId = r.Id
	GROUP BY c.CountryName
	ORDER BY HighestPeakElevation DESC, 
	         LongestRiverLength DESC, 
			 c.CountryName ASC

GO

SELECT TOP(5)
       Ranked.CountryName,
       Ranked.[Highest Peak Name],
	   Ranked.[Highest Peak Elevation],
	   Ranked.Mountain
	FROM
	(SELECT TOP(5)
	       c.CountryName,
		   ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
		   ISNULL(p.Elevation, 0) AS [Highest Peak Elevation],
		   ISNULL(m.MountainRange, '(no mountain)') AS Mountain,
		   DENSE_RANK() 
			OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Rank]
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc
			ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m
			ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p
			ON m.Id = p.MountainId
		ORDER BY c.CountryName, p.PeakName) AS Ranked
	WHERE Ranked.Rank = 1