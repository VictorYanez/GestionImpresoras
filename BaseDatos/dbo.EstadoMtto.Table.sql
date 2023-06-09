USE [DBAppImpresoras]
GO
/****** Object:  Table [dbo].[EstadoMtto]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EstadoMtto]') AND type in (N'U'))
DROP TABLE [dbo].[EstadoMtto]
GO
/****** Object:  Table [dbo].[EstadoMtto]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoMtto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_EstadoMtto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EstadoMtto] ON 

INSERT [dbo].[EstadoMtto] ([Id], [Nombre], [Descripcion]) VALUES (1, N'En ejecución ', N'El impresor está en mantenimiento ')
INSERT [dbo].[EstadoMtto] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Programado', N'Se ha solicitado ejecución de mantenimiento')
INSERT [dbo].[EstadoMtto] ([Id], [Nombre], [Descripcion]) VALUES (3, N'En espera de repuestos ', N'En espera de repuestos solicitados ')
SET IDENTITY_INSERT [dbo].[EstadoMtto] OFF
GO
