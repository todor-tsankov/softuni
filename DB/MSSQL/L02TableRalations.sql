CREATE DATABASE TableRelations

GO

USE TableRelations

GO

CREATE TABLE Persons(
	PersonID INT NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(10, 2) NOT NULL,
	PassportID INT NOT NULL
)

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY,
	PassportNumber CHAR(8) NOT NULL
)

INSERT INTO Passports(PassportID, PassportNumber)
	VALUES (101, 'N34FG21B'),
	       (102, 'K65LO4R7'),
		   (103, 'ZE657QP2')

INSERT INTO Persons(PersonID, FirstName, Salary, PassportID)
	VALUES (1, 'Roberto',43300.00 , 102),
	       (2, 'Tom',56100.00 , 103),
		   (3, 'Yana',60200.00 , 101)

ALTER TABLE Persons
	ADD CONSTRAINT PK_PersonID 
	PRIMARY KEY (PersonID)

ALTER TABLE Persons
	ADD CONSTRAINT FK_PassportID 
	FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

GO

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
)

INSERT INTO Manufacturers(ManufacturerID, [Name], EstablishedOn)
	VALUES (1, 'BMW', '07/03/1916'),
		   (2, 'Tesla', '01/01/2003'),
		   (3, 'Lada', '01/05/1966')

INSERT INTO Models(ModelID, [Name], ManufacturerID)
	VALUES (101, 'X1', 1),
	       (102, 'i6', 1),
		   (103, 'Model S', 2),
		   (104, 'Model X', 2),
		   (105, 'Model 3', 2),
		   (106, 'Nova', 3)

GO

-- P03 
CREATE TABLE Students(
	StudentID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
    ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID),
)

ALTER TABLE StudentsExams
	ADD CONSTRAINT PK_StudentIDExamID PRIMARY KEY (StudentID, ExamID)

INSERT INTO Students(StudentID, [Name])
	VALUES (1, 'Mila'),
	       (2, 'Toni'),
		   (3, 'Ron')

INSERT INTO Exams(ExamID, [Name])
	VALUES (101, 'SpringMVC'),
	       (102, 'Neo4j'),
		   (103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES (1, 101),
	       (1, 102),
		   (2, 101),
		   (3, 103),
		   (2, 102),
		   (2, 103)

GO

--P04
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(TeacherID, [Name], ManagerID)
	VALUES (101, 'John', NULL),
	       (102, 'Maya', 106),
		   (103, 'Silvia', 106),
		   (104, 'Ted', 105),
		   (105, 'Mark', 101),
		   (106, 'Greta', 101)

GO

--P05

CREATE DATABASE OnlineStore

GO

USE OnlineStore

GO

CREATE TABLE [ItemTypes](
	ItemTypeID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Items](
	ItemID INT PRIMARY KEY,
	[Name] NVARCHAR(50),
	ItemTypeID INT FOREIGN KEY REFERENCES [ItemTypes](ItemTypeID) NOT NULL
)

CREATE TABLE [Cities](
	CityID INT PRIMARY KEY,
	[Name] NVARCHAR(50)
)

CREATE TABLE [Customers](
	CustomerID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE [Orders](
	OrderID INT PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE [OrderItems](
	OrderID INT FOREIGN KEY REFERENCES [Orders](OrderID) NOT NULL,
	ItemID INT FOREIGN KEY REFERENCES [Items](ItemID) NOT NULL
)

ALTER TABLE [OrderItems]
	ADD CONSTRAINT PK_OrderIDItemID
	PRIMARY KEY (OrderID, ItemID)

GO

--P06

CREATE DATABASE UniversityDatabase

GO

USE UniversityDatabase

GO

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY,
	SubjectName NVARCHAR(50) NOT NULL
)

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY,
	StudentNumber NVARCHAR(10) NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(12, 2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
)

CREATE TABLE Agenda(
	 StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	 SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID) NOT NULL
)

ALTER TABLE Agenda
	ADD CONSTRAINT PK_StudentIDSubjectID
	PRIMARY KEY (StudentID, SubjectID)

-- P09

USE Geography

GO

SELECT MountainRange, PeakName, Elevation FROM Peaks
	JOIN Mountains ON Peaks.MountainId = Mountains.Id
	WHERE MountainRange = 'Rila'
	ORDER BY Elevation DESC