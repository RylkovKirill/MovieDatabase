CREATE TRIGGER Movie_Delete
ON [dbo].[Movies]
AFTER DELETE
AS
INSERT INTO [dbo].[MoviesHistory] (
    [Id],
    [MovieId],
    [Name],
    [Country],
    [Language],
    [Description],
    [ImagePath],
    [Action],
    [Budget],
    [BoxOffice],
    [Runtime],
    [DateOfRelease],
    [Date],
    [RatingId],
    [DirectorId],
    [DistributorId])
SELECT 
    NEWID(),
    [Id],
    [Name],
    [Country],
    [Language],
    [Description],
    [ImagePath],
    'Delete',
    [Budget],
    [BoxOffice],
    [Runtime],
    [DateOfRelease],
    GETDATE(),
    [RatingId],
    [DirectorId],
    [DistributorId]
FROM DELETED