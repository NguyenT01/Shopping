
/****** CHECK SHOPPING DB IF IT NOT EXISTS ***********/
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Shopping')
BEGIN
  CREATE DATABASE Shopping;
END;

GO
USE [Shopping]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15/03/2024 9:29:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 15/03/2024 9:29:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[CreatedUser] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedUser] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 15/03/2024 9:29:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[OrderDate] [datetime] NULL,
	[CreatedUser] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedUser] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 15/03/2024 9:29:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[OrderId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NULL,
	[CreatedUser] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedUser] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Price]    Script Date: 15/03/2024 9:29:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Price](
	[PriceId] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NULL,
	[PriceValue] [decimal](12, 2) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreatedUser] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedUser] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PriceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 15/03/2024 9:29:06 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedUser] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedUser] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240126040129_InitDB1', N'8.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240126102555_InitDB2', N'8.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240129073537_InitProductDB1', N'8.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240129074010_InitProductDbSample', N'8.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240129074225_InitProductDbSample2', N'8.0.1')
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'a941bf44-4232-4fe8-d295-08dc207203e0', N'Lan', N'Anh', N'pltk453@gmail.com', N'666 Hang Bai HN', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'da75c078-ed98-4f96-e175-08dc213e33bf', N'Duong', N'Qua', N'example22@gmail.com', N'727 South East Street, AU 22108', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'fbaf0c99-e5fb-4630-aa3d-1f8e0964424f', N'Linh', N'La', N'22234@gmail.com', N'dsf State, UK, KF11354', NULL, CAST(N'2024-03-06T14:37:29.853' AS DateTime), NULL, CAST(N'2024-03-06T14:37:29.853' AS DateTime))
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'5e8db6a1-0bd9-4ad4-9626-5b9e07ab1064', N'Linh', N'Ka', N'linhka121@gmail.com', N'Hanoi, VN', NULL, CAST(N'2024-02-15T13:40:39.593' AS DateTime), NULL, CAST(N'2024-02-15T13:40:39.593' AS DateTime))
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'94845d16-1c44-4fc6-8af0-9042dfec41f0', N'Alexa', N'Otofun', N'qua.duong21@gmail.com', N'100A Autumn Street, AU 21478', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'af5eee95-4dc4-4048-8b3e-a1297c424d0e', N'Nguyen', N'Tran', N'tsn2147@gmail.com', N'Generic State, UK, KF11354', NULL, CAST(N'2024-03-06T14:36:49.183' AS DateTime), NULL, CAST(N'2024-03-06T14:36:49.183' AS DateTime))
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'dd6a69a9-6922-4b4d-a617-f9e71385006b', N'Maxima', N'Pokemon', N'poke222@gmail.com', N'222 West Street, EU', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Order] ([OrderId], [CustomerId], [OrderDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'd18ce1b4-0740-4ac9-b15d-958ba6b36021', N'5e8db6a1-0bd9-4ad4-9626-5b9e07ab1064', CAST(N'2024-02-19T14:53:37.060' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Order] ([OrderId], [CustomerId], [OrderDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'4c91274b-25a6-4f76-9e5e-aa4c07623052', N'a941bf44-4232-4fe8-d295-08dc207203e0', CAST(N'2024-02-04T07:07:07.253' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Order] ([OrderId], [CustomerId], [OrderDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'a739cc37-4211-4c88-9c0d-abe4307f6194', N'a941bf44-4232-4fe8-d295-08dc207203e0', CAST(N'2024-02-05T08:13:17.123' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Order] ([OrderId], [CustomerId], [OrderDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'66e73dd9-820c-44d2-b8d0-bc1155df2218', N'af5eee95-4dc4-4048-8b3e-a1297c424d0e', CAST(N'2024-03-07T11:39:58.497' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Order] ([OrderId], [CustomerId], [OrderDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'45e71ff8-ab82-4024-a0a2-bd777445ff87', N'af5eee95-4dc4-4048-8b3e-a1297c424d0e', CAST(N'2024-03-07T11:32:20.757' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OrderItem] ([OrderId], [ProductId], [Quantity], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'd18ce1b4-0740-4ac9-b15d-958ba6b36021', N'bcda33a3-476e-40a0-b558-0c14e7c70ed0', 78, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OrderItem] ([OrderId], [ProductId], [Quantity], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'd18ce1b4-0740-4ac9-b15d-958ba6b36021', N'e2a85f91-ddab-427d-91eb-4c8c74a487ff', 12, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OrderItem] ([OrderId], [ProductId], [Quantity], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'd18ce1b4-0740-4ac9-b15d-958ba6b36021', N'761c91fa-0d01-4cca-b067-95bb8ebc5449', 8, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OrderItem] ([OrderId], [ProductId], [Quantity], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'4c91274b-25a6-4f76-9e5e-aa4c07623052', N'bcda33a3-476e-40a0-b558-0c14e7c70ed0', 11, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OrderItem] ([OrderId], [ProductId], [Quantity], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'4c91274b-25a6-4f76-9e5e-aa4c07623052', N'e2a85f91-ddab-427d-91eb-4c8c74a487ff', 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OrderItem] ([OrderId], [ProductId], [Quantity], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'66e73dd9-820c-44d2-b8d0-bc1155df2218', N'761c91fa-0d01-4cca-b067-95bb8ebc5449', 7, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Price] ([PriceId], [ProductID], [PriceValue], [StartDate], [EndDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'39d3e584-b7b6-426c-9c83-6bc9f888f023', N'761c91fa-0d01-4cca-b067-95bb8ebc5449', CAST(2727.00 AS Decimal(12, 2)), CAST(N'2024-02-19T03:04:55.183' AS DateTime), CAST(N'2024-02-21T03:04:55.183' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Price] ([PriceId], [ProductID], [PriceValue], [StartDate], [EndDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'37f4ce4b-3365-41c9-b994-b1a5df23ec4e', N'bcda33a3-476e-40a0-b558-0c14e7c70ed0', CAST(377.81 AS Decimal(12, 2)), CAST(N'2024-02-02T04:04:04.223' AS DateTime), CAST(N'2024-02-26T08:08:08.457' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Price] ([PriceId], [ProductID], [PriceValue], [StartDate], [EndDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'135017a0-ca59-4bbc-8e1c-c233b58c2789', N'761c91fa-0d01-4cca-b067-95bb8ebc5449', CAST(1234.00 AS Decimal(12, 2)), CAST(N'2024-02-17T08:04:19.777' AS DateTime), CAST(N'2024-03-11T13:01:12.887' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Price] ([PriceId], [ProductID], [PriceValue], [StartDate], [EndDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'a647c8be-11bf-461e-ace4-db24cc85ea7c', N'bcda33a3-476e-40a0-b558-0c14e7c70ed0', CAST(422.65 AS Decimal(12, 2)), CAST(N'2024-02-01T08:58:17.043' AS DateTime), CAST(N'2024-02-01T08:58:17.043' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Price] ([PriceId], [ProductID], [PriceValue], [StartDate], [EndDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'1395ee70-9b85-4d74-90dd-f4e6f1b772cd', N'8bfe1c9b-7506-48cc-9086-f7a9e25932c4', CAST(2533.00 AS Decimal(12, 2)), CAST(N'2024-03-07T11:02:54.673' AS DateTime), CAST(N'9999-12-31T23:59:59.997' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Price] ([PriceId], [ProductID], [PriceValue], [StartDate], [EndDate], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'42d9887f-7475-405c-b93c-ff4339113581', N'2323e6ab-1e97-41fa-b56e-6abc0a6a3bf5', CAST(0.00 AS Decimal(12, 2)), CAST(N'2024-03-07T11:00:39.183' AS DateTime), CAST(N'9999-12-31T23:59:59.997' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'bcda33a3-476e-40a0-b558-0c14e7c70ed0', N'Potato', N'A potato is a starchy tuberous vegetable that is widely consumed worldwide. It is versatile and can be cooked in various ways, such as boiling, baking, or frying.', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'e2a85f91-ddab-427d-91eb-4c8c74a487ff', N'Cherry', N'Cherry is a small, round fruit that grows on cherry trees. It comes in different varieties and colors, such as red, yellow, or black', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'2323e6ab-1e97-41fa-b56e-6abc0a6a3bf5', N'Blueberry', N'Blueberries have a sweet and tangy flavor and are often used in baking, smoothies, or eaten fresh.', NULL, CAST(N'2024-03-07T11:00:39.150' AS DateTime), NULL, CAST(N'2024-03-07T11:00:39.150' AS DateTime))
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'761c91fa-0d01-4cca-b067-95bb8ebc5449', N'Apple', N'Apple is a round fruit with a crisp and juicy texture.', NULL, CAST(N'2024-02-16T15:28:58.473' AS DateTime), NULL, CAST(N'2024-02-16T15:28:58.473' AS DateTime))
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'de2018fd-4e94-4a9c-83f4-e41b5114064c', N'Tuna', N'Tuna is a type of saltwater fish that belongs to the mackerel family. It is known for its firm, flavorful flesh and is popular in cuisines around the world.', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [CreatedUser], [CreatedDate], [UpdatedUser], [UpdatedDate]) VALUES (N'8bfe1c9b-7506-48cc-9086-f7a9e25932c4', N'Lion Fish', N'The lionfish is a venomous marine fish native to the Indo-Pacific region. It is known for its striking appearance, with vibrant colors and long, venomous spines', NULL, CAST(N'2024-03-07T11:02:54.573' AS DateTime), NULL, CAST(N'2024-03-07T11:02:54.573' AS DateTime))
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Price]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Price]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Price]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Price]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductId])
GO