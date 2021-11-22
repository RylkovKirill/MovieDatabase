CREATE TABLE [dbo].[Reviews] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Rating]      INT              NOT NULL,
    [Content]     NVARCHAR (2048)  NULL,
    [DateCreated] DATETIME2 (7)    NOT NULL,
    [DateUpdated] DATETIME2 (7)    NOT NULL,
    [UserId]      UNIQUEIDENTIFIER NOT NULL,
    [MovieId]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reviews_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reviews_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movies] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Reviews_Id]
    ON [dbo].[Reviews]([Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Reviews_MovieId]
    ON [dbo].[Reviews]([MovieId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Reviews_UserId]
    ON [dbo].[Reviews]([UserId] ASC);

