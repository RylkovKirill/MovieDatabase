CREATE TABLE [dbo].[ReviewsHistory] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Rating]      INT              NOT NULL,
    [Content]     NVARCHAR (2048)  NULL,
    [Action]      NVARCHAR (64)    NULL,
    [DateCreated] DATETIME2 (7)    NOT NULL,
    [DateUpdated] DATETIME2 (7)    NOT NULL,
    [Date]        DATETIME2 (7)    NOT NULL,
    [UserId]      UNIQUEIDENTIFIER NOT NULL,
    [MovieId]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ReviewsHistory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ReviewsHistory_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ReviewsHistory_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movies] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ReviewsHistory_Id]
    ON [dbo].[ReviewsHistory]([Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ReviewsHistory_MovieId]
    ON [dbo].[ReviewsHistory]([MovieId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ReviewsHistory_UserId]
    ON [dbo].[ReviewsHistory]([UserId] ASC);

