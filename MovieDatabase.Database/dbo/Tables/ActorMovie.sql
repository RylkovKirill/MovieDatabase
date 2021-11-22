CREATE TABLE [dbo].[ActorMovie] (
    [ActorsId] UNIQUEIDENTIFIER NOT NULL,
    [MoviesId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ActorMovie] PRIMARY KEY CLUSTERED ([ActorsId] ASC, [MoviesId] ASC),
    CONSTRAINT [FK_ActorMovie_Actors_ActorsId] FOREIGN KEY ([ActorsId]) REFERENCES [dbo].[Actors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ActorMovie_Movies_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [dbo].[Movies] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ActorMovie_MoviesId]
    ON [dbo].[ActorMovie]([MoviesId] ASC);

