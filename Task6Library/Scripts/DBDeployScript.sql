CREATE DATABASE Task6DB;
GO
USE Task6DB;
GO
CREATE TABLE [dbo].[Groups]
(
	[Id] INT NOT NULL PRIMARY KEY([Id] ASC), 
    [Name] NVARCHAR(50) NULL
);

CREATE TABLE [dbo].[Subjects]
(
	[Id] INT NOT NULL PRIMARY KEY([Id] ASC), 
    [Name] NVARCHAR(100) NULL
);

CREATE TABLE [dbo].[Sessions]
(
	[Id] INT NOT NULL PRIMARY KEY([Id] ASC), 
    [EducationPeriod] NVARCHAR(50) NULL,
    [Semestr] INT NULL
);


CREATE TABLE [dbo].[SubjectsOfGroups]
(
	[Id] INT NOT NULL PRIMARY KEY([Id] ASC), 
	[GroupId] INT NULL, 
	[SubjectId] INT NULL,
	CONSTRAINT fk_subjectsOfGroups_1 FOREIGN KEY([GroupId]) REFERENCES [dbo].[Groups]([Id]),
	CONSTRAINT fk_subjectsOfGroups_2 FOREIGN KEY([SubjectId]) REFERENCES [dbo].[Subjects]([Id])
);

CREATE TABLE [dbo].[Exams]
(
	[Id] INT NOT NULL PRIMARY KEY([Id] ASC),
	[SessionId] INT NULL, 
    [ExamDate] DATETIME NULL,
	[SubjectsOfGroupId] INT NULL,
	CONSTRAINT fk_exams_1 FOREIGN KEY([SessionId]) REFERENCES [dbo].[Sessions]([Id]),
	CONSTRAINT fk_exams_2 FOREIGN KEY([SubjectsOfGroupId]) REFERENCES [dbo].[SubjectsOfGroups]([Id])
);

CREATE TABLE [dbo].[Students] 
(
    [Id] INT NOT NULL PRIMARY KEY([Id] ASC),
    [FullName] NVARCHAR (150) NULL,
    [Gender]  NVARCHAR (10) NULL,
    [DateOfBirth] DATETIME NULL,
    [GroupId] INT NULL,
    CONSTRAINT fk_students FOREIGN KEY([GroupId]) REFERENCES [dbo].[Groups]([Id])
);

CREATE TABLE [dbo].[ResultsOfExams] 
(
    [Id] INT NOT NULL PRIMARY KEY([Id] ASC),
    [StudentId] INT NULL,
    [ExamId] INT NULL,
    [Result] INT NULL,
	CONSTRAINT fk_results_exams_1 FOREIGN KEY([StudentId]) REFERENCES [dbo].[Students]([Id]),
	CONSTRAINT fk_results_exams_2 FOREIGN KEY([ExamId]) REFERENCES [dbo].[Exams]([Id])
);