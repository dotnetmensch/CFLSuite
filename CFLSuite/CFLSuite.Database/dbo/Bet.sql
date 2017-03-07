CREATE TABLE [dbo].[Bet]
(
	[BetID] INT NOT NULL IDENTITY, 
    [ThrowTypeID] INT NOT NULL, 
    [BetDateTimeStarted] DATETIME NOT NULL, 
    CONSTRAINT [PK_Bet] PRIMARY KEY ([BetID]), 
    CONSTRAINT [FK_Bet_ThrowType] FOREIGN KEY (ThrowTypeID) REFERENCES ThrowType(ThrowTypeID) 
)
