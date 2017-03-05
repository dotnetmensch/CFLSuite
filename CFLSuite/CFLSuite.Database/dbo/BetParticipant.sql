CREATE TABLE [dbo].[BetParticipant]
(
	[BetParticipantID] INT NOT NULL IDENTITY, 
    [BetID] INT NOT NULL, 
    [PlayerID] INT NOT NULL, 
    [Winner] BIT NOT NULL, 
    [Payout] NVARCHAR(255) NULL, 
    CONSTRAINT [PK_BetParticipant] PRIMARY KEY ([BetParticipantID]), 
    CONSTRAINT [FK_BetParticipant_Bet] FOREIGN KEY (BetID) REFERENCES Bet(BetID), 
    CONSTRAINT [FK_BetParticipant_Player] FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID) 
)
