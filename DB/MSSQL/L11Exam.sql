CREATE DATABASE TripService

USE TripService

CREATE TABLE Cities(
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(20) NOT NULL,
	CountryCode char(2) NOT NULL
)

CREATE TABLE Hotels(
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(30) NOT NULL,
	CityId int REFERENCES Cities(Id) NOT NULL,
	EmployeeCount int NOT NULL,
	BaseRate decimal(38, 2)
)

CREATE TABLE Rooms(
	Id int IDENTITY PRIMARY KEY,
	Price decimal(38, 2) NOT NULL,
	Type nvarchar(20) NOT NULL,
	Beds int NOT NULL,
	HotelId int REFERENCES Hotels(Id) NOT NULL
)


CREATE TABLE Trips(
	Id int IDENTITY PRIMARY KEY,
	RoomId int REFERENCES Rooms(Id) NOT NULL,
	BookDate date NOT NULL,
	ArrivalDate date NOT NULL,
	ReturnDate date NOT NULL,
	CancelDate date,
	CHECK(BookDate < ArrivalDate),
	CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts(
	Id int IDENTITY PRIMARY KEY ,
	FirstName nvarchar(50) NOT NULL,
	MiddleName nvarchar(20),
	LastName nvarchar(50) NOT NULL,
	CityId int REFERENCES Cities(Id) NOT NULL,
	BirthDate date NOT NULL,
	Email varchar(100) NOT NULL
)

CREATE TABLE AccountsTrips(
	AccountId int REFERENCES Accounts(Id) NOT NULL,
	TripId int REFERENCES Trips(Id) NOT NULL,
	Luggage int NOT NULL CHECK(Luggage >= 0),
	PRIMARY KEY (AccountId, TripId)
)


INSERT INTO Accounts(FirstName,	MiddleName,	LastName, CityId, BirthDate, Email)
	VALUES ('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
	       ('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
		   ('Ivan', 'Petrovich', 'Pavlov', 59,'1849-09-26', 'i_pavlov@softuni.bg'),
		   ('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
	VALUES (101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
	       (102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
		   (103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
		   (104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
		   (109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

UPDATE Rooms
	SET Price *= 1.14
	WHERE HotelId IN(5, 7, 9)

DELETE
	FROM AccountsTrips
	WHERE AccountId = 47

SELECT a.FirstName,
       a.LastName,
	   FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate,
	   c.Name AS Hometown,
	   a.Email
	FROM Accounts AS a
	JOIN Cities AS c
		ON a.CityId = c.Id
	WHERE Email LIKE 'e%'
	ORDER BY Hometown

SELECT c.Name AS City,
       COUNT(h.Id) AS Hotels
	FROM Cities AS c
	JOIN Hotels AS h
		ON c.Id = h.CityId
	GROUP BY c.Name
	ORDER BY Hotels DESC, City


--P07

SELECT a.Id AS  AccountId,
       a.FirstName + ' ' + a.LastName AS FullName,
	   MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
	FROM Accounts AS a
	JOIN AccountsTrips AS at
		ON a.Id = at.AccountId
	JOIN Trips AS t
		ON at.TripId = t.Id
	WHERE a.MiddleName IS NULL 
		AND t.CancelDate IS NULL
	GROUP BY a.Id, a.FirstName, a.LastName
	ORDER BY LongestTrip DESC, ShortestTrip
	

--P08

SELECT TOP(10) c.Id,
               c.Name AS City,
			   c.CountryCode AS Country,
			   COUNT(a.Id) AS Accounts
	FROM Cities AS c
	JOIN Accounts AS a
		ON c.Id = a.CityId
	GROUP BY c.Id, c.Name, c.CountryCode
	ORDER BY Accounts DESC


--P09

SELECT a.Id,
       a.Email,
	   c.Name AS City,
	   COUNT(c2.Id) AS Trips
	FROM Accounts AS a
	JOIN Cities AS c
		ON a.CityId = c.Id
	JOIN AccountsTrips AS at
		ON a.Id = at.AccountId
	JOIN Trips AS t
		ON at.TripId = t.Id
	JOIN Rooms AS r
		ON t.RoomId = r.Id
	JOIN Hotels AS h
		ON r.HotelId = h.Id
	JOIN Cities AS c2
		ON h.CityId = c2.Id
	WHERE c.Name = c2.Name
	GROUP BY a.Id, a.Email, c.Name
	ORDER BY Trips DESC, a.Id

--P10

SELECT t.Id,
       a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '') + a.LastName AS [Full Name],
	   c.Name AS [From],
	   c2.Name AS [To],
	   CASE
		WHEN t.CancelDate IS NULL THEN CAST(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS nvarchar)+ ' days' 
		ELSE 'Canceled'
	   END AS Duration
	FROM Accounts AS a
	JOIN Cities AS c
		ON a.CityId = c.Id
	JOIN AccountsTrips AS at
		ON a.Id = at.AccountId
	JOIN Trips AS t
		ON at.TripId = t.Id
	JOIN Rooms AS r
		ON t.RoomId = r.Id
	JOIN Hotels AS h
		ON r.HotelId = h.Id
	JOIN Cities AS c2
		ON h.CityId = c2.Id
	ORDER BY [Full Name], t.Id

CREATE PROCEDURE usp_SwitchRoom(@TripId int, @TargetRoomId int)
AS
BEGIN
	DECLARE @CurrentHotelId int =  (SELECT r.HotelId
										FROM Trips AS t
										JOIN Rooms AS r
											ON t.RoomId = r.Id
										WHERE t.Id = @TripId)

	DECLARE @NewHotelId int =  (SELECT r.HotelId 
									FROM Rooms AS r
									WHERE r.Id = @TargetRoomId)

	IF(@CurrentHotelId != @NewHotelId)
	BEGIN
		THROW 50001, 'Target room is in another hotel!', 1
	END

	DECLARE @NewRoomBeds int = (SELECT Beds
									FROM Rooms
									WHERE Id = @TargetRoomId)

	DECLARE @PeopleCount int = (SELECT COUNT(*)
									FROM Trips AS t
									JOIN AccountsTrips AS at
										ON t.Id = at.TripId
									WHERE t.Id = @TripId)

	IF(@NewRoomBeds < @PeopleCount)
	BEGIN
		THROW 50002, 'Not enough beds in target room!', 1
	END

	UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId
END

CREATE FUNCTION udf_GetAvailableRoom(@HotelId int, @Date date, @People int)
RETURNS nvarchar(100)
AS
BEGIN
	DECLARE @result nvarchar(100);

	IF(NOT EXISTS(SELECT *
						FROM Hotels AS h
						JOIN Rooms AS r
							ON h.Id = r.HotelId
						JOIN Trips AS t
							ON r.Id = t.RoomId
						WHERE h.Id = @HotelId --@HOTEL ID
							AND r.Beds >= @People -- @PEOPLE
							AND (t.ArrivalDate > @Date OR t.ReturnDate < @Date  OR t.CancelDate IS NOT NULL)
							AND (NOT EXISTS(SELECT * 
												FROM Trips AS TT 
												WHERE r.Id = TT.RoomId
													AND TT.ArrivalDate <= @Date 
													AND TT.ReturnDate >= @Date  
													AND TT.CancelDate IS NULL))))
	BEGIN
		SET @result = 'No rooms available';
		RETURN @result;
	END
	
	DECLARE @price decimal(38, 2) = (SELECT TOP(1) r.Price
											FROM Hotels AS h
											JOIN Rooms AS r
												ON h.Id = r.HotelId
											JOIN Trips AS t
												ON r.Id = t.RoomId
											WHERE h.Id = @HotelId --@HOTEL ID
												AND r.Beds >= @People -- @PEOPLE
												AND (t.ArrivalDate > @Date OR t.ReturnDate < @Date  OR t.CancelDate IS NOT NULL)
											ORDER BY r.Price DESC)

	DECLARE @roomType nvarchar(100)= (SELECT TOP(1) r.Type
											FROM Hotels AS h
											JOIN Rooms AS r
												ON h.Id = r.HotelId
											JOIN Trips AS t
												ON r.Id = t.RoomId
											WHERE h.Id = @HotelId --@HOTEL ID
												AND r.Beds >= @People -- @PEOPLE
												AND (t.ArrivalDate > @Date OR t.ReturnDate < @Date  OR t.CancelDate IS NOT NULL)
											ORDER BY r.Price DESC)

	DECLARE @roomId int = (SELECT TOP(1) r.Id
										FROM Hotels AS h
										JOIN Rooms AS r
											ON h.Id = r.HotelId
										JOIN Trips AS t
											ON r.Id = t.RoomId
										WHERE h.Id = @HotelId --@HOTEL ID
											AND r.Beds >= @People -- @PEOPLE
											AND (t.ArrivalDate > @Date OR t.ReturnDate < @Date  OR t.CancelDate IS NOT NULL)
										ORDER BY r.Price DESC)
	
	DECLARE @beds int = (SELECT TOP(1) r.Beds
								FROM Hotels AS h
								JOIN Rooms AS r
									ON h.Id = r.HotelId
								JOIN Trips AS t
									ON r.Id = t.RoomId
								WHERE h.Id = @HotelId --@HOTEL ID
									AND r.Beds >= @People -- @PEOPLE
									AND (t.ArrivalDate > @Date OR t.ReturnDate < @Date  OR t.CancelDate IS NOT NULL)
								ORDER BY r.Price DESC)

	DECLARE @totalPrice decimal(38, 2) = ((SELECT BaseRate FROM Hotels WHERE Id = @HotelId) + @price) * @people;

    SET @result = 'Room ' + CAST(@roomId AS nvarchar) +': ' + CAST(@roomType as nvarchar) 
	             +' (' + CAST(@beds AS nvarchar) +' beds) - $' + CAST(@totalPrice AS nvarchar)

	RETURN @result;
END
