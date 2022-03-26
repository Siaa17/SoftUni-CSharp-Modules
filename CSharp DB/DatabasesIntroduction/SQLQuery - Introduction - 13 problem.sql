CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [DirectorName] NVARCHAR(50) NOT NULL,
			 [Notes] NVARCHAR(MAX),
)

INSERT INTO [Directors]([DirectorName], [Notes]) VALUES 
                       ('Sia', 'The best'),
                       ('Peter', 'Not bad'),
                       ('Gogo', NULL),
                       ('Bianka', 'The best'),
                       ('Hristo', 'Good director')

CREATE TABLE [Genres]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [GenreName] NVARCHAR(50) NOT NULL,
			 [Notes] NVARCHAR(MAX),
)

INSERT INTO [Genres]([GenreName], [Notes]) VALUES
                    ('Comedy', 'Very funny'),
					('Drama', NULL),
					('Horror', 'Terrifying'),
					('Mistery', 'Interesting'),
					('Romance', NULL)

CREATE TABLE [Categories]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [CategoryName] NVARCHAR(50) NOT NULL,
			 [Notes] NVARCHAR(MAX),
)

INSERT INTO [Categories]([CategoryName], [Notes]) VALUES
                    ('Action', 'Very funny'),
					('Thriller', 'Scarry'),
					('Fantasy', 'Interesting'),
					('Western', NULL),
					('Sci-fi', NULL)

CREATE TABLE [Movies]
(
             [Id] INT PRIMARY KEY IDENTITY,
			 [Title] NVARCHAR(50) NOT NULL,
			 [DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
			 [CopyrightYear] INT NOT NULL,
			 [Length] INT NOT NULL,
			 [GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
			 [CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
			 [Rating] REAL CHECK ([Rating] >= 0 AND [Rating] <= 10) NOT NULL,
			 [Notes] NVARCHAR(MAX)
)

INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes]) VALUES
                    ('Joker', 1, 2019, 122, 1, 3, 8.4, 'Deserves to watch'),
					('Notthing Hill', 5, 1999, 124, 2, 3, 7.1, 'Highly recommend'),
					('Hachi: A Dogs Tale', 3, 2009, 93, 2, 4, 8.1, 'Deserves to watch'),
					('Her', 2, 2013, 126, 3, 3, 7.9, 'Good movie'),
					('Fatherhood', 4, 2021, 109, 5, 4, 6.6, 'Good movie')
