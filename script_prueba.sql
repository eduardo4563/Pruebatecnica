USE [master]
GO
/****** Object:  Database [libros]    Script Date: 25/05/2023 22:52:37 ******/
CREATE DATABASE [libros]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'libros', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\libros.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'libros_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\libros_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [libros] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [libros].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [libros] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [libros] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [libros] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [libros] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [libros] SET ARITHABORT OFF 
GO
ALTER DATABASE [libros] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [libros] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [libros] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [libros] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [libros] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [libros] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [libros] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [libros] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [libros] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [libros] SET  ENABLE_BROKER 
GO
ALTER DATABASE [libros] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [libros] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [libros] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [libros] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [libros] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [libros] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [libros] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [libros] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [libros] SET  MULTI_USER 
GO
ALTER DATABASE [libros] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [libros] SET DB_CHAINING OFF 
GO
ALTER DATABASE [libros] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [libros] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [libros] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [libros] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [libros] SET QUERY_STORE = ON
GO
ALTER DATABASE [libros] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [libros]
GO
/****** Object:  Table [dbo].[asignatura]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignatura](
	[id_asig] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_asig] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[libros]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libros](
	[id_libro] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[asignatura] [int] NULL,
	[stock] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_libro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[asignatura] ([id_asig], [descripcion], [estado]) VALUES (260303, N'mario', 0)
GO
ALTER TABLE [dbo].[libros]  WITH CHECK ADD  CONSTRAINT [fk_asignatura] FOREIGN KEY([asignatura])
REFERENCES [dbo].[asignatura] ([id_asig])
GO
ALTER TABLE [dbo].[libros] CHECK CONSTRAINT [fk_asignatura]
GO
/****** Object:  StoredProcedure [dbo].[sp_borrar_asignatura]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_borrar_asignatura]
@id_asignatura int
as 
begin
delete from asignatura where id_asig=@id_asignatura
end
GO
/****** Object:  StoredProcedure [dbo].[sp_borrar_libros]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_borrar_libros]

@id_libro int
as 
begin

delete from libros where  id_libro=@id_libro
end
GO
/****** Object:  StoredProcedure [dbo].[sp_editar_asignatura]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_editar_asignatura]
@id_asig int,
@descripcion varchar(50),
@estado  bit 

AS
Begin
  update asignatura set descripcion= @descripcion,estado=@estado where id_asig=@id_asig
end
GO
/****** Object:  StoredProcedure [dbo].[sp_editar_libros]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_editar_libros]
@id_libro int,
@descripcion varchar(50),
@asignatura  int ,
@stock  int 
AS
Begin
  update libros set descripcion= @descripcion,asignatura=@asignatura,stock=@stock where id_libro=@id_libro
end
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_asigantura]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_insertar_asigantura]
@id_asig int,
@descripcion varchar(50),
@estado  bit 

AS
Begin
 INSERT INTO [dbo].[asignatura](id_asig,descripcion,estado)
		   values (@id_asig,@descripcion, @estado)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_libros]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_insertar_libros]
@id_libro int,
@descripcion varchar(50),
@asignatura  int ,
@stock  int 
AS
Begin
 INSERT INTO [dbo].[libros](id_libro,descripcion,asignatura,stock)
		   values (@id_libro,@descripcion, @asignatura,@stock)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_asignatura]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  procedure [dbo].[sp_listar_asignatura]
as
select * from asignatura
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_li]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[sp_listar_li]

as
select * from libros
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_libros]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[sp_listar_libros]
@busqueda varchar(20)
as
select * from libros
where descripcion like '%' + @busqueda +'%' 
GO
/****** Object:  StoredProcedure [dbo].[sp_llenarselect]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_llenarselect]
as
select [id_asig] from asignatura where estado='1'
GO
/****** Object:  StoredProcedure [dbo].[sp_obtener]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_obtener](
@Idlibros int

)
as
begin
	select * from libros where id_libro=@Idlibros
end
GO
/****** Object:  StoredProcedure [dbo].[sp_obtener_asignatura]    Script Date: 25/05/2023 22:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_obtener_asignatura](
@Idasignatura int

)
as
begin
	select * from asignatura where id_asig=@Idasignatura
end
GO
USE [master]
GO
ALTER DATABASE [libros] SET  READ_WRITE 
GO
