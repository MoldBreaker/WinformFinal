CREATE DATABASE [CoffeeManagement];
GO
USE [CoffeeManagement]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 10/23/2023 10:35:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[CardNumber] [varchar](20) NOT NULL,
	[UserId] [int] NULL,
	[Rank] [nvarchar](50) NULL,
	[Point] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CardNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 10/23/2023 10:35:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TableId] [int] NULL,
	[TotalPrice] [float] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Discount] [float] NULL,
	[AfterDiscount] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 10/23/2023 10:35:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[InvoiceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/23/2023 10:35:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Image] [varchar](255) NULL,
	[SellPrice] [float] NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 10/23/2023 10:35:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/23/2023 10:35:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [varchar](10) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 10/23/2023 10:35:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/23/2023 10:35:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[SDT] [varchar](20) NULL,
	[RoleId] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Card] ([CardNumber], [UserId], [Rank], [Point]) VALUES (N'0935673253', 4, N'Đồng', 1621)
INSERT [dbo].[Card] ([CardNumber], [UserId], [Rank], [Point]) VALUES (N'0963638362', 8, N'Vô Hạng', 0)
INSERT [dbo].[Card] ([CardNumber], [UserId], [Rank], [Point]) VALUES (N'0963828283', 10, N'Đồng', 1380)
INSERT [dbo].[Card] ([CardNumber], [UserId], [Rank], [Point]) VALUES (N'0973832872', 9, N'Đồng', 1931)
INSERT [dbo].[Card] ([CardNumber], [UserId], [Rank], [Point]) VALUES (N'0987654321', 2, N'Bạc', 4372)
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (1, 2, 1, 231000, CAST(N'2023-10-17T16:53:18.777' AS DateTime), 10, 207900)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (2, 2, NULL, 210000, CAST(N'2023-10-17T16:58:22.197' AS DateTime), 10, 189000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (4, 2, 3, 20000, CAST(N'2023-10-17T17:02:27.550' AS DateTime), 0, 20000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (5, 2, NULL, 320000, CAST(N'2023-10-17T17:04:11.417' AS DateTime), 15, 272000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (6, 2, NULL, 32000, CAST(N'2023-10-18T22:37:05.270' AS DateTime), 0, 32000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (7, 2, NULL, 20000, CAST(N'2023-10-18T22:37:10.467' AS DateTime), 0, 20000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (8, 2, NULL, 3500000, CAST(N'2023-10-19T08:00:43.293' AS DateTime), 15, 2975000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (9, 2, 10, 260000, CAST(N'2023-10-19T22:04:47.140' AS DateTime), 10, 234000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (10, 2, NULL, 203000, CAST(N'2023-10-21T11:53:02.177' AS DateTime), 10, 182700)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (11, 2, NULL, 616000, CAST(N'2023-10-21T11:53:37.377' AS DateTime), 15, 523600)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (12, 4, NULL, 301000, CAST(N'2023-10-21T11:55:24.607' AS DateTime), 15, 255850)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (13, 4, 10, 594000, CAST(N'2023-10-21T11:55:42.633' AS DateTime), 15, 504900)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (14, 4, 10, 282000, CAST(N'2023-10-21T11:56:04.560' AS DateTime), 10, 253800)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (15, 4, NULL, 348000, CAST(N'2023-10-21T11:56:37.953' AS DateTime), 15, 295800)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (16, 4, NULL, 260000, CAST(N'2023-10-21T11:57:12.000' AS DateTime), 10, 234000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (17, 4, NULL, 1285000, CAST(N'2023-10-21T11:59:28.543' AS DateTime), 15, 1092250)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (18, 2, NULL, 140000, CAST(N'2023-10-21T16:10:18.820' AS DateTime), 5, 133000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (19, 2, 1, 35000, CAST(N'2023-10-21T22:12:03.727' AS DateTime), 0, 35000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (20, 2, NULL, 32000, CAST(N'2023-10-23T08:18:19.533' AS DateTime), 0, 32000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (21, 2, 9, 35000, CAST(N'2023-10-23T08:19:22.157' AS DateTime), 0, 35000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (22, 2, 3, 147000, CAST(N'2023-10-23T08:27:28.353' AS DateTime), 5, 139650)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (23, 8, NULL, 815000, CAST(N'2023-10-23T08:55:07.540' AS DateTime), 15, 692750)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (24, 8, NULL, 680000, CAST(N'2023-10-23T08:55:37.567' AS DateTime), 15, 578000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (25, 8, NULL, 560000, CAST(N'2023-10-23T08:56:18.793' AS DateTime), 15, 476000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (26, 9, NULL, 1071000, CAST(N'2023-10-23T09:04:00.427' AS DateTime), 15, 910350)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (27, 9, NULL, 454000, CAST(N'2023-10-23T09:04:32.763' AS DateTime), 15, 385900)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (28, 9, 10, 749000, CAST(N'2023-10-23T09:05:09.187' AS DateTime), 15, 636650)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (29, 10, 6, 769000, CAST(N'2023-10-23T09:07:46.300' AS DateTime), 15, 653650)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (30, 10, NULL, 446000, CAST(N'2023-10-23T09:08:26.613' AS DateTime), 15, 379100)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (31, 10, NULL, 410000, CAST(N'2023-10-23T09:08:46.533' AS DateTime), 15, 348500)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [TableId], [TotalPrice], [CreatedAt], [Discount], [AfterDiscount]) VALUES (32, 2, 10, 32000, CAST(N'2023-10-23T10:14:02.900' AS DateTime), 0, 32000)
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (1, 1, 3, 96000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (1, 2, 1, 35000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (1, 3, 5, 100000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (2, 2, 6, 210000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (4, 3, 1, 20000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (5, 1, 10, 320000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (6, 1, 1, 32000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (7, 3, 1, 20000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (8, 2, 100, 3500000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (9, 1, 3, 96000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (9, 3, 5, 100000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (9, 9, 2, 64000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (10, 7, 5, 75000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (10, 9, 4, 128000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (11, 10, 7, 245000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (11, 15, 5, 115000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (11, 17, 8, 256000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (12, 5, 4, 140000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (12, 6, 7, 161000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (13, 2, 15, 525000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (13, 6, 3, 69000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (14, 13, 3, 90000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (14, 17, 6, 192000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (15, 1, 4, 128000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (15, 5, 5, 175000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (15, 7, 3, 45000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (16, 9, 5, 160000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (16, 11, 4, 100000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (17, 2, 20, 700000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (17, 6, 5, 115000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (17, 7, 10, 150000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (17, 9, 10, 320000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (18, 2, 4, 140000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (19, 5, 1, 35000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (20, 1, 1, 32000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (21, 5, 1, 35000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (22, 3, 1, 20000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (22, 4, 2, 70000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (22, 6, 1, 23000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (22, 8, 2, 34000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (23, 1, 15, 480000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (23, 5, 5, 175000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (23, 9, 5, 160000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (24, 15, 5, 115000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (24, 16, 7, 245000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (24, 17, 10, 320000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (25, 10, 4, 140000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (25, 13, 12, 360000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (25, 14, 10, 60000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (26, 10, 12, 420000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (26, 12, 8, 216000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (26, 15, 5, 115000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (26, 17, 10, 320000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (27, 3, 13, 260000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (27, 7, 5, 75000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (27, 8, 7, 119000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (28, 9, 7, 224000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (28, 16, 15, 525000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (29, 9, 5, 160000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (29, 12, 7, 189000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (29, 13, 12, 360000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (29, 18, 10, 60000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (30, 4, 10, 350000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (30, 9, 3, 96000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (31, 14, 10, 60000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (31, 16, 10, 350000)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Quantity], [Price]) VALUES (32, 9, 1, 32000)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (1, 1, N'Chè bưởi', NULL, 32000, N'Ngon')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (2, 2, N'Trà đào cam sả', NULL, 35000, N'Ngon ng?t')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (3, 3, N'Cà phê sữa', NULL, 20000, N'Ð?ng')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (4, 4, N'Sinh tố dâu', NULL, 35000, N'Chua ngon')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (5, 4, N'Sinh tố bơ', NULL, 35000, N'Béo')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (6, 5, N'Bánh tráng trộn', NULL, 23000, N'Ngon')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (7, 6, N'Pepsi', NULL, 15000, N'Ng?t')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (8, 6, N'Coca', NULL, 17000, N'Ng?t')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (9, 6, N'Nước tăng lực Monster', NULL, 32000, N'Khó u?ng')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (10, 1, N'Chè thái', NULL, 35000, N'Ngon')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (11, 3, N'Bạc xỉu', NULL, 25000, N'Ngon ng?t')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (12, 2, N'Trà sữa thái xanh', NULL, 27000, N'Ng?t, có trân châu')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (13, 2, N'Trà sữa ô long', NULL, 30000, N'Có trân châu')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (14, 8, N'Aquafina', NULL, 6000, N'T?t cho s?c kh?e')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (15, 3, N'Cà phê muối', NULL, 23000, N'Béo ngon')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (16, 7, N'Mix cần tây & táo', NULL, 35000, N'Ð?ng, khó u?ng')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (17, 7, N'Mix ổi & thơm', NULL, 32000, N'Chua ngon')
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Image], [SellPrice], [Description]) VALUES (18, 8, N'Lavie', NULL, 6000, N'T?t cho s?c kh?e')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([CategoryId], [CategoryName]) VALUES (1, N'Chè')
INSERT [dbo].[ProductCategory] ([CategoryId], [CategoryName]) VALUES (2, N'Trà')
INSERT [dbo].[ProductCategory] ([CategoryId], [CategoryName]) VALUES (3, N'Cà phê')
INSERT [dbo].[ProductCategory] ([CategoryId], [CategoryName]) VALUES (4, N'Sinh tố')
INSERT [dbo].[ProductCategory] ([CategoryId], [CategoryName]) VALUES (5, N'Ăn vặt')
INSERT [dbo].[ProductCategory] ([CategoryId], [CategoryName]) VALUES (6, N'Nước ngọt')
INSERT [dbo].[ProductCategory] ([CategoryId], [CategoryName]) VALUES (7, N'Nước ép')
INSERT [dbo].[ProductCategory] ([CategoryId], [CategoryName]) VALUES (8, N'Nước lọc')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'KH', N'Khách Hàng')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'NV', N'Nhân Viên')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'QL', N'Quản Lý')
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([TableId], [TableName], [Status]) VALUES (1, N'B01', 0)
INSERT [dbo].[Table] ([TableId], [TableName], [Status]) VALUES (2, N'B02', 0)
INSERT [dbo].[Table] ([TableId], [TableName], [Status]) VALUES (3, N'B03', 2)
INSERT [dbo].[Table] ([TableId], [TableName], [Status]) VALUES (4, N'B04', 0)
INSERT [dbo].[Table] ([TableId], [TableName], [Status]) VALUES (5, N'B05', 0)
INSERT [dbo].[Table] ([TableId], [TableName], [Status]) VALUES (6, N'B06', 2)
INSERT [dbo].[Table] ([TableId], [TableName], [Status]) VALUES (7, N'B07', 0)
INSERT [dbo].[Table] ([TableId], [TableName], [Status]) VALUES (8, N'B08', 2)
INSERT [dbo].[Table] ([TableId], [TableName], [Status]) VALUES (9, N'B09', 0)
INSERT [dbo].[Table] ([TableId], [TableName], [Status]) VALUES (10, N'B10', 0)
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Username], [Email], [Password], [SDT], [RoleId]) VALUES (1, N'tayhoang', N'tayhoang64@gmail.com', N'Tayden123@', N'0988910527', N'QL')
INSERT [dbo].[User] ([UserId], [Username], [Email], [Password], [SDT], [RoleId]) VALUES (2, N'nguyenvana', N'nguyenvana@gmail.com', N'Nguyenvana123@', N'0987654321', N'KH')
INSERT [dbo].[User] ([UserId], [Username], [Email], [Password], [SDT], [RoleId]) VALUES (3, N'nguyenvanb', N'nguyenvanb@gmail.com', N'Nguyenvanb123@', N'0963253257', N'NV')
INSERT [dbo].[User] ([UserId], [Username], [Email], [Password], [SDT], [RoleId]) VALUES (4, N'nguyenvanc', N'nguyenvanc@gmail.com', N'Nguyenvanc123@', N'0935673253', N'KH')
INSERT [dbo].[User] ([UserId], [Username], [Email], [Password], [SDT], [RoleId]) VALUES (5, N'nguyenthevu', N'nguyenthevu@gmail.com', N'Vu123456?', N'0987123456', N'QL')
INSERT [dbo].[User] ([UserId], [Username], [Email], [Password], [SDT], [RoleId]) VALUES (6, N'nguyenngotrucchi', N'trucchi@gmail.com', N'Chi123456?', N'0984256782', N'QL')
INSERT [dbo].[User] ([UserId], [Username], [Email], [Password], [SDT], [RoleId]) VALUES (7, N'nguyenminhtri', N'minhtri@gmail.com', N'Tri123456?', N'0953627527', N'QL')
INSERT [dbo].[User] ([UserId], [Username], [Email], [Password], [SDT], [RoleId]) VALUES (8, N'nguyenvand', N'nguyenvand@gmail.com', N'Nguyenvand123@', N'0963638362', N'KH')
INSERT [dbo].[User] ([UserId], [Username], [Email], [Password], [SDT], [RoleId]) VALUES (9, N'nguyenvane', N'nguyenvane@gmail.com', N'Nguyenvane123@', N'0973832872', N'KH')
INSERT [dbo].[User] ([UserId], [Username], [Email], [Password], [SDT], [RoleId]) VALUES (10, N'nguyenvanf', N'nguyenvanf@gmail.com', N'Nguyenvanf123@', N'0963828283', N'KH')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__A9D1053465D90525]    Script Date: 10/23/2023 10:35:20 AM ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ('KH') FOR [RoleId]
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([TableId])
REFERENCES [dbo].[Table] ([TableId])
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([InvoiceId])
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProductCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
