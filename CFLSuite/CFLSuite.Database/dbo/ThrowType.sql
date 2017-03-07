CREATE TABLE [dbo].[ThrowType]
(
	[ThrowTypeID] INT NOT NULL IDENTITY, 
    [Description] NVARCHAR(1048) NOT NULL, 
    CONSTRAINT [PK_ThrowType] PRIMARY KEY ([ThrowTypeID]) 
)
