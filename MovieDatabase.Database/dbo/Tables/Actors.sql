CREATE TABLE [dbo].[Actors] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [FirstName]   NVARCHAR (64)    NOT NULL,
    [LastName]    NVARCHAR (64)    NOT NULL,
    [DateOfBirth] DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Actors_Id]
    ON [dbo].[Actors]([Id] ASC);

