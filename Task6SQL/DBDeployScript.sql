CREATE TABLE [dbo].[Groups]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Course] INT NULL
);

CREATE TABLE [dbo].[Subjects]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NULL
);

CREATE TABLE [dbo].[Students] (
    [Id]          INT            NOT NULL,
    [FullName]    NVARCHAR (150) NULL,
    [Gender]      INT            NULL,
    [DateOfBirth] DATETIME       NULL,
    [GroupId]     INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT fk_groups FOREIGN KEY([GroupId]) REFERENCES [dbo].[Groups]([Id])
);

CREATE TABLE [dbo].[Exams] (
    [Id]        INT      NOT NULL,
    [SubjectId] INT      NULL,
    [GroupId]   INT      NULL,
    [ExamDate]  DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT fk_subjects FOREIGN KEY([SubjectId]) REFERENCES [dbo].[Subjects]([Id]),
	CONSTRAINT fk_groups FOREIGN KEY([GroupId]) REFERENCES [dbo].[Groups]([Id])
);

CREATE TABLE [dbo].[ExamsResults] (
    [Id]        INT NOT NULL,
    [StudentId] INT NULL,
    [ExamId] INT NULL,
    [Mark]      INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT fk_students FOREIGN KEY([StudentId]) REFERENCES [dbo].[Students]([Id]),
	CONSTRAINT fk_exams FOREIGN KEY([ExamId]) REFERENCES [dbo].[Exams]([Id])
);







