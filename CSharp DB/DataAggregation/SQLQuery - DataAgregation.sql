USE [Gringotts]

SELECT COUNT(*) 
    AS [Count]
  FROM [WizzardDeposits]

SELECT MAX([MagicWandSize])
    AS [LongestMagicWand]
  FROM [WizzardDeposits]

  SELECT [DepositGroup],
         MAX([MagicWandSize])
      AS [LongestMagicWand]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

  SELECT TOP(2) [DepositGroup]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize]) ASC

  SELECT [DepositGroup],
         SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

  SELECT [DepositGroup],
         SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

  SELECT [DepositGroup],
         SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

  SELECT [DepositGroup], 
         [MagicWandCreator],
		 MIN([DepositCharge]) AS [MinDepositCharge]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]

 SELECT [AgeGroup],
        COUNT([Id]) AS [WizardCount]
   FROM 
        (SELECT *,
                CASE 
	                 WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
					 WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
			         WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
			         WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
			         WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
			         WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
			         ELSE '[61+]'
	             END AS [AgeGroup]
           FROM [WizzardDeposits])
		     AS [AgeGroupingSubquery]
GROUP BY [AgeGroup]

  SELECT LEFT([FirstName], 1) AS [FirstLetter]
    FROM [WizzardDeposits]
   WHERE [DepositGroup] = 'Troll Chest'
GROUP BY LEFT([FirstName], 1)
ORDER BY [FirstLetter] ASC

  SELECT [DepositGroup], 
         [IsDepositExpired],
		 AVG([DepositInterest]) AS [AverageInterest]
    FROM [WizzardDeposits]
   WHERE [DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired] ASC

 SELECT SUM([Difference]) AS [SumDifference]
   FROM
		(SELECT [FirstName] AS [Host Wizard],
			   [DepositAmount] AS [Host Wizard Deposit],
			   LEAD([FirstName]) OVER(ORDER BY [Id]) AS [Guest Wizard],
			   LEAD([DepositAmount]) OVER(ORDER BY [Id]) AS [Guest Wizard Deposit],
			   [DepositAmount] - LEAD([DepositAmount]) OVER(ORDER BY [Id]) AS [Difference]
		  FROM [WizzardDeposits])
		    AS [DifferenceSubquery]

USE [SoftUni]

  SELECT [DepartmentID],
         SUM([Salary]) AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID] ASC

  SELECT [DepartmentID],
         MIN([Salary]) AS [MinimumSalary]
    FROM [Employees]
   WHERE [DepartmentID] IN (2, 5, 7) AND [HireDate] > '2000-01-01'
GROUP BY [DepartmentID]

GO

SELECT *
  INTO [EmployeesWithSalaryHigherThan30000]
  FROM [Employees]
 WHERE [Salary] > 30000

DELETE 
  FROM [EmployeesWithSalaryHigherThan30000]
 WHERE [ManagerID] = 42

UPDATE [EmployeesWithSalaryHigherThan30000]
   SET [Salary] += 5000
 WHERE [DepartmentID] = 1

  SELECT [DepartmentID],
         AVG([Salary]) AS [AverageSalary]
    FROM [EmployeesWithSalaryHigherThan30000]
GROUP BY [DepartmentID]
GO

  SELECT [DepartmentID],
         MAX([Salary]) AS [MaxSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
  HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

-- First solution method (17):
SELECT COUNT([Salary]) AS [Count]
  FROM [Employees]
 WHERE [ManagerID] IS NULL

 -- Second solution method (17):
SELECT COUNT(*) AS [Count]
  FROM [Employees]
 WHERE [ManagerID] IS NULL

SELECT DISTINCT
       [DepartmentID],
	   [Salary] AS [ThirdHighestSalary]
  FROM
	   (SELECT *,
		       DENSE_RANK() OVER(PARTITION BY([DepartmentID]) ORDER BY[Salary] DESC) AS [SalaryRank]
	      FROM [Employees])
		    AS [SalaryRankingSubquery]
 WHERE [SalaryRank] = 3

  SELECT TOP(10) e.[FirstName],
                 e.[LastName],
		         e.[DepartmentID]
    FROM [Employees] AS e
   WHERE e.[Salary] > (SELECT AVG(esub.[Salary]) AS [DepartmentAverageSalary]
                       FROM [Employees] AS esub
                      WHERE esub.[DepartmentID] = e.[DepartmentID]
                   GROUP BY esub.[DepartmentID])
ORDER BY e.[DepartmentID] ASC
 