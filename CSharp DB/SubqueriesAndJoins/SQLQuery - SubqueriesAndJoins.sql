USE [Softuni]

   SELECT TOP(5) e.[EmployeeID], 
                 e.[JobTitle],
	             a.[AddressID],
	             a.[AddressText]
     FROM [Employees] AS e
LEFT JOIN [Addresses] AS a
       ON e.[AddressID] = a.[AddressID]
 ORDER BY a.[AddressID] ASC

   SELECT TOP(50) e.[FirstName],
                  e.[LastName],
		          t.[Name] AS [Town],
		          a.[AddressText]
     FROM [Employees] AS e
LEFT JOIN [Addresses] AS a
       ON e.[AddressID] = a.[AddressID]
LEFT JOIN [Towns] AS t
       ON a.[TownID] = t.[TownID]
 ORDER BY e.[FirstName] ASC, e.[LastName] ASC

   SELECT e.[EmployeeID],
          e.[FirstName],
	      e.[LastName],
	      d.[Name] AS [DepartmentName]
     FROM [Employees] AS e
LEFT JOIN [Departments] AS d
       ON e.[DepartmentID] = d.[DepartmentID]
	WHERE d.[Name] = 'Sales'
 ORDER BY e.[EmployeeID] ASC

   SELECT TOP(5) e.[EmployeeID],
                 e.[FirstName],
	             e.[Salary],
	             d.[Name] AS [DepartmentName]
     FROM [Employees] AS e
LEFT JOIN [Departments] AS d
       ON e.[DepartmentID] = d.[DepartmentID]
	WHERE e.[Salary] > 15000
 ORDER BY e.[DepartmentID] ASC
 
   SELECT TOP(3) e.[EmployeeID],
                 e.[FirstName]
     FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep
       ON e.[EmployeeID] = ep.[EmployeeID]
	WHERE ep.[ProjectID] IS NULL
 ORDER BY e.[EmployeeID] ASC

   SELECT e.[FirstName],
	      e.[LastName],
		  e.[HireDate],
		  d.[Name] AS [DeptName]
     FROM [Employees] AS e
LEFT JOIN [Departments] AS d
       ON e.[DepartmentID] = d.[DepartmentID]
	WHERE e.[HireDate] > '1999-01-01' AND d.[Name] IN ('Sales', 'Finance')
 ORDER BY e.[HireDate] ASC
 
    SELECT TOP(5) e.[EmployeeID],
	              e.[FirstName],
		          p.[Name] AS [ProjectName]
      FROM [Employees] AS e
INNER JOIN [EmployeesProjects] AS ep
        ON e.[EmployeeID] = ep.[EmployeeID]
INNER JOIN [Projects] AS p
        ON ep.[ProjectID] = p.[ProjectID]
     WHERE p.[StartDate] > '2002-08-13' AND p.[EndDate] IS NULL
  ORDER BY e.[EmployeeID] ASC

    SELECT e.[EmployeeID],
	       e.[FirstName],
		   CASE
		        WHEN YEAR(p.[StartDate]) >= 2005 THEN NULL
				ELSE p.[Name]
		   END AS [ProjectName]
      FROM [Employees] AS e
INNER JOIN [EmployeesProjects] AS ep
        ON e.[EmployeeID] = ep.[EmployeeID]
INNER JOIN [Projects] AS p
        ON ep.[ProjectID] = p.[ProjectID]
     WHERE e.[EmployeeID] = 24

    SELECT e.[EmployeeID],
	       e.[FirstName],
		   e.[ManagerID],
		   m.[FirstName] AS [ManagerName]
      FROM [Employees] AS e
INNER JOIN [Employees] AS m
        ON e.[ManagerID] = m.[EmployeeID]
     WHERE e.[ManagerID] IN (3, 7)
  ORDER BY e.[EmployeeID] ASC

   SELECT TOP(50) e.[EmployeeID],
           CONCAT(e.[FirstName], ' ', e.[LastName]) AS [EmployeeName],
		   CONCAT(m.[FirstName], ' ', m.[LastName]) AS [ManagerName],
		          d.[Name] AS [DepartmentName]
     FROM [Employees] AS e
