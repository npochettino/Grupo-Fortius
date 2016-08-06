USE [master]
GO
/****** Object:  Database [w1131306_GrupoFortius]    Script Date: 01/31/2016 22:35:46 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'w1131306_GrupoFortius')
BEGIN
CREATE DATABASE [w1131306_GrupoFortius] ON  PRIMARY 
( NAME = N'w1131306_GrupoFortius_Data', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\w1131306_GrupoFortius.ddf' , SIZE = 2304KB , MAXSIZE = 204800KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'w1131306_GrupoFortius_Log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\w1131306_GrupoFortius.ldf' , SIZE = 1024KB , MAXSIZE = 40960KB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [w1131306_GrupoFortius] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [w1131306_GrupoFortius].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [w1131306_GrupoFortius] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET ANSI_NULLS OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET ANSI_PADDING OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET ARITHABORT OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET AUTO_CLOSE ON
GO
ALTER DATABASE [w1131306_GrupoFortius] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [w1131306_GrupoFortius] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET AUTO_UPDATE_STATISTICS OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [w1131306_GrupoFortius] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET  DISABLE_BROKER
GO
ALTER DATABASE [w1131306_GrupoFortius] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [w1131306_GrupoFortius] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [w1131306_GrupoFortius] SET  READ_WRITE
GO
ALTER DATABASE [w1131306_GrupoFortius] SET RECOVERY FULL
GO
ALTER DATABASE [w1131306_GrupoFortius] SET  MULTI_USER
GO
ALTER DATABASE [w1131306_GrupoFortius] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [w1131306_GrupoFortius] SET DB_CHAINING OFF
GO
USE [w1131306_GrupoFortius]
GO
/****** Object:  ForeignKey [FK_modules_modules]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_modules_modules]') AND parent_object_id = OBJECT_ID(N'[dbo].[modules]'))
ALTER TABLE [dbo].[modules] DROP CONSTRAINT [FK_modules_modules]
GO
/****** Object:  ForeignKey [FK_cursos_roles]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cursos_roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[cursos]'))
ALTER TABLE [dbo].[cursos] DROP CONSTRAINT [FK_cursos_roles]
GO
/****** Object:  ForeignKey [FK_usuarios_empresas]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_usuarios_empresas]') AND parent_object_id = OBJECT_ID(N'[dbo].[usuarios]'))
ALTER TABLE [dbo].[usuarios] DROP CONSTRAINT [FK_usuarios_empresas]
GO
/****** Object:  ForeignKey [FK_usuarios_roles]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_usuarios_roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[usuarios]'))
ALTER TABLE [dbo].[usuarios] DROP CONSTRAINT [FK_usuarios_roles]
GO
/****** Object:  ForeignKey [FK_roles_modules_modules]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_roles_modules_modules]') AND parent_object_id = OBJECT_ID(N'[dbo].[roles_modules]'))
ALTER TABLE [dbo].[roles_modules] DROP CONSTRAINT [FK_roles_modules_modules]
GO
/****** Object:  ForeignKey [FK_roles_modules_roles]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_roles_modules_roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[roles_modules]'))
ALTER TABLE [dbo].[roles_modules] DROP CONSTRAINT [FK_roles_modules_roles]
GO
/****** Object:  ForeignKey [FK_diapositivas_cursos]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_diapositivas_cursos]') AND parent_object_id = OBJECT_ID(N'[dbo].[diapositivas]'))
ALTER TABLE [dbo].[diapositivas] DROP CONSTRAINT [FK_diapositivas_cursos]
GO
/****** Object:  ForeignKey [FK_cursos_usuarios_cursos]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cursos_usuarios_cursos]') AND parent_object_id = OBJECT_ID(N'[dbo].[cursos_usuarios]'))
ALTER TABLE [dbo].[cursos_usuarios] DROP CONSTRAINT [FK_cursos_usuarios_cursos]
GO
/****** Object:  ForeignKey [FK_cursos_usuarios_estados_cursos]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cursos_usuarios_estados_cursos]') AND parent_object_id = OBJECT_ID(N'[dbo].[cursos_usuarios]'))
ALTER TABLE [dbo].[cursos_usuarios] DROP CONSTRAINT [FK_cursos_usuarios_estados_cursos]
GO
/****** Object:  ForeignKey [FK_cursos_usuarios_usuarios]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cursos_usuarios_usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[cursos_usuarios]'))
ALTER TABLE [dbo].[cursos_usuarios] DROP CONSTRAINT [FK_cursos_usuarios_usuarios]
GO
/****** Object:  ForeignKey [FK_preguntas_cursos]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_preguntas_cursos]') AND parent_object_id = OBJECT_ID(N'[dbo].[preguntas]'))
ALTER TABLE [dbo].[preguntas] DROP CONSTRAINT [FK_preguntas_cursos]
GO
/****** Object:  ForeignKey [FK_opciones_preguntas]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_opciones_preguntas]') AND parent_object_id = OBJECT_ID(N'[dbo].[opciones]'))
ALTER TABLE [dbo].[opciones] DROP CONSTRAINT [FK_opciones_preguntas]
GO
/****** Object:  ForeignKey [FK_diapositivas_referidas_diapositivas]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_diapositivas_referidas_diapositivas]') AND parent_object_id = OBJECT_ID(N'[dbo].[diapositivas_referidas]'))
ALTER TABLE [dbo].[diapositivas_referidas] DROP CONSTRAINT [FK_diapositivas_referidas_diapositivas]
GO
/****** Object:  ForeignKey [FK_diapositivas_referidas_diapositivas1]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_diapositivas_referidas_diapositivas1]') AND parent_object_id = OBJECT_ID(N'[dbo].[diapositivas_referidas]'))
ALTER TABLE [dbo].[diapositivas_referidas] DROP CONSTRAINT [FK_diapositivas_referidas_diapositivas1]
GO
/****** Object:  Table [dbo].[diapositivas_referidas]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_diapositivas_referidas_diapositivas]') AND parent_object_id = OBJECT_ID(N'[dbo].[diapositivas_referidas]'))
ALTER TABLE [dbo].[diapositivas_referidas] DROP CONSTRAINT [FK_diapositivas_referidas_diapositivas]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_diapositivas_referidas_diapositivas1]') AND parent_object_id = OBJECT_ID(N'[dbo].[diapositivas_referidas]'))
ALTER TABLE [dbo].[diapositivas_referidas] DROP CONSTRAINT [FK_diapositivas_referidas_diapositivas1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[diapositivas_referidas]') AND type in (N'U'))
DROP TABLE [dbo].[diapositivas_referidas]
GO
/****** Object:  Table [dbo].[opciones]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_opciones_preguntas]') AND parent_object_id = OBJECT_ID(N'[dbo].[opciones]'))
ALTER TABLE [dbo].[opciones] DROP CONSTRAINT [FK_opciones_preguntas]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[opciones]') AND type in (N'U'))
DROP TABLE [dbo].[opciones]
GO
/****** Object:  Table [dbo].[preguntas]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_preguntas_cursos]') AND parent_object_id = OBJECT_ID(N'[dbo].[preguntas]'))
ALTER TABLE [dbo].[preguntas] DROP CONSTRAINT [FK_preguntas_cursos]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[preguntas]') AND type in (N'U'))
DROP TABLE [dbo].[preguntas]
GO
/****** Object:  Table [dbo].[cursos_usuarios]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cursos_usuarios_cursos]') AND parent_object_id = OBJECT_ID(N'[dbo].[cursos_usuarios]'))
ALTER TABLE [dbo].[cursos_usuarios] DROP CONSTRAINT [FK_cursos_usuarios_cursos]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cursos_usuarios_estados_cursos]') AND parent_object_id = OBJECT_ID(N'[dbo].[cursos_usuarios]'))
ALTER TABLE [dbo].[cursos_usuarios] DROP CONSTRAINT [FK_cursos_usuarios_estados_cursos]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cursos_usuarios_usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[cursos_usuarios]'))
ALTER TABLE [dbo].[cursos_usuarios] DROP CONSTRAINT [FK_cursos_usuarios_usuarios]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cursos_usuarios]') AND type in (N'U'))
DROP TABLE [dbo].[cursos_usuarios]
GO
/****** Object:  Table [dbo].[diapositivas]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_diapositivas_cursos]') AND parent_object_id = OBJECT_ID(N'[dbo].[diapositivas]'))
ALTER TABLE [dbo].[diapositivas] DROP CONSTRAINT [FK_diapositivas_cursos]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[diapositivas]') AND type in (N'U'))
DROP TABLE [dbo].[diapositivas]
GO
/****** Object:  Table [dbo].[roles_modules]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_roles_modules_modules]') AND parent_object_id = OBJECT_ID(N'[dbo].[roles_modules]'))
ALTER TABLE [dbo].[roles_modules] DROP CONSTRAINT [FK_roles_modules_modules]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_roles_modules_roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[roles_modules]'))
ALTER TABLE [dbo].[roles_modules] DROP CONSTRAINT [FK_roles_modules_roles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[roles_modules]') AND type in (N'U'))
DROP TABLE [dbo].[roles_modules]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_usuarios_empresas]') AND parent_object_id = OBJECT_ID(N'[dbo].[usuarios]'))
ALTER TABLE [dbo].[usuarios] DROP CONSTRAINT [FK_usuarios_empresas]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_usuarios_roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[usuarios]'))
ALTER TABLE [dbo].[usuarios] DROP CONSTRAINT [FK_usuarios_roles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usuarios]') AND type in (N'U'))
DROP TABLE [dbo].[usuarios]
GO
/****** Object:  Table [dbo].[cursos]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cursos_roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[cursos]'))
ALTER TABLE [dbo].[cursos] DROP CONSTRAINT [FK_cursos_roles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cursos]') AND type in (N'U'))
DROP TABLE [dbo].[cursos]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[roles]') AND type in (N'U'))
DROP TABLE [dbo].[roles]
GO
/****** Object:  Table [dbo].[empresas]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[empresas]') AND type in (N'U'))
DROP TABLE [dbo].[empresas]
GO
/****** Object:  Table [dbo].[empresas_cursos]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[empresas_cursos]') AND type in (N'U'))
DROP TABLE [dbo].[empresas_cursos]
GO
/****** Object:  Table [dbo].[estados_cursos]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[estados_cursos]') AND type in (N'U'))
DROP TABLE [dbo].[estados_cursos]
GO
/****** Object:  Table [dbo].[modules]    Script Date: 01/31/2016 22:35:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_modules_modules]') AND parent_object_id = OBJECT_ID(N'[dbo].[modules]'))
ALTER TABLE [dbo].[modules] DROP CONSTRAINT [FK_modules_modules]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[modules]') AND type in (N'U'))
DROP TABLE [dbo].[modules]
GO
/****** Object:  User [HOSTHM\BK-DBWebBk-Oper-HH-DGroup]    Script Date: 01/31/2016 22:35:46 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'HOSTHM\BK-DBWebBk-Oper-HH-DGroup')
DROP USER [HOSTHM\BK-DBWebBk-Oper-HH-DGroup]
GO
/****** Object:  User [HOSTHM\w1131306]    Script Date: 01/31/2016 22:35:46 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'HOSTHM\w1131306')
DROP USER [HOSTHM\w1131306]
GO
/****** Object:  User [w1131306_admin]    Script Date: 01/31/2016 22:35:46 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'w1131306_admin')
DROP USER [w1131306_admin]
GO
/****** Object:  User [w1131306_admin]    Script Date: 01/31/2016 22:35:46 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'w1131306_admin')
CREATE USER [w1131306_admin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [HOSTHM\w1131306]    Script Date: 01/31/2016 22:35:46 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'HOSTHM\w1131306')
CREATE USER [HOSTHM\w1131306] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [HOSTHM\BK-DBWebBk-Oper-HH-DGroup]    Script Date: 01/31/2016 22:35:46 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'HOSTHM\BK-DBWebBk-Oper-HH-DGroup')
CREATE USER [HOSTHM\BK-DBWebBk-Oper-HH-DGroup]
GO
/****** Object:  Table [dbo].[modules]    Script Date: 01/31/2016 22:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[modules]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[modules](
	[id_module] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[caption] [varchar](50) NULL,
	[action] [varchar](100) NULL,
	[icon] [varchar](30) NULL,
	[description] [varchar](150) NULL,
	[type] [int] NULL,
	[habilitado] [bit] NULL,
	[activo] [bit] NULL,
	[orden] [int] NULL,
	[id_module_parent] [bigint] NULL,
 CONSTRAINT [PK_modules] PRIMARY KEY CLUSTERED 
(
	[id_module] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[modules] ON
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (3, N'Seguridad', N'Seguridad', N'#', N'fa fa-lock fa-fw', N'Seguridad', 2, 1, 1, 1, NULL)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (4, N'Modulos', N'Modulos', N'/Module', N'fa fa-list fa-fw', N'Modulos', 1, 1, 1, 0, 3)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (6, N'Modulos Crear', N'Modulos Crear', N'/Module/Create', N'f', N'Modulos Crear', 3, 1, 1, 0, 4)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (7, N'Modulos Editar', N'Modulos Editar', N'/Module/Edit', N'f', N'Modulos Editar', 3, 1, 1, 0, 4)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (8, N'Roles', N'Roles', N'/Rol', N'fa fa-user-secret fa-fw', N'Roles', 1, 1, 1, 1, 3)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (9, N'Roles Save', N'Roles Save', N'/Rol/Save', N'f', N'Roles Save', 3, 1, 1, 0, 8)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (10, N'Usuarios', N'Usuarios', N'/Usuario', N'fa fa-user fa-fw', N'Usuarios', 1, 1, 1, 2, 3)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (11, N'Usuarios Save', N'Usuarios Save', N'/Usuario/Save', N'f', N'Usuarios Save', 3, 1, 1, 0, 10)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (12, N'Usuarios ChangePassword', N'Usuarios ChangePassword', N'/Usuario/ChangePassword', N'f', N'Usuarios ChangePassword', 3, 1, 1, 0, NULL)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (13, N'Rol modulos', N'Rol modulos', N'/Rol/RolModules', N'f', N'Rol modulos', 3, 1, 1, 0, 8)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (14, N'Home', N'Home', N'/Home', N'f', N'Home', 3, 1, 1, 0, NULL)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (15, N'Panel de Control', N'Panel de Control', N'/PanelDeControl', N'fa fa-cogs fa-fw', N'Panel de Control', 1, 1, 1, 3, 3)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (16, N'Reiniciar Variables Aplicacion', N'Reiniciar Variables Aplicacion', N'/PanelDeControl/ReiniciarVariablesAplicacion', N'f', N'Reiniciar Variables Aplicacion', 3, 1, 1, 0, 15)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (17, N'General', N'General', N'#', N'fa fa-list fa-fw', N'General', 2, 1, 1, 1, NULL)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (18, N'Empresas', N'Empresas', N'/Empresa', N'fa fa-suitcase fa-fw', N'Empresas', 1, 1, 1, 0, 17)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (19, N'Crear editar Empresa', N'Crear editar Empresa', N'/Empresa/Save', N'f', N'Crear editar Empresa', 3, 1, 1, 0, 18)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20, N'Gestion Cursos', N'Gestion Cursos', N'/Curso', N'fa fa-fw fa-file-video-o', N'Gestion Cursos', 1, 1, 1, 1, 17)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (21, N'Crear Editar Curso', N'Crear Editar Curso', N'/Curso/Save', N'f', N'Crear Editar Curso', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (10020, N'Usuarios Empresa', N'Usuarios Empresa', N'/Usuario/IndexEmpresa', N'fa fa-fw fa-user', N'Usuarios Empresa', 1, 1, 1, 2, 17)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (10021, N'Crear Editar Usuario para empresa', N'Crear Editar Usuario para empresa', N'/Usuario/SaveUsuarioEmpresa', N'f', N'Crear Editar Usuario para empresa', 3, 1, 1, 0, 10020)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20020, N'Asignar Cursos', N'Asignar Cursos', N'/Empresa/AsignarCursos', N'f', N'Asignar Cursos', 3, 1, 1, 0, 18)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20021, N'Subir Archivos a Curso', N'Subir Archivos a Curso', N'/Curso/RecargarCurso', N'f', N'Subir Archivos a Curso', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20022, N'Mis Cursos', N'Mis Cursos', N'/Curso/MisCursos', N'fa fa-fw fa-file-video-o', N'Mis Cursos', 1, 1, 1, 3, 17)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20023, N'Ver Curso', N'Ver Curso', N'/Curso/VerCurso', N'f', N'Ver Curso', 3, 1, 1, 0, 20022)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20024, N'Ver curso desde administrador', N'Ver curso desde administrador', N'/Curso/VerCursoAdmin', N'f', N'Ver curso desde administrador', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20025, N'Cargar Imagen', N'Cargar Imagen', N'/Empresa/CargarImagen', N'fa fa-fw fa-picture-o', N'Cargar Imagen', 1, 1, 1, 2, 17)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20026, N'Preguntas del Curso', N'Preguntas del Curso', N'/Pregunta/Index', N'f', N'Preguntas del Curso', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20027, N'Crear Pregunta', N'Crear Pregunta', N'/Pregunta/Create', N'f', N'Crear Pregunta', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20028, N'Editar Pregunta', N'Editar Pregunta', N'/Pregunta/Edit', N'f', N'Editar Pregunta', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20029, N'Hacer Examen', N'Hacer Examen', N'/Curso/HacerExamen', N'f', N'Hacer Examen', 3, 1, 1, 0, 20022)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20030, N'Reporte Cursos Usuarios', N'Reporte Cursos Usuarios', N'/Curso/ReporteCursosUsuarios', N'fa fa-fw fa-list', N'Reporte Cursos Usuarios', 1, 1, 1, 4, 17)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20031, N'Generar Reporte Cursos Usuarios', N'Generar Reporte Cursos Usuarios', N'/Curso/GenerarReporteCursosUsuarios', N'f', N'Generar Reporte Cursos Usuarios', 3, 1, 1, 0, 20030)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20032, N'Empresa Cursos', N'Empresa Cursos', N'/Empresa/EmpresaCursos', N'f', N'Empresa Cursos', 3, 1, 1, 0, 18)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20033, N'Empresa Curso Save', N'Empresa Curso Save', N'/Empresa/EmpresaCursoSave', N'f', N'Empresa Curso Save', 3, 1, 1, 0, 18)
SET IDENTITY_INSERT [dbo].[modules] OFF
/****** Object:  Table [dbo].[estados_cursos]    Script Date: 01/31/2016 22:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[estados_cursos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[estados_cursos](
	[id_estadocurso] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_estados_cursos] PRIMARY KEY CLUSTERED 
(
	[id_estadocurso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[estados_cursos] ON
INSERT [dbo].[estados_cursos] ([id_estadocurso], [nombre], [activo]) VALUES (1, N'No iniciado', 1)
INSERT [dbo].[estados_cursos] ([id_estadocurso], [nombre], [activo]) VALUES (2, N'Iniciado', 1)
INSERT [dbo].[estados_cursos] ([id_estadocurso], [nombre], [activo]) VALUES (3, N'Evaluacion Vista', 1)
INSERT [dbo].[estados_cursos] ([id_estadocurso], [nombre], [activo]) VALUES (4, N'Evaluacion Realizada', 1)
SET IDENTITY_INSERT [dbo].[estados_cursos] OFF
/****** Object:  Table [dbo].[empresas_cursos]    Script Date: 01/31/2016 22:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[empresas_cursos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[empresas_cursos](
	[id_empresa] [bigint] NULL,
	[id_curso] [bigint] NOT NULL,
	[id_empresacurso] [bigint] IDENTITY(1,1) NOT NULL,
	[limite_tiempo] [bit] NULL,
	[fecha_hasta] [datetime] NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_empresas_cursos] PRIMARY KEY CLUSTERED 
(
	[id_empresacurso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[empresas_cursos] ON
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (7, 1, 2, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (4, 1, 3, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (3, 1, 4, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (6, 1, 5, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (1, 1, 6, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (2, 1, 7, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (5, 1, 8, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (8, 1, 9, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (2, 2, 10, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (2, 3, 11, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (2, 4, 12, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (2, 5, 13, 0, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (2, 6, 14, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[empresas_cursos] OFF
/****** Object:  Table [dbo].[empresas]    Script Date: 01/31/2016 22:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[empresas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[empresas](
	[id_empresa] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[activo] [bit] NULL,
	[imagen] [varchar](150) NULL,
 CONSTRAINT [PK_empresas] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[empresas] ON
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (1, N'Fortius', 1, NULL)
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (2, N'Mymsys', 1, N'logoEmpresa2.png')
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (3, N'Empresa Prueba', 1, N'logoEmpresa3.png')
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (4, N'Empresa Modelo', 1, NULL)
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (5, N'Test', 1, NULL)
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (6, N'EmpresaPruebaCall', 1, NULL)
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (7, N'Cliente1', 1, NULL)
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (8, N'Apache', 1, NULL)
SET IDENTITY_INSERT [dbo].[empresas] OFF
/****** Object:  Table [dbo].[roles]    Script Date: 01/31/2016 22:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[roles](
	[id_rol] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[activo] [bit] NULL,
	[nivel] [int] NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[roles] ON
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (1, N'Administrador', 1, 100)
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (2, N'Administrador sitio', 1, 90)
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (3, N'Empresa', 1, 80)
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (4, N'Alto', 1, 70)
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (5, N'Medio', 1, 60)
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (6, N'Bajo', 1, 50)
SET IDENTITY_INSERT [dbo].[roles] OFF
/****** Object:  Table [dbo].[cursos]    Script Date: 01/31/2016 22:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cursos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cursos](
	[id_curso] [bigint] IDENTITY(1,1) NOT NULL,
	[activo] [bit] NULL,
	[nombre] [varchar](100) NULL,
	[descripcion] [varchar](250) NULL,
	[filesFolder] [varchar](250) NULL,
	[fechaAlta] [datetime] NULL,
	[cargado] [bit] NULL,
	[id_rol] [bigint] NULL,
	[html] [varchar](100) NULL,
 CONSTRAINT [PK_cursos] PRIMARY KEY CLUSTERED 
(
	[id_curso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[cursos] ON
INSERT [dbo].[cursos] ([id_curso], [activo], [nombre], [descripcion], [filesFolder], [fechaAlta], [cargado], [id_rol], [html]) VALUES (1, 1, N'Curso de prueba', N'Curso de prueba', N'vdxseYakNkuuDK2rxkYY2Q', CAST(0x0000A571015E6784 AS DateTime), 1, 5, N'index_lms_html5.html')
INSERT [dbo].[cursos] ([id_curso], [activo], [nombre], [descripcion], [filesFolder], [fechaAlta], [cargado], [id_rol], [html]) VALUES (2, 1, N'LIDERAZGO-Módulo1', N'Curso Liderazgo - Modulo 1', N'ptFMNmjl-UqyXIN6-cY9ng', CAST(0x0000A595013EE904 AS DateTime), 1, 4, N'story_html5.html')
INSERT [dbo].[cursos] ([id_curso], [activo], [nombre], [descripcion], [filesFolder], [fechaAlta], [cargado], [id_rol], [html]) VALUES (3, 1, N'LIDERAZGO-Módulo2', N'Curso Liderazgo - Modulo 2', N'7qOx1nF5k0-CYgvc9ZgPGQ', CAST(0x0000A595013FD940 AS DateTime), 1, 4, N'story_html5.html')
INSERT [dbo].[cursos] ([id_curso], [activo], [nombre], [descripcion], [filesFolder], [fechaAlta], [cargado], [id_rol], [html]) VALUES (4, 1, N'LIDERAZGO-Módulo3', N'Curso Liderazgo - Modulo 3', N'QIz-M7nT_kWn1u67Pl0wMA', CAST(0x0000A59501421AFC AS DateTime), 1, 4, N'story_html5.html')
INSERT [dbo].[cursos] ([id_curso], [activo], [nombre], [descripcion], [filesFolder], [fechaAlta], [cargado], [id_rol], [html]) VALUES (5, 1, N'GUIADelegadoMódulo2', N'Curso Guía Delegado - Módulo 2', N'SmzIEZFUXkqQK0dY4CtAww', CAST(0x0000A59501446BF4 AS DateTime), 1, 4, N'story_html5.html')
INSERT [dbo].[cursos] ([id_curso], [activo], [nombre], [descripcion], [filesFolder], [fechaAlta], [cargado], [id_rol], [html]) VALUES (6, 1, N'GUIADelegadoMódulo1', N'Curso Guía Delegado - Módulo 1', N'8tEjmunIqkyQPaBNMWwbeA', CAST(0x0000A59501458660 AS DateTime), 1, 4, N'story.html')
SET IDENTITY_INSERT [dbo].[cursos] OFF
