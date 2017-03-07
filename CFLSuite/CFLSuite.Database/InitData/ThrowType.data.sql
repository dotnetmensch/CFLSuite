Merge Into ThrowType As Target
Using (Values	
	('Standing Underhand'),
	('Sitting Underhand'),
	('Free Throw')
)
As Source ([Description])
On Target.[Description] = Source.[Description]

-- INSERT new rows --
When NOT MATCHED By Target Then
Insert ([Description])
Values (Source.[Description]);