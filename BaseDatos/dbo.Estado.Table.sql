USE [DBAppImpresoras]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Estado]') AND type in (N'U'))
DROP TABLE [dbo].[Estado]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Estado] ON 

INSERT [dbo].[Estado] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Reparación Externa', N'En reparación fuera de la institución ')
INSERT [dbo].[Estado] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Dañada', N'Equipo dañado')
INSERT [dbo].[Estado] ([Id], [Nombre], [Descripcion]) VALUES (4, N'Esperando dar de baja ', N'Equipo para dar de baja')
INSERT [dbo].[Estado] ([Id], [Nombre], [Descripcion]) VALUES (6, N'Reparación Interna', N'El equipo está en reparación dentro de la institución ')
INSERT [dbo].[Estado] ([Id], [Nombre], [Descripcion]) VALUES (9, N'Fuera de uso, por usuario', N'Fuera de uso por el usuario ')
INSERT [dbo].[Estado] ([Id], [Nombre], [Descripcion]) VALUES (10, N'Dañada  TK1', N'Dañada TK1')
SET IDENTITY_INSERT [dbo].[Estado] OFF
GO