LEFT JOIN [Employees] AS m
       ON e.[ManagerID] = m.[EmployeeID]
LEFT JOIN [Departments] AS d
       ON e.[DepartmentID] = d.[DepartmentID]
 ORDER BY e.[EmployeeID] ASC

  SELECT MIN(a.[AverageSalary]) AS [MinAverageSalary]
    FROM
 (SELECT AVG([Salary]) AS [AverageSalary]
    FROM [Employees] 
GROUP BY [DepartmentID]) AS a

USE [Geography]

   SELECT c.[CountryCode],
          m.[MountainRange],
		  p.[PeakName],
		  p.[Elevation]
     FROM [Peaks] AS p
LEFT JOIN [Mountains] AS m
       ON p.[MountainId] = m.[Id]
LEFT JOIN [MountainsCountries] AS mc
       ON m.[Id] = mc.[MountainId]
LEFT JOIN [Countries] AS c
       ON mc.[CountryCode] = c.[CountryCode]
    WHERE c.[CountryCode] = 'BG' AND p.[Elevation] > 2835
 ORDER BY p.[Elevation] DESC

   SELECT c.[CountryCode],
          COUNT(mc.[MountainId]) AS [MountainRanges]
     FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
       ON c.[CountryCode] = mc.[CountryCode]
	WHERE c.[CountryCode] IN ('BG', 'RU', 'US')
 GROUP BY c.[CountryCode]

   SELECT TOP(5) c.[CountryName],
                 r.[RiverName]
     FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr
       ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
       ON cr.[RiverId] = r.[Id]
	WHERE c.[ContinentCode] = 'AF'
 ORDER BY [CountryName] ASC

 SELECT [ContinentCode],
        [CurrencyCode],
	    [CurrencyCount] AS [CurrencyUsage]
   FROM
        (SELECT *,
                DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CurrencyCount] DESC)
	         AS [CurrencyRank]
           FROM
                (SELECT [ContinentCode], [CurrencyCode],
                        COUNT([CurrencyCode]) 
				     AS [CurrencyCount]
                   FROM [Countries]
               GROUP BY [ContinentCode], [CurrencyCode])
                     AS [CurrencyCountSubquery]
          WHERE [CurrencyCount] > 1)
             AS [CurrencyRankingSubquery]
   WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode] ASC

   SELECT COUNT(c.[CountryCode]) AS [Count]
     FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
       ON c.[CountryCode] = mc.[CountryCode]
    WHERE mc.[MountainId] IS NULL

   SELECT TOP(5) c.[CountryName],
             MAX(p.[Elevation]) AS [HighestPeakElevation],
		     MAX(r.[Length]) AS [LongestRiverLength]
     FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
       ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m
       ON  mc.[MountainId] = m.[Id]
LEFT JOIN [Peaks] AS p
       ON m.[Id] = p.[MountainId]
LEFT JOIN [CountriesRivers] AS cr
       ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
       ON cr.[RiverId] = r.[Id]
 GROUP BY c.[CountryName]
 ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.[CountryName] ASC

 SELECT TOP(5) [CountryName] AS [Country],
        ISNULL([PeakName], '(no highest peak)') AS [Highest Peak Name],
	    ISNULL([Elevation], 0) AS [Highest Peak Elevation],
	    ISNULL([MountainRange], '(no mountain)') AS [Mountain]
   FROM
        (SELECT c.[CountryName],
                p.[PeakName],
		        p.[Elevation],
		        m.[MountainRange],
		        DENSE_RANK() OVER(PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [PeakRank]
           FROM [Countries] AS c
      LEFT JOIN [MountainsCountries] AS mc
             ON c.[CountryCode] = mc.[CountryCode]
      LEFT JOIN [Mountains] AS m
             ON mc.[MountainId] = m.[Id]
      LEFT JOIN [Peaks] AS p
             ON m.[Id] = p.[MountainId])
			 AS [PeaksRankingSubquery]
   WHERE [PeakRank] = 1
ORDER BY [Country] ASC, [Highest Peak Name] ASC
