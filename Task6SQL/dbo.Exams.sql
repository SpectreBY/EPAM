CREATE TABLE [dbo].[Exams] (
    [Id]        INT      NOT NULL,
    [SubjectId] INT      NULL,
    [GroupId]   INT      NULL,
    [ExamDate]  DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT fk1 FOREIGN KEY([SubjectId]) REFERENCES [dbo].[Subjects]([Id]),
	CONSTRAINT fk2 FOREIGN KEY([GroupId]) REFERENCES [dbo].[Groups]([Id])
);

