USE [SoftUni]

SELECT * FROM [Departments]

SELECT [Name] FROM [Departments]

SELECT [FirstName], [LastName], [Salary] 
  FROM [Employees]

SELECT [FirstName], [MiddleName], [LastName]
  FROM [Employees]

SELECT CONCAT([FirstName], '.', [LastName], '@', 'softuni.bg') 
    AS [Full Email Address] 
  FROM [Employees]

SELECT DISTINCT [Salary] FROM [Employees]

SELECT * FROM [Employees]
        WHERE [JobTitle] = 'Sales Representative'

SELECT [FirstName], [LastName], [JobTitle]
  FROM [Employees]
 WHERE [Salary] BETWEEN 20000 AND 30000

 SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) 
     AS [Full Name] 
   FROM [Employees]
  WHERE [Salary] IN (25000, 14000, 12500, 23600)

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [ManagerID] IS NULL

  SELECT [FirstName], [LastName], [Salary] 
    FROM [Employees]
   WHERE [Salary] > 50000 
ORDER BY [Salary] DESC

   SELECT TOP(5) [FirstName], [LastName] 
     FROM [Employees]
 ORDER BY [Salary] DESC
 
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [DepartmentID] <> 4

  SELECT * 
    FROM [Employees]
ORDER BY [Salary] DESC, [FirstName] ASC, [LastName] DESC, [MiddleName] ASC

GO

CREATE VIEW [V_EmployeesSalaries] AS
    (SELECT [FirstName], [LastName], [Salary] 
       FROM [Employees])

SELECT * FROM [V_EmployeesSalaries]
GO

GO

CREATE VIEW [V_EmployeeNameJobTitle] AS
    (SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name],
              [JobTitle] AS [Job Title]
       FROM [Employees])

SELECT * FROM [V_EmployeeNameJobTitle]
GO

SELECT DISTINCT [JobTitle] 
           FROM [Employees]

  SELECT TOP(10) * 
    FROM [Projects]
   WHERE [StartDate] IS NOT NULL
ORDER BY [StartDate] ASC, [Name] ASC

  SELECT TOP(7) [FirstName], [LastName], [HireDate]
    FROM [Employees]
ORDER BY [HireDate] DESC

UPDATE [Employees]
   SET [Salary] += [Salary] * 0.12
 WHERE [DepartmentID] IN (1, 2, 4, 11)

SELECT [Salary] FROM [Employees]

USE [Geography]

  SELECT [PeakName] 
    FROM [Peaks]
ORDER BY [PeakName] ASC
 
  SELECT TOP(30) [CountryName], [Population] 
    FROM [Countries]
   WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC, [CountryName] ASC

  SELECT [CountryName], [CountryCode],
          CASE
		     WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
			 ELSE 'Not Euro'
		  END AS [Currency]
    FROM [Countries] 
ORDER BY [CountryName] ASC

USE [Diablo]

  SELECT [Name] 
    FROM [Characters]
ORDER BY [Name] ASC
