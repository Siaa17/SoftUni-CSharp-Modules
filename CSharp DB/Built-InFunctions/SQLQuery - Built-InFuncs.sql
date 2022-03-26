USE [SoftUni]

--SQL Built-In Solution Method:
SELECT [FirstName], [LastName] 
  FROM [Employees]
 WHERE LEFT([FirstName], 2) = 'Sa'

SELECT [FirstName], [LastName] 
  FROM [Employees]
 WHERE SUBSTRING([FirstName], 1, 2) = 'Sa'

--SQL Wildcards Solution Method:
SELECT [FirstName], [LastName] 
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'

--SQL Built-In Solution Method:
SELECT [FirstName], [LastName]
  FROM [Employees] 
 WHERE CHARINDEX('ei', [LastName]) <> 0

--SQL Wildcards Solution Method:
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'

SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3 , 10) AND YEAR([HireDate]) BETWEEN 1995 AND 2005

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%'

  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name] ASC

   SELECT [TownID], [Name]
     FROM [Towns]
    WHERE [Name] LIKE '[mkbe]%'
 ORDER BY [Name] ASC

   SELECT [TownID], [Name]
     FROM [Towns]
    WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
 ORDER BY [Name] ASC

   SELECT [TownID], [Name]
     FROM [Towns]
    WHERE [Name] NOT LIKE '[rbd]%'
 ORDER BY [Name] ASC

   SELECT [TownID], [Name]
     FROM [Towns]
    WHERE [Name] LIKE '[^rbd]%'
 ORDER BY [Name] ASC

GO

CREATE VIEW [V_EmployeesHiredAfter2000] AS 
    (SELECT [FirstName], [LastName]
       FROM [Employees]
      WHERE YEAR([HireDate]) > 2000)
GO

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5

  SELECT [EmployeeID], [FirstName], [LastName], [Salary],
         DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID])
	  AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

  SELECT * 
    FROM 
	      (SELECT [EmployeeID], [FirstName], [LastName], [Salary],
                  DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID])
	           AS [Rank]
		     FROM [Employees]
		    WHERE [Salary] BETWEEN 10000 AND 50000)
	  AS [RankedEmployees]
   WHERE [Rank] = 2
ORDER BY [Salary] DESC

USE [Geography]

  SELECT [CountryName] AS [Country Name], 
         [IsoCode] AS [ISO Code]
    FROM [Countries]
   WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode] ASC

  SELECT p.[PeakName], r.[RiverName],
         LOWER(CONCAT(LEFT(p.[PeakName], LEN(p.[PeakName]) - 1), r.[RiverName])) 
	  AS [Mix]
    FROM [Peaks] AS p, 
         [Rivers] AS r
   WHERE RIGHT(p.[PeakName], 1) = LEFT(r.[RiverName], 1)
ORDER BY [Mix]

USE [Diablo]

  SELECT TOP(50) [Name],
         FORMAT([Start], 'yyyy-MM-dd') 
      AS [Start]
    FROM [Games]
   WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start] ASC, [Name] ASC

  SELECT [Username],
         SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email]))
	  AS [Email Provider]
    FROM [Users]
ORDER BY [Email Provider] ASC, [Username] ASC

  SELECT [Username], [IpAddress]  AS [IP Address]
    FROM [Users]
   WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username] ASC

  SELECT [Name] 
      AS [Game],
         CASE
	          WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
			  WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
			  ELSE 'Evening'
	     END 
	  AS [Part of the Day],
	     CASE
	          WHEN [Duration] <= 3 THEN 'Extra Short'
			  WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
			  WHEN [Duration] > 6 THEN 'Long'
			  ELSE 'Extra Long'
	     END
	  AS [Duration]
    FROM [Games]
ORDER BY [Game] ASC, [Duration] ASC

USE [Orders]

SELECT [ProductName], [OrderDate], 
        DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
		DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
  FROM [Orders]

CREATE TABLE [People]
(
             [Id] INT IDENTITY,
			 [Name] VARCHAR(50) NOT NULL,
			 [Birthdate] DATETIME2
)

INSERT INTO [People]([Name], [Birthdate]) VALUES
                    ('Victor', '2000-12-07 00:00:00.000'),
					('Steven', '1992-09-10 00:00:00.000'),
					('Stephen', '1910-09-19 00:00:00.000'),
					('John', '2010-01-06 00:00:00.000')

SELECT [Name],
       --YEAR(GETDATE()) - YEAR([Birthdate]) AS [Age in Years],
       DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Years],	   
       DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age in Months],
	   DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age in Days],
	   DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
  FROM [People]