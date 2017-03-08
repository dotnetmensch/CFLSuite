﻿CREATE TABLE [dbo].[Bet]
(
	[BetID] INT NOT NULL IDENTITY, 
    [Description] NVARCHAR(1048) NULL, 
    [BetStarted] DATETIME NOT NULL, 
    [ThrowID] INT NULL, 
    CONSTRAINT [PK_Bet] PRIMARY KEY ([BetID]), 
    CONSTRAINT [FK_Bet_Throw] FOREIGN KEY (ThrowID) REFERENCES [Throw](ThrowID) 
)
