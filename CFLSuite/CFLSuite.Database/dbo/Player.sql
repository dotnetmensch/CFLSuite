CREATE TABLE [dbo].[Player]
(
	[PlayerID] INT NOT NULL IDENTITY , 
    [Name] NVARCHAR(1048) NOT NULL, 
    CONSTRAINT [PK_Players] PRIMARY KEY ([PlayerID])
)
