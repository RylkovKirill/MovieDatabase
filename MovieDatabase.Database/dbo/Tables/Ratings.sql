CREATE TABLE [dbo].[Ratings] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (64)    NOT NULL,
    [Description] NVARCHAR (2048)  NULL,
    CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Ratings_Id]
    ON [dbo].[Ratings]([Id] ASC);

