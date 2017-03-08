CREATE TABLE [dbo].[Participant]
(
	[ParticipantID] INT NOT NULL IDENTITY , 
    [PlayerID] INT NOT NULL, 
    [BetID] INT NOT NULL, 
    [Winner] BIT NOT NULL, 
    CONSTRAINT [PK_Participant] PRIMARY KEY ([ParticipantID]), 
    CONSTRAINT [FK_Participant_Player] FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID), 
    CONSTRAINT [FK_Participant_Bet] FOREIGN KEY (BetID) REFERENCES Bet(BetID)
)
