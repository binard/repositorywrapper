DELETE FROM [User];
SET IDENTITY_INSERT [User] ON;
INSERT INTO [User](Id, Email, Name, FirstName) Values(1, 'test@test.fr', 'Robert', 'Firmin'); 
INSERT INTO [User](Id, Email, Name, FirstName) Values(2, 'michel@gmail.com', 'Dubois', 'Michel');
SET IDENTITY_INSERT [User] OFF;