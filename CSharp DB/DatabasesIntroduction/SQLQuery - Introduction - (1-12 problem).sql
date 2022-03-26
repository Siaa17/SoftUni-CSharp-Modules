CREATE DATABASE [Minions]

USE [Minions]

CREATE TABLE [Minions]
(
             [Id] INT PRIMARY KEY NOT NULL,
             [Name] NVARCHAR(50) NOT NULL,
			 [Age] INT
)

DROP TABLE [Minions]

CREATE TABLE [Towns]
(
             [Id] INT PRIMARY KEY NOT NULL,
             [Name] NVARCHAR(50) NOT NULL
)

ALTER TABLE [Minions]
        ADD [TownId] INT
		
   ALTER TABLE [Minions]
ADD CONSTRAINT [FK_MinionsTownId] FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])

INSERT INTO [Towns]([Id], [Name]) VALUES
                   (1, 'Sofia'),
                   (2, 'Plovdiv'),
                   (3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId]) VALUES
                     (1, 'Kevin', 22, 1),
					 (2, 'Bob', 15, 3),
					 (3, 'Steward', NULL, 2)

   --DELETE FROM [Minions]
TRUNCATE TABLE [Minions]

DROP TABLE [Minions]
DROP TABLE [Towns]

CREATE TABLE [People]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(200) NOT NULL,
			 [Picture] VARBINARY(MAX),
			 [Height] DECIMAL(3, 2),
			 [Weight] DECIMAL(5 ,2),
			 [Gender] CHAR(1) NOT NULL,
			 [Birthdate] DATE NOT NULL,
			 [Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography]) VALUES
                    ('Sia Grozdarska', NULL, 1.65, 50.20, 'f', '1995-12-17', 'Too long'),
					('Bianka Nikolaeva', NULL, 1.85, 80.00, 'm', '1995-12-17', 'Too long'),
					('Vesi Makseva', NULL, 1.68, 70.20, 'f', '1969-10-12', 'Too long'),
					('Ari Arina', NULL, 1.25, 40.00, 'f', '2005-01-08', 'Too long'),
					('Pesho Petrov', NULL, 1.65, 85.20, 'm', '1992-05-25', 'Too long')

CREATE TABLE [Users]
(
             [Id] BIGINT PRIMARY KEY IDENTITY,
			 [Username] VARCHAR(30) UNIQUE NOT NULL,
			 [Password] VARCHAR(26) NOT NULL,
			 [ProfilePicture] VARBINARY(MAX),
			 CHECK (DATALENGTH([ProfilePicture]) <= 900000),
			 [LastLoginTime] DATETIME2,
			 [IsDeleted] BIT NOT NULL	
)

INSERT INTO [Users]([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted]) VALUES
                   ('SianaG', '123456B', NULL, '2020-06-23', 0),
				   ('Viki', '123VK', NULL, '2019-12-14', 1),
				   ('Peshko', '0011P', NULL, '2020-04-10', 1),
				   ('Niko', '65213Ni', NULL, '2020-11-30', 0),
				   ('Roni', 'V21452', NULL, '2021-08-16', 0)

    ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC07546A9C4E]

   ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersCompositeIdUsername] PRIMARY KEY ([Id], [Username])

   ALTER TABLE [Users]
ADD CONSTRAINT [CHK_PassLength] CHECK (DATALENGTH([Password]) >= 5)

   ALTER TABLE [Users]
ADD CONSTRAINT [df_LastLoginTime] DEFAULT SYSDATETIME() FOR [LastLoginTime]

    ALTER TABLE [Users]
DROP CONSTRAINT [PK_UsersCompositeIdUsername]
    ALTER TABLE [Users]
 ADD CONSTRAINT [PK_UsersId] PRIMARY KEY ([Id])
    ALTER TABLE [Users]
 ADD CONSTRAINT [UC_Username] UNIQUE ([Username])
    ALTER TABLE [Users]
 ADD CONSTRAINT [CHK_UsernameLength] CHECK (DATALENGTH(Username) >= 3)

