CREATE TABLE [dbo].[Prize]
(
	[PrizeID] INT NOT NULL IDENTITY, 
    [WinningParticipantID] INT NOT NULL, 
    [LosingParticipantID] INT NOT NULL, 
    [PrizeDescription] NVARCHAR(255) NOT NULL, 
    CONSTRAINT [PK_Prize] PRIMARY KEY ([PrizeID]), 
    CONSTRAINT [FK_Prize_WinningParticipant] FOREIGN KEY ([WinningParticipantID]) REFERENCES Participant(ParticipantID), 
    CONSTRAINT [FK_Prize_LosingParticipant] FOREIGN KEY ([LosingParticipantID]) REFERENCES Participant(ParticipantID), 
)
