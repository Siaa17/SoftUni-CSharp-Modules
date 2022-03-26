USE [SoftUni]

GO

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
    SELECT [FirstName],
	       [LastName]
      FROM [Employees]
	 WHERE [Salary] > 35000
END
GO

EXEC usp_GetEmployeesSalaryAbove35000

GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@number DECIMAL(18, 4))
AS
BEGIN
    SELECT [FirstName],
	       [LastName]
      FROM [Employees]
	 WHERE [Salary] >= @number
END
GO

EXEC usp_GetEmployeesSalaryAboveNumber 48100

GO

CREATE PROC usp_GetTownsStartingWith (@startingString VARCHAR(50))
AS
BEGIN
    SELECT [Name] AS [Town]
	  FROM [Towns]
	 WHERE [Name] LIKE @startingString + '%'
	 --WHERE SUBSTRING([Name], 1, LEN(@startingString)) = @startingString	 
END
GO

EXEC usp_GetTownsStartingWith 'b'

GO

CREATE PROC usp_GetEmployeesFromTown (@townName NVARCHAR(50))
AS 
BEGIN
    SELECT [FirstName] AS [First Name],
	       [LastName] AS [Last Name]
	  FROM [Employees] AS e
 LEFT JOIN [Addresses] AS a
        ON e.[AddressID] = a.[AddressID]
 LEFT JOIN [Towns] AS t
        ON a.[TownID] = t.[TownID]
	 WHERE t.[Name] = @townName
END

GO

EXEC usp_GetEmployeesFromTown 'Sofia'

GO

CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
    DECLARE @salaryLevel VARCHAR(7)

    IF (@salary < 30000)
	BEGIN
	    SET @salaryLevel = 'Low'
	END
	IF (@salary BETWEEN 30000 AND 50000)
	BEGIN
	    SET @salaryLevel = 'Average'
	END
	IF (@salary > 50000)
	BEGIN
	    SET @salaryLevel = 'High'
	END

	RETURN @salaryLevel
END

GO

SELECT [Salary],
       [dbo].ufn_GetSalaryLevel([Salary]) AS [SalaryLevel]
  FROM [Employees]

GO

CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel VARCHAR(7))
AS
BEGIN
    SELECT [FirstName] AS [First Name],
	       [LastName] AS [Last Name]
	  FROM [Employees]
	 WHERE [dbo].ufn_GetSalaryLevel([Salary]) = @salaryLevel
END

GO

EXEC usp_EmployeesBySalaryLevel 'High'

GO

CREATE FUNCTION ufn_IsWordComprised (@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
    DECLARE @count INT = 1

	WHILE(LEN(@word) >= @count)
	BEGIN
	    DECLARE @currentLetter CHAR(1) = SUBSTRING(@word, @count, 1)
		
		IF(@setOfLetters NOT LIKE CONCAT('%', @currentLetter, '%')) 
		          RETURN 0

		SET @count += 1
    END

	RETURN 1
END

GO

SELECT [dbo].ufn_IsWordComprised('oistmiahf', 'Sofia') AS [Result]
SELECT [dbo].ufn_IsWordComprised('oistmiahf', 'halves') AS [Result]

GO

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
    DELETE 
	  FROM [EmployeesProjects]
	 WHERE [EmployeeID] IN (SELECT [EmployeeID]
	                          FROM [Employees]
							 WHERE [DepartmentID] = @departmentId)

    UPDATE [Employees]
	   SET [ManagerID] = NULL
	 WHERE [ManagerID] IN (SELECT [EmployeeID]
	                         FROM [Employees]
							WHERE [DepartmentID] = @departmentId)
	
     ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT NULL

	UPDATE [Departments]
	   SET [ManagerID] = NULL
	 WHERE [ManagerID] IN (SELECT [EmployeeID]
	                         FROM [Employees]
							WHERE [DepartmentID] = @departmentId)

    DELETE 
	  FROM [Employees]
	 WHERE [DepartmentID] = @departmentId
	
	DELETE 
	  FROM [Departments]
	 WHERE [DepartmentID] = @departmentId

	SELECT COUNT(*)
	  FROM [Employees]
	 WHERE [DepartmentID] = @departmentId
END

GO

EXEC usp_DeleteEmployeesFromDepartment 4

GO

USE [Bank]

GO

CREATE PROC usp_GetHoldersFullName 
AS
BEGIN
    SELECT CONCAT([FirstName], ' ', [LastName]) 
	    AS [Full Name]
	  FROM [AccountHolders]
END

GO

EXEC usp_GetHoldersFullName

GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(18, 4))
AS 
BEGIN 
    SELECT ah.[FirstName] AS [First Name], 
	       ah.[LastName] AS [Last Name]
	  FROM [AccountHolders] AS ah
INNER JOIN [Accounts] AS a 
        ON ah.[Id] = a.[AccountHolderId]
  GROUP BY ah.[FirstName], ah.[LastName]
    HAVING SUM(a.[Balance]) > @number
  ORDER BY ah.[FirstName] ASC, ah.[LastName] ASC
END

GO

EXEC usp_GetHoldersWithBalanceHigherThan 50000

GO

CREATE FUNCTION ufn_CalculateFutureValue (@initialSum DECIMAL(18, 4), @yearlyInterestRate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN  
	SET @initialSum = @initialSum * (POWER((1 + @yearlyInterestRate), @years))
    RETURN @initialSum
END

GO

SELECT [dbo].ufn_CalculateFutureValue(1000, 0.1, 5) AS [Output]

GO

CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @interestRate FLOAT)
AS 
BEGIN
    DECLARE @years INT = 5

	SELECT a.[Id] AS [Account Id],
	       ah.[FirstName] AS [First Name],
		   ah.[LastName] AS [Last Name],
		   a.[Balance] AS [Current Balance],
		   [dbo].ufn_CalculateFutureValue(a.[Balance], @interestRate, @years) 
		AS [Balance in 5 years]
	  FROM [AccountHolders] AS ah
INNER JOIN [Accounts] AS a 
        ON ah.[Id] = a.[AccountHolderId]
     WHERE a.[Id] = @accountId
END

GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1

GO

USE [Diablo]

GO

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN (SELECT SUM([Cash]) AS [SumCash]
          FROM
			  (SELECT g.[Name],
					  ug.[Cash],
					  ROW_NUMBER() OVER(PARTITION BY g.[Name] ORDER BY ug.[Cash] DESC) AS [RowNumber]
			     FROM [UsersGames] AS ug
		   INNER JOIN [Games] AS g
				   ON ug.[GameId] = g.[Id]
			    WHERE g.[Name] = @gameName)
				   AS [RowNumberSubquery]
          WHERE [RowNumber] % 2 <> 0)   

GO

SELECT * FROM ufn_CashInUsersGames ('Love in a mist')
