USE [master]
GO
/****** Object:  Database [TrabajoPracticoN4]    Script Date: 7/12/2020 13:33:27 ******/
CREATE DATABASE [TrabajoPracticoN4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrabajoPracticoN4', FILENAME = N'E:\SQL2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\TrabajoPracticoN4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TrabajoPracticoN4_log', FILENAME = N'E:\SQL2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\TrabajoPracticoN4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TrabajoPracticoN4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrabajoPracticoN4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrabajoPracticoN4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrabajoPracticoN4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrabajoPracticoN4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TrabajoPracticoN4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrabajoPracticoN4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TrabajoPracticoN4] SET  MULTI_USER 
GO
ALTER DATABASE [TrabajoPracticoN4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrabajoPracticoN4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrabajoPracticoN4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrabajoPracticoN4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TrabajoPracticoN4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TrabajoPracticoN4] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TrabajoPracticoN4] SET QUERY_STORE = OFF
GO
USE [TrabajoPracticoN4]
GO
/****** Object:  Table [dbo].[Armas]    Script Date: 7/12/2020 13:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Armas](
	[nombre] [nvarchar](50) NOT NULL,
	[idArma] [numeric](18, 0) NOT NULL,
	[precio] [float] NOT NULL,
	[stock] [numeric](18, 0) NOT NULL,
	[tipoArma] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'Rayo De Zeus', CAST(1 AS Numeric(18, 0)), 1000, CAST(94 AS Numeric(18, 0)), N'armaMagica')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'Arrasador de tormentas', CAST(2 AS Numeric(18, 0)), 1500, CAST(79 AS Numeric(18, 0)), N'armaMagica')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'Baston De Baron', CAST(3 AS Numeric(18, 0)), 900, CAST(18 AS Numeric(18, 0)), N'armaMagica')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'PALO NIVEL 1', CAST(4 AS Numeric(18, 0)), 50, CAST(63 AS Numeric(18, 0)), N'armaMagica')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'ARMA ESPIRITUAL', CAST(5 AS Numeric(18, 0)), 1000, CAST(43 AS Numeric(18, 0)), N'armaMagica')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'Arco de Artemis', CAST(6 AS Numeric(18, 0)), 500, CAST(57 AS Numeric(18, 0)), N'armaADistancia')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'Gomera Castigadora', CAST(7 AS Numeric(18, 0)), 70, CAST(6 AS Numeric(18, 0)), N'armaADistancia')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'Ballesta', CAST(8 AS Numeric(18, 0)), 200, CAST(43 AS Numeric(18, 0)), N'armaADistancia')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'ARCO DIVINO', CAST(9 AS Numeric(18, 0)), 2000, CAST(67 AS Numeric(18, 0)), N'armaADistancia')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'BEST BOW LVL50', CAST(10 AS Numeric(18, 0)), 2500, CAST(243 AS Numeric(18, 0)), N'armaADistancia')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'Espada De Ares', CAST(11 AS Numeric(18, 0)), 10000, CAST(243 AS Numeric(18, 0)), N'armaCuerpoACuerpo')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'Escudo 300', CAST(12 AS Numeric(18, 0)), 6000, CAST(12 AS Numeric(18, 0)), N'armaCuerpoACuerpo')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'Dagas De Kratos', CAST(13 AS Numeric(18, 0)), 15000, CAST(65 AS Numeric(18, 0)), N'armaCuerpoACuerpo')
INSERT [dbo].[Armas] ([nombre], [idArma], [precio], [stock], [tipoArma]) VALUES (N'Rayo De Zeus', CAST(20 AS Numeric(18, 0)), 1000, CAST(100 AS Numeric(18, 0)), N'armaMagica')
GO
USE [master]
GO
ALTER DATABASE [TrabajoPracticoN4] SET  READ_WRITE 
GO
