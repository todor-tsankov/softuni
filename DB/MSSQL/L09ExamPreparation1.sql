CREATE DATABASE Airport

USE Airport

CREATE TABLE Planes(
	Id int IDENTITY PRIMARY KEY,
	[Name] varchar(30) NOT NULL,
	Seats int NOT NULL,
	Range int NOT NULL
)

CREATE TABLE Flights(
	Id int IDENTITY PRIMARY KEY,
	DepartureTime datetime,
	ArrivalTime datetime,
	Origin varchar(50) NOT NULL,
	Destination varchar(50) NOT NULL,
	PlaneId int REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE LuggageTypes(
	Id int IDENTITY PRIMARY KEY,
	Type varchar(30) NOT NULL
)

CREATE TABLE Passengers(
	Id int IDENTITY PRIMARY KEY,
	FirstName varchar(30) NOT NULL,
	LastName varchar(30) NOT NULL,
	Age int NOT NULL,
	Address varchar(30) NOT NULL,
	PassportId char(11) NOT NULL
)

CREATE TABLE Luggages(
	Id int IDENTITY PRIMARY KEY,
	LuggageTypeId int REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId int REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets(
	Id int IDENTITY PRIMARY KEY,
	PassengerId int REFERENCES Passengers(Id) NOT NULL,
	FlightId int REFERENCES Flights(Id) NOT NULL,
	LuggageId int REFERENCES Luggages(Id) NOT NULL,
	Price decimal(20, 2) NOT NULL
)

--P02

INSERT INTO Planes(Name, Seats, Range)
	VALUES('Airbus 336', 112, 5132),
          ('Airbus 330', 432, 5325),
          ('Boeing 369', 231, 2355),
          ('Stelt 297 ', 254, 2143),
          ('Boeing 338', 165, 5111),
          ('Airbus 558', 387, 1342),
          ('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes(Type)
	VALUES ('Crossbody Bag'),
           ('School Backpack'),
           ('Shoulder Bag')

UPDATE Tickets
	SET Price *= 1.13
	WHERE FlightId = (SELECT Id 
						FROM Flights 
						WHERE Destination = 'Carlsbad')

DECLARE @FID int = (SELECT Id 
						FROM Flights 
						WHERE Destination = 'Ayn Halagim')

DELETE
	FROM Tickets
	WHERE FlightId = @FID

DELETE
	FROM Flights
	WHERE Id = @FID


SELECT *
	FROM  Planes
	WHERE Name LIKE '%tr%'
	ORDER BY Id, Name, Seats, Range

SELECT f.Id AS FlightId,
       SUM(t.Price) AS Price
	FROM Flights AS f
	JOIN Tickets AS t
		ON f.Id = t.FlightId
	GROUP BY f.Id
	ORDER BY SUM(t.Price) DESC, f.Id

SELECT p.FirstName + ' ' + p.LastName AS [Full Name],
       f.Origin,
	   f.Destination
	FROM Passengers AS p
	JOIN Tickets AS t
		ON p.Id = t.PassengerId
	JOIN Flights AS f
		ON t.FlightId = f.Id
	ORDER BY [Full Name], f.Origin, f.Destination

SELECT p.FirstName,
       p.LastName,
	   p.Age
	FROM Passengers AS p
	LEFT JOIN Tickets AS t
		ON p.Id = t.PassengerId
	WHERE t.Id IS NULL
	ORDER BY p.Age DESC, p.FirstName, p.LastName

SELECT p.FirstName + ' ' + p.LastName AS [Full Name],
       pl.Name AS [Plane Name],
	   f.Origin + ' - ' + f.Destination AS Trip,
	   lt.Type AS [Luggage Type]
	FROM Passengers AS p
	JOIN Tickets AS t
		ON p.Id = t.PassengerId
	JOIN Flights AS f
		ON t.FlightId = f.Id
	JOIN Planes AS pl
		ON f.PlaneId = pl.Id
	LEFT JOIN Luggages AS l
		ON t.LuggageId = l.Id
	LEFT JOIN LuggageTypes AS lt
		ON l.LuggageTypeId = lt.Id
	ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]


SELECT p.Name,
       p.Seats,
	   COUNT(t.Id) AS [Passengers Count]
	FROM Planes AS p
	LEFT JOIN Flights AS f
		ON p.Id = f.PlaneId
	LEFT JOIN Tickets AS t
		ON f.Id = t.FlightId
	GROUP BY p.Name, p.Seats
	ORDER BY [Passengers Count] DESC, p.Name, p.Seats


CREATE FUNCTION udf_CalculateTickets
(@origin nvarchar(50), @destination nvarchar(50), @peopleCount int) 
RETURNS nvarchar(30)
AS
BEGIN
	DECLARE @result nvarchar(30);

	IF(@peopleCount <= 0)
	BEGIN
		SET @result = 'Invalid people count!';
		RETURN @result;
	END

	DECLARE @FID int = (SELECT Id 
							FROM Flights 
							WHERE Origin = @origin 
								AND Destination = @destination)

	IF(NOT EXISTS(SELECT * FROM Flights WHERE Id = @FID))
	BEGIN
		SET @result = 'Invalid flight!';
		RETURN @result;
	END

	SET @result = (SELECT TOP(1) Price
						FROM Flights AS f
						JOIN Tickets AS t
							ON f.Id = t.FlightId
						WHERE f.Id = @FID) * @peopleCount

	RETURN 'Total price ' + @result;
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)


CREATE PROC usp_CancelFlights
AS
BEGIN
	UPDATE Flights
		SET ArrivalTime = NULL, 
		    DepartureTime = NULL
		WHERE DepartureTime < ArrivalTime
END

EXEC usp_CancelFlights

SELECT *, DATEDIFF(SECOND, DepartureTime, ArrivalTime) FROM Flights WHERE DATEDIFF(HOUR, DepartureTime, ArrivalTime) < 0