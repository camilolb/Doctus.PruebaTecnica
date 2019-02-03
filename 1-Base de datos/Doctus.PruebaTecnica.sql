USE [Doctus.PruebaTecnica]
GO
/****** Object:  User [usrPruebaTecnica]    Script Date: 03/02/2019 10:51:45 ******/
CREATE USER [usrPruebaTecnica] FOR LOGIN [usrPruebaTecnica] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_datareader] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [usrPruebaTecnica]
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 03/02/2019 10:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Creado] [datetime] NOT NULL,
	[Modificado] [datetime] NULL,
 CONSTRAINT [PK_Actividad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 03/02/2019 10:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[Creado] [datetime] NOT NULL,
	[Modificado] [datetime] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Horas]    Script Date: 03/02/2019 10:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Hora] [int] NOT NULL,
	[IdActividad] [int] NOT NULL,
 CONSTRAINT [PK_Horas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Actividad] ON 

INSERT [dbo].[Actividad] ([Id], [Descripcion], [Estado], [Creado], [Modificado]) VALUES (1, N'Pruab', 0, CAST(0x0000AB2C00000000 AS DateTime), NULL)
INSERT [dbo].[Actividad] ([Id], [Descripcion], [Estado], [Creado], [Modificado]) VALUES (2, N'retert', 0, CAST(0x0000A9E8007D5F99 AS DateTime), NULL)
INSERT [dbo].[Actividad] ([Id], [Descripcion], [Estado], [Creado], [Modificado]) VALUES (3, N'prueba2', 0, CAST(0x0000A9E80124C4C2 AS DateTime), NULL)
INSERT [dbo].[Actividad] ([Id], [Descripcion], [Estado], [Creado], [Modificado]) VALUES (4, N'prueba 3', 0, CAST(0x0000A9E80126C8F9 AS DateTime), NULL)
INSERT [dbo].[Actividad] ([Id], [Descripcion], [Estado], [Creado], [Modificado]) VALUES (5, N'prueba 10', 0, CAST(0x0000A9E9009EE420 AS DateTime), NULL)
INSERT [dbo].[Actividad] ([Id], [Descripcion], [Estado], [Creado], [Modificado]) VALUES (6, N'asdsad', 1, CAST(0x0000A9E900AB116B AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Actividad] OFF
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([Id], [Email], [Password], [Creado], [Modificado]) VALUES (1, N'clopezb@hotmail.com', N'123456', CAST(0x0000A9E800AB1242 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Empleado] OFF
SET IDENTITY_INSERT [dbo].[Horas] ON 

INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (2, CAST(0x0000AB2C00000000 AS DateTime), 2, 1)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (3, CAST(0x0000AB2C00000000 AS DateTime), 3, 1)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (4, CAST(0x0000A9EE005265C0 AS DateTime), 2, 2)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (7, CAST(0x0000AA9D00000000 AS DateTime), 3, 2)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (8, CAST(0x0000AA0400000000 AS DateTime), 4, 2)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (9, CAST(0x0000A9E800000000 AS DateTime), 5, 1)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (10, CAST(0x0000A9E800000000 AS DateTime), 5, 1)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (15, CAST(0x0000AA9D00000000 AS DateTime), 4, 3)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (16, CAST(0x0000A9C900000000 AS DateTime), 5, 3)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (22, CAST(0x0000A9E800000000 AS DateTime), 5, 4)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (23, CAST(0x0000AA6000000000 AS DateTime), 5, 5)
INSERT [dbo].[Horas] ([Id], [Fecha], [Hora], [IdActividad]) VALUES (29, CAST(0x0000AA0200000000 AS DateTime), 2, 6)
SET IDENTITY_INSERT [dbo].[Horas] OFF
ALTER TABLE [dbo].[Empleado] ADD  CONSTRAINT [DF_Empleado_Creado]  DEFAULT (getdate()) FOR [Creado]
GO
