CREATE TABLE [dbo].[Genres] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (64)    NOT NULL,
    [Description] NVARCHAR (2048)  NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Genres_Id]
    ON [dbo].[Genres]([Id] ASC);

