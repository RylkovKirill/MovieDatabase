CREATE TRIGGER Review_Delete
ON [dbo].[Reviews]
AFTER DELETE
AS
INSERT INTO [dbo].[ReviewHistory] ( 
    [Id],
    [ReviewId],
    [Rating],
    [Content],
    [Action],
    [DateCreated],
    [DateUpdated],
    [Date],
    [UserId],
    [MovieId])
SELECT 
    NEWID(),
    [Id],
    [Rating],
    [Content],
    'Delete',
    [DateCreated],
    [DateUpdated],
    GETDATE(),
    [UserId],
    [MovieId]
FROM DELETED