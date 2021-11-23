CREATE TABLE [dbo].[MoviesHistory] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Name]          NVARCHAR (64)    NOT NULL,
    [Country]       NVARCHAR (32)    NOT NULL,
    [Language]      NVARCHAR (32)    NOT NULL,
    [Description]   NVARCHAR (2048)  NULL,
    [ImagePath]     NVARCHAR (64)    NULL,
    [Action]        NVARCHAR (64)    NULL,
    [Budget]        DECIMAL (14, 2)  NOT NULL,
    [BoxOffice]     DECIMAL (14, 2)  NOT NULL,
    [Runtime]       TIME (7)         NOT NULL,
    [DateOfRelease] DATETIME2 (7)    NOT NULL,
    [Date]          DATETIME2 (7)    NOT NULL,
    [RatingId]      UNIQUEIDENTIFIER NULL,
    [DirectorId]    UNIQUEIDENTIFIER NULL,
    [DistributorId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_MoviesHistory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MoviesHistory_Directors_DirectorId] FOREIGN KEY ([DirectorId]) REFERENCES [dbo].[Directors] ([Id]),
    CONSTRAINT [FK_MoviesHistory_Distributors_DistributorId] FOREIGN KEY ([DistributorId]) REFERENCES [dbo].[Distributors] ([Id]),
    CONSTRAINT [FK_MoviesHistory_Ratings_RatingId] FOREIGN KEY ([RatingId]) REFERENCES [dbo].[Ratings] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_MoviesHistory_DirectorId]
    ON [dbo].[MoviesHistory]([DirectorId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MoviesHistory_DistributorId]
    ON [dbo].[MoviesHistory]([DistributorId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MoviesHistory_Id]
    ON [dbo].[MoviesHistory]([Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MoviesHistory_RatingId]
    ON [dbo].[MoviesHistory]([RatingId] ASC);

