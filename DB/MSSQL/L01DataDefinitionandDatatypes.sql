CREATE DATABASE Minions

CREATE TABLE Minions(
       Id INT NOT NULL,
	   [Name] VARCHAR(50) NOT NULL,
	   Age INT
)

CREATE TABLE Towns(
     Id INT NOT NULL,
	 [Name] VARCHAR(50) NOT NULL
)

ALTER TABLE Minions
     ADD TownId INT NOT NULL

ALTER TABLE Minions
     ADD CONSTRAINT PK_MinionId PRIMARY KEY ([Id]) 

ALTER TABLE Towns
     ADD CONSTRAINT PK_TownId PRIMARY KEY (Id)

ALTER TABLE Minions 
     ADD CONSTRAINT FK_TownId FOREIGN KEY (TownId)
	               REFERENCES Towns(Id)

INSERT INTO Towns(Id, [Name])
          VALUES (1, 'Sofia'),
		         (2, 'Plovdiv'),
		         (3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
          VALUES   (1, 'Kevin', 22, 1),
		           (2, 'Bob', 15, 3),
				   (3, 'Steward', NULL, 2)
USE Minions

CREATE TABLE People(
      Id INT IDENTITY NOT NULL,
	  [Name] NVARCHAR(200) NOT NULL,
	  Picture VARBINARY(MAX),
	  Height DECIMAL(3, 2),
	  [Weight] DECIMAL(5 ,2),
	  Gender CHAR(1) NOT NULL,
	  Birthdate DATE NOT NULL,
	  Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Height, [Weight], Gender, Birthdate)
           VALUES ('Pesho', 1.85, 100.2, 'm', '2020-05-22'),
		          ('Gosho', 1.50, 50.2, 'f', '2020-05-22'),
				  ('Tosho', 1.69, 80.3, 'm', '2020-05-22'),
				  ('Bosho', 1.72, 60.2, 'f', '2020-05-22'),
				  ('Mosho', 2.20, 150.2, 'm', '2020-05-22')


CREATE TABLE Users(
      Id BIGINT PRIMARY KEY IDENTITY,
	  Username VARCHAR(30) NOT NULL,
	  [Password] VARCHAR(26) NOT NULL,
	  ProfilePicture VARBINARY(MAX),
	  LastLoginTime DATETIME2,
	  IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
           VALUES ('toshko', 'parola', '2020-05-22T10:55:21.0832316'  , 0),
		          ('toshko1', 'parola1', '2020-05-22T10:55:21.0832316', 0),
				  ('toshko2', 'parola2', '2020-05-22T10:55:21.0832316', 0),
				  ('toshko3', 'parola3', '2020-05-22T10:55:21.0832316', 0),
				  ('toshko4', 'parola4', '2020-05-22T10:55:21.0832316', 0)

ALTER TABLE Users
           DROP CONSTRAINT [PK__Users__3214EC07A2B430CB]

ALTER TABLE Users
    ADD CONSTRAINT PK_IdUsername PRIMARY KEY(Id, Username)

ALTER TABLE Users
    ADD CONSTRAINT CK_Password CHECK (LEN([Password]) >= 5)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
      VALUES ('TOSHKO1234', '12345', '2020-05-22T10:55:21.0832316', 0)

ALTER TABLE Users
     ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username, [Password], IsDeleted)
     VALUES ('TIMETEST', '12345', 0)

ALTER TABLE Users
    DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
    ADD CONSTRAINT PK_Id PRIMARY KEY(Id)

ALTER TABLE Users
    ADD CONSTRAINT UQ_Username UNIQUE(Username)

ALTER TABLE Users
	ADD CONSTRAINT CK_Username CHECK(LEN(Username) >= 3)



CREATE TABLE Directors (
    Id INT IDENTITY PRIMARY KEY, 
    DirectorName NVARCHAR(100) NOT NULL, 
    Notes NVARCHAR(MAX)
)

CREATE TABLE Genres (
    Id INT IDENTITY PRIMARY KEY, 
    GenreName NVARCHAR(100) NOT NULL, 
    Notes NVARCHAR(MAX)
)

CREATE TABLE Categories (
    Id INT IDENTITY PRIMARY KEY, 
    CategoryName NVARCHAR(100) NOT NULL, 
    Notes NVARCHAR(MAX)
)

CREATE TABLE Movies (
    Id INT IDENTITY PRIMARY KEY, 
    Title NVARCHAR(100) NOT NULL, 
    DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL, 
    CopyrightYear INT NOT NULL, 
    [Length] INT, 
    GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL, 
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL, 
    Rating DECIMAL(2,1), 
    Notes NVARCHAR(MAX)
)

INSERT INTO Directors([DirectorName], Notes)
          VALUES ('Toshko', 'velik sym'),
		         ('Goshko', 'velik sym'),
				 ('Poshko', NULL),
				 ('Moshko', 'velik sym'),
				 ('Boshko', NULL)

INSERT INTO Genres(GenreName, Notes)
          VALUES ('Zabaven', 'haha'),
		         ('Strashen', 'ooo'),
				 ('Tyjen', NULL),
				 ('18+', 'xxx'),
				 ('Misteriq', NULL)

INSERT INTO Categories(CategoryName, Notes)
          VALUES ('BG', 'qaz'),
		         ('Chuzd', 'qaz'),
				 ('Anime', NULL),
				 ('Children', NULL),
				 ('Nz', NULL)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
         VALUES ('SAMPLE0', 1, 2000, 120, 2, 3, 5.5, 'NOTE'),
		        ('SAMPLE1', 2, 2001, 120, 1, 2, 6, 'NOTE 1'),
				('SAMPLE2', 3, 2002, 12, 3, 1, 9, NULL),
				('SAMPLE3', 4, 2003, 150, 5, 5, 5.5, '5'),
				('SAMPLE4', 5, 2004, 100, 4, 3, 7.5, NULL)

CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories (
         Id INT IDENTITY PRIMARY KEY,
         CategoryName NVARCHAR(100) NOT NULL, 
         DailyRate DECIMAL(6,2) NOT NULL, 
         WeeklyRate DECIMAL(6,2) NOT NULL, 
         MonthlyRate DECIMAL(6,2) NOT NULL, 
         WeekendRate DECIMAL(6,2) NOT NULL
)

CREATE TABLE Cars (
       Id INT IDENTITY PRIMARY KEY, 
       PlateNumber NVARCHAR(15) NOT NULL, 
       Manufacturer NVARCHAR(100) NOT NULL, 
       Model NVARCHAR(100) NOT NULL, 
	   CarYear INT NOT NULL, 
       CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	   Doors INT NOT NULL, 
       Picture VARBINARY(MAX), 
	   Condition NVARCHAR(50) NOT NULL, 
       Available BIT NOT NULL
)

CREATE TABLE Employees (
       Id INT IDENTITY PRIMARY KEY, 
       FirstName NVARCHAR(50) NOT NULL, 
       LastName NVARCHAR(50) NOT NULL, 
       Title NVARCHAR(50) NOT NULL, 
       Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
       Id INT IDENTITY PRIMARY KEY, 
       DriverLicenceNumber NVARCHAR(100) NOT NULL, 
       FullName NVARCHAR(150) NOT NULL, 
	   [Address] NVARCHAR(500) NOT NULL, 
       City NVARCHAR(100) NOT NULL, 
       ZIPCode INT NOT NULL, 
       Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders (
       Id INT IDENTITY PRIMARY KEY, 
       EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
       CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL, 
       CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL, 
       TankLevel INT NOT NULL, 
       KilometrageStart INT NOT NULL, 
       KilometrageEnd INT NOT NULL, 
       TotalKilometrage INT NOT NULL, 
       StartDate DATE NOT NULL, 
       EndDate DATE NOT NULL, 
       TotalDays INT NOT NULL,
       RateApplied DECIMAL(6, 2),
       TaxRate DECIMAL(6, 2), 
       OrderStatus NVARCHAR(50), 
       Notes NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
      VALUES ('kategoriq', 5, 30, 100, 50),
	         ('kategoriq1', 6, 35, 100, 50),
			 ('kategoriq2', 7, 40, 100, 50)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
      VALUES ('BG 1234 SF', 'BMW', 'E46', 2000, 1, 4, 'NEW', 0),
	         ('BG 2453 SF', 'BMW', 'E46', 1999, 1, 4, 'NEW', 0),
			 ('BG 3454 SF', 'WV', 'GOLF', 2003, 1, 4, 'NEW', 0)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
      VALUES ('TODOR', 'TSANKOV', 'CHIEF', 'NQMA'),
	         ('TODOR', 'VE', 'CHISTACH', 'NQMA'),
			 ('TODOR', 'ME', 'CHIEF', 'IMA')

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
      VALUES ('DSF7S8DFHU','BOSA NA KOKOSA', 'PROTOPOPINSTI', 'SOFIA', 1003, 'NE'),
	         ('SDSJDF8DFH','SHEFA NA RELEFA', 'TUTGOVIHTE', 'SOFIA', 1200, 'IMA MNOGO'),
			 ('SDFS89FHNS','TOSHKO AFRIKANSKI', 'BEOGRAD', 'SD', 1020, 'DA')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, 
                          KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, 
						  RateApplied, TaxRate, OrderStatus, Notes)
      VALUES (1, 2, 3, 100, 220000, 220150, 150, '2020-05-21', '2020-05-22', 2,
	          1, 20, 'READY', NULL),

			  (2, 2, 2, 100, 220000, 220150, 150, '2020-05-21', '2020-05-22', 2,
	          1, 20, 'READY', NULL),

			  (3, 2, 1, 100, 220000, 220150, 150, '2020-05-21', '2020-05-22', 2,
	          1, 20, 'READY', NULL)


CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees (
       Id INT IDENTITY PRIMARY KEY, 
       FirstName NVARCHAR(50) NOT NULL, 
       LastName NVARCHAR(50) NOT NULL, 
       Title NVARCHAR (50) NOT NULL, 
       Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
       AccountNumber INT PRIMARY KEY, 
       FirstName NVARCHAR(50) NOT NULL,
       LastName NVARCHAR(50) NOT NULL, 
       PhoneNumber BIGINT NOT NULL,
       EmergencyName NVARCHAR(50), 
       EmergencyNumber BIGINT,
       Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus (
       RoomStatus NVARCHAR(50) PRIMARY KEY, 
       Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes (
      RoomType NVARCHAR(50) PRIMARY KEY,
      Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes (
      BedType NVARCHAR(50) PRIMARY KEY,
      Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms (
     RoomNumber INT PRIMARY KEY, 
     RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL, 
     BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL, 
     Rate DECIMAL(8,2) NOT NULL, 
     RoomStatus NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL, 
     Notes NVARCHAR(MAX)
)

CREATE TABLE Payments (
     Id INT IDENTITY PRIMARY KEY, 
     EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
     PaymentDate DATE NOT NULL, 
     AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
     FirstDateOccupied  DATE NOT NULL,
     LastDateOccupied DATE NOT NULL, 
     TotalDays INT NOT NULL,
     AmountCharged DECIMAL(8, 2) NOT NULL,
     TaxRate INT NOT NULL,
     TaxAmount DECIMAL(8, 2) NOT NULL,
     PaymentTotal DECIMAL(8, 2) NOT NULL, 
     Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies (
     Id INT IDENTITY PRIMARY KEY, 
     EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)  NOT NULL,
     DateOccupied DATE NOT NULL, 
     AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
     RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL, 
     RateApplied DECIMAL(8, 2) NOT NULL, 
     PhoneCharge DECIMAL(8, 2) NOT NULL, 
     Notes NVARCHAR(MAX)
)

INSERT INTO Employees ( FirstName, LastName, Title, Notes)
     VALUES ('TOSHKO', 'TSANKOV', 'SHEF', ''),
	        ('TOSHKO1', 'TSANKOV', 'SHEF', ''),
	        ('TOSHKO2', 'TSANKOV', 'SHEF', '')

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
     VALUES (1, 'IVA', 'TSANKOVA', 21321321, 'TATI', 0347398, NULL),
	        (2, 'BOBY', 'TSANKOVA', 21321321, 'TATI', 0347398, NULL),
	        (3, 'MOBBY', 'TSANKOVA', 21321321, 'TATI', 0347398, NULL)

INSERT INTO RoomStatus (RoomStatus)
     VALUES ('FREE'),
	        ('NOT FREE'),
			('NONE')

INSERT INTO RoomTypes (RoomType)
     VALUES ('SINGLE'),
	        ('DOUBLE'),
			('TRIPPLE')

INSERT INTO BedTypes (BedType)
    VALUES ('SINGLE'),
	        ('DOUBLE'),
			('TRIPPLE')

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus)
   VALUES (1, 'SINGLE', 'SINGLE', 5, 'FREE'),
          (2, 'SINGLE', 'SINGLE', 5, 'FREE'),
		  (3, 'SINGLE', 'SINGLE', 5, 'FREE')

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, 
                     AmountCharged, TaxRate, TaxAmount, PaymentTotal)
	 VALUES (1, '2020-05-22', 1, '2020-05-22', '2020-05-22', 5, 100, 20, 20, 120),
	        (1, '2020-05-22', 1, '2020-05-22', '2020-05-22', 5, 100, 20, 20, 120),
			(1, '2020-05-22', 1, '2020-05-22', '2020-05-22', 5, 100, 20, 20, 120)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
     VALUES (1, '2020-05-22', 1, 1, 1, 10),
	        (1, '2020-05-22', 1, 1, 1, 10),
			(1, '2020-05-22', 1, 1, 1, 10)

SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC 

TRUNCATE TABLE Occupancies

UPDATE Payments
SET TaxRate = TaxRate * 0.93

SELECT TaxRate FROM Payments

UPDATE Employees
SET Salary *= 1.1

SELECT Salary FROM Employees

