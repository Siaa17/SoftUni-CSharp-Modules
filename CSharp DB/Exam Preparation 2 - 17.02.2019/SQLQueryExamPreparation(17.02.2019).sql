CREATE DATABASE [School]

USE [School]

--- 1. DDL

CREATE TABLE [Students]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [FirstName] NVARCHAR(30) NOT NULL,
			 [MiddleName] NVARCHAR(25),
	         [LastName] NVARCHAR(30) NOT NULL,
			 [Age] INT CHECK([Age] BETWEEN 5 AND 100),  
			 [Address] NVARCHAR(50),
			 [Phone] NCHAR(10)
);

CREATE TABLE [Subjects]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [Name] NVARCHAR(20) NOT NULL,
			 [Lessons] INT CHECK([Lessons] > 0) NOT NULL
);

CREATE TABLE [StudentsSubjects]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [StudentId] INT FOREIGN KEY REFERENCES [Students]([Id]) NOT NULL,
			 [SubjectId] INT FOREIGN KEY REFERENCES [Subjects]([Id]) NOT NULL,
			 [Grade] DECIMAL(3, 2) CHECK([Grade] BETWEEN 2 AND 6) NOT NULL
);

CREATE TABLE [Exams]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,
			 [Date] DATETIME,
			 [SubjectId] INT FOREIGN KEY REFERENCES [Subjects]([Id]) NOT NULL
);

CREATE TABLE [StudentsExams]
(
             [StudentId] INT FOREIGN KEY REFERENCES [Students]([Id]) NOT NULL,
			 [ExamId] INT FOREIGN KEY REFERENCES [Exams]([Id]) NOT NULL,
			 [Grade] DECIMAL(3, 2) CHECK([Grade] BETWEEN 2 AND 6) NOT NULL,
			 PRIMARY KEY([StudentId], [ExamId])
);

CREATE TABLE [Teachers]
(
             [Id] INT PRIMARY KEY IDENTITY NOT NULL,  
			 [FirstName] NVARCHAR(20) NOT NULL,
			 [LastName] NVARCHAR(20) NOT NULL,
			 [Address] NVARCHAR(20) NOT NULL,
			 [Phone] CHAR(10),
			 [SubjectId] INT FOREIGN KEY REFERENCES [Subjects]([Id]) NOT NULL
);

CREATE TABLE [StudentsTeachers]
(
             [StudentId] INT FOREIGN KEY REFERENCES [Students]([Id]) NOT NULL,
			 [TeacherId] INT FOREIGN KEY REFERENCES [Teachers]([Id]) NOT NULL,
			 PRIMARY KEY([StudentId], [TeacherId])
)

--- 2. Insert

INSERT INTO [Teachers]([FirstName], [LastName], [Address], [Phone], [SubjectId]) VALUES
                      ('Ruthanne', 'Bamb', '84948 Mesta Junction', 3105500146, 6),
					  ('Gerrard', 'Lowin', '370 Talisman Plaza', 3324874824, 2),
					  ('Merrile', 'Lambdin', '81 Dahle Plaza', 4373065154, 5),
					  ('Bert', 'Ivie', '2 Gateway Circle', 4409584510,	4)

INSERT INTO [Subjects]([Name], [Lessons]) VALUES
                      ('Geometry', 12),
					  ('Health', 10),
					  ('Drama', 7),
					  ('Sports', 9)

--- 3. Update

UPDATE [StudentsSubjects]
   SET [Grade] = 6.00
 WHERE [SubjectId] IN (1, 2) AND [Grade] >= 5.50

--- 4. Delete

   DELETE [StudentsTeachers]
     FROM [StudentsTeachers] AS st
LEFT JOIN [Teachers] AS t
       ON st.[TeacherId] = t.[Id]
    WHERE t.[Phone] LIKE '%72%'

DELETE 
  FROM [Teachers]
 WHERE [Phone] LIKE '%72%'

--- 5. Teen Students

  SELECT [FirstName],
         [LastName],
	     [Age]
    FROM [Students]
   WHERE [Age] >= 12
