USE [master]
GO
/****** Object:  Database [OriginSoftwareChallenge]    Script Date: 11/08/2022 17:09:19 ******/
CREATE DATABASE [OriginSoftwareChallenge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OriginSoftwareChallenge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OriginSoftwareChallenge.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OriginSoftwareChallenge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OriginSoftwareChallenge_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OriginSoftwareChallenge] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OriginSoftwareChallenge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OriginSoftwareChallenge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET ARITHABORT OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET RECOVERY FULL 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET  MULTI_USER 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OriginSoftwareChallenge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OriginSoftwareChallenge] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OriginSoftwareChallenge', N'ON'
GO
ALTER DATABASE [OriginSoftwareChallenge] SET QUERY_STORE = OFF
GO
USE [OriginSoftwareChallenge]
GO
/****** Object:  Table [dbo].[Operaciones]    Script Date: 11/08/2022 17:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaYHora] [datetime] NOT NULL,
	[DineroRetirado] [money] NOT NULL,
	[IdTarjeta] [int] NOT NULL,
	[Codigo] [int] NOT NULL,
	[DineroRestante] [money] NOT NULL,
	[NroTarjeta] [numeric](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjetas]    Script Date: 11/08/2022 17:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjetas](
	[Id] [int] NOT NULL,
	[Nro] [numeric](18, 0) NOT NULL,
	[PIN] [int] NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[Balance] [money] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Operaciones] ON 

INSERT [dbo].[Operaciones] ([Id], [FechaYHora], [DineroRetirado], [IdTarjeta], [Codigo], [DineroRestante], [NroTarjeta]) VALUES (1, CAST(N'2022-08-11T16:21:12.613' AS DateTime), 500.0000, 1, 3711, 19000.0000, CAST(4876374629873877 AS Numeric(18, 0)))
INSERT [dbo].[Operaciones] ([Id], [FechaYHora], [DineroRetirado], [IdTarjeta], [Codigo], [DineroRestante], [NroTarjeta]) VALUES (2, CAST(N'2022-08-11T16:27:02.950' AS DateTime), 500.0000, 1, 2324, 18500.0000, CAST(4876374629873877 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Operaciones] OFF
GO
INSERT [dbo].[Tarjetas] ([Id], [Nro], [PIN], [IsBlocked], [FechaVencimiento], [Balance]) VALUES (1, CAST(4876374629873877 AS Numeric(18, 0)), 3827, 0, CAST(N'2024-07-03' AS Date), 18500.0000)
INSERT [dbo].[Tarjetas] ([Id], [Nro], [PIN], [IsBlocked], [FechaVencimiento], [Balance]) VALUES (2, CAST(7352634488972342 AS Numeric(18, 0)), 2987, 0, CAST(N'2023-08-02' AS Date), 15000.0000)
INSERT [dbo].[Tarjetas] ([Id], [Nro], [PIN], [IsBlocked], [FechaVencimiento], [Balance]) VALUES (3, CAST(3366523163536783 AS Numeric(18, 0)), 3982, 1, CAST(N'2024-09-09' AS Date), 10000.0000)
GO
USE [master]
GO
ALTER DATABASE [OriginSoftwareChallenge] SET  READ_WRITE 
GO
