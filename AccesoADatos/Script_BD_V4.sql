USE master
GO
if exists(select * from sys.databases where name='SiGMA') 
DROP DATABASE [SiGMA] 
GO
CREATE DATABASE [SiGMA]
GO
USE [SiGMA]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 08/09/2014 00:30:02 ******/
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
INSERT [dbo].[Permisos] ([idPermiso], [tipoPermiso]) VALUES (1, N'Lectura')
INSERT [dbo].[Permisos] ([idPermiso], [tipoPermiso]) VALUES (2, N'Escritura')
INSERT [dbo].[Permisos] ([idPermiso], [tipoPermiso]) VALUES (3, N'Borrado')
SET IDENTITY_INSERT [dbo].[Permisos] OFF
/****** Object:  Table [dbo].[Roles]    Script Date: 08/09/2014 00:30:02 ******/
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
INSERT [dbo].[Roles] ([idRol], [nombre], [descripcion]) VALUES (1, N'Dueño', N'es dueño de mascota')
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  Table [dbo].[Estados]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estados](
	[idEstado] [int] NOT NULL,
	[nombreEstado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (1, N'Con Dueño')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (2, N'En Adopcion')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (3, N'Adoptada')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (4, N'Perdida')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (5, N'Hallada')
INSERT [dbo].[Estados] ([idEstado], [nombreEstado]) VALUES (6, N'Fallecida')
/****** Object:  Table [dbo].[Especies]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Especies](
	[idEspecie] [int] NOT NULL,
	[nombreEspecie] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Especies] PRIMARY KEY CLUSTERED 
(
	[idEspecie] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Especies] ([idEspecie], [nombreEspecie]) VALUES (1, N'Perro')
INSERT [dbo].[Especies] ([idEspecie], [nombreEspecie]) VALUES (2, N'Gato')
/****** Object:  Table [dbo].[Edades]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Edades](
	[idEdad] [int] NOT NULL,
	[nombreEdad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Edades] PRIMARY KEY CLUSTERED 
(
	[idEdad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Edades] ([idEdad], [nombreEdad]) VALUES (1, N'Cachoro')
INSERT [dbo].[Edades] ([idEdad], [nombreEdad]) VALUES (2, N'Adulto')
INSERT [dbo].[Edades] ([idEdad], [nombreEdad]) VALUES (3, N'Senior')
/****** Object:  Table [dbo].[CuidadosEspeciales]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuidadosEspeciales](
	[idCuidadoEspecial] [int] NOT NULL,
	[descripcion] [varchar](250) NOT NULL,
 CONSTRAINT [PK_CuidadosEspeciales] PRIMARY KEY CLUSTERED 
(
	[idCuidadoEspecial] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Colores]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Colores](
	[idColor] [int] NOT NULL,
	[nombreColor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Colores] PRIMARY KEY CLUSTERED 
(
	[idColor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoriaRazas]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoriaRazas](
	[idCategoriaRazas] [int] NOT NULL,
	[nombreCategoriaRaza] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CategoriaRazas] PRIMARY KEY CLUSTERED 
(
	[idCategoriaRazas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 08/09/2014 00:30:02 ******/
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
/****** Object:  Table [dbo].[TipoDocumentos]    Script Date: 08/09/2014 00:30:02 ******/
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
INSERT [dbo].[TipoDocumentos] ([idTipoDocumento], [nombre]) VALUES (1, N'D.N.I.')
INSERT [dbo].[TipoDocumentos] ([idTipoDocumento], [nombre]) VALUES (2, N'Pasaporte')
SET IDENTITY_INSERT [dbo].[TipoDocumentos] OFF
/****** Object:  Table [dbo].[Usuarios]    Script Date: 08/09/2014 00:30:02 ******/
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
INSERT [dbo].[Usuarios] ([user], [password]) VALUES (N'gon', N'a')
INSERT [dbo].[Usuarios] ([user], [password]) VALUES (N'masi', N'a')
/****** Object:  Table [dbo].[UsuarioRoles]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRoles](
	[user] [nvarchar](50) NOT NULL,
	[idRol] [int] NOT NULL,
 CONSTRAINT [PK_RolesXUsuario] PRIMARY KEY CLUSTERED 
(
	[user] ASC,
	[idRol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesiones]    Script Date: 08/09/2014 00:30:02 ******/
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
/****** Object:  Table [dbo].[PermisosRoles]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PermisosRoles](
	[idRol] [int] NOT NULL,
	[idPermiso] [int] NOT NULL,
	[pantalla] [varchar](100) NULL,
 CONSTRAINT [PK_PermisosXRoles] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC,
	[idPermiso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Barrios]    Script Date: 08/09/2014 00:30:02 ******/
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
/****** Object:  Table [dbo].[Razas]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Razas](
	[idRaza] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Personas]    Script Date: 08/09/2014 00:30:02 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Personas] ON
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [idTipoDocumento], [nroDocumento], [email], [domicilio], [idBarrio], [telefonoFijo], [telefonoCelular], [fechaNacimiento], [user]) VALUES (1, N'Maximiliano', N'Tarnowski', 1, N'11111111111', N'maxi@mail.com', NULL, NULL, NULL, NULL, NULL, N'masi')
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [idTipoDocumento], [nroDocumento], [email], [domicilio], [idBarrio], [telefonoFijo], [telefonoCelular], [fechaNacimiento], [user]) VALUES (2, N'Gonzalo', N'diaz cornejo', 1, N'a', N'gon@mail.com', NULL, NULL, NULL, NULL, NULL, N'gon')
SET IDENTITY_INSERT [dbo].[Personas] OFF
/****** Object:  Table [dbo].[Voluntarios]    Script Date: 08/09/2014 00:30:02 ******/
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
/****** Object:  Table [dbo].[Duenios]    Script Date: 08/09/2014 00:30:02 ******/
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
INSERT [dbo].[Duenios] ([idDuenio], [idPersona]) VALUES (1, 1)
INSERT [dbo].[Duenios] ([idDuenio], [idPersona]) VALUES (2, 2)
SET IDENTITY_INSERT [dbo].[Duenios] OFF
/****** Object:  Table [dbo].[Mascotas]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mascotas](
	[idMascota] [int] NOT NULL,
	[nombreMascota] [varchar](50) NULL,
	[idEstado] [int] NOT NULL,
	[idEspecie] [int] NOT NULL,
	[idEdad] [int] NOT NULL,
	[idRaza] [int] NOT NULL,
	[idColor] [int] NOT NULL,
	[tratoAnimales] [varchar](200) NULL,
	[tratoNinios] [varchar](200) NULL,
	[caracter] [varchar](200) NULL,
	[observaciones] [varchar](500) NULL,
	[alimentacionEspecial] [varchar](200) NULL,
	[fechaNacimiento] [date] NULL,
	[sexo] [int] NOT NULL,
	[idDuenio] [int] NULL,
 CONSTRAINT [PK_Mascotas] PRIMARY KEY CLUSTERED 
(
	[idMascota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perdidas]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perdidas](
	[idPerdida] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Adopciones]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Adopciones](
	[idAdopcion] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Hallazgos]    Script Date: 08/09/2014 00:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hallazgos](
	[idHallazgo] [int] NOT NULL,
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
/****** Object:  ForeignKey [FK_Adopciones_Duenios]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Adopciones]  WITH CHECK ADD  CONSTRAINT [FK_Adopciones_Duenios] FOREIGN KEY([idDuenio])
REFERENCES [dbo].[Duenios] ([idDuenio])
GO
ALTER TABLE [dbo].[Adopciones] CHECK CONSTRAINT [FK_Adopciones_Duenios]
GO
/****** Object:  ForeignKey [FK_Adopciones_Mascotas]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Adopciones]  WITH CHECK ADD  CONSTRAINT [FK_Adopciones_Mascotas] FOREIGN KEY([idMascota])
REFERENCES [dbo].[Mascotas] ([idMascota])
GO
ALTER TABLE [dbo].[Adopciones] CHECK CONSTRAINT [FK_Adopciones_Mascotas]
GO
/****** Object:  ForeignKey [FK_Adopciones_Voluntarios]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Adopciones]  WITH CHECK ADD  CONSTRAINT [FK_Adopciones_Voluntarios] FOREIGN KEY([idVoluntario])
REFERENCES [dbo].[Voluntarios] ([idVoluntario])
GO
ALTER TABLE [dbo].[Adopciones] CHECK CONSTRAINT [FK_Adopciones_Voluntarios]
GO
/****** Object:  ForeignKey [FK_Barrios_Localidades]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Barrios]  WITH CHECK ADD  CONSTRAINT [FK_Barrios_Localidades] FOREIGN KEY([idLocalidad])
REFERENCES [dbo].[Localidades] ([idLocalidad])
GO
ALTER TABLE [dbo].[Barrios] CHECK CONSTRAINT [FK_Barrios_Localidades]
GO
/****** Object:  ForeignKey [FK_Duenios_Personas]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Duenios]  WITH CHECK ADD  CONSTRAINT [FK_Duenios_Personas] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Personas] ([idPersona])
GO
ALTER TABLE [dbo].[Duenios] CHECK CONSTRAINT [FK_Duenios_Personas]
GO
/****** Object:  ForeignKey [FK_Hallazgos_Barrios]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Hallazgos]  WITH CHECK ADD  CONSTRAINT [FK_Hallazgos_Barrios] FOREIGN KEY([idBarrioHallazgo])
REFERENCES [dbo].[Barrios] ([idBarrio])
GO
ALTER TABLE [dbo].[Hallazgos] CHECK CONSTRAINT [FK_Hallazgos_Barrios]
GO
/****** Object:  ForeignKey [FK_Hallazgos_Mascotas]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Hallazgos]  WITH CHECK ADD  CONSTRAINT [FK_Hallazgos_Mascotas] FOREIGN KEY([idMascota])
REFERENCES [dbo].[Mascotas] ([idMascota])
GO
ALTER TABLE [dbo].[Hallazgos] CHECK CONSTRAINT [FK_Hallazgos_Mascotas]
GO
/****** Object:  ForeignKey [FK_Hallazgos_Perdidas]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Hallazgos]  WITH CHECK ADD  CONSTRAINT [FK_Hallazgos_Perdidas] FOREIGN KEY([idPerdida])
REFERENCES [dbo].[Perdidas] ([idPerdida])
GO
ALTER TABLE [dbo].[Hallazgos] CHECK CONSTRAINT [FK_Hallazgos_Perdidas]
GO
/****** Object:  ForeignKey [FK_Hallazgos_Sesiones]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Hallazgos]  WITH CHECK ADD  CONSTRAINT [FK_Hallazgos_Sesiones] FOREIGN KEY([idSesion])
REFERENCES [dbo].[Sesiones] ([idSesion])
GO
ALTER TABLE [dbo].[Hallazgos] CHECK CONSTRAINT [FK_Hallazgos_Sesiones]
GO
/****** Object:  ForeignKey [FK_Mascotas_Colores]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Colores] FOREIGN KEY([idColor])
REFERENCES [dbo].[Colores] ([idColor])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Colores]
GO
/****** Object:  ForeignKey [FK_Mascotas_Duenios]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Duenios] FOREIGN KEY([idDuenio])
REFERENCES [dbo].[Duenios] ([idDuenio])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Duenios]
GO
/****** Object:  ForeignKey [FK_Mascotas_Edades]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Edades] FOREIGN KEY([idEdad])
REFERENCES [dbo].[Edades] ([idEdad])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Edades]
GO
/****** Object:  ForeignKey [FK_Mascotas_Especies]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Especies] FOREIGN KEY([idEspecie])
REFERENCES [dbo].[Especies] ([idEspecie])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Especies]
GO
/****** Object:  ForeignKey [FK_Mascotas_Estados]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Estados] FOREIGN KEY([idEstado])
REFERENCES [dbo].[Estados] ([idEstado])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Estados]
GO
/****** Object:  ForeignKey [FK_Mascotas_Razas]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Razas] FOREIGN KEY([idRaza])
REFERENCES [dbo].[Razas] ([idRaza])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Razas]
GO
/****** Object:  ForeignKey [FK_Perdidas_Barrios]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Perdidas]  WITH CHECK ADD  CONSTRAINT [FK_Perdidas_Barrios] FOREIGN KEY([idBarrioPerdida])
REFERENCES [dbo].[Barrios] ([idBarrio])
GO
ALTER TABLE [dbo].[Perdidas] CHECK CONSTRAINT [FK_Perdidas_Barrios]
GO
/****** Object:  ForeignKey [FK_Perdidas_Mascotas]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Perdidas]  WITH CHECK ADD  CONSTRAINT [FK_Perdidas_Mascotas] FOREIGN KEY([idMascota])
REFERENCES [dbo].[Mascotas] ([idMascota])
GO
ALTER TABLE [dbo].[Perdidas] CHECK CONSTRAINT [FK_Perdidas_Mascotas]
GO
/****** Object:  ForeignKey [FK_Perdidas_Sesiones]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Perdidas]  WITH CHECK ADD  CONSTRAINT [FK_Perdidas_Sesiones] FOREIGN KEY([idSesion])
REFERENCES [dbo].[Sesiones] ([idSesion])
GO
ALTER TABLE [dbo].[Perdidas] CHECK CONSTRAINT [FK_Perdidas_Sesiones]
GO
/****** Object:  ForeignKey [FK_PermisosXRoles_Permisos]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[PermisosRoles]  WITH CHECK ADD  CONSTRAINT [FK_PermisosXRoles_Permisos] FOREIGN KEY([idPermiso])
REFERENCES [dbo].[Permisos] ([idPermiso])
GO
ALTER TABLE [dbo].[PermisosRoles] CHECK CONSTRAINT [FK_PermisosXRoles_Permisos]
GO
/****** Object:  ForeignKey [FK_PermisosXRoles_Roles]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[PermisosRoles]  WITH CHECK ADD  CONSTRAINT [FK_PermisosXRoles_Roles] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[PermisosRoles] CHECK CONSTRAINT [FK_PermisosXRoles_Roles]
GO
/****** Object:  ForeignKey [FK_Personas_Barrios]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Barrios] FOREIGN KEY([idBarrio])
REFERENCES [dbo].[Barrios] ([idBarrio])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Barrios]
GO
/****** Object:  ForeignKey [FK_Personas_TipoDocumentos]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_TipoDocumentos] FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[TipoDocumentos] ([idTipoDocumento])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_TipoDocumentos]
GO
/****** Object:  ForeignKey [FK_Personas_Usuarios]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Usuarios] FOREIGN KEY([user])
REFERENCES [dbo].[Usuarios] ([user])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Usuarios]
GO
/****** Object:  ForeignKey [FK_Razas_CategoriaRazas]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Razas]  WITH CHECK ADD  CONSTRAINT [FK_Razas_CategoriaRazas] FOREIGN KEY([idCategoriaRaza])
REFERENCES [dbo].[CategoriaRazas] ([idCategoriaRazas])
GO
ALTER TABLE [dbo].[Razas] CHECK CONSTRAINT [FK_Razas_CategoriaRazas]
GO
/****** Object:  ForeignKey [FK_Razas_CuidadosEspeciales]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Razas]  WITH CHECK ADD  CONSTRAINT [FK_Razas_CuidadosEspeciales] FOREIGN KEY([idCuidadoEspecial])
REFERENCES [dbo].[CuidadosEspeciales] ([idCuidadoEspecial])
GO
ALTER TABLE [dbo].[Razas] CHECK CONSTRAINT [FK_Razas_CuidadosEspeciales]
GO
/****** Object:  ForeignKey [FK_Razas_Especies]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Razas]  WITH CHECK ADD  CONSTRAINT [FK_Razas_Especies] FOREIGN KEY([idEspecie])
REFERENCES [dbo].[Especies] ([idEspecie])
GO
ALTER TABLE [dbo].[Razas] CHECK CONSTRAINT [FK_Razas_Especies]
GO
/****** Object:  ForeignKey [FK_Sesiones_Usuarios]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Sesiones]  WITH CHECK ADD  CONSTRAINT [FK_Sesiones_Usuarios] FOREIGN KEY([user])
REFERENCES [dbo].[Usuarios] ([user])
GO
ALTER TABLE [dbo].[Sesiones] CHECK CONSTRAINT [FK_Sesiones_Usuarios]
GO
/****** Object:  ForeignKey [FK_RolesXUsuario_Roles]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[UsuarioRoles]  WITH CHECK ADD  CONSTRAINT [FK_RolesXUsuario_Roles] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[UsuarioRoles] CHECK CONSTRAINT [FK_RolesXUsuario_Roles]
GO
/****** Object:  ForeignKey [FK_RolesXUsuario_Usuarios]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[UsuarioRoles]  WITH CHECK ADD  CONSTRAINT [FK_RolesXUsuario_Usuarios] FOREIGN KEY([user])
REFERENCES [dbo].[Usuarios] ([user])
GO
ALTER TABLE [dbo].[UsuarioRoles] CHECK CONSTRAINT [FK_RolesXUsuario_Usuarios]
GO
/****** Object:  ForeignKey [FK_Voluntarios_Personas]    Script Date: 08/09/2014 00:30:02 ******/
ALTER TABLE [dbo].[Voluntarios]  WITH CHECK ADD  CONSTRAINT [FK_Voluntarios_Personas] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Personas] ([idPersona])
GO
ALTER TABLE [dbo].[Voluntarios] CHECK CONSTRAINT [FK_Voluntarios_Personas]
GO
