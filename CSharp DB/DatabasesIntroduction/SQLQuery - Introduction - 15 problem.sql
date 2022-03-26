CREATE DATABASE [Hotel]

USE [Hotel]

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
             [AccountNumber] INT PRIMARY KEY IDENTITY,
			 [FirstName] NVARCHAR(30) NOT NULL,
			 [LastName] NVARCHAR(30) NOT NULL,
			 [PhoneNumber] INT UNIQUE NOT NULL,
			 [EmergencyName] NVARCHAR(30),
			 [EmergencyNumber] INT,
			 [Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers]([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes]) VALUES
                       ('Diyan', 'Fotev', 02361452, NULL, NULL, NULL),
					   ('Stoyan', 'Peshev', 02963781, NULL, NULL, NULL),
					   ('Diyan', 'Fotev', 02433758, NULL, NULL, NULL)

CREATE TABLE [RoomStatus]
(
             [RoomStatus] NVARCHAR(20) PRIMARY KEY,
			 [Notes] NVARCHAR(MAX)
)

INSERT INTO [RoomStatus]([RoomStatus], [Notes]) VALUES
                        ('Available', NULL),
						('Not available', NULL),
						('Status 3',NULL)

CREATE TABLE [RoomTypes]
(
             [RoomType] NVARCHAR(20) PRIMARY KEY,
			 [Notes] NVARCHAR(MAX)
)

INSERT INTO [RoomTypes]([RoomType], [Notes]) VALUES
                       ('Double room', NULL),
					   ('Single room', NULL),
					   ('Apartment', NULL)

CREATE TABLE [BedTypes]
(
             [BedType] NVARCHAR(20) PRIMARY KEY,
			 [Notes] NVARCHAR(MAX)
)

INSERT INTO [BedTypes]([BedType], [Notes]) VALUES
                      ('Air Bed', NULL),
					  ('Waterbed', NULL),
					  ('Murphy Bed', NULL)

CREATE TABLE [Rooms]
(
             [RoomNumber] INT PRIMARY KEY IDENTITY,
			 [RoomType] NVARCHAR(20) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]) NOT NULL,
			 [BedType] NVARCHAR(20) FOREIGN KEY REFERENCES [BedTypes]([BedType]) NOT NULL,
			 [Rate] DECIMAL(3, 1),
			 [RoomStatus] NVARCHAR(20) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]) NOT NULL,
			 [Notes] NVARCHAR(MAX)
)

INSERT INTO [Rooms]([RoomType], [BedType], [Rate], [RoomStatus], [Notes]) VALUES
                    ('Double room', 'Air Bed', 35.5, 'Status1', NULL),
	                ('Single room', 'Waterbed', 40.2, 'Status2', NULL),
	                ('Apartment', 'Murphy Bed', 50.6, 'Status3', NULL)

CREATE TABLE [Payments]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL, 
			 [PaymentDate] DATETIME2 NOT NULL,
			 [AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
			 [FirstDateOccupied] DATETIME2 NOT NULL,
			 [LastDateOccupied] DATETIME2 NOT NULL,
			 [TotalDays] INT NOT NULL,
			 [AmountCharged] DECIMAL(10, 2),
			 [TaxRate] DECIMAL(5, 2),
			 [TaxAmount] DECIMAL(10, 2),
			 [PaymentTotal] DECIMAL(10, 2),
			 [Notes] NVARCHAR(MAX)
)

INSERT INTO [Payments]([EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [TotalDays], [AmountCharged], [TaxRate], [TaxAmount], [PaymentTotal], [Notes]) VALUES
                      (1, '2010-04-11', 1, '2010-05-03', '2010-05-13', 10, 350.50, 6.55, 36.90, 393.95, NULL),
					  (2, '2012-07-19', 2, '2012-08-20', '2012-08-26', 6, 400.20, 8.00, 42.00, 450.20, NULL),
					  (3, '2016-02-04', 3, '2016-03-18', '2016-03-25', 7, 385.00, 7.40, 40.50, 432.90, NULL)

CREATE TABLE [Occupancies]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL, 
			 [DateOccupied] DATETIME2 NOT NULL,
			 [AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
			 [RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]) NOT NULL,
			 [RateApplied] BIT NOT NULL,
			 [PhoneCharge] DECIMAL(5, 2),
			 [Notes] NVARCHAR(MAX)
)

INSERT INTO [Occupancies]([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge], [Notes]) VALUES
                         (3, '2018-09-17', 1, 1, 0, 13.40, NULL),
	                     (2, '2019-07-05', 3, 3, 1, 16.20, NULL),
	                     (1, '2006-12-10', 2, 2, 1, 19.10, NULL)
