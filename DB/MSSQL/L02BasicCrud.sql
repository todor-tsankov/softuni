USE SoftUni

GO

SELECT * FROM Departments

GO

SELECT [Name] FROM Departments

GO

SELECT FirstName, LastName, Salary FROM Employees

GO

SELECT FirstName, MiddleName, LastName FROM Employees

GO

SELECT FirstName + '.' + LastName + '@softuni.bg' FROM Employees

GO

SELECT Salary FROM Employees
	GROUP BY Salary

GO

SELECT * FROM Employees
	WHERE JobTitle = 'Sales Representative'

GO

SELECT FirstName, LastName, JobTitle FROM Employees
	WHERE Salary >= 20000 AND Salary <= 30000

GO

SELECT FirstName + ' ' + MiddleName + ' ' + LAstName AS [Full Name] FROM Employees
	WHERE Salary IN (25000, 14000, 12500, 23600)

GO

SELECT FirstName, LastName FROM Employees
	WHERE ManagerID IS NULL

GO

SELECT FirstName, LastName, Salary FROM Employees
	WHERE Salary > 50000
	ORDER BY Salary DESC

GO

SELECT TOP(5) FirstName, LastName FROM Employees
	ORDER BY Salary DESC

GO

SELECT FirstName, LastName FROM Employees
	WHERE DepartmentID != '4'

GO

SELECT * FROM Employees
	ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName

GO

CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary FROM Employees

GO

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName + ' ' + (SELECT ISNULL(MiddleName, '')) + ' ' + LastName AS [Full Name], JobTitle FROM Employees

GO

SELECT JobTitle FROM Employees
	GROUP BY JobTitle

GO

SELECT TOP(10) * FROM Projects
	ORDER BY StartDate, [Name]

GO

SELECT TOP(7) FirstName, LastName, HireDate FROM Employees
	ORDER BY HireDate DESC

GO

UPDATE Employees
	SET Salary *= 1.12
	WHERE (SELECT [Name] FROM Departments
	       WHERE Employees.DepartmentID = Departments.DepartmentID) IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')

SELECT Salary FROM Employees

GO

USE Geography

GO

SELECT PeakName FROM Peaks
	ORDER BY PeakName ASC

GO

SELECT TOP(30) CountryName, [Population] FROM Countries
	WHERE (SELECT ContinentName FROM Continents WHERE Countries.ContinentCode = Continents.ContinentCode) = 'Europe'
	ORDER BY [Population] DESC

GO

SELECT CountryName, 
       CountryCode, 
	   CASE
			WHEN CurrencyCode = 'EUR' THEN 'Euro'
			ELSE 'Not Euro'
	   END AS Currency
	   FROM Countries
	   ORDER BY CountryName

GO

USE Diablo

GO

SELECT [Name] FROM Characters
	ORDER BY [Name]

GO