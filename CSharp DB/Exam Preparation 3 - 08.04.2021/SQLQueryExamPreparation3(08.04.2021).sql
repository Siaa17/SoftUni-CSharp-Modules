CREATE DATABASE [Service]

USE [Service]

--- 1. DDL

CREATE TABLE [Users]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [Username] VARCHAR(30) UNIQUE NOT NULL,
			 [Password] VARCHAR(50) NOT NULL,
			 [Name] VARCHAR(50),
			 [Birthdate] DATETIME, 
			 [Age] INT CHECK([Age] BETWEEN 14 AND 110),
			 [Email] VARCHAR(50) NOT NULL
);

CREATE TABLE [Departments]
(
		     [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [Name] VARCHAR(50) NOT NULL
);

CREATE TABLE [Employees]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,  
			 [FirstName] VARCHAR(25),
			 [LastName] VARCHAR(25),
			 [Birthdate] DATETIME,
			 [Age] INT CHECK([Age] BETWEEN 18 AND 110),
			 [DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id])
);

CREATE TABLE [Categories]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [Name] VARCHAR(50) NOT NULL,
			 [DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL
);

CREATE TABLE [Status]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [Label] VARCHAR(30) NOT NULL
);

CREATE TABLE [Reports] 
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
			 [StatusId] INT FOREIGN KEY REFERENCES [Status]([Id]) NOT NULL,
			 [OpenDate] DATETIME NOT NULL,
			 [CloseDate] DATETIME,
			 [Description] VARCHAR(200) NOT NULL,
			 [UserId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL,
			 [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id])
)

--- 2. Insert

INSERT INTO [Employees]([FirstName], [LastName], [Birthdate], [DepartmentId]) VALUES
                       ('Marlo', 'O''Malley', '1958-9-21', 1),
					   ('Niki', 'Stanaghan', '1969-11-26', 4),
					   ('Ayrton', 'Senna', '1960-03-21', 9),
					   ('Ronnie', 'Peterson', '1944-02-14', 9),
					   ('Giovanna', 'Amati', '1959-07-20', 5)
					   
INSERT INTO [Reports]([CategoryId], [StatusId], [OpenDate], [CloseDate], [Description], [UserId], [EmployeeId]) VALUES
                     (1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
					 (6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
					 (14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
					 (4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--- 3. Update

UPDATE [Reports]
   SET [CloseDate] = GETDATE()
 WHERE [CloseDate] IS NULL

--- 4. Delete

DELETE 
  FROM [Reports] 
 WHERE [StatusId] = 4

--- 5. Unassigned Reports

  SELECT [Description],
         FORMAT([OpenDate], 'dd-MM-yyyy') AS [OpenDate]
    FROM [Reports] AS r
   WHERE [EmployeeId] IS NULL
ORDER BY r.[OpenDate] ASC, [Description] ASC

--- 6. Reports & Categories

    SELECT r.[Description],
           c.[Name] AS [CategoryName]
      FROM [Reports] AS r
INNER JOIN [Categories] AS c
        ON r.[CategoryId] = c.[Id]
     WHERE c.[Name] IS NOT NULL
  ORDER BY r.[Description] ASC, c.[Name] ASC

--- 7. Most Reported Category

   SELECT TOP(5) c.[Name] AS [CategoryName],
          COUNT(r.[CategoryId]) AS [ReportsNumber]
     FROM [Categories] AS c
INNER JOIN [Reports] AS r
       ON c.[Id] = r.[CategoryId]
 GROUP BY c.[Name]
 ORDER BY [ReportsNumber] DESC, c.[Name] ASC

--- 8. Birthday Report

   SELECT u.[Username],
          c.[Name] AS [CategoryName]
      FROM [Reports] AS r
INNER JOIN [Users] AS u
        ON r.[UserId] = u.[Id]
INNER JOIN [Categories] AS c
        ON r.[CategoryId] = c.[Id]
     WHERE DAY(r.[OpenDate]) = DAY(u.[Birthdate]) AND
	       MONTH(r.OpenDate) = MONTH(u.[Birthdate])
  ORDER BY u.[Username] ASC, [CategoryName] ASC

--- 9. Users per Employee

-- First Solution Method:
   SELECT CONCAT(e.[FirstName], ' ', e.[LastName]) AS [FullName],
          COUNT(u.[Id]) AS [UsersCount]
     FROM [Employees] AS e
LEFT JOIN [Reports] AS r
       ON e.[Id] = r.[EmployeeId]
LEFT JOIN [Users] AS u
       ON r.[UserId] = u.[Id]
 GROUP BY e.[FirstName], e.[LastName]
 ORDER BY [UsersCount] DESC, [FullName] ASC

-- Second Solution Method:
   SELECT CONCAT(e.[FirstName], ' ', e.[LastName]) AS [FullName],
          COUNT(DISTINCT r.[UserId]) AS [UsersCount]
     FROM [Employees] AS e
LEFT JOIN [Reports] AS r
       ON e.[Id] = r.[EmployeeId]
 GROUP BY e.[FirstName], e.[LastName]
 ORDER BY [UsersCount] DESC, [FullName]

--- 10. Full Info

   SELECT ISNULL(e.[FirstName] + ' ' + e.[LastName], 'None') AS [Employee],
          ISNULL(d.[Name], 'None')AS [Department], 
		  c.[Name] AS [Category],
		  r.[Description],
		  FORMAT(r.[OpenDate], 'dd.MM.yyyy') AS [OpenDate],
		  s.[Label] AS [Status],
		  ISNULL(u.[Name], 'None') AS [User]
     FROM [Reports] AS r
LEFT JOIN [Employees] AS e
       ON r.[EmployeeId] = e.[Id]
LEFT JOIN [Departments] AS d
       ON e.[DepartmentId] = d.[Id]
LEFT JOIN [Categories] AS c
       ON r.[CategoryId] = c.[Id]
LEFT JOIN [Status] AS s
       ON r.[StatusId] = s.[Id]
LEFT JOIN [Users] AS u
       ON r.[UserId] = u.[Id]
 ORDER BY e.[FirstName] DESC, e.[LastName] DESC, d.[Name] ASC, c.[Name] ASC,
          r.[Description] ASC, r.[OpenDate] ASC, [Status] ASC, [User] ASC

--- 11. Hours to Complete
GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS
BEGIN
    DECLARE @totalHours INT = DATEDIFF(HOUR, @StartDate, @EndDate)

	IF((@StartDate IS NULL) OR (@EndDate IS NULL))
	  RETURN 0

	  RETURN @totalHours
END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

--- 12. Assign Employee
GO

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
    DECLARE @EmployeeDepartmentId INT = (SELECT [DepartmentId] FROM [Employees] 
	                              WHERE [Id] = @EmployeeId)

    DECLARE @CategoryDepartmentId INT = (SELECT c.[DepartmentId] FROM [Reports] AS r
	                                       JOIN [Categories] AS c 
										     ON r.[CategoryId] = c.[Id]
									      WHERE r.[Id] = @ReportId)

    IF(@EmployeeDepartmentId <> @CategoryDepartmentId)
	  THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1

     UPDATE [Reports]
        SET [EmployeeId] = @EmployeeId
	  WHERE [Id] = @ReportId
END

GO

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2
