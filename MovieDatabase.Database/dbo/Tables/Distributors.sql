CREATE TABLE [dbo].[Distributors] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (64)    NOT NULL,
    [Description] NVARCHAR (2048)  NULL,
    [DateFounded] DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Distributors] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Distributors_Id]
    ON [dbo].[Distributors]([Id] ASC);

