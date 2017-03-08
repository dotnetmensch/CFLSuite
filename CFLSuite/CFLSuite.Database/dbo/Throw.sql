CREATE TABLE [dbo].[Throw]
(
	[ThrowID] INT NOT NULL IDENTITY, 
    [ThrowTypeID] INT NOT NULL, 
    [ThrowingPlayerID] INT NOT NULL, 
    [Points] INT NOT NULL, 
    [ReceivingPlayerID] INT NULL, 
    [RedemptionForThrowID] INT NULL, 
    [BetID] INT NULL, 
    [Notes] NVARCHAR(1048) NULL, 
    CONSTRAINT [PK_Throw] PRIMARY KEY ([ThrowID]), 
    CONSTRAINT [FK_Throw_ThrowingPlayer] FOREIGN KEY (ThrowingPlayerID) REFERENCES Player(PlayerID), 
    CONSTRAINT [FK_Throw_ThrowType] FOREIGN KEY (ThrowTypeID) REFERENCES ThrowType(ThrowTypeID), 
    CONSTRAINT [FK_Throw_ReceivingPlayer] FOREIGN KEY ([ReceivingPlayerID]) REFERENCES Player(PlayerID), 
    CONSTRAINT [FK_Throw_RedemptionForThrow] FOREIGN KEY (RedemptionForThrowID) REFERENCES [Throw](ThrowID), 
    CONSTRAINT [FK_Throw_Bet] FOREIGN KEY (BetID) REFERENCES Bet(BetID) 
)
