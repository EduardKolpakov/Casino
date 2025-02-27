USE [master]
GO
/****** Object:  Database [RPM_Casino]    Script Date: 12/22/2024 3:15:11 AM ******/
CREATE DATABASE [RPM_Casino]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RPM_Casino', FILENAME = N'C:\Users\Kolpa\RPM_Casino.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RPM_Casino_log', FILENAME = N'C:\Users\Kolpa\RPM_Casino_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RPM_Casino] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RPM_Casino].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RPM_Casino] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RPM_Casino] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RPM_Casino] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RPM_Casino] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RPM_Casino] SET ARITHABORT OFF 
GO
ALTER DATABASE [RPM_Casino] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RPM_Casino] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RPM_Casino] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RPM_Casino] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RPM_Casino] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RPM_Casino] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RPM_Casino] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RPM_Casino] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RPM_Casino] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RPM_Casino] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RPM_Casino] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RPM_Casino] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RPM_Casino] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RPM_Casino] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RPM_Casino] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RPM_Casino] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RPM_Casino] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RPM_Casino] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RPM_Casino] SET  MULTI_USER 
GO
ALTER DATABASE [RPM_Casino] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RPM_Casino] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RPM_Casino] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RPM_Casino] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RPM_Casino] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RPM_Casino] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RPM_Casino] SET QUERY_STORE = OFF
GO
USE [RPM_Casino]
GO
/****** Object:  Table [dbo].[BalanceHistory]    Script Date: 12/22/2024 3:15:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BalanceHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[BalanceChange] [nvarchar](20) NULL,
	[GameType] [nvarchar](30) NULL,
 CONSTRAINT [PK_BalanceHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GamesHistory]    Script Date: 12/22/2024 3:15:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GamesHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GameName] [nvarchar](50) NULL,
	[Bet] [int] NULL,
	[Result] [nvarchar](50) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_GamesHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 12/22/2024 3:15:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Type] [nvarchar](30) NULL,
	[summ] [int] NULL,
 CONSTRAINT [PK_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/22/2024 3:15:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Balance] [int] NULL,
	[Role] [nvarchar](25) NULL,
	[TgUs] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BalanceHistory] ON 

INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (1, 1, N'+5000', N'BlackJack')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (2, 1, N'-10000', N'BlackJack')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (3, 1, N'-40000', N'BlackJack')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (1002, 1, N'20000', N'BlackJack')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (1003, 1, N'10000', N'Slots')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (1004, 1, N'-20000', N'Slots')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (1005, 1, N'-15000', N'Slots')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (2002, 2002, N'5000', N'BlackJack')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (2003, 2002, N'30000', N'Slots')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (2004, 2002, N'-10000', N'BlackJack')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (2005, 2002, N'10000', N'Slots')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (3002, 2003, N'-5000', N'BlackJack')
INSERT [dbo].[BalanceHistory] ([ID], [UserID], [BalanceChange], [GameType]) VALUES (4002, 1, N'-15', N'Slots')
SET IDENTITY_INSERT [dbo].[BalanceHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[GamesHistory] ON 

INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (1, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (2, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (3, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (4, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (5, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (6, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (7, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (8, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (9, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (10, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (11, N'BlackJack', 10000, N'Won (20000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (12, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (13, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (14, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (15, N'BlackJack', 5000, N'Won (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (16, N'BlackJack', 20000, N'Lost (20000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (17, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (18, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (19, N'BlackJack', 5000, N'Won (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (20, N'BlackJack', 10000, N'Lost (10000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (21, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (22, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (23, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (24, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (25, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (26, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (27, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (28, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (1002, N'BlackJack', 5000, N'Won (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (1003, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (1004, N'BlackJack', 5000, N'Won (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (2002, N'Slots', 5000, N'Won (10000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (2003, N'Slots', 5000, N'Won (10000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (2004, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (2005, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (2006, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (2007, N'BlackJack', 5000, N'Lost (5000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (2008, N'Slots', 15000, N'Won (30000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (2009, N'Slots', 15000, N'Lost (15000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (2010, N'Slots', 15000, N'Lost (15000)', 1)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (3002, N'BlackJack', 5000, N'Won (5000)', 2002)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (3003, N'Slots', 15000, N'Won (30000)', 2002)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (3004, N'BlackJack', 5000, N'Lost (5000)', 2002)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (3005, N'BlackJack', 5000, N'Lost (5000)', 2002)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (3006, N'Slots', 5000, N'Won (10000)', 2002)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (3007, N'Slots', 5000, N'Won (10000)', 2002)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (3008, N'Slots', 5000, N'Won (10000)', 2002)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (4002, N'BlackJack', 5000, N'Lost (5000)', 2003)
INSERT [dbo].[GamesHistory] ([ID], [GameName], [Bet], [Result], [UserID]) VALUES (5002, N'Slots', 15, N'Lost (15)', 1)
SET IDENTITY_INSERT [dbo].[GamesHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionHistory] ON 

INSERT [dbo].[TransactionHistory] ([ID], [UserID], [Type], [summ]) VALUES (1, 1, N'Пополнение', 50000)
INSERT [dbo].[TransactionHistory] ([ID], [UserID], [Type], [summ]) VALUES (2, 1, N'Вывод', 15000)
INSERT [dbo].[TransactionHistory] ([ID], [UserID], [Type], [summ]) VALUES (3, 2002, N'Пополнение', 50000)
INSERT [dbo].[TransactionHistory] ([ID], [UserID], [Type], [summ]) VALUES (4, 2002, N'Пополнение', 50000)
INSERT [dbo].[TransactionHistory] ([ID], [UserID], [Type], [summ]) VALUES (5, 2002, N'Вывод', 55000)
INSERT [dbo].[TransactionHistory] ([ID], [UserID], [Type], [summ]) VALUES (1002, 2003, N'Пополнение', 59000)
INSERT [dbo].[TransactionHistory] ([ID], [UserID], [Type], [summ]) VALUES (1003, 2003, N'Пополнение', 59000)
SET IDENTITY_INSERT [dbo].[TransactionHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Login], [Password], [Balance], [Role], [TgUs]) VALUES (1, N'Eduard', N'Kolpak', 99985, N'Owner', NULL)
INSERT [dbo].[Users] ([ID], [Login], [Password], [Balance], [Role], [TgUs]) VALUES (2, N'Bulat', N'Ikhsan', 0, N'admin', NULL)
INSERT [dbo].[Users] ([ID], [Login], [Password], [Balance], [Role], [TgUs]) VALUES (1002, N'Karimjan', N'Ishak', 0, N'User', NULL)
INSERT [dbo].[Users] ([ID], [Login], [Password], [Balance], [Role], [TgUs]) VALUES (2002, N'Ildar', N'Sabir', 100000, N'Admin', NULL)
INSERT [dbo].[Users] ([ID], [Login], [Password], [Balance], [Role], [TgUs]) VALUES (2003, N'Riyaz', N'zarip', 113000, N'Owner', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[BalanceHistory]  WITH CHECK ADD  CONSTRAINT [FK_BalanceHistory_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[BalanceHistory] CHECK CONSTRAINT [FK_BalanceHistory_Users]
GO
ALTER TABLE [dbo].[GamesHistory]  WITH CHECK ADD  CONSTRAINT [FK_GamesHistory_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[GamesHistory] CHECK CONSTRAINT [FK_GamesHistory_Users]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistory_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK_TransactionHistory_Users]
GO
USE [master]
GO
ALTER DATABASE [RPM_Casino] SET  READ_WRITE 
GO
