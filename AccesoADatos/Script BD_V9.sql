USE master
GO
if exists(select * from sys.databases where name='SiGMA') 
DROP DATABASE [SiGMA] 
GO
CREATE DATABASE [SiGMA]
GO
USE [SiGMA]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[idPermiso] [int] IDENTITY(1,1) NOT NULL,
	[tipoPermiso] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[idPermiso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permisos] ON
INSERT [dbo].[Permisos] ([idPermiso], [tipoPermiso]) VALUES (1, N'Visualizacion')
INSERT [dbo].[Permisos] ([idPermiso], [tipoPermiso]) VALUES (2, N'Grabacion')
INSERT [dbo].[Permisos] ([idPermiso], [tipoPermiso]) VALUES (3, N'Eliminacion')
SET IDENTITY_INSERT [dbo].[Permisos] OFF
/****** Object:  Table [dbo].[Roles]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([idRol], [nombre], [descripcion]) VALUES (1, N'Administrador', NULL)
INSERT [dbo].[Roles] ([idRol], [nombre], [descripcion]) VALUES (2, N'Dueño', NULL)
INSERT [dbo].[Roles] ([idRol], [nombre], [descripcion]) VALUES (4, N'Encargado Difusion', NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  Table [dbo].[Estados]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estados](
	[idEstado] [int] IDENTITY(1,1) NOT NULL,
	[nombreEstado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Estados] ON
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (1, N'Con dueño')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (2, N'Hallada')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (3, N'Perdida')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (4, N'En adopcion')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (5, N'Adoptada')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (6, N'Fallecida')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (7, N'Borrada')
SET IDENTITY_INSERT [dbo].[Estados] OFF
/****** Object:  Table [dbo].[Especies]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Especies](
	[idEspecie] [int] IDENTITY(1,1) NOT NULL,
	[nombreEspecie] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Especies] PRIMARY KEY CLUSTERED 
(
	[idEspecie] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Especies] ON
INSERT [dbo].[Especies] ([idEspecie], [nombreEspecie]) VALUES (1, N'Perro')
INSERT [dbo].[Especies] ([idEspecie], [nombreEspecie]) VALUES (2, N'Gato')
SET IDENTITY_INSERT [dbo].[Especies] OFF
/****** Object:  Table [dbo].[Edades]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Edades](
	[idEdad] [int] IDENTITY(1,1) NOT NULL,
	[nombreEdad] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Edades] PRIMARY KEY CLUSTERED 
(
	[idEdad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Edades] ON
INSERT [dbo].[Edades] ([idEdad], [nombreEdad], [descripcion]) VALUES (1, N'Cachorro', N'0 a 2 Años')
INSERT [dbo].[Edades] ([idEdad], [nombreEdad], [descripcion]) VALUES (2, N'Adulto', N'2 a 8 Años')
INSERT [dbo].[Edades] ([idEdad], [nombreEdad], [descripcion]) VALUES (3, N'Senior', N'Mas de 8 Años')
SET IDENTITY_INSERT [dbo].[Edades] OFF
/****** Object:  Table [dbo].[CuidadosEspeciales]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuidadosEspeciales](
	[idCuidadoEspecial] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](500) NULL,
 CONSTRAINT [PK_CuidadosEspeciales] PRIMARY KEY CLUSTERED 
(
	[idCuidadoEspecial] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CuidadosEspeciales] ON
INSERT [dbo].[CuidadosEspeciales] ([idCuidadoEspecial], [descripcion]) VALUES (1, N'Los perros pequeños necesitan cortes de uñas más frecuentes. Tienen una boca más delicada. Deben ser cuidados del frio y calor extremo. Necesitan alimentos más energéticos y con mayor frecuencia. Los problemas de corazón son frecuente, aprender a tomar el pulso del can en casa o vigilar el jadeo excesivo del perro, ayudan a prevenir los problemas cardiacos ')
INSERT [dbo].[CuidadosEspeciales] ([idCuidadoEspecial], [descripcion]) VALUES (2, N'Los perros grandes no pueden vivir en departamentos o casas pequeñas, necesitan de espacios, jardines o parques amplios para poder crecer sanos y fuertes. Consumen gran cantidad de alimento. Si su pelo es largo, el cuidado del mismo puede tornarse costoso y difícil. De pequeños son muy torpes, sobre todo si hay niños en la casa; pero de adultos, son excelentes compañeros. Necesitan de compañía y ejercicio constante.')
INSERT [dbo].[CuidadosEspeciales] ([idCuidadoEspecial], [descripcion]) VALUES (3, N'Los perros medianos son animales capaces de adaptarse a cualquier ambiente, y en muchos casos, con los cuidados apropiados hasta pueden mantenerse en departamentos, pero es importante que se mantenga un régimen riguroso de paseos y actividades que puedan realizar, para que jueguen, corran y hagan todo tipo de ejercicios físicos y así no se sientan atrapados en el hogar.')
INSERT [dbo].[CuidadosEspeciales] ([idCuidadoEspecial], [descripcion]) VALUES (4, N'Para el bienestar del gato se debe mantener la bandeja sanitaria limpia. Tener un soporte o un tronco (pequeño) para el afilado de uñas. Maceta con hierba. Realizar cepillado. Cepillar si tiene pelo largo. Mantener siempre el agua fresca. El comedero siempre limpio. Llevar el plan sanitario al día (Vacunas y antiparasitarios)')
SET IDENTITY_INSERT [dbo].[CuidadosEspeciales] OFF
/****** Object:  Table [dbo].[Colores]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Colores](
	[idColor] [int] IDENTITY(1,1) NOT NULL,
	[nombreColor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Colores] PRIMARY KEY CLUSTERED 
(
	[idColor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Colores] ON
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (1, N'Negro')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (2, N'Rojo')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (3, N'Azul')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (4, N'Blanco')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (5, N'Marron')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (6, N'Beige')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (7, N'Crema')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (8, N'Gris')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (9, N'Albaricoque')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (10, N'Bicolor')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (11, N'Tricolor')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (12, N'Atigrado')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (13, N'Arlequin')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (14, N'Moteado')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (15, N'Dorado')
INSERT [dbo].[Colores] ([idColor], [nombreColor]) VALUES (16, N'Plateado')
SET IDENTITY_INSERT [dbo].[Colores] OFF
/****** Object:  Table [dbo].[CategoriaRazas]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoriaRazas](
	[idCategoriaRazas] [int] IDENTITY(1,1) NOT NULL,
	[nombreCategoriaRaza] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CategoriaRazas] PRIMARY KEY CLUSTERED 
(
	[idCategoriaRazas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CategoriaRazas] ON
INSERT [dbo].[CategoriaRazas] ([idCategoriaRazas], [nombreCategoriaRaza]) VALUES (1, N'Compañía')
INSERT [dbo].[CategoriaRazas] ([idCategoriaRazas], [nombreCategoriaRaza]) VALUES (2, N'Potencialmente Peligroso')
INSERT [dbo].[CategoriaRazas] ([idCategoriaRazas], [nombreCategoriaRaza]) VALUES (3, N'Caza')
INSERT [dbo].[CategoriaRazas] ([idCategoriaRazas], [nombreCategoriaRaza]) VALUES (4, N'Guardián')
INSERT [dbo].[CategoriaRazas] ([idCategoriaRazas], [nombreCategoriaRaza]) VALUES (5, N'Deporte')
INSERT [dbo].[CategoriaRazas] ([idCategoriaRazas], [nombreCategoriaRaza]) VALUES (6, N'Trabajo')
INSERT [dbo].[CategoriaRazas] ([idCategoriaRazas], [nombreCategoriaRaza]) VALUES (7, N'Pastor')
SET IDENTITY_INSERT [dbo].[CategoriaRazas] OFF
/****** Object:  Table [dbo].[CaracteresMascota]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaracteresMascota](
	[idCaracter] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Caracteres] PRIMARY KEY CLUSTERED 
(
	[idCaracter] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CaracteresMascota] ON
INSERT [dbo].[CaracteresMascota] ([idCaracter], [descripcion]) VALUES (1, N'Malo                                              ')
INSERT [dbo].[CaracteresMascota] ([idCaracter], [descripcion]) VALUES (2, N'Regular                                           ')
INSERT [dbo].[CaracteresMascota] ([idCaracter], [descripcion]) VALUES (3, N'Bueno                                             ')
SET IDENTITY_INSERT [dbo].[CaracteresMascota] OFF
/****** Object:  Table [dbo].[Localidades]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[idLocalidad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[idLocalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[user] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[user] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Usuarios] ([user], [password]) VALUES (N'rob', N'12')
INSERT [dbo].[Usuarios] ([user], [password]) VALUES (N'RobS', N'a')
/****** Object:  Table [dbo].[TipoDocumentos]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumentos](
	[idTipoDocumento] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoDocumentos] PRIMARY KEY CLUSTERED 
(
	[idTipoDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TipoDocumentos] ON
INSERT [dbo].[TipoDocumentos] ([idTipoDocumento], [nombre]) VALUES (1, N'DNI')
INSERT [dbo].[TipoDocumentos] ([idTipoDocumento], [nombre]) VALUES (2, N'Pasaporte')
SET IDENTITY_INSERT [dbo].[TipoDocumentos] OFF
/****** Object:  Table [dbo].[Sesiones]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesiones](
	[idSesion] [int] IDENTITY(1,1) NOT NULL,
	[fechaHoraInicio] [datetime] NULL,
	[fechaHoraFin] [datetime] NULL,
	[user] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sesiones] PRIMARY KEY CLUSTERED 
(
	[idSesion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesXUsuario]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesXUsuario](
	[user] [nvarchar](50) NOT NULL,
	[idRol] [int] NOT NULL,
	[test] [nchar](10) NULL,
 CONSTRAINT [PK_RolesXUsuario] PRIMARY KEY CLUSTERED 
(
	[user] ASC,
	[idRol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[RolesXUsuario] ([user], [idRol], [test]) VALUES (N'rob', 2, NULL)
INSERT [dbo].[RolesXUsuario] ([user], [idRol], [test]) VALUES (N'RobS', 2, NULL)
/****** Object:  Table [dbo].[PermisosXRoles]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PermisosXRoles](
	[idRol] [int] NOT NULL,
	[idPermiso] [int] NOT NULL,
	[pantalla] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PermisosXRoles] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC,
	[idPermiso] ASC,
	[pantalla] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[PermisosXRoles] ([idRol], [idPermiso], [pantalla]) VALUES (1, 1, N'AsignarPermisos.aspx')
INSERT [dbo].[PermisosXRoles] ([idRol], [idPermiso], [pantalla]) VALUES (1, 1, N'ConsultarUsuario.aspx')
INSERT [dbo].[PermisosXRoles] ([idRol], [idPermiso], [pantalla]) VALUES (1, 1, N'RegistrarUsuario.aspx')
/****** Object:  Table [dbo].[Barrios]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barrios](
	[idBarrio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[idLocalidad] [int] NULL,
 CONSTRAINT [PK_Barrios] PRIMARY KEY CLUSTERED 
(
	[idBarrio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Razas]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Razas](
	[idRaza] [int] IDENTITY(1,1) NOT NULL,
	[idEspecie] [int] NOT NULL,
	[nombreRaza] [varchar](50) NOT NULL,
	[idCategoriaRaza] [int] NULL,
	[idCuidadoEspecial] [int] NULL,
	[PesoRaza] [varchar](50) NULL,
 CONSTRAINT [PK_Razas] PRIMARY KEY CLUSTERED 
(
	[idRaza] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Razas] ON
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (1, 2, N'Abisinio', 1, 4, N'4 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (2, 2, N'Bombay', 1, 4, N'2 - 5 kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (3, 2, N'Korat', 1, 4, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (4, 1, N'Akita Inu', 2, 2, N'30 - 55 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (5, 1, N'American Pit Bull Terrier', 2, 3, N'15 - 30 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (7, 1, N'Pastor Belga', 7, 3, N'25 - 45 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (8, 1, N'Affenpinscher', 1, 1, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (9, 1, N'Airedale Terrier', 1, 3, N'18 - 28 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (11, 1, N'Alaskan Malamute', 6, 2, N'30 - 50 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (12, 1, N'Pastor Inglés', 7, 2, N'25 - 40 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (13, 1, N'American Staffordshire Terrier', 2, 3, N'20 - 40 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (14, 1, N'Basset Hound', 3, 3, N'20 - 30 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (15, 1, N'Beagle', 3, 3, N'8 - 16 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (16, 1, N'Bichon Frisé', 1, 1, N'3 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (17, 1, N'Bichón Maltés', 1, 1, N'3 - 4 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (20, 1, N'Bloodhound', 3, 3, N'35 - 50 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (21, 1, N'Border Collie', 7, 3, N'12 - 22 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (22, 1, N'Boston Terrier', 1, 1, N'6 - 12 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (23, 1, N'Bóxer', 6, 3, N'25 - 33 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (24, 1, N'Braco Alemán', 3, 3, N'20 - 30 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (25, 1, N'Vizsla', 3, 3, N'20 - 30 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (27, 1, N'Braco Italiano', 3, 3, N'25 - 40 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (28, 1, N'Weimaraner', 3, 3, N'25 - 40 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (29, 1, N'Bulldog Americano', 4, 2, N'30 - 55 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (30, 1, N'Bulldog Francés', 1, 1, N'8 -14 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (31, 1, N'Bulldog Inglés', 4, 3, N'20 - 30 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (32, 1, N'Bullmastiff', 2, 2, N'40 - 60 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (33, 1, N'Caniche Gigante', 3, 3, N'16 - 22 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (34, 1, N'Caniche Mediano', 3, 1, N'10 - 14 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (35, 1, N'Caniche Miniatura', 1, 1, N'4 - 7 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (36, 1, N'Caniche Toy', 1, 1, N'2 - 4 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (39, 1, N'Chihuahueño', 1, 1, N'1,5 - 3 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (40, 1, N'Crestado Chino', 1, 1, N'5 - 7 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (41, 1, N'Chow Chow', 4, 3, N'20 - 32 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (42, 1, N'Cocker Spaniel Americano', 3, 1, N'8 - 14 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (43, 1, N'Cocker Spaniel Inglés', 3, 1, N'10 - 16 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (44, 1, N'Collie', 7, 3, N'19 - 30 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (45, 1, N'Collie Barbudo', 7, 3, N'18 - 28 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (46, 1, N'Dachshund', 1, 1, N'7 - 9 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (47, 1, N'Dálmata', 4, 3, N'15 - 32 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (51, 1, N'Dóberman', 2, 2, N'30 - 45 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (52, 1, N'Dogo Argentino', 2, 2, N'36 - 45 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (53, 1, N'Dogo de Burdeos', 2, 2, N'45 - 60 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (54, 1, N'Papillón', 1, 1, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (55, 1, N'Fox Terrier', 1, 1, N'7 - 10 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (56, 1, N'Galgo', 5, 3, N'25 - 35 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (57, 1, N'Golden Retriever', 5, 2, N'25 - 38 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (59, 1, N'Gran danés', 4, 2, N'60 - 100 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (60, 1, N'Grifón belga', 1, 1, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (61, 1, N'Husky Siberiano', 6, 3, N'16 - 28 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (62, 1, N'Jack Russell Terrier', 3, 1, N'5 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (63, 1, N'Parson Russell Terrier', 3, 1, N'6 - 10 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (65, 1, N'Keeshond', 4, 3, N'25 - 32 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (66, 1, N'Komondor', 7, 2, N'40 - 60 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (67, 1, N'Kuvasz', 7, 2, N'35 - 55 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (68, 1, N'Labrador Retriever', 5, 2, N'25 - 38 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (69, 1, N'Galgo Afgano', 5, 3, N'26 - 34 kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (70, 1, N'Lobo de Saarloos', 7, 3, N'25 - 35 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (71, 1, N'Lhasa Apso', 1, 1, N'5 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (72, 1, N'Mastín del Pirineo', 6, 2, N'60 - 90 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (73, 1, N'Mastín Español', 4, 2, N'60 - 100 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (74, 1, N'Mastín Inglés', 4, 2, N'60 - 110 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (75, 1, N'Mastín Napolitano', 2, 2, N'60 - 80 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (76, 1, N'Mastín Tibetano', 4, 2, N'40 - 75 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (77, 1, N'Pastor Alemán', 7, 2, N'25 - 40 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (79, 1, N'Pastor Blanco Suizo', 7, 2, N'25 - 40 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (80, 1, N'Pastor de los Pirineos', 7, 1, N'8 - 15 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (81, 1, N'Pekinés', 1, 1, N'3 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (82, 1, N'Pointer Inglés', 3, 3, N'20 - 30 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (83, 1, N'Gran Pirineo', 6, 2, N'50 - 80 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (84, 1, N'Fila Brasileño', 2, 2, N'55 - 80 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (85, 1, N'Sheltie', 6, 1, N'8 - 15 Kg ')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (86, 1, N'Pinscher Alemán', 4, 3, N'15 - 20 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (87, 1, N'Pinscher Miniatura', 1, 1, N'4 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (88, 1, N'Pomerania', 1, 1, N'2 - 4 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (89, 1, N'Presa Canario', 2, 2, N'40 -60 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (90, 1, N'Pug', 1, 1, N'6 - 10 kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (91, 1, N'Puli', 7, 1, N'10 - 15 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (92, 1, N'Rottweiler', 2, 2, N'40 - 55 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (93, 1, N'Saluki', 4, 3, N'22 - 30 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (94, 1, N'Samoyedo', 6, 3, N'20 - 35 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (95, 1, N'San Bernardo', 6, 2, N'55 - 90 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (96, 1, N'Schnauzer Estándar', 6, 3, N'14 - 20 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (97, 1, N'Schnauzer Gigante', 6, 2, N'32 - 45 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (98, 1, N'Schnauzer Miniatura', 1, 1, N'4 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (99, 1, N'Setter Inglés', 5, 3, N'25 - 30 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (100, 1, N'Setter Irlandés', 5, 3, N'25 - 32 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (101, 1, N'Shar Pei', 4, 3, N'18 - 30 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (102, 1, N'Shiba Inu', 6, 1, N'7 - 12 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (103, 1, N'Shih Tzu', 1, 1, N'5 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (104, 1, N'Sussex Spaniel', 3, 3, N'15 - 22 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (105, 1, N'Terranova', 6, 2, N'50 - 70 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (106, 1, N'Silky Terrier', 1, 1, N'3 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (107, 1, N'Terrier Escocés', 3, 1, N'8 - 12 kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (108, 1, N'Terrier Galés', 3, 1, N'8 - 12 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (109, 1, N'Terrier Irlandés', 3, 1, N'8 - 12 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (110, 1, N'Yorkshire Terrier', 1, 1, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (111, 1, N'Whippet', 3, 3, N'10 - 15 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (112, 1, N'West Highland White Terrier', 1, 1, N'6 - 10 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (113, 1, N'Tosa Inu', 2, 2, N'60 - 100 Kg')
GO
print 'Processed 100 total records'
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (114, 1, N'Staffordshire Bull Terrier', 2, 3, N'12 - 20 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (115, 1, N'Mestizo', 6, NULL, N'Desconocido')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (116, 2, N'American Curl', 1, 4, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (117, 2, N'American Shorthaired', 1, 4, N'5 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (118, 2, N'Azul Ruso', 1, 4, N'2 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (120, 2, N'American Wirehair', 1, 4, N'3 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (121, 2, N'Angora Turco', 1, 4, N'2 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (122, 2, N'Balinés', 1, 4, N'2 - 5 kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (123, 2, N'Bengala', 1, 4, N'5 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (124, 2, N'Sagrado de Birmania', 1, 4, N'4 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (125, 2, N'Bobtail Japonés', 1, 4, N'2 - 4 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (126, 2, N'Bosque de Noruega', 1, 4, N'3 - 9 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (127, 2, N'British Shorthair', 1, 4, N'4 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (128, 2, N'Burmés', 1, 4, N'4 - 7 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (129, 2, N'Burmilla', 1, 4, N'3 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (130, 2, N'California Spangled', 1, 4, N'4 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (131, 2, N'Cartujo', 1, 4, N'3 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (132, 2, N'Cornix Rex', 1, 4, N'2 - 4 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (133, 2, N'Ceilán', 1, 4, N'3 - 5 Kh')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (134, 2, N'Cymric', 1, 4, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (135, 2, N'Devon Rex', 1, 4, N'2 - 4 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (136, 2, N'Mau Egipcio ', 1, 4, N'2 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (137, 2, N'European Shorthaired', 1, 4, N'3 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (138, 2, N'Exotico', 1, 4, N'3 - 6 kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (139, 2, N'Highland Fold', 1, 4, N'2 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (140, 2, N'German Rex', 1, 4, N'3 - 6 kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (141, 2, N'Havana ', 1, 4, N'3 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (142, 2, N'Himalayo', 1, 4, N'4 - 7 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (143, 2, N'Javanés', 1, 4, N'3 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (144, 2, N'Korat', 1, 4, N'2 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (145, 2, N'Maine Coon', 1, 4, N'6 - 11 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (147, 2, N'Manx', 1, 4, N'4 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (148, 2, N'Munchkin', 1, 4, N'3 - 6 kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (149, 2, N'Ocicat', 1, 4, N'2 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (150, 2, N'Oriental Shorthair', 1, 4, N'2 - 4 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (151, 2, N'Oriental Longhair', 1, 4, N'2 - 4 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (152, 2, N'Persa', 1, 4, N'3 - 7 kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (153, 2, N'Peterbald', 1, 4, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (154, 2, N'Pixie Bob', 1, 4, N'4 - 10 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (155, 2, N'Ragdoll', 1, 4, N'4 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (156, 2, N'Selkirk Rex', 1, 4, N'4 - 7 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (158, 2, N'Scottish Fold', 1, 4, N'3 - 6 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (159, 2, N'Serengeti', 1, 4, N'4 - 7 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (160, 2, N'Seychellois', 1, 4, N'4 - 7 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (161, 2, N'Siamés', 1, 4, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (162, 2, N'Siberiano', 1, 4, N'4 - 9 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (163, 2, N'Snowshoe', 1, 4, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (164, 2, N'Sphynx', 1, 4, N'3 - 7 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (165, 2, N'Singapura', 1, 4, N'2 - 4 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (166, 2, N'Somali', 1, 4, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (167, 2, N'Tonkinés', 1, 4, N'3 - 5 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (168, 2, N'Van Turco', 1, 4, N'4 - 8 Kg')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (169, 2, N'Mestizo', 1, NULL, N'Desconocido')
INSERT [dbo].[Razas] ([idRaza], [idEspecie], [nombreRaza], [idCategoriaRaza], [idCuidadoEspecial], [PesoRaza]) VALUES (170, 2, N'Toyger', 1, 4, N'4 - 9 Kg')
SET IDENTITY_INSERT [dbo].[Razas] OFF
/****** Object:  Table [dbo].[Personas]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[idTipoDocumento] [int] NULL,
	[nroDocumento] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[domicilio] [nvarchar](50) NULL,
	[idBarrio] [int] NULL,
	[telefonoFijo] [nvarchar](50) NULL,
	[telefonoCelular] [nvarchar](50) NULL,
	[fechaNacimiento] [date] NULL,
	[user] [nvarchar](50) NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [Unique_Email_Personas] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Personas] ON
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [idTipoDocumento], [nroDocumento], [email], [domicilio], [idBarrio], [telefonoFijo], [telefonoCelular], [fechaNacimiento], [user]) VALUES (4, N'Robertita', N'Sarasa', 1, N'123', N'rob@mail.com', NULL, NULL, NULL, NULL, NULL, N'rob')
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [idTipoDocumento], [nroDocumento], [email], [domicilio], [idBarrio], [telefonoFijo], [telefonoCelular], [fechaNacimiento], [user]) VALUES (12, N'Robertita', N'Sarasa', 1, N'34131314', N'robs@mail.com', NULL, NULL, NULL, NULL, NULL, N'RobS')
SET IDENTITY_INSERT [dbo].[Personas] OFF
/****** Object:  Table [dbo].[Voluntarios]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voluntarios](
	[idVoluntario] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NOT NULL,
 CONSTRAINT [PK_Voluntarios] PRIMARY KEY CLUSTERED 
(
	[idVoluntario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Duenios]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duenios](
	[idDuenio] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NULL,
 CONSTRAINT [PK_Duenios] PRIMARY KEY CLUSTERED 
(
	[idDuenio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Duenios] ON
INSERT [dbo].[Duenios] ([idDuenio], [idPersona]) VALUES (5, 12)
SET IDENTITY_INSERT [dbo].[Duenios] OFF
/****** Object:  Table [dbo].[Mascotas]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mascotas](
	[idMascota] [int] IDENTITY(1,1) NOT NULL,
	[nombreMascota] [varchar](50) NULL,
	[idEstado] [int] NOT NULL,
	[idEspecie] [int] NOT NULL,
	[idEdad] [int] NOT NULL,
	[idRaza] [int] NOT NULL,
	[idColor] [int] NOT NULL,
	[tratoAnimales] [varchar](200) NULL,
	[tratoNinios] [varchar](200) NULL,
	[observaciones] [varchar](500) NULL,
	[alimentacionEspecial] [varchar](200) NULL,
	[fechaNacimiento] [date] NULL,
	[sexo] [varchar](50) NOT NULL,
	[idDuenio] [int] NULL,
	[idCaracter] [int] NULL,
	[imagen] [varbinary](max) NULL,
 CONSTRAINT [PK_Mascotas] PRIMARY KEY CLUSTERED 
(
	[idMascota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Mascotas] ON
INSERT [dbo].[Mascotas] ([idMascota], [nombreMascota], [idEstado], [idEspecie], [idEdad], [idRaza], [idColor], [tratoAnimales], [tratoNinios], [observaciones], [alimentacionEspecial], [fechaNacimiento], [sexo], [idDuenio], [idCaracter], [imagen]) VALUES (1, N'Pepo', 1, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, N'Hembra', NULL, 1, NULL)
INSERT [dbo].[Mascotas] ([idMascota], [nombreMascota], [idEstado], [idEspecie], [idEdad], [idRaza], [idColor], [tratoAnimales], [tratoNinios], [observaciones], [alimentacionEspecial], [fechaNacimiento], [sexo], [idDuenio], [idCaracter], [imagen]) VALUES (2, N'sarasa', 1, 1, 1, 4, 1, NULL, NULL, NULL, NULL, NULL, N'Hembra', NULL, 1, 0xFFD8FFE000104A46494600010100000100010000FFDB00840009060714121215141214141415171514141415141415141415141414161614151414181C2820181D251E151421312125292B2E2E2E171F3338332C37282D2E2B010A0A0A0E0D0E1A10101A2C1C1C242C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2CFFC000110800C2010303012200021101031101FFC4001C0000010501010100000000000000000000030002040506010708FFC4003B1000010302020805030303020701000000010002110321043105124151617181910622A1B1F013C1D13242E10752F12392627282A2B2D2E214FFC400190100030101010000000000000000000000000102030405FFC40023110002020202030100030100000000000000010211031221310441511322617152FFDA000C03010002110311003F00CC6ADD15AC4A2E9ED0BA4F1589AD456B52684E0824E86A786A4D6A20080381A9C02E809C1A811C0D4A13E1761340075573511B552D55A080EAA45A8BAA96AA000EAA5AA8DAAB9AA8005AABBAA89AABBAA958E80162639AA4EAA696A2C08AE6A1B9AA539A985AA9302239884E6A96E082E6AAB1119C131C11DC10C845800210C847213084808EE098E6A905A84E093023B9A86E0A438213824004B524F49056C6936A7B5336F5446AC90DB1E11004C6A235021ED0880263511A8159D013A1209ED0811C013A17404E84C066AAE108CCA44980093B80BABBD05E19A95DD76B9ACDA488C8DE0EFE0426DD1518393A467F554FD1DA0EBD79FA54CB80CCD80EE6DD17A9607C3D87A40453639C046BB9AD2E31B4DB3E2AD008593CBF0ED8787FF4CF3CC17F4FDEE6CD4A829BAFE50D0E8378920C6E57343C0587021C5EE3BE4039CEEE8B5692CF76CE85E3E35E8CAD5F01618E46A3728F303194E62FB73DE8587FE9FD01FADEF7766EC1F79EEB5E9236657E18FE196C7781B0EF035269C6EB836B0337CFDCAC9E96F06D7A776335DB30354EB3B848D9B3D782F55493536889F8D097F47836270CE6121C082266C7666A2B82F78C7E8EA759A5B51A083C04F358BC4FF4EA49D5AC209FDCD3206F307CC7B7D96B1CABD9CB3F164BAE4F367042705B2D35E0F7D230D05C2FABB490337BCE4D1C1656AE188CC473B2D949339A506BB21382110A454082E0AAC80442616A2A690936005CD42705248427352B1D1188437354973509C12D8288FAAB88B0925B0517C734F6A6EADCF34F014AA063DA88D436A23420411A88D436844684AC078446A6B02D6786BC27FF00E801EF7C53DA1A3CC78039297245C31B93A45061B06F7B835AD2E2720013ECB75A17C16C003AB79A47E83220F3047B2D3E0347D3A2D0DA6D0D1DC9E64DCA94B37919E862F1231E65C95B87D0587644526DB29F37237DBC5592062F14DA6DD6790071207BA8982D28DAA4EAC40CF6C70277E56594B22BA3A9452E95164B887F512A8F809390C2252A353AF23A485DFAEA165B1D1252941FACA3BB1324F6EE094E59290226CAEA882B71D9745A55A511C9614165294D71E0AA7C43887D366BB6045DC65C1DD2073BF056E54845CAA5D33E1AA35C1F2B58E3FB9AD0093C577C35A64625867F536C78F1572538CED5A14A09F0CF13D3FE18AB87BBF2D90091FEECA566AA3617D1B5A8B5E21C0387100FBAF2CF1BF84DD489A94C4D3278EB37838FDD6F1CA79F9BC7D795D18021348477B10F5553C872D0221308462D4C2166E63480B9A82F0A49084E0A7F41D11E124F21247E8145E96DCA706A2965D38352FD44D720DAD446B53C3510312FD45435AD45A5489303329D4D9F02F4BF07F8769D3A6DAAF64D4371AF04B06C81B0FAA4B259AE2C4E6E915FE11F09C455AE088FD2CDFC5DF85B8240091728756B02605CFA0E2A673A3D3C5894152250A886FAFBBE7CFB2055ADAA0EADCE598CCECFCEE51E4813330D99DE7AF3F90B2737D1A5195FEA0E942D0D0DBEAC99CCEB4EADB75E72CE0DF612F83C16D21AC4871DAE373C01991D65657C69589AB4D82E4BBCC22410C926DB7CC4F72B59E1D90C0203784C13D1650E5D8E5F0D552ABBC7DBD112A626397B730AB46283443811CFDC140AB8D1983DF22ADCE9124AAF8C1B2D7F7DBF38A651C4EC3B67A5F2F5F555956A02641BF69E1CD45757893BB2ED07B8858ECEECB34E6D91FE24287F5A019CA5C7FDB007B288CC5C58DF6F3191F9C50B135C16C4E707BDCFBAD9B4D10992E9E2EF1C7BEEF6526862F6CC0FBACD8AE4DC6D313C04DD4BC33E60CFFCA386F33659C5B29B35547100843C6C169903A8047AD953D1AC5A41249E961D76A9AFABACDCE4761DC885D319590CC6686C7FD0C591273332206A98D832B91BF62F4A63E403BC2F21F11D314B154DE1E002754B6730EDBE513237903D57A5787B15AF445E4B638588FF0023A153075268AF44CD6D4307239499F7521CD0E04100822083911B957D6C5832D3008317DFB3B885DC0E2F618CED1F2EAE2E9D08C1F8FBC2629FFAD41A753F7B45C34CE711202F3F7317D0F51E087074110419B888B83F85E17A629B05476A0B498B447AA9C93D4E1CF8D2768A87350DCD525CD432D58BCC6144770427354A73509CD52F30E88A5A92316A497EC1A9A12DBA735A9E5B74F0D51FB09C79181A881ABA1A881AA5E516A3F0A61C0F15EA1A331A7E8309898886C58718B02BCC1816C742E2670E5BB45C72CADD3D95E3CB7674F8EEA45D3F490703B87967613B637FB73BA0D3C5B8998DBBF767D95137117DD161B00399B7CB1DE53C630FED9B0038E73D361E16E4AB6B3D02E9B5FDEE79901AD036666DC94AC755D5A6EE8378898B850300FB81B8CF50241FFC8F644D24F8A6F246507D7FF954BA11E6FA6097E300DCD1041DE60C0833FA776F5BDD12DD560B73B7BC01ECBCFDCF0FC554204F980BC6C6B444E79ADB68D122036FD7ECDB754A0C522756C44FDA1A4FB851C8E9CDA44F3170AC598481275B91CBB42A7D298A0C9DD7B839748B27255D897231C24C08E1723A8DC84FAA0000DA47A8B11EEAB6B69001C0837CC4190641FC829D88C46B491C23EE785A143A289CDAC6C33CC67D0FB7AA155AA7B0BF316FB15170EFDFBD3AB4831B37EC2215227D8FA752F07788E5F0844A38F325D3220401BA3E7454D89C5188FCDC7CF659DC569234C38EB1190926605E637669AE0747A9E02BB6AE4403D27FDC5589A25A2E09F6E1915E6DE1DD21376B1EF8DAD831CEFEAB7DA2F4C086870371B6C791F90B5835EC992A313FD40A4EF2BD8498735D067619B596CBC15889D600FEC07FEE977BAA2F1A526B98E820883024F58BFE11BFA7B8B0ED483FB238CC5E7A82A7AC834FF89A5D28EF31236C72F2CFCFF2AAD98C874EC26E2722058F507D0EF56BA5DA637199078EA93EB0EFF70591AD8888ED97031F8EA1692EC9B35DA23165DAF37107A816239FCDCBCAF4BB3FD57C19B9BEFE246C3BD6C70B8C346839D693683B45B5BD01ECB17893ACE277995C7E4E55491CD9B974427350DCD528B50CB571FE86544673505C14B73505CD4B761446D549161711B051A28BA706AEC27B5AB3FD06E3C89AD4F0D5D6B538052F20B538029FA3B166999CF250C353DA14ACAD3B1A45CE369D839BCC8B58E67EFE8A151AB60264DCFA993E83B2761311060E4441F9C915F860DF33727031C241F9D177E2CCA676E3C9B2FECD1E8B6DA4EEF717EF03D547F1256D563813004B89E0DD53EE5CA4E06C26FBC93B85BDA7BACC78C31DAEC701B4474247FEA574B97F134329A05DAD524E6E717773369E6BD27475568001CF898F4D8BCD34653D5337E8616AF09317363DF971530748522F71FA5B58B994EE45CB5B197F739C4401C4AF35F1378A69D325BF569B9D7FF4E94D58331E62006833196F4BFA81A2ABEA1349EF149D06A31B2D6B88100BE3F50D9175E5B5A9D504D9FE610EBC8709061CE06E2C0C1DC174456DD8236BA2F4F8A80E4355D91B66222FBEEB63A36A17B41F5DFB32ECBCAF44E05D51D49A1A41882608CCB8DB80B2F68F0CE897536341BB9D7CBF48D992CA505748BF44BC0616D31F0E7EA54AAB8780797B03FCF757985D130254B3A3AD1D8F45B4713A326CF3FC5606C731F2E6CBCBBC6F4AAB0B9AEF2B641E32328E19775F446334312DF2C058EF187837EB52111ACDB1373AC266F7E63AA3471E46A47818C596BC3A96B52CBF43C839093AC238F7DABD2BC11E20C6621C1955FAF4DA4BDAF708A8D1103CC23587033BD57B7C1AC6BAED1B330244F3175B5D09A3D941A0345CE676BB8CAA94931339A7310E2D320E59807ECAB3C158D752AB7B80ED61C2E27D24F456DA629CB48F6907DE103C1DA2BEA3C8D85AEBEE3163D0C1E8B9E49EC814A91E9F8B6FD5A3233D513CC09FC2C2BA8975433600924EE5A3F0AE3CF9A93FF50F291C59E5B740D545E267FD37BA9B7AF2331E9AAAB3644A1B1327AAB2A34C6335CC0B344B40E44FDA3B2A970525C10CB579129B93B6723E48EE0865AA4B9A84F0A6C288D5020B8290F080E0A931D012124E85D4EC7468C36E88D0BBAA88D6AC9A29AE468088D6223588A1A950A808A69C188DAA9C18B36835001AA6E12ADE0E47D388EC87AABAC6DD38B71768A4A9D9658EC49653038477B2A3D238727F50BEEDDB87CDEB7FA2747B4B439F4C8700235AF96446E59ED2F861AC7AAF6746A2A4FD9D3B5A30E59AA723F39AD2E0D9B6D96C1EF7BA895B072ECA6F3F254DC3883BB9CA220CE62376C3C63DB35418BD06C264301248B8B09D804E656ADF4A4667BC0282DC28DA2009278F59F5856AD0220E81F0FB04388CB2E3D78ADEE8EC381B2FC7E5954E8D60746C032CD5DB3141B2328F65BE2EED849939AC4E34D5556D314D8DD773C06AA7C478E680FD275BD96FB091ACD551F1587916859FC2F8C68BC89312AEB098CD7CB2D877F44ED32599BD29A2C024B61B3983604F1F9F8558DA7B875BCC6E9EF92D669BA6434B8098CF88543AA3BEC23CC3ACC958C95306CA1D2B200FF1DA0AB6F0561209233830A1690A12E1C76C47B2D1686A1F4691738EAC8B11751D3B645F05054C41A78A2E71D5BC13B08D92020788B18DAF575DA7F681710091B41FF192163EEF264BAF99CD43217913CD269C5F5664E4EA88EF647CFBA1908CF4272C4904F084F08C42616AA45D119C101E14A7B505ED4E874478493C85C4530A35042235A86D28813A2E8284F6A1028B4CA4E22A08D4F0980A7859342142D0786745EB9D777E919712A2E82D13F59D26434667EC16DA9530D0034401905DDE1789B3DE5D1718D9D22D0B27A6A9413016B1CE59DD2C64AF4B3F28D4CBBCECDBBBE14DA4C33793CBEFB53B1D4A3F813FE1446624CDC775C8845ED1788B472331FCA4E76B6F3CB2B7050F0F52791DEADF096CB3F55AF624C3E0A9C0939EE0898FC586B6C24E5362546C4D7D56E66F37178E6A92BE3603A097E40DB25AC2E81B321E20D30DA952A49D465317D9ACF76C5947F89E936C20DF6DD0BC6F561CF832C7904EC322CB08B58D94AA8F47C278CA88700E00B66E0E5FC2F42F0BE9C26A7D30E2580075374E6C700403CAE3A2F9E29BA0CDBAE4BD4FFA7FA4096C902480D1B0068DC9BBB14AA8F76A759AF05B3323BAA4C4E0CB6C2E3E45D2D018D36198DE73563888D6396FCE0224ACCAF828E8D0D678DDF2C1682AD50DA71205AD22555D16EACB8C813691B784FE147D20F96D803BF565AE1C60DBD02E5CD9744D224A1C719713317FED007A12A15410A7D66B4ED8E63EE267B050AAB79770BC9ECCE445A85093AA3931A1268485098423EAA6962A48D9223B9882F629BAA81502BA1D10CB5711CD3491A8CB66BAEA431CA031EA435E8434893AC9ED72881E88D721A064C6BD1A85C80A131CAEFC3AC9A8200719C8E4A54369244B46D74461FE9D268EB9466A6AE043ACF85EF24A11491AAE102C4550A834856066013C45FD959D7AE0DA3BE4AB718E3197B2E7C8EC651621C098DBC552E2EC76FCE2ADB1D500BEE55956A878B9BF381F335CEC0580C5C18D9929C7490A751A1F60EB0713693908FF002A86ABA3646EDA00DE8CCAEDA8354E62C0EDE5C154644D1ADC5563AB1BB61C8EE597C7E2EC41B6F8E251A86912D1A953934CCC8E24ED54DA76B91300C6E1F75BA9A268C4F8ADE1D20C99369CD625ED82B61A6EA5B274F224CACE55248F2533CC857099A1168D2248B596F3C27880D0040D816530387AA607D391C6C7995ABD07A2EAC8966AF017EA894F913AA3D6BC335F5E26F19EE5A0C5B1CF21ADCDF9998B0D9ADB3EEB27A0A93A881F50DE018DA78722B75A19BADE639EC17303605777C18D5B195F04594C35B161BFD32595C6384FF691B8DA7EDCC7F2BD0B10D9695E79A6DE03CFBC45F885E7F9D1A698E4A8ABC554EEA0BEA2589ACA19AAB813E4CA43DE894C20B4A3532B4711C6214352D54E057095491AA435CC42753452E4D71569154472125D2927A851C6B0A334A92EA1748D0590C6B0292D086CA68B0860C4B69E0BC06A8351C2E6C382CAE8FA05CF00024923212BD330940536068D81757878EE5B7C252E4338A818C2148A95157E25A0EFEE47B2F427D1764675403331D6EAAF1F8A3FB44F42A4576119F493F2541AEF0D113D0FF165CB20297154DEE99EF397F2AB9F8483992499E11D15C56AC6E3766772AD734EB6B124F4B705343B2162A5C0F0FB665563AAC65B32F9B4A95A5AB123547EEB4F036FC28D55B1EDFCFA286842769030038070BC4E68F434931C035ED8D939AACD59F4F5F8532A982DE6A7943A4CB6AF80A6FF00D3AAEDDD540A9A1F876C828D4DA6F78B9163C8FCE6A5D0AAE162E3DFD55A6C96A83613438905D0D8DB90EDB6CAF30EF6D31FE9824EC7EC046E07A770AA1AD2624F0BEFF90AD304D191C8EE5B449A2761EA99D63249DAB6FE1FC4F960FE164F0D851B168F46D020794C1DD982B48269D81A1AD548612338B7F2BCEBC41882E24B809EC3A2DC622A96D326DCB62F3BD38E932238C10617379CF848997251621C82D289542105E6635C90D121A515AF51DA571CE5B4DD22D12BEB269AAA26BA41CA212B29130544D7D4515D5509D5574A65124D44942FAABA9D81A9DA9C80CA88C5600CE0722812A13899561A3689A8E0D68928516DD211ACF0868E001A845F64AD2547420E0680A6C0D1B026D472F671434824032B93C7A2AEC439DB2DC549AF5C0B2ACC5E384C5871294E808B8A67FC4EF60AA31448BEB4F1CBD94CAFBCBF9004CFE140C506C584F224FB9BAE765223B9F3CBBF541791F3EC82EAE05A3A45BF0826B913FE766DF5403226299716E7D0FE4FA2838F3DFE4FA42B4A8E06FB4E5CB7A87569C9E7F3F09342299EF22FC47F2A43E8C891CFF3EC8B530F36446D381F36E6A544AB20D4A8728BEFE23FC27D3AA7F3CFEC8EFA59F036F7FCA73695E785D3A024E0DD23E6CD9F382B3C3B41FE6156D0A506CA750AFF0000F757125975820E6E44C770B45A3ABEC70E456630D5FE4ABFD16E92256D1EC865DE9724509009E4754F75E77A46A8793620F1027BD97A5E926CE1DE227CB964BCBABB20AE2F3DB52426407840A8A4D60A3D45CB0489061E9A5E9AB814E4E782D747415D73D22106A153154338E7A139C9C4A0B8AD2C670BD2432524EC66C6984769851DB5115AF554263AA90B47E09C3CD42FD836ACD6A49002F43D034052A42D04892BA7C5C7B4EFE105C547A8189AC005DAB5FCAA9F135CEFF585E94B841676BD781B7B2A8C4D469CE7B5BD51F115605CCF0B7B2AEAF5F5B77585CD229103144E6C3EA07F2A1B71AE061CE3F9E7652DC4EF11C23DC2878B78C9A277C82B3712EC2E25C0F2CEDBF62835F68F9F250C62C36C32DD69093AA83717DF7D9B3EC9081C1073E5C2FEC9B52A5A4738F9D122E9708F965CA80116B6D8F9F39A280752ACD39FC9BFCE6B95CCF7FE07BA0B627383B0CC5B714E2365A37489E63720070E3F0A6EBFCF9C93699B41CF2EB74A9B1001D8FC8A2B197DD3911F39A05360BF0BA974DDB371FC2A4844FC250BC8242D368A7444DF8ACCD0AE00CFD55AE0316E395F9DBEEB48D264B66DB10ED6A0E02F68CE179D62E996CCDB995B4AEF70C33CC498CA335E798EC41BFF003F75CDE755A208B887A8CFA88188AC82C7AE2401E53989A18771EC9F4DA77149B45EAFAA3AF51AA1525ED3B8F651EA30EE3D94DA1A4C09284F467533B8F6437B0EE3DBE6E28B1B4FE014975C08495501A1A4548695D496C365AE86BD46CEF5BD7E4124977789D3327D80C49F2AA8C41CBE6C5D4974C8114FA49D6F9B954D771B5F72492E59766ABA3AF376F250F1B99E452490FA045662059BCDA3BE69B8416EBF92BA9291FA1CEDBCFEC9CF3EEEF70924A89605D99E5F647C3E612494FB1FA1836FFD3EE51F6F41EC924A8431A7CC79A5376F23EE92480255175D5EE07674F649257126469AB388C2BE09C87BAC0E965D4961E67AFF0008467B10B948AE24B897404B150EF3BB3397C27BA7B6ABBFB8F72924A5A4529CBE85A955D7B9CF79E2A254AAE1938EFCCA4928491729CAFB02710EFEE7773CD0DD5DDFDCEEE571245216F2FA0CD671CDC7B95C4925A506CFE9FFD9)
SET IDENTITY_INSERT [dbo].[Mascotas] OFF
/****** Object:  Table [dbo].[Perdidas]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perdidas](
	[idPerdida] [int] IDENTITY(1,1) NOT NULL,
	[idSesion] [int] NOT NULL,
	[idMascota] [int] NOT NULL,
	[FechaHoraPerdida] [datetime] NULL,
	[mapaPerdida] [varchar](250) NULL,
	[ubicacionPerdida] [varchar](500) NULL,
	[idBarrioPerdida] [int] NULL,
	[observaciones] [nchar](10) NULL,
 CONSTRAINT [PK_Perdidas] PRIMARY KEY CLUSTERED 
(
	[idPerdida] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Adopciones]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Adopciones](
	[idAdopcion] [int] IDENTITY(1,1) NOT NULL,
	[idMascota] [int] NOT NULL,
	[idDuenio] [int] NOT NULL,
	[idVoluntario] [int] NOT NULL,
	[fechaAdopcion] [date] NOT NULL,
	[observaciones] [varchar](500) NULL,
 CONSTRAINT [PK_Adopciones] PRIMARY KEY CLUSTERED 
(
	[idAdopcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hallazgos]    Script Date: 08/31/2014 02:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hallazgos](
	[idHallazgo] [int] IDENTITY(1,1) NOT NULL,
	[idSesion] [int] NOT NULL,
	[idMascota] [int] NOT NULL,
	[ubicacionHallazgo] [varchar](500) NULL,
	[fechaHoraHallazgo] [datetime] NOT NULL,
	[idBarrioHallazgo] [int] NULL,
	[observaciones] [varchar](500) NULL,
	[idPerdida] [int] NULL,
 CONSTRAINT [PK_Hallazgos] PRIMARY KEY CLUSTERED 
(
	[idHallazgo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Check [chk_Ninios_Mascota]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [chk_Ninios_Mascota] CHECK  (([tratoNinios]='Si' OR [tratoNinios]='No'))
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [chk_Ninios_Mascota]
GO
/****** Object:  Check [chk_Sexo_Mascota]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [chk_Sexo_Mascota] CHECK  (([sexo]='Macho' OR [sexo]='Hembra'))
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [chk_Sexo_Mascota]
GO
/****** Object:  Check [chk_tratoAnimales_Mascota]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [chk_tratoAnimales_Mascota] CHECK  (([tratoAnimales]='Si' OR [tratoAnimales]='No'))
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [chk_tratoAnimales_Mascota]
GO
/****** Object:  ForeignKey [FK_Adopciones_Duenios]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Adopciones]  WITH CHECK ADD  CONSTRAINT [FK_Adopciones_Duenios] FOREIGN KEY([idDuenio])
REFERENCES [dbo].[Duenios] ([idDuenio])
GO
ALTER TABLE [dbo].[Adopciones] CHECK CONSTRAINT [FK_Adopciones_Duenios]
GO
/****** Object:  ForeignKey [FK_Adopciones_Mascotas]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Adopciones]  WITH CHECK ADD  CONSTRAINT [FK_Adopciones_Mascotas] FOREIGN KEY([idMascota])
REFERENCES [dbo].[Mascotas] ([idMascota])
GO
ALTER TABLE [dbo].[Adopciones] CHECK CONSTRAINT [FK_Adopciones_Mascotas]
GO
/****** Object:  ForeignKey [FK_Adopciones_Voluntarios]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Adopciones]  WITH CHECK ADD  CONSTRAINT [FK_Adopciones_Voluntarios] FOREIGN KEY([idVoluntario])
REFERENCES [dbo].[Voluntarios] ([idVoluntario])
GO
ALTER TABLE [dbo].[Adopciones] CHECK CONSTRAINT [FK_Adopciones_Voluntarios]
GO
/****** Object:  ForeignKey [FK_Barrios_Localidades]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Barrios]  WITH CHECK ADD  CONSTRAINT [FK_Barrios_Localidades] FOREIGN KEY([idLocalidad])
REFERENCES [dbo].[Localidades] ([idLocalidad])
GO
ALTER TABLE [dbo].[Barrios] CHECK CONSTRAINT [FK_Barrios_Localidades]
GO
/****** Object:  ForeignKey [FK_Duenios_Personas]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Duenios]  WITH CHECK ADD  CONSTRAINT [FK_Duenios_Personas] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Personas] ([idPersona])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Duenios] CHECK CONSTRAINT [FK_Duenios_Personas]
GO
/****** Object:  ForeignKey [FK_Hallazgos_Barrios]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Hallazgos]  WITH CHECK ADD  CONSTRAINT [FK_Hallazgos_Barrios] FOREIGN KEY([idBarrioHallazgo])
REFERENCES [dbo].[Barrios] ([idBarrio])
GO
ALTER TABLE [dbo].[Hallazgos] CHECK CONSTRAINT [FK_Hallazgos_Barrios]
GO
/****** Object:  ForeignKey [FK_Hallazgos_Mascotas]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Hallazgos]  WITH CHECK ADD  CONSTRAINT [FK_Hallazgos_Mascotas] FOREIGN KEY([idMascota])
REFERENCES [dbo].[Mascotas] ([idMascota])
GO
ALTER TABLE [dbo].[Hallazgos] CHECK CONSTRAINT [FK_Hallazgos_Mascotas]
GO
/****** Object:  ForeignKey [FK_Hallazgos_Perdidas]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Hallazgos]  WITH CHECK ADD  CONSTRAINT [FK_Hallazgos_Perdidas] FOREIGN KEY([idPerdida])
REFERENCES [dbo].[Perdidas] ([idPerdida])
GO
ALTER TABLE [dbo].[Hallazgos] CHECK CONSTRAINT [FK_Hallazgos_Perdidas]
GO
/****** Object:  ForeignKey [FK_Hallazgos_Sesiones]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Hallazgos]  WITH CHECK ADD  CONSTRAINT [FK_Hallazgos_Sesiones] FOREIGN KEY([idSesion])
REFERENCES [dbo].[Sesiones] ([idSesion])
GO
ALTER TABLE [dbo].[Hallazgos] CHECK CONSTRAINT [FK_Hallazgos_Sesiones]
GO
/****** Object:  ForeignKey [FK_Mascotas_CaracteresMascota]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_CaracteresMascota] FOREIGN KEY([idCaracter])
REFERENCES [dbo].[CaracteresMascota] ([idCaracter])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_CaracteresMascota]
GO
/****** Object:  ForeignKey [FK_Mascotas_Colores]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Colores] FOREIGN KEY([idColor])
REFERENCES [dbo].[Colores] ([idColor])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Colores]
GO
/****** Object:  ForeignKey [FK_Mascotas_Duenios]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Duenios] FOREIGN KEY([idDuenio])
REFERENCES [dbo].[Duenios] ([idDuenio])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Duenios]
GO
/****** Object:  ForeignKey [FK_Mascotas_Edades]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Edades] FOREIGN KEY([idEdad])
REFERENCES [dbo].[Edades] ([idEdad])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Edades]
GO
/****** Object:  ForeignKey [FK_Mascotas_Especies]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Especies] FOREIGN KEY([idEspecie])
REFERENCES [dbo].[Especies] ([idEspecie])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Especies]
GO
/****** Object:  ForeignKey [FK_Mascotas_Estados]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Estados] FOREIGN KEY([idEstado])
REFERENCES [dbo].[Estados] ([idEstado])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Estados]
GO
/****** Object:  ForeignKey [FK_Mascotas_Razas]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Razas] FOREIGN KEY([idRaza])
REFERENCES [dbo].[Razas] ([idRaza])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Razas]
GO
/****** Object:  ForeignKey [FK_Perdidas_Barrios]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Perdidas]  WITH CHECK ADD  CONSTRAINT [FK_Perdidas_Barrios] FOREIGN KEY([idBarrioPerdida])
REFERENCES [dbo].[Barrios] ([idBarrio])
GO
ALTER TABLE [dbo].[Perdidas] CHECK CONSTRAINT [FK_Perdidas_Barrios]
GO
/****** Object:  ForeignKey [FK_Perdidas_Mascotas]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Perdidas]  WITH CHECK ADD  CONSTRAINT [FK_Perdidas_Mascotas] FOREIGN KEY([idMascota])
REFERENCES [dbo].[Mascotas] ([idMascota])
GO
ALTER TABLE [dbo].[Perdidas] CHECK CONSTRAINT [FK_Perdidas_Mascotas]
GO
/****** Object:  ForeignKey [FK_Perdidas_Sesiones]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Perdidas]  WITH CHECK ADD  CONSTRAINT [FK_Perdidas_Sesiones] FOREIGN KEY([idSesion])
REFERENCES [dbo].[Sesiones] ([idSesion])
GO
ALTER TABLE [dbo].[Perdidas] CHECK CONSTRAINT [FK_Perdidas_Sesiones]
GO
/****** Object:  ForeignKey [FK_PermisosXRoles_Permisos]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[PermisosXRoles]  WITH CHECK ADD  CONSTRAINT [FK_PermisosXRoles_Permisos] FOREIGN KEY([idPermiso])
REFERENCES [dbo].[Permisos] ([idPermiso])
GO
ALTER TABLE [dbo].[PermisosXRoles] CHECK CONSTRAINT [FK_PermisosXRoles_Permisos]
GO
/****** Object:  ForeignKey [FK_PermisosXRoles_Roles]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[PermisosXRoles]  WITH CHECK ADD  CONSTRAINT [FK_PermisosXRoles_Roles] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[PermisosXRoles] CHECK CONSTRAINT [FK_PermisosXRoles_Roles]
GO
/****** Object:  ForeignKey [FK_Personas_Barrios]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Barrios] FOREIGN KEY([idBarrio])
REFERENCES [dbo].[Barrios] ([idBarrio])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Barrios]
GO
/****** Object:  ForeignKey [FK_Personas_TipoDocumentos]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_TipoDocumentos] FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[TipoDocumentos] ([idTipoDocumento])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_TipoDocumentos]
GO
/****** Object:  ForeignKey [FK_Personas_Usuarios]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Usuarios] FOREIGN KEY([user])
REFERENCES [dbo].[Usuarios] ([user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Usuarios]
GO
/****** Object:  ForeignKey [FK_Razas_CategoriaRazas]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Razas]  WITH CHECK ADD  CONSTRAINT [FK_Razas_CategoriaRazas] FOREIGN KEY([idCategoriaRaza])
REFERENCES [dbo].[CategoriaRazas] ([idCategoriaRazas])
GO
ALTER TABLE [dbo].[Razas] CHECK CONSTRAINT [FK_Razas_CategoriaRazas]
GO
/****** Object:  ForeignKey [FK_Razas_CuidadosEspeciales]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Razas]  WITH CHECK ADD  CONSTRAINT [FK_Razas_CuidadosEspeciales] FOREIGN KEY([idCuidadoEspecial])
REFERENCES [dbo].[CuidadosEspeciales] ([idCuidadoEspecial])
GO
ALTER TABLE [dbo].[Razas] CHECK CONSTRAINT [FK_Razas_CuidadosEspeciales]
GO
/****** Object:  ForeignKey [FK_Razas_Especies]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Razas]  WITH CHECK ADD  CONSTRAINT [FK_Razas_Especies] FOREIGN KEY([idEspecie])
REFERENCES [dbo].[Especies] ([idEspecie])
GO
ALTER TABLE [dbo].[Razas] CHECK CONSTRAINT [FK_Razas_Especies]
GO
/****** Object:  ForeignKey [FK_RolesXUsuario_Roles]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[RolesXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolesXUsuario_Roles] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[RolesXUsuario] CHECK CONSTRAINT [FK_RolesXUsuario_Roles]
GO
/****** Object:  ForeignKey [FK_RolesXUsuario_Usuarios]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[RolesXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolesXUsuario_Usuarios] FOREIGN KEY([user])
REFERENCES [dbo].[Usuarios] ([user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolesXUsuario] CHECK CONSTRAINT [FK_RolesXUsuario_Usuarios]
GO
/****** Object:  ForeignKey [FK_Sesiones_Usuarios]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Sesiones]  WITH CHECK ADD  CONSTRAINT [FK_Sesiones_Usuarios] FOREIGN KEY([user])
REFERENCES [dbo].[Usuarios] ([user])
GO
ALTER TABLE [dbo].[Sesiones] CHECK CONSTRAINT [FK_Sesiones_Usuarios]
GO
/****** Object:  ForeignKey [FK_Voluntarios_Personas]    Script Date: 08/31/2014 02:24:36 ******/
ALTER TABLE [dbo].[Voluntarios]  WITH CHECK ADD  CONSTRAINT [FK_Voluntarios_Personas] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Personas] ([idPersona])
GO
ALTER TABLE [dbo].[Voluntarios] CHECK CONSTRAINT [FK_Voluntarios_Personas]
GO
