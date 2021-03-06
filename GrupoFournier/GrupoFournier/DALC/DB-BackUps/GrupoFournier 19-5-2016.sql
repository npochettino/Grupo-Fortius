USE [GrupoFournier]
GO
/****** Object:  Table [dbo].[botones]    Script Date: 19/5/2016 8:39:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[botones](
	[id_boton] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[contenido] [text] NULL,
	[id_diapositiva] [bigint] NULL,
	[color] [varchar](50) NULL,
	[orden] [int] NULL,
 CONSTRAINT [PK_botones] PRIMARY KEY CLUSTERED 
(
	[id_boton] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cursos]    Script Date: 19/5/2016 8:39:42 p. m. ******/
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
	[imagen] [varchar](250) NULL,
 CONSTRAINT [PK_cursos] PRIMARY KEY CLUSTERED 
(
	[id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cursos_usuarios]    Script Date: 19/5/2016 8:39:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cursos_usuarios](
	[id_usuario] [bigint] NOT NULL,
	[id_curso] [bigint] NOT NULL,
	[id_estadocurso] [bigint] NOT NULL,
	[nota] [float] NOT NULL,
	[activo] [bit] NULL,
	[id_cursousuario] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_cursos_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_cursousuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[diapositivas]    Script Date: 19/5/2016 8:39:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[diapositivas](
	[id_diapositiva] [bigint] IDENTITY(1,1) NOT NULL,
	[orden] [int] NULL,
	[titulo] [varchar](250) NULL,
	[contenidoTexto] [text] NULL,
	[id_curso] [bigint] NOT NULL,
	[imagen] [varchar](250) NULL,
	[colorTitulo] [varchar](50) NULL,
	[colorContenido] [varchar](50) NULL,
	[id_plantilla] [bigint] NULL,
	[video] [varchar](250) NULL,
 CONSTRAINT [PK_diapositivas] PRIMARY KEY CLUSTERED 
(
	[id_diapositiva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[diapositivas_referidas]    Script Date: 19/5/2016 8:39:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diapositivas_referidas](
	[id_diapositiva] [bigint] NOT NULL,
	[id_diapositiva_referida] [bigint] NOT NULL,
 CONSTRAINT [PK_diapositivas_referidas] PRIMARY KEY CLUSTERED 
(
	[id_diapositiva] ASC,
	[id_diapositiva_referida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[empresas]    Script Date: 19/5/2016 8:39:42 p. m. ******/
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
	[imagen] [varchar](max) NULL,
 CONSTRAINT [PK_empresas] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[empresas_cursos]    Script Date: 19/5/2016 8:39:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[estados_cursos]    Script Date: 19/5/2016 8:39:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[estados_cursos](
	[id_estadocurso] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_estados_cursos] PRIMARY KEY CLUSTERED 
(
	[id_estadocurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[modules]    Script Date: 19/5/2016 8:39:42 p. m. ******/
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
/****** Object:  Table [dbo].[opciones]    Script Date: 19/5/2016 8:39:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[opciones](
	[id_opcion] [bigint] IDENTITY(1,1) NOT NULL,
	[id_pregunta] [bigint] NULL,
	[descripcion] [varchar](max) NULL,
	[correcta] [bit] NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_opciones] PRIMARY KEY CLUSTERED 
(
	[id_opcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[plantillas]    Script Date: 19/5/2016 8:39:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[plantillas](
	[id_plantilla] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[estructura] [text] NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_plantillas] PRIMARY KEY CLUSTERED 
(
	[id_plantilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[preguntas]    Script Date: 19/5/2016 8:39:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[preguntas](
	[id_pregunta] [bigint] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](max) NULL,
	[orden] [int] NULL,
	[activo] [bit] NULL,
	[id_curso] [bigint] NULL,
 CONSTRAINT [PK_preguntas] PRIMARY KEY CLUSTERED 
(
	[id_pregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[roles]    Script Date: 19/5/2016 8:39:42 p. m. ******/
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
/****** Object:  Table [dbo].[roles_modules]    Script Date: 19/5/2016 8:39:42 p. m. ******/
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
/****** Object:  Table [dbo].[textos]    Script Date: 19/5/2016 8:39:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[textos](
	[id_texto] [bigint] IDENTITY(1,1) NOT NULL,
	[contenido] [text] NULL,
	[id_diapositiva] [bigint] NULL,
	[orden] [int] NULL,
 CONSTRAINT [PK_textos] PRIMARY KEY CLUSTERED 
(
	[id_texto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 19/5/2016 8:39:42 p. m. ******/
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
SET IDENTITY_INSERT [dbo].[botones] ON 

INSERT [dbo].[botones] ([id_boton], [nombre], [contenido], [id_diapositiva], [color], [orden]) VALUES (7, N'Boton 1', N'<p>Boton 1 Boton 1&nbsp;</p>', 2, N'#099652', 1)
INSERT [dbo].[botones] ([id_boton], [nombre], [contenido], [id_diapositiva], [color], [orden]) VALUES (8, N'Boton 2', N'<p>Boton 2 Boton 2 Boton 2</p>', 2, N'#af3a3a', 2)
INSERT [dbo].[botones] ([id_boton], [nombre], [contenido], [id_diapositiva], [color], [orden]) VALUES (9, N'Boton 3 ', N'<p>Boton 3&nbsp;Boton 3&nbsp;Boton 3</p>', 2, N'#2e05a3', 3)
INSERT [dbo].[botones] ([id_boton], [nombre], [contenido], [id_diapositiva], [color], [orden]) VALUES (13, N'Boton 1', N'<p>Boton 1&nbsp;Boton 1&nbsp;Boton 1</p>', 4, N'#d60d0d', 1)
INSERT [dbo].[botones] ([id_boton], [nombre], [contenido], [id_diapositiva], [color], [orden]) VALUES (14, N'Boton 2', N'<p>Boton 2&nbsp;Boton 2&nbsp;Boton&nbsp;2</p>', 4, N'#2a4fad', 2)
INSERT [dbo].[botones] ([id_boton], [nombre], [contenido], [id_diapositiva], [color], [orden]) VALUES (15, N'Boton 3', N'<p>Boton 3&nbsp;Boton 3&nbsp;Boton3</p>', 4, N'#e50808', 3)
SET IDENTITY_INSERT [dbo].[botones] OFF
SET IDENTITY_INSERT [dbo].[cursos] ON 

INSERT [dbo].[cursos] ([id_curso], [activo], [nombre], [descripcion], [filesFolder], [fechaAlta], [cargado], [id_rol], [html], [imagen]) VALUES (10003, 1, N'Curso Prueba', N'Curso Prueba', N'GJhiDhlFrUCZygwieFTazQ', CAST(N'2015-12-16 22:50:25.000' AS DateTime), 1, 4, N'index_lms_html5.html', N'curso10003.jpg')
INSERT [dbo].[cursos] ([id_curso], [activo], [nombre], [descripcion], [filesFolder], [fechaAlta], [cargado], [id_rol], [html], [imagen]) VALUES (20003, 1, N'Otro curso', N'Otro curso', N'cRczWJ1_PEKaVdq8rTuL-Q', CAST(N'2016-01-05 22:35:34.000' AS DateTime), 1, 5, N'no_probar', NULL)
SET IDENTITY_INSERT [dbo].[cursos] OFF
SET IDENTITY_INSERT [dbo].[cursos_usuarios] ON 

INSERT [dbo].[cursos_usuarios] ([id_usuario], [id_curso], [id_estadocurso], [nota], [activo], [id_cursousuario]) VALUES (1, 10003, 4, 50, 1, 10005)
SET IDENTITY_INSERT [dbo].[cursos_usuarios] OFF
SET IDENTITY_INSERT [dbo].[diapositivas] ON 

INSERT [dbo].[diapositivas] ([id_diapositiva], [orden], [titulo], [contenidoTexto], [id_curso], [imagen], [colorTitulo], [colorContenido], [id_plantilla], [video]) VALUES (2, 1, N'Introducción', N'<p>En un mundo tan cambiante y competitivo confiamos en que la diferencia est&aacute;, nada m&aacute;s y nada menos que en las personas, en la formaci&oacute;n y las competencias que tengan, por eso apostamos continuamente a la capacitaci&oacute;n. Durante el desarrollo de esta actividad de formaci&oacute;n, vamos a recorrer un camino juntos: el camino del aprendizaje. En este recorrido vamos a profundizar la relaci&oacute;n entre las personas y las organizaciones, tarea compleja pero a la vez desafiante de llevarla a cabo. Para mediar en esta ida y vuelta surge una figura muy importante, El L&iacute;der, tema central de nuestros pr&oacute;ximos encuentros virtuales. Te damos la Bienvenida y es un agrado para nosotros saber que est&aacute;s ah&iacute;</p>', 10003, NULL, N'#000000', N'#000000', 1, NULL)
INSERT [dbo].[diapositivas] ([id_diapositiva], [orden], [titulo], [contenidoTexto], [id_curso], [imagen], [colorTitulo], [colorContenido], [id_plantilla], [video]) VALUES (3, 2, N'Diapositiva 2', N'<p>1. L&iacute;der se nace. 2. Mi estilo de liderazgo no se puede cambiar. 3. El liderazgo tiene s&oacute;lo un estilo. 4. El ambiente donde yo lidero es importante. 5. El liderazgo significa influir en los dem&aacute;s para que act&uacute;en de cierta manera que tenga como resultado la productividad y la acci&oacute;n. 6. Todo buen l&iacute;der tiene una visi&oacute;n que comparte con sus seguidores.</p>', 10003, N'curso10003diapositiva3.png', N'#000000', N'#000000', 2, NULL)
INSERT [dbo].[diapositivas] ([id_diapositiva], [orden], [titulo], [contenidoTexto], [id_curso], [imagen], [colorTitulo], [colorContenido], [id_plantilla], [video]) VALUES (4, 3, N'Diapositiva 3', N'<p>Diapositiva 3 Diapositiva 3 Diapositiva 3 Diapositiva 3 Diapositiva 3</p>', 10003, NULL, N'#000000', N'#000000', 1, NULL)
INSERT [dbo].[diapositivas] ([id_diapositiva], [orden], [titulo], [contenidoTexto], [id_curso], [imagen], [colorTitulo], [colorContenido], [id_plantilla], [video]) VALUES (5, 4, N'Diapositiva 4', N'<p>Diapositiva 4 Diapositiva 4 Diapositiva 4 Diapositiva 4 Diapositiva 4</p>', 10003, NULL, N'#ef1111', N'#2e20d6', 4, NULL)
INSERT [dbo].[diapositivas] ([id_diapositiva], [orden], [titulo], [contenidoTexto], [id_curso], [imagen], [colorTitulo], [colorContenido], [id_plantilla], [video]) VALUES (7, 5, N'Diapositiva 5', N'<p>d</p>', 10003, NULL, N'#000000', N'#000000', 3, NULL)
INSERT [dbo].[diapositivas] ([id_diapositiva], [orden], [titulo], [contenidoTexto], [id_curso], [imagen], [colorTitulo], [colorContenido], [id_plantilla], [video]) VALUES (12, 6, N'Diapositiva 6', NULL, 10003, NULL, N'#000000', NULL, 5, N'curso10003diapositiva12.mp4')
SET IDENTITY_INSERT [dbo].[diapositivas] OFF
INSERT [dbo].[diapositivas_referidas] ([id_diapositiva], [id_diapositiva_referida]) VALUES (2, 3)
INSERT [dbo].[diapositivas_referidas] ([id_diapositiva], [id_diapositiva_referida]) VALUES (3, 4)
INSERT [dbo].[diapositivas_referidas] ([id_diapositiva], [id_diapositiva_referida]) VALUES (4, 3)
INSERT [dbo].[diapositivas_referidas] ([id_diapositiva], [id_diapositiva_referida]) VALUES (5, 2)
INSERT [dbo].[diapositivas_referidas] ([id_diapositiva], [id_diapositiva_referida]) VALUES (5, 3)
SET IDENTITY_INSERT [dbo].[empresas] ON 

INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (1, N'Fortius', 1, NULL)
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (2, N'Mymsys', 1, N'logoEmpresa2.png')
INSERT [dbo].[empresas] ([id_empresa], [nombre], [activo], [imagen]) VALUES (3, N'Empresa Prueba', 1, NULL)
SET IDENTITY_INSERT [dbo].[empresas] OFF
SET IDENTITY_INSERT [dbo].[empresas_cursos] ON 

INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (3, 10003, 3, 1, NULL, 1)
INSERT [dbo].[empresas_cursos] ([id_empresa], [id_curso], [id_empresacurso], [limite_tiempo], [fecha_hasta], [activo]) VALUES (2, 10003, 10004, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[empresas_cursos] OFF
SET IDENTITY_INSERT [dbo].[estados_cursos] ON 

INSERT [dbo].[estados_cursos] ([id_estadocurso], [nombre], [activo]) VALUES (1, N'No iniciado', 1)
INSERT [dbo].[estados_cursos] ([id_estadocurso], [nombre], [activo]) VALUES (2, N'Iniciado', 1)
INSERT [dbo].[estados_cursos] ([id_estadocurso], [nombre], [activo]) VALUES (3, N'Evaluacion Vista', 1)
INSERT [dbo].[estados_cursos] ([id_estadocurso], [nombre], [activo]) VALUES (4, N'Evaluacion Realizada', 1)
SET IDENTITY_INSERT [dbo].[estados_cursos] OFF
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
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (20024, N'Ver curso desde administrador', N'Ver curso desde administrador', N'/Curso/VerCursoAdmin', N'f', N'Ver curso desde administrador', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (30020, N'Cargar Imagen', N'Cargar Imagen', N'/Empresa/CargarImagen', N'fa fa-fw fa-picture-o', N'Cargar Imagen', 1, 1, 1, 2, 17)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (30021, N'Preguntas del Curso', N'Preguntas del Curso', N'/Pregunta', N'f', N'Preguntas del Curso', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (30022, N'Crear Pregunta', N'Crear Pregunta', N'/Pregunta/Create', N'f', N'Crear Pregunta', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (30023, N'Editar Pregunta', N'Editar Pregunta', N'/Pregunta/Edit', N'f', N'Editar Pregunta', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (40020, N'Hacer Examen', N'Hacer Examen', N'/Curso/HacerExamen', N'f', N'Hacer Examen', 3, 1, 1, 0, 20022)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (40021, N'Reporte Cursos Usuarios', N'Reporte Cursos Usuarios', N'/Curso/ReporteCursosUsuarios', N'fa fa-fw fa-list', N'Reporte Cursos Usuarios', 1, 1, 1, 4, 17)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (40022, N'Generar Reporte Cursos Usuarios', N'Generar Reporte Cursos Usuarios', N'/Curso/GenerarReporteCursosUsuarios', N'f', N'Generar Reporte Cursos Usuarios', 3, 1, 1, 0, 40021)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (40023, N'Empresa Cursos', N'Empresa Cursos', N'/Empresa/EmpresaCursos', N'f', N'Empresa Cursos', 3, 1, 1, 0, 18)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (40024, N'Empresa Curso Save', N'Empresa Curso Save', N'/Empresa/EmpresaCursoSave', N'f', N'Empresa Curso Save', 3, 1, 1, 0, 18)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (50020, N'Diapositivas Save', N'Diapositivas Save', N'/Diapositiva/Save', N'fa fa-fw fa-file-image-o', N'Diapositivas Save', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (50021, N'Diapositivas Index', N'Diapositivas Index', N'/Diapositiva', N'f', N'Diapositivas Index', 3, 1, 1, 0, 20)
INSERT [dbo].[modules] ([id_module], [name], [caption], [action], [icon], [description], [type], [habilitado], [activo], [orden], [id_module_parent]) VALUES (50022, N'Ver Curso con Diapositivas', N'Ver Curso con Diapositivas', N'/Diapositiva/VerCurso', N'f', N'Ver Curso con Diapositivas', 3, 1, 1, 0, 20022)
SET IDENTITY_INSERT [dbo].[modules] OFF
SET IDENTITY_INSERT [dbo].[opciones] ON 

INSERT [dbo].[opciones] ([id_opcion], [id_pregunta], [descripcion], [correcta], [activo]) VALUES (1, 2, N'Opcion incorrecta', 0, 1)
INSERT [dbo].[opciones] ([id_opcion], [id_pregunta], [descripcion], [correcta], [activo]) VALUES (2, 2, N'Opcion correcta', 1, 1)
INSERT [dbo].[opciones] ([id_opcion], [id_pregunta], [descripcion], [correcta], [activo]) VALUES (10006, NULL, N'somos 1', 0, 1)
INSERT [dbo].[opciones] ([id_opcion], [id_pregunta], [descripcion], [correcta], [activo]) VALUES (10007, NULL, N'somos 2', 1, 1)
INSERT [dbo].[opciones] ([id_opcion], [id_pregunta], [descripcion], [correcta], [activo]) VALUES (20007, 10002, N'1', 1, 1)
INSERT [dbo].[opciones] ([id_opcion], [id_pregunta], [descripcion], [correcta], [activo]) VALUES (20008, 10002, N'2', 0, 1)
INSERT [dbo].[opciones] ([id_opcion], [id_pregunta], [descripcion], [correcta], [activo]) VALUES (20009, 20004, N'aaa', 1, 1)
INSERT [dbo].[opciones] ([id_opcion], [id_pregunta], [descripcion], [correcta], [activo]) VALUES (20010, 20004, N'bbb', 0, 1)
SET IDENTITY_INSERT [dbo].[opciones] OFF
SET IDENTITY_INSERT [dbo].[plantillas] ON 

INSERT [dbo].[plantillas] ([id_plantilla], [nombre], [estructura], [activo]) VALUES (1, N'Botones', N'<div class="contenedorBotones text-center"></div><div class="contenedorTextos text-center"></div>', 1)
INSERT [dbo].[plantillas] ([id_plantilla], [nombre], [estructura], [activo]) VALUES (2, N'Textos centrados', N'<div class="contenidoTextosCentrados text-center"></div>', 1)
INSERT [dbo].[plantillas] ([id_plantilla], [nombre], [estructura], [activo]) VALUES (3, N'Textos en diferentes posiciones', N'<div  class="row"><div class="textosDiferentePosicion col-sm-6" id="contenedorSuperiorIzquierdo" style="display: none"></div><div class="textosDiferentePosicion col-sm-6" id="contenedorSuperiorDerecho" style="display: none"></div>
</div>
<div class="row">
<div class="textosDiferentePosicion col-sm-6 col-sm-push-3" id="contenedorCentral" style="display: none"></div>
</div>
<div class="row"><div class="textosDiferentePosicion col-sm-6" id="contenedorInferiorIzquierdo" style="display: none"></div><div class="textosDiferentePosicion col-sm-6" id="contenedorInferiorDerecho" style="display: none"></div>
</div>', 1)
INSERT [dbo].[plantillas] ([id_plantilla], [nombre], [estructura], [activo]) VALUES (4, N'Textos apilados horizontalmente', N'<div class="contenedorTextosHorizontales text-center"></div>', 1)
INSERT [dbo].[plantillas] ([id_plantilla], [nombre], [estructura], [activo]) VALUES (5, N'Video', N'<div class="contenedorVideo text-center"></div>', 1)
SET IDENTITY_INSERT [dbo].[plantillas] OFF
SET IDENTITY_INSERT [dbo].[preguntas] ON 

INSERT [dbo].[preguntas] ([id_pregunta], [titulo], [orden], [activo], [id_curso]) VALUES (2, N'La pregunta', 2, 1, 10003)
INSERT [dbo].[preguntas] ([id_pregunta], [titulo], [orden], [activo], [id_curso]) VALUES (10002, N'Cuantos somos', 1, 1, 10003)
INSERT [dbo].[preguntas] ([id_pregunta], [titulo], [orden], [activo], [id_curso]) VALUES (20004, N'AAa', 3, 1, 10003)
SET IDENTITY_INSERT [dbo].[preguntas] OFF
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
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (17, 4)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (17, 5)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (17, 6)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (18, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (18, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (19, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (19, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (21, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (21, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10020, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10020, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10021, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (10021, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20020, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20020, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20021, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20021, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20022, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20022, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20022, 4)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20022, 5)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20022, 6)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20023, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20023, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20023, 4)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20023, 5)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20023, 6)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20024, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (20024, 2)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (30020, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (30020, 3)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (30021, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (30022, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (30023, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (40020, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (40021, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (40022, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (40023, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (40024, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (50020, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (50021, 1)
INSERT [dbo].[roles_modules] ([id_module], [id_rol]) VALUES (50022, 1)
SET IDENTITY_INSERT [dbo].[textos] ON 

INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (8, N'<p>Texto 1&nbsp;Texto 1&nbsp;Texto 1&nbsp;Texto 1</p>', 3, 1)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (9, N'<p><span style="color: #ff0000; background-color: #00ffff;">Texto 2&nbsp;Texto 2&nbsp;Texto 2&nbsp;Texto&nbsp;2&nbsp;</span></p>', 3, 2)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (10, N'<p><span style="color: #ff0000; background-color: #cc99ff;"><strong>Texto 3&nbsp;Texto 3&nbsp;Texto 3&nbsp;Texto&nbsp;3</strong></span></p>', 3, 3)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (20, N'<p>Texto 1&nbsp;Texto 1&nbsp;Texto 1&nbsp;Texto 1</p>', 5, 1)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (21, N'<p>Texto 2&nbsp;Texto 2&nbsp;Texto 2&nbsp;Texto&nbsp;2&nbsp;</p>', 5, 2)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (22, N'<p><strong>Texto 3&nbsp;Texto 3&nbsp;Texto 3&nbsp;Texto&nbsp;3</strong></p>', 5, 3)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (23, N'<p>Texto 4&nbsp;Texto 4&nbsp;Texto 4&nbsp;Texto&nbsp;4</p>', 5, 4)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (28, N'<p>Texto 1</p>', 7, 1)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (29, N'<p>Texto 2</p>', 7, 2)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (30, N'<p>Text 3</p>', 7, 3)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (31, N'<p>Texto&nbsp;4</p>', 7, 4)
INSERT [dbo].[textos] ([id_texto], [contenido], [id_diapositiva], [orden]) VALUES (32, N'<p>Texto&nbsp;5</p>', 7, 5)
SET IDENTITY_INSERT [dbo].[textos] OFF
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [password], [nombre_completo], [mail], [id_rol], [activo], [habilitado], [id_empresa]) VALUES (1, N'emiliano', N'PFWqjzKsYHAozej9ldFY9z5XiRqr4gvalNxB1HdPU/fsfDfw', N'Emiliano Magnani', N'emimagnani90@gmail.com', 1, 1, 1, 2)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [password], [nombre_completo], [mail], [id_rol], [activo], [habilitado], [id_empresa]) VALUES (2, N'facundo', N'ZQj0/Xr+WQlTCdOk63EFkWhiKuqeWpyxvp7BMDLUT1t8oB+4', N'Facundo Mantovani', N'facundomantovani@hotmail.com', 1, 1, 1, 2)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [password], [nombre_completo], [mail], [id_rol], [activo], [habilitado], [id_empresa]) VALUES (10003, N'usuariofortius', N'SI0lWDvrmMSa679WNzqsw0TXQ20INL+ZZ8IGlh95HrhX6W7S', N'Usuario Fortius', N'usuariofortius@fortius.com', 2, 1, 1, 1)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [password], [nombre_completo], [mail], [id_rol], [activo], [habilitado], [id_empresa]) VALUES (10004, N'usuariobajo', N'H2lFxPfiqR6Fma1jv63n+GdHjCAfHAWIM29vHJp+Qns2jXnP', N'Usuario Bajo', N'asd@asd.com', 6, 1, 1, 3)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [password], [nombre_completo], [mail], [id_rol], [activo], [habilitado], [id_empresa]) VALUES (10005, N'ezequiel', N'NXQgUncNIL95g3HPsqbr9uUihMtr2RxIOGyxuZQnMnFBuFHE', N'Ezequiel', N'ezequiel@ezequiel.com', 1, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
ALTER TABLE [dbo].[botones]  WITH CHECK ADD  CONSTRAINT [FK_botones_diapositivas] FOREIGN KEY([id_diapositiva])
REFERENCES [dbo].[diapositivas] ([id_diapositiva])
GO
ALTER TABLE [dbo].[botones] CHECK CONSTRAINT [FK_botones_diapositivas]
GO
ALTER TABLE [dbo].[cursos]  WITH CHECK ADD  CONSTRAINT [FK_cursos_roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[roles] ([id_rol])
GO
ALTER TABLE [dbo].[cursos] CHECK CONSTRAINT [FK_cursos_roles]
GO
ALTER TABLE [dbo].[cursos_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_cursos_usuarios_cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[cursos_usuarios] CHECK CONSTRAINT [FK_cursos_usuarios_cursos]
GO
ALTER TABLE [dbo].[cursos_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_cursos_usuarios_estados_cursos] FOREIGN KEY([id_estadocurso])
REFERENCES [dbo].[estados_cursos] ([id_estadocurso])
GO
ALTER TABLE [dbo].[cursos_usuarios] CHECK CONSTRAINT [FK_cursos_usuarios_estados_cursos]
GO
ALTER TABLE [dbo].[cursos_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_cursos_usuarios_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[cursos_usuarios] CHECK CONSTRAINT [FK_cursos_usuarios_usuarios]
GO
ALTER TABLE [dbo].[diapositivas]  WITH CHECK ADD  CONSTRAINT [FK_diapositivas_cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[diapositivas] CHECK CONSTRAINT [FK_diapositivas_cursos]
GO
ALTER TABLE [dbo].[diapositivas]  WITH CHECK ADD  CONSTRAINT [FK_diapositivas_diapositivas] FOREIGN KEY([id_diapositiva])
REFERENCES [dbo].[diapositivas] ([id_diapositiva])
GO
ALTER TABLE [dbo].[diapositivas] CHECK CONSTRAINT [FK_diapositivas_diapositivas]
GO
ALTER TABLE [dbo].[diapositivas]  WITH CHECK ADD  CONSTRAINT [FK_diapositivas_plantillas] FOREIGN KEY([id_plantilla])
REFERENCES [dbo].[plantillas] ([id_plantilla])
GO
ALTER TABLE [dbo].[diapositivas] CHECK CONSTRAINT [FK_diapositivas_plantillas]
GO
ALTER TABLE [dbo].[diapositivas]  WITH CHECK ADD  CONSTRAINT [FK_diapositivas_plantillas1] FOREIGN KEY([id_plantilla])
REFERENCES [dbo].[plantillas] ([id_plantilla])
GO
ALTER TABLE [dbo].[diapositivas] CHECK CONSTRAINT [FK_diapositivas_plantillas1]
GO
ALTER TABLE [dbo].[diapositivas_referidas]  WITH CHECK ADD  CONSTRAINT [FK_diapositivas_referidas_diapositivas] FOREIGN KEY([id_diapositiva])
REFERENCES [dbo].[diapositivas] ([id_diapositiva])
GO
ALTER TABLE [dbo].[diapositivas_referidas] CHECK CONSTRAINT [FK_diapositivas_referidas_diapositivas]
GO
ALTER TABLE [dbo].[diapositivas_referidas]  WITH CHECK ADD  CONSTRAINT [FK_diapositivas_referidas_diapositivas1] FOREIGN KEY([id_diapositiva_referida])
REFERENCES [dbo].[diapositivas] ([id_diapositiva])
GO
ALTER TABLE [dbo].[diapositivas_referidas] CHECK CONSTRAINT [FK_diapositivas_referidas_diapositivas1]
GO
ALTER TABLE [dbo].[modules]  WITH CHECK ADD  CONSTRAINT [FK_modules_modules] FOREIGN KEY([id_module_parent])
REFERENCES [dbo].[modules] ([id_module])
GO
ALTER TABLE [dbo].[modules] CHECK CONSTRAINT [FK_modules_modules]
GO
ALTER TABLE [dbo].[opciones]  WITH CHECK ADD  CONSTRAINT [FK_opciones_preguntas] FOREIGN KEY([id_pregunta])
REFERENCES [dbo].[preguntas] ([id_pregunta])
GO
ALTER TABLE [dbo].[opciones] CHECK CONSTRAINT [FK_opciones_preguntas]
GO
ALTER TABLE [dbo].[preguntas]  WITH CHECK ADD  CONSTRAINT [FK_preguntas_cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[preguntas] CHECK CONSTRAINT [FK_preguntas_cursos]
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
ALTER TABLE [dbo].[textos]  WITH CHECK ADD  CONSTRAINT [FK_textos_diapositivas] FOREIGN KEY([id_diapositiva])
REFERENCES [dbo].[diapositivas] ([id_diapositiva])
GO
ALTER TABLE [dbo].[textos] CHECK CONSTRAINT [FK_textos_diapositivas]
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
