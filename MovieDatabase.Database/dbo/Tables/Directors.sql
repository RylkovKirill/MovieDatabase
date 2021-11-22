CREATE TABLE [dbo].[Directors] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [FirstName]   NVARCHAR (64)    NOT NULL,
    [LastName]    NVARCHAR (64)    NOT NULL,
    [DateOfBirth] DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Directors] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Directors_Id]
    ON [dbo].[Directors]([Id] ASC);

