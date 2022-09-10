USE Bank

GO

CREATE TABLE Logs(
	LogId int IDENTITY PRIMARY KEY,
	AccountId int REFERENCES Accounts(Id) NOT NULL, 
	OldSum money NOT NULL, 
	NewSum money NOT NULL
)

GO

CREATE TRIGGER tr_LogSumChanges ON Accounts 
FOR UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
		SELECT i.Id,
		       d.Balance,
			   i.Balance
			FROM deleted AS d
			JOIN inserted AS i
				ON d.Id = i.Id

GO

CREATE TABLE NotificationEmails(
	Id int IDENTITY PRIMARY KEY, 
	Recipient int REFERENCES Accounts(Id) NOT NULL, 
	Subject Nvarchar(50) NOT NULL, 
	Body nvarchar(100) NOT NULL
	)

GO

CREATE TRIGGER tr_EnterMailForInsertedLog
ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails (Recipient, Subject, Body)
		SELECT i.AccountId,
		       'Balance change for account: ' + CAST(i.AccountId AS nvarchar),
			   'On ' + FORMAT(GETDATE(), 'MMMM dd yyyy h:mm') + ' your balance was changed from ' 
					 + CAST(i.OldSum AS nvarchar) + ' to ' + CAST(i.NewSum AS nvarchar)
			FROM inserted AS i

GO

UPDATE Accounts
	SET Balance += 10


GO

CREATE PROC usp_DepositMoney (@AccountId int, @MoneyAmount money)
AS
BEGIN
	BEGIN TRANSACTION
		IF(@MoneyAmount <= 0)
			BEGIN
				ROLLBACK;
				RETURN;
			END
		IF(NOT EXISTS(SELECT * FROM Accounts WHERE Id = @AccountId))
			BEGIN
				ROLLBACK;
				RETURN;
			END

		UPDATE Accounts
			SET Balance += @MoneyAmount
			WHERE Id = @AccountId

	COMMIT
END

GO

CREATE PROC usp_WithdrawMoney(@AccountId int, @MoneyAmount money)
AS
BEGIN
	BEGIN TRANSACTION
		IF(@MoneyAmount <= 0)
			BEGIN
				ROLLBACK;
				RETURN;
			END
		IF(NOT EXISTS(SELECT * FROM Accounts WHERE Id = @AccountId))
			BEGIN
				ROLLBACK;
				RETURN;
			END

		UPDATE Accounts
			SET Balance -= @MoneyAmount
			WHERE Id = @AccountId

	COMMIT
END

GO

CREATE PROC usp_TransferMoney
(@SenderId int, @ReceiverId int, @Amount money)
AS
BEGIN
	BEGIN TRANSACTION
		IF(@Amount <= 0)
			BEGIN
				ROLLBACK;
				RETURN;
			END
		IF(NOT EXISTS(SELECT * FROM Accounts WHERE Id = @SenderId))
			BEGIN
				ROLLBACK;
				RETURN;
			END
		IF(NOT EXISTS(SELECT * FROM Accounts WHERE Id = @ReceiverId))
			BEGIN
				ROLLBACK;
				RETURN;
			END

		UPDATE Accounts
			SET Balance -= @Amount
			WHERE Id = @SenderId

		UPDATE Accounts
			SET Balance += @Amount
			WHERE Id = @ReceiverId
	COMMIT
END

GO


USE Diablo

GO

	IF((SELECT Cash FROM UsersGames WHERE Id = 110) <
	   (SELECT SUM(Price) FROM Items WHERE MinLevel >= 11 AND MinLevel <= 12))
		BEGIN
			ROLLBACK;
			RETURN;
		END

     IF((SELECT Cash FROM UsersGames WHERE Id = 110) <
	   (SELECT SUM(Price) FROM Items WHERE MinLevel >= 19 AND MinLevel <= 21))
		BEGIN
			ROLLBACK;
			RETURN;

		END


DECLARE @UserGameId int =  (SELECT ug.Id
								FROM UsersGames AS ug
								JOIN Users AS u
									ON ug.UserId = u.Id
								JOIN Games AS g
									ON ug.GameId = g.Id
								WHERE u.FirstName = 'Stamat'
									AND g.Name = 'Safflower')

DECLARE @avaibleMoney money = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId);
DECLARE @neededMoney money = (SELECT SUM(Price) FROM Items WHERE MinLevel >= 11 AND MinLevel <= 12)

BEGIN TRANSACTION TRAN1
BEGIN

	IF(@avaibleMoney >= @neededMoney)
		BEGIN
			UPDATE UsersGames
				SET Cash -= @neededMoney
				WHERE Id = @UserGameId
	
			INSERT INTO UserGameItems(ItemId, UserGameId)
				SELECT i.Id,
				       @UserGameId
					FROM Items AS i
					WHERE i.MinLevel >= 11
						AND i.MinLevel <= 12

			COMMIT TRANSACTION TRAN1
		END

	ELSE
		BEGIN
			ROLLBACK;
		END
END 

BEGIN TRANSACTION
BEGIN	
	SET @avaibleMoney = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId);
	SET @neededMoney = (SELECT SUM(Price) FROM Items WHERE MinLevel >= 19 AND MinLevel <= 21);

	IF(@avaibleMoney >= @neededMoney)
		BEGIN
			UPDATE UsersGames
				SET Cash -= @neededMoney
				WHERE Id = @UserGameId

			INSERT INTO UserGameItems(ItemId, UserGameId)
				SELECT i.Id,
				       @UserGameId
					FROM Items AS i
					WHERE i.MinLevel >= 19
						AND i.MinLevel <= 21

			COMMIT TRANSACTION TRAN2
		END
	ELSE
		BEGIN
			ROLLBACK;
		END
END

SELECT i.Name AS [Item Name]
	FROM UserGameItems AS ugi
	JOIN Items AS i
		ON ugi.ItemId = i.Id
	WHERE ugi.UserGameId = @UserGameId
	ORDER BY i.Name


USE SoftUni

GO

CREATE PROC usp_AssignProject(@emloyeeId int, @projectID int)
AS
BEGIN
	BEGIN TRANSACTION
		IF ((SELECT COUNT(*) 
				FROM EmployeesProjects 
				WHERE EmployeeID = @emloyeeId) >= 3)
		BEGIN
			ROLLBACK;
			THROW 50001, 'The employee has too many projects!', 1
		END

		INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
			VALUES(@emloyeeId, @projectID)

	COMMIT
END

EXEC usp_AssignProject 1, 5
EXEC usp_AssignProject 1, 2
EXEC usp_AssignProject 1, 3

SELECT * FROM EmployeesProjects

GO

CREATE TABLE Deleted_Employees(
	EmployeeId INT PRIMARY KEY, 
	FirstName varchar(50) NOT NULL, 
	LastName varchar(50) NOT NULL, 
	MiddleName varchar(50) NOT NULL, 
	JobTitle varchar(50) NOT NULL, 
	DepartmentId int REFERENCES Departments(DepartmentId) NOT NULL, 
	Salary money NOT NULL
	)

CREATE TRIGGER tr_LogDeletedEmployees
ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, 
	                              JobTitle, DepartmentId, Salary)
		SELECT FirstName, LastName, MiddleName, 
		       JobTitle, DepartmentId, Salary
			FROM deleted

USE Diablo

GO

