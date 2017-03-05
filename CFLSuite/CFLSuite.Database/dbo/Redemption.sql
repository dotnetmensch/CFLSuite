CREATE TABLE [dbo].[Redemption]
(
	[RedemptionID] INT NOT NULL IDENTITY, 
    [BetID] INT NULL, 
    [Description] NVARCHAR(1048) NULL, 
    [PlayerID] INT NOT NULL, 
    CONSTRAINT [PK_Redemption] PRIMARY KEY ([RedemptionID]), 
    CONSTRAINT [FK_Redemption_Bet] FOREIGN KEY (BetID) REFERENCES Bet(BetID), 
    CONSTRAINT [FK_Redemption_Player] FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID) 
)
