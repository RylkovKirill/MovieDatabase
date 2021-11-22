CREATE TABLE [dbo].[GenreMovie] (
    [GenresId] UNIQUEIDENTIFIER NOT NULL,
    [MoviesId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_GenreMovie] PRIMARY KEY CLUSTERED ([GenresId] ASC, [MoviesId] ASC),
    CONSTRAINT [FK_GenreMovie_Genres_GenresId] FOREIGN KEY ([GenresId]) REFERENCES [dbo].[Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_GenreMovie_Movies_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [dbo].[Movies] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_GenreMovie_MoviesId]
    ON [dbo].[GenreMovie]([MoviesId] ASC);

