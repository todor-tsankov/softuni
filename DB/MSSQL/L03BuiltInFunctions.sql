USE SoftUni

GO

SELECT FirstName, LastName
	FROM Employees
	WHERE FirstName LIKE 'SA%'

GO

SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

GO

SELECT FirstName
	FROM Employees
	WHERE (DepartmentID = 3 OR DepartmentID = 10) 
	      AND DATEPART(YEAR, HireDate) >= 1995
		  AND DATEPART(YEAR, HireDate) <= 2005

GO

SELECT FirstName, LastName
	FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

GO

SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) = 5
	   OR LEN([Name]) = 6
	ORDER BY [Name]

GO

SELECT TownId, [Name]
	FROM Towns
	WHERE [Name] LIKE 'M%'
	   OR [Name] LIKE 'K%'
	   OR [Name] LIKE 'B%'
	   OR [Name] LIKE 'E%'
	ORDER BY [Name]

GO

SELECT TownId, [Name]
	FROM Towns
	WHERE [Name] NOT LIKE 'R%'
	  AND [Name] NOT LIKE 'B%'
	  AND [Name] NOT LIKE 'D%'
	ORDER BY [Name]

GO

CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName
		FROM Employees
		WHERE DATEPART(YEAR, HireDate) > 2000

GO

SELECT FirstName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5

GO

SELECT EmployeeID, 
       FirstName, 
	   LastName, 
	   Salary, 
	   DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary >= 10000 AND Salary <= 50000 
	ORDER BY Salary DESC

GO

SELECT * FROM
	(SELECT EmployeeID, 
	        FirstName, 
		    LastName, 
		    Salary, 
		    DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
		FROM Employees
		WHERE Salary >= 10000 AND Salary <= 50000
		) AS temp
	WHERE [Rank] = 2
	ORDER BY Salary DESC
GO

USE [Geography]

GO

SELECT CountryName, 
      [IsoCode] AS [ISO Code]
	FROM Countries
	WHERE CountryName LIKE '%A%A%A%'
	ORDER BY IsoCode

GO

SELECT DISTINCT
       PeakName, 
       RiverName, 
	   LOWER(LEFT(PeakName, LEN(PeakName) - 1) + RiverName) AS Mix
	FROM Peaks
	JOIN Rivers ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix

GO

USE Diablo

GO

SELECT TOP(50)
       [Name],
       FORMAT([Start], 'yyyy-MM-dd') AS [Start]
	FROM Games
	WHERE DATEPART(YEAR, [Start]) = 2011 
	   OR DATEPART(YEAR, [Start]) = 2012
	ORDER BY [Start]

GO

SELECT Username, 
       SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider], Username

GO

SELECT Username, 
       IpAddress AS [IP Address]
	FROM Users
	WHERE IpAddress LIKE '___.1%.%.___'
	ORDER BY Username

GO

SELECT [Name] AS Game,
		CASE
			WHEN DATEPART(HOUR, [Start]) < 12 
				THEN 'Morning'
			WHEN DATEPART(HOUR, [Start]) < 18
				THEN 'Afternoon'
			WHEN DATEPART(HOUR, [Start]) < 24
				THEN 'Evening'
			END AS [Part of the Day],
		CASE 
			WHEN Duration <= 3
				THEN 'Extra Short'
			WHEN Duration <= 6
				THEN 'Short'
			WHEN Duration > 6
				THEN 'Long'
			WHEN Duration IS NULL
				THEN 'Extra Long'
			END AS Duration
	FROM Games
	ORDER BY Game, Duration, [Part of the Day]

GO

SELECT ProductName,
       OrderDate,
	   DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
	FROM Orders
GO