CREATE TABLE [dbo].[Movies] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Name]          NVARCHAR (64)    NOT NULL,
    [Country]       NVARCHAR (32)    NOT NULL,
    [Language]      NVARCHAR (32)    NOT NULL,
    [Description]   NVARCHAR (2048)  NULL,
    [ImagePath]     NVARCHAR (64)    NULL,
    [Budget]        DECIMAL (14, 2)  NOT NULL,
    [BoxOffice]     DECIMAL (14, 2)  NOT NULL,
    [Runtime]       TIME (7)         NOT NULL,
    [DateOfRelease] DATETIME2 (7)    NOT NULL,
    [RatingId]      UNIQUEIDENTIFIER NULL,
    [DirectorId]    UNIQUEIDENTIFIER NULL,
    [DistributorId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Movies_Directors_DirectorId] FOREIGN KEY ([DirectorId]) REFERENCES [dbo].[Directors] ([Id]),
    CONSTRAINT [FK_Movies_Distributors_DistributorId] FOREIGN KEY ([DistributorId]) REFERENCES [dbo].[Distributors] ([Id]),
    CONSTRAINT [FK_Movies_Ratings_RatingId] FOREIGN KEY ([RatingId]) REFERENCES [dbo].[Ratings] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Movies_DirectorId]
    ON [dbo].[Movies]([DirectorId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Movies_DistributorId]
    ON [dbo].[Movies]([DistributorId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Movies_Id]
    ON [dbo].[Movies]([Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Movies_RatingId]
    ON [dbo].[Movies]([RatingId] ASC);

