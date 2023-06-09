USE [DBAppImpresoras]
GO
/****** Object:  Table [dbo].[Medio]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Medio]') AND type in (N'U'))
DROP TABLE [dbo].[Medio]
GO
/****** Object:  Table [dbo].[Medio]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[ConRespuesta] [bit] NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_Medio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Medio] ON 

INSERT [dbo].[Medio] ([Id], [Nombre], [ConRespuesta], [Descripcion]) VALUES (1, N'Correo Electroníco', 1, N'Correos Electronícos Institucional o personal')
INSERT [dbo].[Medio] ([Id], [Nombre], [ConRespuesta], [Descripcion]) VALUES (2, N'Ticket', 1, N'Ticket de Intranet ')
INSERT [dbo].[Medio] ([Id], [Nombre], [ConRespuesta], [Descripcion]) VALUES (3, N'Por medio de Whatapp', 1, N'Por medio de Whatapp')
INSERT [dbo].[Medio] ([Id], [Nombre], [ConRespuesta], [Descripcion]) VALUES (4, N'Llamada Telefónica ', 0, N'Llamada Telefónica ')
INSERT [dbo].[Medio] ([Id], [Nombre], [ConRespuesta], [Descripcion]) VALUES (5, N'Solicitud Verbal', 0, N'Solicitud Verbal')
SET IDENTITY_INSERT [dbo].[Medio] OFF
GO
