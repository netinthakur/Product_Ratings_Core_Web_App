SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT INTO [dbo].[Customer] ([Id], [Name], [Email]) VALUES (1, N'John Smith', N'john@gmail.com')
INSERT INTO [dbo].[Customer] ([Id], [Name], [Email]) VALUES (2, N'Adam Bell', N'adam@gmail.com')
INSERT INTO [dbo].[Customer] ([Id], [Name], [Email]) VALUES (3, N'Chris Watson', N'chris@gmail.com')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([Id], [Name], [Price]) VALUES (1, N'Apple iPhone', CAST(800.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Product] ([Id], [Name], [Price]) VALUES (2, N'HP Elite Book', CAST(700.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Product] ([Id], [Name], [Price]) VALUES (3, N'Play Station 4', CAST(600.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Rating] ON
INSERT INTO [dbo].[Rating] ([Id], [CustomerId], [ProductId], [RatingValue], [Comment]) VALUES (1, 1, 1, 5, N'Existing New look')
INSERT INTO [dbo].[Rating] ([Id], [CustomerId], [ProductId], [RatingValue], [Comment]) VALUES (2, 2, 2, 5, N'Excellent performance')
SET IDENTITY_INSERT [dbo].[Rating] OFF
