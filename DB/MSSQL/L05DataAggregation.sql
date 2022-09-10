SELECT COUNT(*) AS [Count]
	FROM WizzardDeposits

GO

SELECT MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits

GO

SELECT DepositGroup,
       MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
	GROUP BY DepositGroup

GO

SELECT TOP(2)
       DepositGroup 
	FROM WizzardDeposits
	GROUP BY DepositGroup
	ORDER BY AVG(MagicWandSize)

GO

SELECT DepositGroup,
       SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	GROUP BY DepositGroup

GO

SELECT DepositGroup,
       SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup

GO

SELECT DepositGroup,
       SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator =  'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY SUM(DepositAmount) DESC

GO

SELECT DepositGroup,
       MagicWandCreator,
	   MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup

GO

SELECT AgeGroup,
       COUNT(*) AS WizardCount
	FROM 
		(SELECT 
			CASE
				WHEN Age <= 10 THEN '[0-10]'
				WHEN Age <= 20 THEN '[11-20]'
				WHEN Age <= 30 THEN '[21-30]'
				WHEN Age <= 40 THEN '[31-40]'
				WHEN Age <= 50 THEN '[41-50]'
				WHEN Age <= 60 THEN '[51-60]'
				ELSE '[61+]' 
			END AS AgeGroup
		FROM WizzardDeposits
		) AS Ages
	GROUP BY AgeGroup

GO

SELECT LEFT(FirstName, 1) AS FirstLetter
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY LEFT(FirstName, 1)
	ORDER BY LEFT(FirstName, 1)

GO

SELECT DepositGroup,
       IsDepositExpired,
	   AVG(DepositInterest) AS AverageInterest
	FROM WizzardDeposits
	WHERE DepositStartDate > '1985-01-01'
	GROUP BY DepositGroup, IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired

GO

SELECT (SELECT DepositAmount 
			FROM WizzardDeposits 
			WHERE Id = 1) 
             - DepositAmount AS SumDifference
	FROM WizzardDeposits
	WHERE Id = 162

GO

SELECT DepartmentID,
       SUM(Salary) AS TotalSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID

GO

SELECT DepartmentID,
       MIN(Salary) AS MinimumSalary
	FROM Employees
	WHERE HireDate > '2000-01-01'
	GROUP BY DepartmentID
	HAVING DepartmentID IN(2, 5, 7)

GO

--START

SELECT *
	INTO Empl
	FROM Employees
	WHERE Salary > 30000

DELETE
	FROM Empl
	WHERE ManagerID = 42

UPDATE Empl
	SET Salary += 5000
	WHERE DepartmentID = 1

SELECT DepartmentID,
       AVG(Salary) AS AverageSalary
	FROM Empl
	GROUP BY DepartmentID

GO

--END

SELECT DepartmentID,
       MAX(Salary) AS MaxSalary
	FROM Employees
	GROUP BY DepartmentID
	HAVING  MAX(Salary) < 30000 OR MAX(Salary) > 70000

GO

SELECT COUNT(*) AS [Count]
	FROM Employees
	WHERE ManagerID IS NULL

GO

SELECT DepartmentID,
       HighestSalary AS ThirdHighestSalary
	FROM
	(SELECT DepartmentID,
	        MAX(Salary) AS HighestSalary,
	        DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC)
			AS [Rank]
		FROM Employees
		GROUP BY DepartmentID, Salary) AS Ranked
	WHERE [Rank] = 3

GO

SELECT TOP(10)
       FirstName,
       LastName,
	   DepartmentID
	FROM Employees AS e
	WHERE Salary > (SELECT AVG(Salary) 
						FROM Employees AS s
						GROUP BY DepartmentID
						HAVING s.DepartmentID = e.DepartmentID)

GO




	--P01
	SELECT 162 AS [Count]
	
	--P02
	SELECT 31 AS LongestMagicWand
	
	--P12
	SELECT 44393.97 AS SumDifference
	
	--P17
	SELECT 4 AS [Count]

