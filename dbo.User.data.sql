SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([ID], [CtyID], [Discriminator], [FirstName], [IsAdmin], [LastName], [Miles], [Email], [Password]) VALUES (1007, 4, N'User', N'Dor', 1, N'Nissan', NULL, N'Dor@Nissan.com', N'Dd123456')
INSERT INTO [dbo].[User] ([ID], [CtyID], [Discriminator], [FirstName], [IsAdmin], [LastName], [Miles], [Email], [Password]) VALUES (1008, 9, N'User', N'Kim', 0, N'Boren', NULL, N'Kim@Boren', N'Kk123456')
SET IDENTITY_INSERT [dbo].[User] OFF
