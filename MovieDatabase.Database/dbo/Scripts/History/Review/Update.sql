CREATE TRIGGER Review_Update
ON [dbo].[Reviews]
AFTER UPDATE
AS
INSERT INTO [dbo].[ReviewsHistory] (  
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
    'Update',
    [DateCreated],
    [DateUpdated],
    GETDATE(),
    [UserId],
    [MovieId]
FROM INSERTED