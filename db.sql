USE [master]
GO
/****** Object:  Database [Book-Store]    Script Date: 02-Apr-17 10:36:12 PM ******/
CREATE DATABASE [Book-Store]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Book-Store', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Book-Store.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Book-Store_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Book-Store_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Book-Store] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Book-Store].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Book-Store] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Book-Store] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Book-Store] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Book-Store] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Book-Store] SET ARITHABORT OFF 
GO
ALTER DATABASE [Book-Store] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Book-Store] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Book-Store] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Book-Store] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Book-Store] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Book-Store] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Book-Store] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Book-Store] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Book-Store] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Book-Store] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Book-Store] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Book-Store] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Book-Store] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Book-Store] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Book-Store] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Book-Store] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Book-Store] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Book-Store] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Book-Store] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Book-Store] SET  MULTI_USER 
GO
ALTER DATABASE [Book-Store] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Book-Store] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Book-Store] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Book-Store] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Book-Store]
GO
/****** Object:  Table [dbo].[BookCategory]    Script Date: 02-Apr-17 10:36:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Categoryname] [nchar](50) NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_BookCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 02-Apr-17 10:36:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Authorname] [varchar](50) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Publishdate] [date] NOT NULL,
	[BookCategoryId] [int] NOT NULL,
	[BookImageUrl] [varchar](200) NULL,
	[Rating] [int] NULL,
	[Weight] [decimal](6, 2) NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 02-Apr-17 10:36:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[CustomerDetailsid] [int] IDENTITY(1,1) NOT NULL,
	[Customername] [varchar](50) NOT NULL,
	[ShippingAddress] [varchar](max) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[Createdate] [datetime] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerDetailsid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 02-Apr-17 10:36:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Createdate] [datetime] NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[TotalWeight] [decimal](18, 0) NOT NULL,
	[TotalShippingCharges] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 02-Apr-17 10:36:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[BookPrice] [decimal](18, 0) NOT NULL,
	[BookWeight] [decimal](18, 0) NOT NULL,
	[Createdate] [datetime] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShippingCharges]    Script Date: 02-Apr-17 10:36:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingCharges](
	[ShippingRate] [decimal](18, 0) NOT NULL,
	[Weight] [decimal](6, 2) NOT NULL,
	[Createdate] [datetime] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ShippingCharges] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 02-Apr-17 10:36:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[Createdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BookCategory] ON 

INSERT [dbo].[BookCategory] ([Id], [Categoryname], [Createdate]) VALUES (1, N'Fantasy                                           ', CAST(0x0000A74A00000000 AS DateTime))
INSERT [dbo].[BookCategory] ([Id], [Categoryname], [Createdate]) VALUES (2, N'Historical                                        ', CAST(0x0000A74300000000 AS DateTime))
INSERT [dbo].[BookCategory] ([Id], [Categoryname], [Createdate]) VALUES (3, N'Children''s Books                                  ', CAST(0x0000A74500000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[BookCategory] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Name], [Authorname], [Price], [Publishdate], [BookCategoryId], [BookImageUrl], [Rating], [Weight], [Createdate]) VALUES (1, N'abc', N'xyz', CAST(500 AS Decimal(18, 0)), CAST(0x89240B00 AS Date), 1, NULL, 6, CAST(20.00 AS Decimal(6, 2)), CAST(0x0000A72500000000 AS DateTime))
INSERT [dbo].[Books] ([Id], [Name], [Authorname], [Price], [Publishdate], [BookCategoryId], [BookImageUrl], [Rating], [Weight], [Createdate]) VALUES (2, N'cdf', N'ijk', CAST(450 AS Decimal(18, 0)), CAST(0x363A0B00 AS Date), 2, NULL, 8, CAST(30.00 AS Decimal(6, 2)), CAST(0x0000A6FF00000000 AS DateTime))
INSERT [dbo].[Books] ([Id], [Name], [Authorname], [Price], [Publishdate], [BookCategoryId], [BookImageUrl], [Rating], [Weight], [Createdate]) VALUES (3, N'PQR', N'Jkl', CAST(670 AS Decimal(18, 0)), CAST(0x11390B00 AS Date), 3, NULL, 7, CAST(35.00 AS Decimal(6, 2)), CAST(0x0000A7A100000000 AS DateTime))
INSERT [dbo].[Books] ([Id], [Name], [Authorname], [Price], [Publishdate], [BookCategoryId], [BookImageUrl], [Rating], [Weight], [Createdate]) VALUES (4, N'a new book', N'jlkj', CAST(444 AS Decimal(18, 0)), CAST(0xA43C0B00 AS Date), 1, N'mzone.pkLogo.png', NULL, CAST(1.00 AS Decimal(6, 2)), CAST(0x0000A74900000000 AS DateTime))
INSERT [dbo].[Books] ([Id], [Name], [Authorname], [Price], [Publishdate], [BookCategoryId], [BookImageUrl], [Rating], [Weight], [Createdate]) VALUES (5, N'asdf', N'jlk', CAST(45 AS Decimal(18, 0)), CAST(0xA43C0B00 AS Date), 1, N'saimShop.pk_.png', 44, CAST(66.00 AS Decimal(6, 2)), CAST(0x0000A74900000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[CustomerDetails] ON 

INSERT [dbo].[CustomerDetails] ([CustomerDetailsid], [Customername], [ShippingAddress], [PhoneNo], [Createdate], [OrderId]) VALUES (1, N'arslan', N'lahore', N'1654', CAST(0x0000A74801576D0D AS DateTime), 2)
INSERT [dbo].[CustomerDetails] ([CustomerDetailsid], [Customername], [ShippingAddress], [PhoneNo], [Createdate], [OrderId]) VALUES (2, N'test cus', N'gasdf', N'888sd', CAST(0x0000A74801739856 AS DateTime), 4)
INSERT [dbo].[CustomerDetails] ([CustomerDetailsid], [Customername], [ShippingAddress], [PhoneNo], [Createdate], [OrderId]) VALUES (3, N'asdf', N'kkks', N'lkj', CAST(0x0000A748017C7E73 AS DateTime), 6)
SET IDENTITY_INSERT [dbo].[CustomerDetails] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderId], [UserId], [Createdate], [Status], [TotalWeight], [TotalShippingCharges]) VALUES (2, 2, CAST(0x0000A74801576CB2 AS DateTime), N'processing', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([OrderId], [UserId], [Createdate], [Status], [TotalWeight], [TotalShippingCharges]) VALUES (3, 2, CAST(0x0000A7480164628B AS DateTime), N'processing', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([OrderId], [UserId], [Createdate], [Status], [TotalWeight], [TotalShippingCharges]) VALUES (4, 2, CAST(0x0000A748017397FE AS DateTime), N'processing', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([OrderId], [UserId], [Createdate], [Status], [TotalWeight], [TotalShippingCharges]) VALUES (5, 2, CAST(0x0000A748017C5B85 AS DateTime), N'processing', CAST(135 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([OrderId], [UserId], [Createdate], [Status], [TotalWeight], [TotalShippingCharges]) VALUES (6, 2, CAST(0x0000A748017C7E6B AS DateTime), N'processing', CAST(135 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [BookId], [Quantity], [BookPrice], [BookWeight], [Createdate], [OrderId]) VALUES (0, 2, 1, CAST(450 AS Decimal(18, 0)), CAST(30 AS Decimal(18, 0)), CAST(0x0000A74801576D06 AS DateTime), 2)
INSERT [dbo].[OrderDetails] ([Id], [BookId], [Quantity], [BookPrice], [BookWeight], [Createdate], [OrderId]) VALUES (1, 1, 1, CAST(500 AS Decimal(18, 0)), CAST(20 AS Decimal(18, 0)), CAST(0x0000A7480173984E AS DateTime), 4)
INSERT [dbo].[OrderDetails] ([Id], [BookId], [Quantity], [BookPrice], [BookWeight], [Createdate], [OrderId]) VALUES (2, 3, 3, CAST(670 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), CAST(0x0000A748017C5C61 AS DateTime), 5)
INSERT [dbo].[OrderDetails] ([Id], [BookId], [Quantity], [BookPrice], [BookWeight], [Createdate], [OrderId]) VALUES (3, 2, 1, CAST(450 AS Decimal(18, 0)), CAST(30 AS Decimal(18, 0)), CAST(0x0000A748017C5C83 AS DateTime), 5)
INSERT [dbo].[OrderDetails] ([Id], [BookId], [Quantity], [BookPrice], [BookWeight], [Createdate], [OrderId]) VALUES (4, 3, 3, CAST(670 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), CAST(0x0000A748017C7E6D AS DateTime), 6)
INSERT [dbo].[OrderDetails] ([Id], [BookId], [Quantity], [BookPrice], [BookWeight], [Createdate], [OrderId]) VALUES (5, 2, 1, CAST(450 AS Decimal(18, 0)), CAST(30 AS Decimal(18, 0)), CAST(0x0000A748017C7E71 AS DateTime), 6)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[ShippingCharges] ON 

INSERT [dbo].[ShippingCharges] ([ShippingRate], [Weight], [Createdate], [id]) VALUES (CAST(10 AS Decimal(18, 0)), CAST(5.00 AS Decimal(6, 2)), CAST(0x0000A74800000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ShippingCharges] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [IsAdmin], [Createdate]) VALUES (1, N'admin', N'admin123', 1, CAST(0x0000A74201127DD2 AS DateTime))
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsAdmin], [Createdate]) VALUES (2, N'arslan', N'123456', 0, CAST(0x0000A74801175CE9 AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_TotalWeight]  DEFAULT ((0)) FOR [TotalWeight]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_TotalShippingCharges]  DEFAULT ((0)) FOR [TotalShippingCharges]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_BookCategory] FOREIGN KEY([BookCategoryId])
REFERENCES [dbo].[BookCategory] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_BookCategory]
GO
ALTER TABLE [dbo].[CustomerDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDetails_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[CustomerDetails] CHECK CONSTRAINT [FK_CustomerDetails_Order]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Users]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Books]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Order]
GO
USE [master]
GO
ALTER DATABASE [Book-Store] SET  READ_WRITE 
GO
