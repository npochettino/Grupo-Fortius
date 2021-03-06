USE [GrupoFournier]
GO
ALTER TABLE [dbo].[usuarios] DROP CONSTRAINT [FK_usuarios_roles]
GO
ALTER TABLE [dbo].[usuarios] DROP CONSTRAINT [FK_usuarios_empresas]
GO
ALTER TABLE [dbo].[roles_modules] DROP CONSTRAINT [FK_roles_modules_roles]
GO
ALTER TABLE [dbo].[roles_modules] DROP CONSTRAINT [FK_roles_modules_modules]
GO
ALTER TABLE [dbo].[modules] DROP CONSTRAINT [FK_modules_modules]
GO
ALTER TABLE [dbo].[cursos] DROP CONSTRAINT [FK_cursos_roles]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 16/12/2015 23:17:32 ******/
DROP TABLE [dbo].[usuarios]
GO
/****** Object:  Table [dbo].[roles_modules]    Script Date: 16/12/2015 23:17:32 ******/
DROP TABLE [dbo].[roles_modules]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 16/12/2015 23:17:32 ******/
DROP TABLE [dbo].[roles]
GO
/****** Object:  Table [dbo].[modules]    Script Date: 16/12/2015 23:17:32 ******/
DROP TABLE [dbo].[modules]
GO
/****** Object:  Table [dbo].[empresas_cursos]    Script Date: 16/12/2015 23:17:32 ******/
DROP TABLE [dbo].[empresas_cursos]
GO
/****** Object:  Table [dbo].[empresas]    Script Date: 16/12/2015 23:17:32 ******/
DROP TABLE [dbo].[empresas]
GO
/****** Object:  Table [dbo].[cursos]    Script Date: 16/12/2015 23:17:32 ******/
DROP TABLE [dbo].[cursos]
GO
/****** Object:  Table [dbo].[cursos]    Script Date: 16/12/2015 23:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[empresas]    Script Date: 16/12/2015 23:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[empresas](
	[id_empresa] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_empresas] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[empresas_cursos]    Script Date: 16/12/2015 23:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empresas_cursos](
	[id_empresa] [bigint] NOT NULL,
	[id_curso] [bigint] NOT NULL,
 CONSTRAINT [PK_empresas_cursos] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC,
	[id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[modules]    Script Date: 16/12/2015 23:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[roles]    Script Date: 16/12/2015 23:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[roles](
	[id_rol] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[activo] [bit] NULL,
	[nivel] [int] NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[roles_modules]    Script Date: 16/12/2015 23:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles_modules](
	[id_module] [bigint] NOT NULL,
	[id_rol] [bigint] NOT NULL,
 CONSTRAINT [PK_roles_modules] PRIMARY KEY CLUSTERED 
(
	[id_module] ASC,
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 16/12/2015 23:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](50) NULL,
	[password] [varchar](250) NULL,
	[nombre_completo] [varchar](250) NULL,
	[mail] [varchar](250) NULL,
	[id_rol] [bigint] NULL,
	[activo] [bit] NULL,
	[habilitado] [bit] NULL,
	[id_empresa] [bigint] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[cursos] ON 

INSERT [dbo].[cursos] ([id_curso], [activo], [nombre], [descripcion], [filesFolder], [fechaAlta], [cargado], [id_rol], [html]) VALUES (10003, 1, N'Curso Prueba', N'Curso Prueba', N'GJhiDhlFrUCZygwieFTazQ', CAST(N'2015-12-16 22:50:25.000' AS DateTime), 1, 6, N'index_lms_html5.html')
SET IDENTITY_INSERT [dbo].[cursos] OFF
SET IDENTITY_INSERT [dbo].[empresas] ON 

INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo]) VALUES (1, N'Fournier', 1)
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo]) VALUES (2, N'Mymsys', 1)
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo]) VALUES (3, N'Empresa Prueba', 1)
SET IDENTITY_INSERT [dbo].[empresas] OFF
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso]) VALUES (2, 10003)
SET IDENTITY_INSERT [dbo].[modules] ON 

INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (3, N'Seguridad', N'Seguridad', N'#', N'fa fa-lock fa-fw', N'Seguridad', 2, 1, 1, 1, NULL)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (4, N'Modulos', N'Modulos', N'/Module', N'fa fa-list fa-fw', N'Modulos', 1, 1, 1, 0, 3)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (6, N'Modulos Crear', N'Modulos Crear', N'/Module/Create', N'f', N'Modulos Crear', 3, 1, 1, 0, 4)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (7, N'Modulos Editar', N'Modulos Editar', N'/Module/Edit', N'f', N'Modulos Editar', 3, 1, 1, 0, 4)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (8, N'Roles', N'Roles', N'/Rol', N'fa fa-user-secret fa-fw', N'Roles', 1, 1, 1, 1, 3)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (9, N'Roles Save', N'Roles Save', N'/Rol/Save', N'f', N'Roles Save', 3, 1, 1, 0, 8)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (10, N'Usuarios', N'Usuarios', N'/Usuario', N'fa fa-user fa-fw', N'Usuarios', 1, 1, 1, 2, 3)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (11, N'Usuarios Save', N'Usuarios Save', N'/Usuario/Save', N'f', N'Usuarios Save', 3, 1, 1, 0, 10)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (12, N'Usuarios ChangePassword', N'Usuarios ChangePassword', N'/Usuario/ChangePassword', N'f', N'Usuarios ChangePassword', 3, 1, 1, 0, 10)
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
SET IDENTITY_INSERT [dbo].[modules] OFF
SET IDENTITY_INSERT [dbo].[roles] ON 

INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (1, N'Administrador', 1, 100)
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (2, N'Administrador sitio', 1, 90)
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (3, N'Empresa', 1, 80)
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (4, N'Alto', 1, 70)
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (5, N'Medio', 1, 60)
INSERT [dbo].[roles] ([id_rol], [nombre], [activo], [nivel]) VALUES (6, N'Bajo', 1, 50)
SET IDENTITY_INSERT [dbo].[roles] OFF
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (3, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (3, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (3, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (3, 4)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (3, 5)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (3, 6)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (4, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (6, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (7, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (8, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (9, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10, 4)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10, 5)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10, 6)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (11, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (11, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (12, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (12, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (12, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (12, 4)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (12, 5)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (12, 6)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (13, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (14, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (14, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (14, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (14, 4)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (14, 5)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (14, 6)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (15, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (16, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (17, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (17, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (17, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (18, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (18, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (19, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (19, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (21, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (21, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10020, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10020, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10020, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10021, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10021, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10021, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20020, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20020, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20021, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20022, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20023, 1)
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [password], [nombre_completo], [mail], [id_rol], [activo], [habilitado], [id_empresa]) VALUES (1, N'emiliano', N'PFWqjzKsYHAozej9ldFY9z5XiRqr4gvalNxB1HdPU/fsfDfw', N'Emiliano Magnani', N'emimagnani90@gmail.com', 1, 1, 1, 2)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [password], [nombre_completo], [mail], [id_rol], [activo], [habilitado], [id_empresa]) VALUES (2, N'facundo', N'ZQj0/Xr+WQlTCdOk63EFkWhiKuqeWpyxvp7BMDLUT1t8oB+4', N'Facundo Mantovani', N'facundomantovani@hotmail.com', 1, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
ALTER TABLE [dbo].[cursos]  WITH CHECK ADD  CONSTRAINT [FK_cursos_roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[roles] ([id_rol])
GO
ALTER TABLE [dbo].[cursos] CHECK CONSTRAINT [FK_cursos_roles]
GO
ALTER TABLE [dbo].[modules]  WITH CHECK ADD  CONSTRAINT [FK_modules_modules] FOREIGN KEY([id_module_parent])
REFERENCES [dbo].[modules] ([id_module])
GO
ALTER TABLE [dbo].[modules] CHECK CONSTRAINT [FK_modules_modules]
GO
ALTER TABLE [dbo].[roles_modules]  WITH CHECK ADD  CONSTRAINT [FK_roles_modules_modules] FOREIGN KEY([id_module])
REFERENCES [dbo].[modules] ([id_module])
GO
ALTER TABLE [dbo].[roles_modules] CHECK CONSTRAINT [FK_roles_modules_modules]
GO
ALTER TABLE [dbo].[roles_modules]  WITH CHECK ADD  CONSTRAINT [FK_roles_modules_roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[roles] ([id_rol])
GO
ALTER TABLE [dbo].[roles_modules] CHECK CONSTRAINT [FK_roles_modules_roles]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_empresas] FOREIGN KEY([id_empresa])
REFERENCES [dbo].[empresas] ([id_empresa])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_empresas]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[roles] ([id_rol])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_roles]
GO
