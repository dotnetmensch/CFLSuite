CREATE TABLE [dbo].[Bet]
(
	[BetID] INT NOT NULL, 
    [ThrowDescription] NVARCHAR(1048) NOT NULL, 
    [BetDateTimeStarted] DATETIME NOT NULL, 
    CONSTRAINT [PK_Bet] PRIMARY KEY ([BetID]) 
)