ORDER BY [FirstName] ASC, [LastName] ASC

--- 6. Students Teachers

    SELECT s.[FirstName],
           s.[LastName],
		   COUNT(st.[TeacherId]) AS[TeachersCount]
      FROM [Students] AS s
INNER JOIN [StudentsTeachers] AS st
        ON s.[Id] = st.[StudentId]
  GROUP BY s.[FirstName], s.[LastName]

--- 7. Students to Go

   SELECT CONCAT(s.[FirstName], ' ', s.[LastName]) AS [Full Name]
     FROM [Students] AS s
LEFT JOIN [StudentsExams] AS se
       ON s.[Id] = se.[StudentId]
	WHERE se.[ExamId] IS NULL
 ORDER BY [Full Name] ASC

--- 8. Top Students

   SELECT TOP(10) s.[FirstName] AS [First Name],
                  s.[LastName] AS [Last Name], 
	              CAST(AVG(se.[Grade]) AS DECIMAL(3, 2)) AS [Grade]
     FROM [Students] AS s
LEFT JOIN [StudentsExams] AS se
       ON s.[Id] = se.[StudentId]
 GROUP BY s.[FirstName], s.[LastName]
 ORDER BY [Grade] DESC, [First Name] ASC, [Last Name] ASC

--- 9. Not So In The Studying

   SELECT 
          CASE 
		      WHEN s.[MiddleName] IS NULL THEN CONCAT(s.[FirstName], ' ', s.[LastName]) 
			  ELSE CONCAT(s.[FirstName], ' ', s.[MiddleName], ' ', s.[LastName])
          END   AS [Full Name]
     FROM [Students] AS s
LEFT JOIN [StudentsSubjects] AS ss
       ON s.[Id] = ss.[StudentId]
	WHERE [SubjectId] IS NULL
 ORDER BY [Full Name] ASC

--- 10. Average Grade per Subject

    SELECT s.[Name],
           AVG(ss.[Grade]) AS [AverageGrade]
      FROM [Subjects] AS s
INNER JOIN [StudentsSubjects] AS ss
        ON s.[Id] = ss.[SubjectId]
  GROUP BY s.[Name], ss.[SubjectId]
  ORDER BY ss.[SubjectId] ASC

--- 11. Exam Grades
GO

CREATE FUNCTION udf_ExamGradesToUpdate (@studentId INT, @grade DECIMAL(3, 2))
RETURNS VARCHAR(80)
AS
BEGIN
    DECLARE @countOfGrades INT = (SELECT COUNT([Grade]) FROM [StudentsExams]
	                                WHERE [StudentId] = @studentId
									AND ([Grade] BETWEEN @grade AND (@grade + 0.50)))

	DECLARE @studentFirstName NVARCHAR(30) = (SELECT [FirstName] FROM [Students]
	                                           WHERE [Id] = @studentId)  
	
	IF (NOT EXISTS(SELECT [Id] FROM [Students] WHERE [Id] = @studentId))
	  RETURN 'The student with provided id does not exist in the school!'
	ELSE IF (@grade > 6)
	  RETURN 'Grade cannot be above 6.00!'

	  RETURN CONCAT('You have to update ', @countOfGrades, ' grades for the student ', @studentFirstName)
END

GO

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

--- 12. Exclude from school
GO

CREATE PROC usp_ExcludeFromSchool (@StudentId INT)
AS
BEGIN
    IF (NOT EXISTS(SELECT [Id] FROM [Students] WHERE [Id] = @StudentId))
	  THROW 50001,'This school has no student with the provided id!', 1

	DELETE FROM [StudentsSubjects]
	 WHERE [StudentId] = @StudentId

	 DELETE FROM [StudentsExams]
	  WHERE [StudentId] = @StudentId

	  DELETE FROM [StudentsTeachers]
	   WHERE [StudentId] = @StudentId

	   DELETE FROM [Students]
	    WHERE [Id] = @StudentId
END 

GO

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301
