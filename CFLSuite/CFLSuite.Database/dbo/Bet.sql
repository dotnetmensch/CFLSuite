CREATE TABLE [dbo].[Bet]
(
	[BetID] INT NOT NULL IDENTITY, 
    [Description] NVARCHAR(1048) NULL, 
    [BetStarted] DATETIME NOT NULL, 
    CONSTRAINT [PK_Bet] PRIMARY KEY ([BetID]) 
)
