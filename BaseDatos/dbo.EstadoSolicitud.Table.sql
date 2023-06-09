USE [DBAppImpresoras]
GO
/****** Object:  Table [dbo].[EstadoSolicitud]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EstadoSolicitud]') AND type in (N'U'))
DROP TABLE [dbo].[EstadoSolicitud]
GO
/****** Object:  Table [dbo].[EstadoSolicitud]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoSolicitud](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Orden] [int] NULL,
 CONSTRAINT [PK_EstaoSolicitud] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EstadoSolicitud] ON 

INSERT [dbo].[EstadoSolicitud] ([Id], [Nombre], [Descripcion], [Orden]) VALUES (1, N'Solicitado al proveedor ', N'Solicitado al proveedor ', NULL)
INSERT [dbo].[EstadoSolicitud] ([Id], [Nombre], [Descripcion], [Orden]) VALUES (2, N'En espera  de recibir el proveedor', N'En espera  de recibir el proveedor', NULL)
INSERT [dbo].[EstadoSolicitud] ([Id], [Nombre], [Descripcion], [Orden]) VALUES (3, N'Recibido por el proveedor ', N'En manos del proveedor ', NULL)
SET IDENTITY_INSERT [dbo].[EstadoSolicitud] OFF
GO
