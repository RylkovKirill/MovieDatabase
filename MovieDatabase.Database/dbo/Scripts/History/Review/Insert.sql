CREATE TRIGGER Review_Insert
ON [dbo].[Reviews]
AFTER INSERT
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
    'Insert',
    [DateCreated],
    [DateUpdated],
    GETDATE(),
    [UserId],
    [MovieId]
FROM INSERTED