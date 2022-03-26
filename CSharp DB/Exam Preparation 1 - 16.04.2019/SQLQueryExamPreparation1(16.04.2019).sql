CREATE DATABASE [Airport]

USE [Airport]

--- 1. DDL

CREATE TABLE [Planes]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [Name] VARCHAR(30) NOT NULL,
			 [Seats] INT NOT NULL,
			 [Range] INT NOT NULL
);

CREATE TABLE [Flights]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,    
			 [DepartureTime] DATETIME,
			 [ArrivalTime] DATETIME,
			 [Origin] VARCHAR(50) NOT NULL,
			 [Destination] VARCHAR(50) NOT NULL,
			 [PlaneId] INT FOREIGN KEY REFERENCES [Planes]([Id]) NOT NULL
);

CREATE TABLE [Passengers]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL, 
			 [FirstName] VARCHAR(30) NOT NULL,
			 [LastName] VARCHAR(30) NOT NULL,
             [Age] INT NOT NULL,
			 [Address] VARCHAR(30) NOT NULL,
			 [PassportId] CHAR(11) NOT NULL
);

CREATE TABLE [LuggageTypes]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [Type] VARCHAR(30) NOT NULL
);

CREATE TABLE [Luggages]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [LuggageTypeId] INT FOREIGN KEY REFERENCES [LuggageTypes]([Id]) NOT NULL,
			 [PassengerId] INT FOREIGN KEY REFERENCES [Passengers]([Id]) NOT NULL
);

CREATE TABLE [Tickets]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [PassengerId] INT FOREIGN KEY REFERENCES [Passengers]([Id]) NOT NULL,
			 [FlightId] INT FOREIGN KEY REFERENCES [Flights]([Id]) NOT NULL,
			 [LuggageId] INT FOREIGN KEY REFERENCES [Luggages]([Id]) NOT NULL,
			 [Price] DECIMAL(18, 2) NOT NULL
)

--- 2. Insert

INSERT INTO [Planes]([Name], [Seats], [Range]) VALUES
                    ('Airbus 336', 112, 5132),
					('Airbus 330', 432, 5325),
					('Boeing 369', 231, 2355),
					('Stelt 297', 254, 2143),
					('Boeing 338', 165, 5111),
					('Airbus 558', 387, 1342),
					('Boeing 128', 345,	5541)

INSERT INTO [LuggageTypes]([Type])	VALUES
                          ('Crossbody Bag'),
						  ('School Backpack'),
						  ('Shoulder Bag')

--- 3. Update
 -- First Solution Method:
   SELECT * 
     FROM [Tickets] AS t
LEFT JOIN [Flights] AS f
       ON t.[FlightId] = f.[Id]
	WHERE f.[Destination] = 'Carlsbad'

UPDATE [Tickets]
   SET Price += [Price] * 0.13
 -- Second Solution Method:
 UPDATE [Tickets]
    SET Price += [Price] * 0.13
  WHERE [FlightId] IN (SELECT [Id] 
                         FROM [Flights]
						WHERE [Destination] = 'Carlsbad')
                      
--- 4. Delete
 -- First Solution Method:
DELETE 
  FROM [Tickets]     
 WHERE [FlightId] IN (SELECT [Id]
		                FROM [Flights]         
	                   WHERE [Destination] = 'Ayn Halagim')
DELETE 
  FROM [Flights] 
 WHERE [Destination] = 'Ayn Halagim'
 -- Second Solution Method:

    DELETE [Tickets] 
      FROM [Tickets] AS t
INNER JOIN [Flights] AS f
        ON t.[FlightId] = f.[Id]  
     WHERE f.[Destination] = 'Ayn Halagim'

DELETE 
  FROM [Flights] 
 WHERE [Destination] = 'Ayn Halagim'

--- 5. The "Tr" Planes

  SELECT *
    FROM [Planes]
   WHERE [Name] LIKE '%tr%'
ORDER BY [Id] ASC, [Name] ASC, [Seats] ASC, [Range] ASC

--- 6. Flight Profits

  SELECT [FlightId],
         SUM([Price]) AS [Price]
    FROM [Tickets]
GROUP BY [FlightId]
ORDER BY [Price] DESC, [FlightId] ASC

--- 7. Passenger Trips

    SELECT CONCAT(p.[FirstName], ' ', p.[LastName]) AS [Full Name],
           f.[Origin],
	       f.[Destination]
      FROM [Tickets] AS t
INNER JOIN [Passengers] AS p
        ON t.[PassengerId] = p.[Id]
INNER JOIN [Flights] AS f
        ON t.[FlightId] = f.[Id]
  ORDER BY [Full Name] ASC, f.[Origin] ASC, f.[Destination] ASC

--- 8. Non Adventures People

   SELECT p.[FirstName] AS [First Name],
          p.[LastName] AS [Last Name],
		  p.[Age]
     FROM [Passengers] AS p
LEFT JOIN [Tickets] AS t
       ON p.[Id] = t.[PassengerId]
    WHERE t.[Id] IS NULL
ORDER BY p.[Age] DESC, p.[FirstName] ASC, p.[LastName] ASC

--- 9. Full Info

SELECT CONCAT(p.[FirstName], ' ', p.[LastName]) AS [Full Name],
       pl.[Name] AS [Plane Name],
	   CONCAT(f.[Origin], ' - ', f.[Destination]) AS [Trip],
	   lt.[Type] AS [Luggage Type]
  FROM [Tickets] AS t
INNER JOIN [Passengers] AS p
        ON t.[PassengerId] = p.[Id]
INNER JOIN [Flights] AS f
        ON t.[FlightId] = f.[Id]
INNER JOIN [Luggages] AS l
        ON t.[LuggageId] = l.[Id]
INNER JOIN [LuggageTypes] AS lt
        ON l.[LuggageTypeId] = lt.[Id]
INNER JOIN [Planes] AS pl
        ON f.[PlaneId] = pl.[Id]
  ORDER BY [Full Name] ASC, [Plane Name] ASC, [Trip] ASC, [Luggage Type] ASC

--- 10.	PSP

   SELECT pl.[Name],
          pl.[Seats],
	      COUNT(t.[PassengerId]) AS [Passengers Count]
     FROM [Planes] AS pl
LEFT JOIN [Flights] AS f
       ON pl.[Id] = f.[PlaneId]
LEFT JOIN [Tickets] AS t
       ON f.[Id] = t.[FlightId]
 GROUP BY pl.[Name], pl.[Seats]
 ORDER BY [Passengers Count] DESC, pl.[Name] ASC, pl.[Seats] ASC

 --- 11. Vacation
 GO

CREATE FUNCTION udf_CalculateTickets (@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
AS
BEGIN
    IF (@peopleCount <= 0)
	  RETURN 'Invalid people count!'

	IF(NOT EXISTS (SELECT 1 FROM [Flights] 
	                WHERE [Origin] = @origin AND [Destination] = @destination))
	  RETURN 'Invalid flight!'

	  RETURN CONCAT('Total price ', (SELECT TOP(1) t.[Price] FROM [Tickets] AS t
	                                   JOIN [Flights] AS f
									     ON t.[FlightId] = f.[Id]
									  WHERE f.[Origin] = @origin AND 
										  f.[Destination] = @destination)
	                                  * @peopleCount)
END

GO

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

--- 12. Wrong Data
GO

CREATE PROC usp_CancelFlights
AS
BEGIN
    UPDATE [Flights]
	   SET [ArrivalTime] = NULL, 
	       [DepartureTime] = NULL
	 WHERE [ArrivalTime] > [DepartureTime]
END

GO

EXEC usp_CancelFlights