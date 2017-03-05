CREATE TABLE [dbo].[RedemptionParticipant]
(
	[RedemptionParticipantID] INT NOT NULL IDENTITY, 
    [PlayerID] INT NOT NULL, 
    [RedemptionID] INT NOT NULL, 
    [Success] BIT NOT NULL, 
    [Prize] NVARCHAR(255) NULL, 
    CONSTRAINT [PK_RedemptionParticipant] PRIMARY KEY ([RedemptionParticipantID]), 
    CONSTRAINT [FK_RedemptionParticipant_Player] FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID), 
    CONSTRAINT [FK_RedemptionParticipant_Redemption] FOREIGN KEY (RedemptionID) REFERENCES Redemption(RedemptionID) 
)
