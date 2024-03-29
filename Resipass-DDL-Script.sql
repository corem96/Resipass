USE [master]
GO
/****** Object:  Database [Resipass]    Script Date: 15/10/2019 01:19:03 p. m. ******/
CREATE DATABASE [Resipass]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Resipass', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER17\MSSQL\DATA\Resipass.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Resipass_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER17\MSSQL\DATA\Resipass_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Resipass] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Resipass].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Resipass] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Resipass] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Resipass] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Resipass] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Resipass] SET ARITHABORT OFF 
GO
ALTER DATABASE [Resipass] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Resipass] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Resipass] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Resipass] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Resipass] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Resipass] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Resipass] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Resipass] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Resipass] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Resipass] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Resipass] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Resipass] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Resipass] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Resipass] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Resipass] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Resipass] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Resipass] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Resipass] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Resipass] SET  MULTI_USER 
GO
ALTER DATABASE [Resipass] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Resipass] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Resipass] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Resipass] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Resipass] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Resipass] SET QUERY_STORE = OFF
GO
USE [Resipass]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15/10/2019 01:19:03 p. m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aviso]    Script Date: 15/10/2019 01:19:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aviso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comunicado] [nvarchar](250) NULL,
	[FechaPublicacion] [datetime2](7) NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_aviso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[domicilio]    Script Date: 15/10/2019 01:19:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[domicilio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [nvarchar](250) NOT NULL,
	[Numero] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_domicilio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[registroPago]    Script Date: 15/10/2019 01:19:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[registroPago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TarjetaId] [int] NOT NULL,
	[FechaPago] [datetime2](7) NOT NULL,
	[FechaVencimiento] [datetime2](7) NOT NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[NumeroFolio] [nvarchar](max) NOT NULL,
	[NumeroAutorizacion] [nvarchar](max) NOT NULL,
	[Sucursal] [nvarchar](max) NOT NULL,
	[Cajero] [nvarchar](150) NOT NULL,
	[ResidenteId] [int] NULL,
 CONSTRAINT [PK_registroPago] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[residente]    Script Date: 15/10/2019 01:19:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[residente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](80) NOT NULL,
	[Apellido] [nvarchar](80) NOT NULL,
	[NombreUsuario] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[DomicilioId] [int] NOT NULL,
 CONSTRAINT [PK_residente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tarjeta]    Script Date: 15/10/2019 01:19:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tarjeta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](20) NOT NULL,
	[Vigencia] [datetime2](7) NOT NULL,
	[Activa] [bit] NOT NULL,
	[ResidenteId] [int] NOT NULL,
	[DomicilioId] [int] NULL,
 CONSTRAINT [PK_tarjeta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 15/10/2019 01:19:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](70) NOT NULL,
	[Apellido] [nvarchar](70) NOT NULL,
	[NombreUsuario] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_aviso_UsuarioId]    Script Date: 15/10/2019 01:19:03 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_aviso_UsuarioId] ON [dbo].[aviso]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_registroPago_ResidenteId]    Script Date: 15/10/2019 01:19:03 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_registroPago_ResidenteId] ON [dbo].[registroPago]
(
	[ResidenteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_registroPago_TarjetaId]    Script Date: 15/10/2019 01:19:03 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_registroPago_TarjetaId] ON [dbo].[registroPago]
(
	[TarjetaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_residente_DomicilioId]    Script Date: 15/10/2019 01:19:03 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_residente_DomicilioId] ON [dbo].[residente]
(
	[DomicilioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tarjeta_DomicilioId]    Script Date: 15/10/2019 01:19:03 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_tarjeta_DomicilioId] ON [dbo].[tarjeta]
(
	[DomicilioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tarjeta_ResidenteId]    Script Date: 15/10/2019 01:19:03 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_tarjeta_ResidenteId] ON [dbo].[tarjeta]
(
	[ResidenteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aviso] ADD  DEFAULT (getutcdate()) FOR [FechaPublicacion]
GO
ALTER TABLE [dbo].[registroPago] ADD  DEFAULT (getutcdate()) FOR [FechaPago]
GO
ALTER TABLE [dbo].[registroPago] ADD  DEFAULT (dateadd(month,(1),getutcdate())) FOR [FechaVencimiento]
GO
ALTER TABLE [dbo].[registroPago] ADD  DEFAULT ((300.0)) FOR [Importe]
GO
ALTER TABLE [dbo].[tarjeta] ADD  DEFAULT ((1)) FOR [Activa]
GO
ALTER TABLE [dbo].[aviso]  WITH CHECK ADD  CONSTRAINT [FK_aviso_usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aviso] CHECK CONSTRAINT [FK_aviso_usuario_UsuarioId]
GO
ALTER TABLE [dbo].[registroPago]  WITH CHECK ADD  CONSTRAINT [FK_registroPago_residente_ResidenteId] FOREIGN KEY([ResidenteId])
REFERENCES [dbo].[residente] ([Id])
GO
ALTER TABLE [dbo].[registroPago] CHECK CONSTRAINT [FK_registroPago_residente_ResidenteId]
GO
ALTER TABLE [dbo].[registroPago]  WITH CHECK ADD  CONSTRAINT [FK_registroPago_tarjeta_TarjetaId] FOREIGN KEY([TarjetaId])
REFERENCES [dbo].[tarjeta] ([Id])
GO
ALTER TABLE [dbo].[registroPago] CHECK CONSTRAINT [FK_registroPago_tarjeta_TarjetaId]
GO
ALTER TABLE [dbo].[residente]  WITH CHECK ADD  CONSTRAINT [FK_residente_domicilio_DomicilioId] FOREIGN KEY([DomicilioId])
REFERENCES [dbo].[domicilio] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[residente] CHECK CONSTRAINT [FK_residente_domicilio_DomicilioId]
GO
ALTER TABLE [dbo].[tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_tarjeta_domicilio_DomicilioId] FOREIGN KEY([DomicilioId])
REFERENCES [dbo].[domicilio] ([Id])
GO
ALTER TABLE [dbo].[tarjeta] CHECK CONSTRAINT [FK_tarjeta_domicilio_DomicilioId]
GO
ALTER TABLE [dbo].[tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_tarjeta_residente_ResidenteId] FOREIGN KEY([ResidenteId])
REFERENCES [dbo].[residente] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tarjeta] CHECK CONSTRAINT [FK_tarjeta_residente_ResidenteId]
GO
USE [master]
GO
ALTER DATABASE [Resipass] SET  READ_WRITE 
GO
