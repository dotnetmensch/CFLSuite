CREATE TABLE [dbo].[Throw]
(
	[ThrowID] INT NOT NULL IDENTITY, 
    [ThrowTypeID] INT NOT NULL, 
    [ParticipantID] INT NOT NULL, 
    [Success] BIT NOT NULL, 
    [Notes] NVARCHAR(1048) NULL, 
    CONSTRAINT [PK_Throw] PRIMARY KEY ([ThrowID]), 
    CONSTRAINT [FK_Throw_ThrowingPlayer] FOREIGN KEY ([ParticipantID]) REFERENCES [Participant]([ParticipantID]), 
    CONSTRAINT [FK_Throw_ThrowType] FOREIGN KEY (ThrowTypeID) REFERENCES ThrowType(ThrowTypeID) 
)
