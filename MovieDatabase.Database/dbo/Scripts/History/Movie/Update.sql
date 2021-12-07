CREATE TRIGGER Movie_Update
ON [dbo].[Movies]
AFTER UPDATE
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
    'Update',
    [Budget],
    [BoxOffice],
    [Runtime],
    [DateOfRelease],
    GETDATE(),
    [RatingId],
    [DirectorId],
    [DistributorId]
FROM INSERTED