CREATE TABLE [dbo].[ExamsResults] (
    [Id]        INT NOT NULL,
    [StudentId] INT NULL,
    [Mark]      INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT fk_1 FOREIGN KEY([StudentId]) REFERENCES [dbo].[Students]([Id])
);

