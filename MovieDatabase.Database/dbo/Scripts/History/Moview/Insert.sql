CREATE TRIGGER Movie_Insert
ON [dbo].[Movies]
AFTER INSERT
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
    'Insert',
    [Budget],
    [BoxOffice],
    [Runtime],
    [DateOfRelease],
    GETDATE(),
    [RatingId],
    [DirectorId],
    [DistributorId]
FROM INSERTED