USE [MaterialInfoDB]
GO
/****** Object:  Table [dbo].[RawMaterials]    Script Date: 2/26/2024 7:16:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RawMaterials](
	[MaterialId] [int] IDENTITY(1,1) NOT NULL,
	[MaterialName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RawMaterial] PRIMARY KEY CLUSTERED 
(
	[MaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 2/26/2024 7:16:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction-Details]    Script Date: 2/26/2024 7:16:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction-Details](
	[TransDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[NoOfItems] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[TransactionId] [int] NULL,
	[MaterialId] [int] NULL,
	[SupplierId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 2/26/2024 7:16:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TotalPrice] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[SupplierId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RawMaterials] ON 
GO
INSERT [dbo].[RawMaterials] ([MaterialId], [MaterialName]) VALUES (1, N'Sand')
GO
INSERT [dbo].[RawMaterials] ([MaterialId], [MaterialName]) VALUES (2, N'Cement')
GO
INSERT [dbo].[RawMaterials] ([MaterialId], [MaterialName]) VALUES (3, N'WhiteSand')
GO
INSERT [dbo].[RawMaterials] ([MaterialId], [MaterialName]) VALUES (4, N'Chemical')
GO
SET IDENTITY_INSERT [dbo].[RawMaterials] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 
GO
INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName]) VALUES (1, N'Xyz')
GO
INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName]) VALUES (2, N'Ahmad')
GO
INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName]) VALUES (3, N'Aman')
GO
INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName]) VALUES (4, N'Ali')
GO
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 
GO
INSERT [dbo].[Transactions] ([TransactionId], [Name], [TotalPrice], [CreatedDate], [TransactionDate], [SupplierId]) VALUES (1, N'invoice #001', 3000, CAST(N'2024-02-18T16:04:11.940' AS DateTime), CAST(N'2024-02-18T16:04:11.940' AS DateTime), 1)
GO
INSERT [dbo].[Transactions] ([TransactionId], [Name], [TotalPrice], [CreatedDate], [TransactionDate], [SupplierId]) VALUES (2, N'Saba Gull', 23456, CAST(N'2024-02-24T01:40:05.570' AS DateTime), CAST(N'2024-02-24T01:40:05.573' AS DateTime), 2)
GO
INSERT [dbo].[Transactions] ([TransactionId], [Name], [TotalPrice], [CreatedDate], [TransactionDate], [SupplierId]) VALUES (1002, N'Saba Ahmad', 45667, CAST(N'2024-02-25T18:36:43.513' AS DateTime), CAST(N'2024-02-25T18:36:43.513' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
ALTER TABLE [dbo].[Transaction-Details]  WITH CHECK ADD FOREIGN KEY([MaterialId])
REFERENCES [dbo].[RawMaterials] ([MaterialId])
GO
ALTER TABLE [dbo].[Transaction-Details]  WITH CHECK ADD FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([SupplierId])
GO
ALTER TABLE [dbo].[Transaction-Details]  WITH CHECK ADD FOREIGN KEY([TransactionId])
REFERENCES [dbo].[Transactions] ([TransactionId])
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([SupplierId])
GO
