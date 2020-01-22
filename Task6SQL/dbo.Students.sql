CREATE TABLE [dbo].[Students] (
    [Id]          INT            NOT NULL,
    [FullName]    NVARCHAR (150) NULL,
    [Gender]      INT            NULL,
    [DateOfBirth] DATETIME       NULL,
    [GroupId]     INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT fk FOREIGN KEY([GroupId]) REFERENCES [dbo].[Groups]([Id])
);

