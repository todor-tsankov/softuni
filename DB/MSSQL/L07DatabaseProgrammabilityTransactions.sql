USE SoftUni

GO



CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName,
	       LastName
		FROM Employees
		WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000





CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber 
@MinSalary DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName,
	       LastName
		FROM Employees
		WHERE Salary >= @MinSalary
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100




CREATE PROCEDURE usp_GetTownsStartingWith @Start NVARCHAR(50)
AS
	BEGIN
		SELECT Name
			FROM Towns
			WHERE Name LIKE @Start + '%'
	END

EXEC usp_GetTownsStartingWith 'Bor'




CREATE PROC usp_GetEmployeesFromTown (@TownName NVARCHAR(100))
AS
	BEGIN
		SELECT e.FirstName,
		       e.LastName
			FROM Employees AS e
			JOIN Addresses AS a
				ON e.AddressID = a.AddressID
			JOIN Towns AS t
				ON a.TownID = t.TownID
			WHERE t.Name = @TownName
	END

EXEC usp_GetEmployeesFromTown 'Sofia'




CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(MAX)
AS
	BEGIN
		IF (@salary < 30000) 
			RETURN 'Low'
		ELSE IF(@salary > 50000)
			RETURN 'High'

		RETURN 'Average'
	END

SELECT dbo.ufn_GetSalaryLevel(13500.00),
       dbo.ufn_GetSalaryLevel(43300.00),
	   dbo.ufn_GetSalaryLevel(125500.00)




CREATE PROC usp_EmployeesBySalaryLevel(@salary NVARCHAR(10))
AS
	BEGIN
		SELECT FirstName,
		       LastName
			FROM Employees
			WHERE @salary = dbo.ufn_GetSalaryLevel(Salary)
	END

EXEC usp_EmployeesBySalaryLevel 'HIGH'




CREATE FUNCTION ufn_IsWordComprised
(@setOfLetters NVARCHAR(100), @word NVARCHAR(100))
RETURNS BIT
AS
	BEGIN
		DECLARE @counter INT = 1;

		WHILE (@counter <= LEN(@word))
		BEGIN
			IF CHARINDEX(SUBSTRING(@word, @counter, 1), @setOfLetters) = 0
				RETURN 0

			SET @counter += 1
		END

		RETURN 1
	END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia'),
       dbo.ufn_IsWordComprised('oistmiahf', 'halves'),
       dbo.ufn_IsWordComprised('bobr', 'Rob'),
       dbo.ufn_IsWordComprised('pppp', 'Guy')

SELECT CHARINDEX(SUBSTRING('Sofia', 6, 1), 'oistmiahf')






CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
	BEGIN

		DELETE
			FROM EmployeesProjects
			WHERE EmployeeID IN (SELECT EmployeeID
									FROM Employees
									WHERE DepartmentID = @departmentId)

		ALTER TABLE Employees
			ALTER COLUMN ManagerID INT

		UPDATE Employees
			SET ManagerID = NULL
			WHERE ManagerID IN (SELECT EmployeeID
									FROM Employees
									WHERE DepartmentID = @departmentId)
		
		ALTER TABLE Departments
			ALTER COLUMN ManagerID INT

		UPDATE Departments
			SET ManagerID = NULL
				WHERE ManagerID IN (SELECT EmployeeID
									FROM Employees
									WHERE DepartmentID = @departmentId)

		DELETE 
			FROM Employees
			WHERE DepartmentID = @departmentId

		DELETE
			FROM Departments
			WHERE DepartmentID = @departmentId

		SELECT COUNT(*)
			FROM Employees
			WHERE DepartmentID = @departmentId
	END

EXEC usp_DeleteEmployeesFromDepartment 1


USE Bank

GO


CREATE PROC usp_GetHoldersFullName
AS
	BEGIN
		SELECT FirstName + ' ' + LastName AS FullName
			FROM AccountHolders
	END

EXEC usp_GetHoldersFullName

GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan @minBalance MONEY
AS
	BEGIN
		SELECT ah.FirstName,
		       ah.LastName
			FROM AccountHolders AS ah
			JOIN Accounts AS a
				ON ah.Id = a.AccountHolderId
			GROUP BY ah.FirstName, ah.LastName
			HAVING SUM(a.Balance) > @minBalance
			ORDER BY ah.FirstName, ah.LastName
	END

GO

CREATE FUNCTION ufn_CalculateFutureValue 
	(@sum DECIMAL(38, 4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(38, 4)
	BEGIN
		RETURN ROUND(@sum * POWER(1 + @yearlyInterestRate, @numberOfYears), 4)
	END

GO

SELECT DBO.ufn_CalculateFutureValue(1000000, 100, 50)

GO

CREATE PROC usp_CalculateFutureValueForAccount @accountId INT, @interest FLOAT
AS
	BEGIN
		SELECT a.Id, 
		       ah.FirstName, 
			   ah.LastName,
			   a.Balance AS [Current Balance],
			   dbo.ufn_CalculateFutureValue(a.Balance, @interest, 5) AS [Balance in 5 years]
			FROM AccountHolders AS ah
			JOIN Accounts AS a
				ON ah.Id = a.AccountHolderId
			WHERE a.Id = @accountId

	END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

USE Diablo

GO

CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(50))
RETURNS TABLE
AS 
RETURN (SELECT SUM(Cash) AS SumCash
			FROM
			(SELECT ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS Row,
			       ug.Cash
				FROM UsersGames AS ug
				JOIN Games AS g
					ON ug.GameId = g.Id
				WHERE g.Name = @GameName
				) AS TMP
			WHERE ROW % 2 != 0)

GO

SELECT *
	FROM ufn_CashInUsersGames('Love in a mist')