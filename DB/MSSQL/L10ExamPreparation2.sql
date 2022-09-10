CREATE DATABASE School

USE School

CREATE TABLE Students(
	Id int IDENTITY PRIMARY KEY,
	FirstName nvarchar(30) NOT NULL,
	MiddleName nvarchar(25),
	LastName nvarchar(30) NOT NULL,
	Age tinyint CHECK(Age > 0) NOT NULL,  --check constraint might be needed
	Address nvarchar(50),
	Phone nchar(10)
)

CREATE TABLE Subjects(
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(20) NOT NULL,
	Lessons int NOT NULL
)

CREATE TABLE StudentsSubjects(
	Id int  IDENTITY PRIMARY KEY,
	StudentId int REFERENCES Students(Id) NOT NULL,
	SubjectId int REFERENCES Subjects(Id) NOT NULL,
	Grade decimal(3, 2) NOT NULL CHECK(Grade >= 2 AND Grade <= 6) --CHECK CONST
)

CREATE TABLE Exams(
	Id int IDENTITY PRIMARY KEY,
	Date datetime,
	SubjectId int REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentId int REFERENCES Students(Id) NOT NULL,
	ExamId int REFERENCES Exams(Id) NOT NULL,
	Grade decimal(3, 2) NOT NULL CHECK(Grade >= 2 AND Grade <= 6),
	CONSTRAINT pk_StudentsExams PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers(
	Id int IDENTITY PRIMARY KEY,
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	Address nvarchar(20) NOT NULL,
	Phone char(10),
	SubjectId int REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
	StudentId int REFERENCES Students(Id) NOT NULL,
	TeacherId int REFERENCES Teachers(Id) NOT NULL,
	CONSTRAINT pk_StudentsTeachers PRIMARY KEY (StudentId, TeacherId)
)


INSERT INTO Teachers(FirstName,	LastName, Address, Phone, SubjectId)
	VALUES ('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
	       ('Gerrard',	'Lowin', '370 Talisman Plaza', '3324874824', 2),
		   ('Merrile',	'Lambdin', '81 Dahle Plaza', '4373065154', 5),
		   ('Bert',	'Ivie',	'2 Gateway Circle',	'4409584510', 4)

INSERT INTO Subjects(Name, Lessons)
	VALUES('Geometry', 12),
	      ('Health', 10),
		  ('Drama', 7),
		  ('Sports', 9)

UPDATE StudentsSubjects
	SET Grade = 6.00
	WHERE SubjectId IN(1, 2) AND Grade >= 5.50


DELETE
	FROM StudentsTeachers
	WHERE TeacherId IN(SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE
	FROM Teachers
	WHERE Phone LIKE '%72%'

SELECT FirstName, LastName, Age
	FROM Students
	WHERE Age >= 12
	ORDER BY FirstName, LastName

SELECT s.FirstName,
       s.LastName,
	   COUNT(st.TeacherId) AS TeachersCount
	FROM Students AS s
	LEFT JOIN StudentsTeachers AS st
		ON s.Id = st.StudentId
	GROUP BY s.FirstName, s.LastName

SELECT s.FirstName + ' ' + s.LastName AS [Full Name]
	FROM Students AS s
	LEFT JOIN StudentsExams AS se
		ON s.Id = se.StudentId
	WHERE se.ExamId IS NULL
	ORDER BY [Full Name]

SELECT TOP(10) s.FirstName AS [First Name],
       s.LastName AS [Last Name],
	   FORMAT(AVG(se.Grade), 'F2') AS Grade
	FROM Students AS s
	JOIN StudentsExams AS se
		ON s.Id = se.StudentId
	GROUP BY s.FirstName, s.LastName
	ORDER BY Grade DESC, s.FirstName, s.LastName

SELECT s.FirstName + ' ' + ISNULL(s.MiddleName + ' ', '') + s.LastName AS [Full Name]
	FROM Students AS s
	LEFT JOIN StudentsSubjects AS sb
		ON s.Id = sb.StudentId
	WHERE sb.SubjectId IS NULL
	ORDER BY [Full Name]

SELECT s.Name,
       AVG(sb.Grade) AS AverageGrade
	FROM Subjects AS s
	JOIN StudentsSubjects AS sb
		ON s.Id = sb.SubjectId
	GROUP BY s.Name, s.Id
	ORDER BY s.Id

CREATE FUNCTION udf_ExamGradesToUpdate
(@studentId int, @grade decimal(3, 2))
RETURNS nvarchar(100)
AS
BEGIN

	DECLARE @result nvarchar(100)

	IF(NOT EXISTS(SELECT * FROM Students WHERE Id = @studentId))
	BEGIN
		SET @result = 'The student with provided id does not exist in the school!';
		RETURN @result;
	END

	IF(@grade > 6.00)
	BEGIN
		SET @result = 'Grade cannot be above 6.00!';
		RETURN @result;
	END

	DECLARE @count int = (SELECT COUNT(*)
							FROM StudentsExams
							WHERE StudentId = @studentId
								AND Grade >= @grade
								AND Grade <= @grade + 0.5)

	SET @result = 'You have to update ' + CAST(@count AS nvarchar) + ' grades for the student ' 
	               +  (SELECT FirstName FROM Students WHERE Id = @studentId)
	RETURN @result;
END

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)

SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)

SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)


GO


CREATE PROC usp_ExcludeFromSchool(@StudentId int)
AS
BEGIN
	BEGIN TRANSACTION

		IF(NOT EXISTS(SELECT * FROM Students WHERE Id = @StudentId))
		BEGIN
			THROW 50001, 'This school has no student with the provided id!', 1;
		END

		DELETE
			FROM StudentsTeachers
			WHERE StudentId = @StudentId

		DELETE
			FROM StudentsSubjects
			WHERE StudentId = @StudentId

		DELETE
			FROM StudentsExams
			WHERE StudentId = @StudentId
	
		DELETE
			FROM Students
			WHERE Id = @StudentId

		COMMIT;
END

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301