CREATE DATABASE [SoftUni]

USE [SoftUni]

CREATE TABLE [Towns]
(
       [Id] INT PRIMARY KEY IDENTITY,
	   [Name] NVARCHAR(30) NOT NULL
)

INSERT INTO [Towns]([Name]) VALUES
                   ('Sofia'),
				   ('Plovdiv'),
				   ('Varna'),
				   ('Burgas')

CREATE TABLE [Addresses]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [AddressText] NVARCHAR(55) NOT NULL,
			 [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])
)

INSERT INTO [Addresses]([AddressText], [TownId]) VALUES 
                       ('bul. Aleksandar Malinov 65', 1),
					   ('bul. Bulgaria 120', 2),
					   ('bul. Primorski 74', 3),
					   ('ul. Odrin 15', 4)

CREATE TABLE [Departments]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(30) NOT NULL
)

INSERT INTO [Departments]([Name]) VALUES 
                         ('Engineering'),
                         ('Sales'),
						 ('Marketing'),
						 ('Software Development'),
						 ('Quality Assurance')						 

CREATE TABLE [Employees]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [FirstName] NVARCHAR(30) NOT NULL,
			 [MiddleName] NVARCHAR(30),
			 [LastName] NVARCHAR(30) NOT NULL,
			 [JobTitle] NVARCHAR(30) NOT NULL,
			 [DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL,
			 [HireDate] DATE NOT NULL,
			 [Salary] DECIMAL(10, 2),
			 [AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary], [AddressId]) VALUES
                       ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, 3),
					   ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, 2),
					   ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 1),
					   ('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, 4),
					   ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 1)

SELECT * FROM [Towns] ORDER BY [Name] ASC
SELECT * FROM [Departments] ORDER BY [Name] ASC
SELECT * FROM [Employees] ORDER BY [Salary] DESC

SELECT [Name] FROM [Towns] ORDER BY [Name] ASC
SELECT [Name] FROM [Departments] ORDER BY [Name] ASC
SELECT [FirstName], [LastName], [JobTitle], [Salary] 
  FROM [Employees] ORDER BY [Salary] DESC

UPDATE [Employees]
   SET [Salary] += [Salary] * 0.1
SELECT [Salary] FROM [Employees]

USE [Hotel]

UPDATE [Payments]
   SET [TaxRate] -= [TaxRate] * 0.03
SELECT [TaxRate] FROM [Payments]

TRUNCATE TABLE [Occupancies]