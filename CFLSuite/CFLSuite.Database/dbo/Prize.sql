CREATE TABLE [dbo].[Prize]
(
	[PrizeID] INT NOT NULL IDENTITY, 
    [WinningPlayerID] INT NOT NULL, 
    [LosingPlayerID] INT NOT NULL, 
    [BetID] INT NOT NULL, 
    [PrizeDescription] NVARCHAR(255) NOT NULL, 
    CONSTRAINT [PK_Prize] PRIMARY KEY ([PrizeID]), 
    CONSTRAINT [FK_Prize_WinningPlayer] FOREIGN KEY (WinningPlayerID) REFERENCES Player(PlayerID), 
    CONSTRAINT [FK_Prize_LosingPlayer] FOREIGN KEY (LosingPlayerID) REFERENCES Player(PlayerID), 
    CONSTRAINT [FK_Prize_Bet] FOREIGN KEY (BetID) REFERENCES Bet(BetID) 
)
