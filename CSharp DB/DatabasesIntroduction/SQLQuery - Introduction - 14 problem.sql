CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [CategoryName] NVARCHAR(35) NOT NULL,
			 [DailyRate] DECIMAL(5, 2) NOT NULL,
			 [WeeklyRate] DECIMAL(5, 2) NOT NULL,
			 [MonthlyRate] DECIMAL(5, 2) NOT NULL,
			 [WeekendRate] DECIMAL(5, 2) NOT NULL
)

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate]) VALUES 
                        ('Category1', 50.00, 80.00, 250.00, 95.00),
						('Category2', 40.00, 70.00, 230.00, 75.00),
						('Category3', 35.00, 60.00, 210.00, 55.00)

CREATE TABLE [Cars]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [PlateNumber] NVARCHAR(15) UNIQUE NOT NULL,
			 [Manufacturer] NVARCHAR(25) NOT NULL,
			 [Model] NVARCHAR(25) NOT NULL,
			 [CarYear] INT NOT NULL,
			 [CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
			 [Doors] INT NOT NULL,
			 [Picture] VARBINARY(MAX),
			 [Condition] NVARCHAR(250),
			 [Available] BIT NOT NULL
)

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available]) VALUES
                  ('E 2214 об', 'Toyota', 'Avensis', 2010, 2, 5, NULL, 'Good', 1),
				  ('PB 1074 му', 'Audi', 'A3', 2001, 3, 3, NULL, 'Good', 1),
				  ('CA 9546 KM', 'Opel', 'Insignia', 2011, 1, 5, NULL, 'Good', 0)

CREATE TABLE [Employees]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [FirstName] NVARCHAR(30) NOT NULL,
			 [LastName] NVARCHAR(30) NOT NULL,
			 [Title] NVARCHAR(35), 
			 [Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes]) VALUES
                       ('Emo', 'Georgiev', 'Manager', NULL),
					   ('Pesho', 'Stamatov', 'Big Boss', NULL),
					   ('Kiro', 'Hristiyanina', 'No one', NULL)

CREATE TABLE [Customers]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [DriverLicenceNumber] INT UNIQUE NOT NULL,
			 [FullName] NVARCHAR(55) NOT NULL,
			 [Address] NVARCHAR(90),
			 [City] NVARCHAR(30) NOT NULL,
			 [ZIPCode] INT,
			 [Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes]) VALUES
                        (123456, 'Pesho Petrov', NULL, 'Sofia', 1000, NULL),
						(482164, 'Gosho Nikolov', NULL, 'Varna', 9000, NULL),
						(987231, 'Filip Hristov', NULL, 'Pleven', 5800, NULL)

CREATE TABLE [RentalOrders]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
			 [CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
 			 [CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
			 [TankLevel] INT,
			 [KilometrageStart] INT NOT NULL,
	         [KilometrageEnd] INT NOT NULL,
	         [TotalKilometrage] INT NOT NULL,
	         [StartDate] DATETIME2 NOT NULL,
	         [EndDate] DATETIME2 NOT NULL,
	         [TotalDays] INT NOT NULL,
	         [RateApplied] BIT NOT NULL,
			 [TaxRate] DECIMAL(5, 2),
	         [OrderStatus] NVARCHAR(50),			 
	         [Notes] NVARCHAR(MAX)
)

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus], [Notes]) VALUES
                          (1, 3, 1, 100, 0, 1200, 20000, '2013-06-13', '2013-06-20', 7, 0, NULL, NULL, NULL),
						  (1, 2, 3, 90, 0, 1100, 17000, '2015-03-09', '2015-03-16', 7, 1, NULL, NULL, NULL),
						  (2, 1, 2, 80, 0, 1000, 15500, '2017-10-22', '2017-10-29', 7, 0, NULL, NULL, NULL)