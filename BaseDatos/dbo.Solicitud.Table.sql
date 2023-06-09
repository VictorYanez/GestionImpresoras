USE [DBAppImpresoras]
GO
ALTER TABLE [dbo].[Solicitud] DROP CONSTRAINT [FK_Solicitud_Impresora_ImpresoraId]
GO
ALTER TABLE [dbo].[Solicitud] DROP CONSTRAINT [FK_Solicitud_EstadoSolicitud_EstadoSolicitudId]
GO
ALTER TABLE [dbo].[Solicitud] DROP CONSTRAINT [FK_Solicitud_Color_ColorId]
GO
ALTER TABLE [dbo].[Solicitud] DROP CONSTRAINT [FK_Medio_SolicitudId]
GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Solicitud]') AND type in (N'U'))
DROP TABLE [dbo].[Solicitud]
GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImpresoraId] [int] NOT NULL,
	[EstadoSolicitudId] [int] NOT NULL,
	[FechaSolicitud] [date] NULL,
	[ColorSolicitado] [nvarchar](200) NULL,
	[Solicitante] [nvarchar](200) NULL,
	[FechaEntrega] [date] NULL,
	[MedioId] [int] NOT NULL,
	[Detalle] [nvarchar](200) NULL,
	[ColorId] [int] NOT NULL,
	[UrlImagen] [nvarchar](max) NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Solicitud] ON 

INSERT [dbo].[Solicitud] ([Id], [ImpresoraId], [EstadoSolicitudId], [FechaSolicitud], [ColorSolicitado], [Solicitante], [FechaEntrega], [MedioId], [Detalle], [ColorId], [UrlImagen]) VALUES (1, 5, 1, CAST(N'2023-06-01' AS Date), NULL, N'Evelyn Carranza', NULL, 1, N'Algún detalle', 2, NULL)
INSERT [dbo].[Solicitud] ([Id], [ImpresoraId], [EstadoSolicitudId], [FechaSolicitud], [ColorSolicitado], [Solicitante], [FechaEntrega], [MedioId], [Detalle], [ColorId], [UrlImagen]) VALUES (2, 13, 1, CAST(N'2023-06-14' AS Date), NULL, N'Evelyn Carranza', NULL, 4, N'Para limpieza también ', 1, NULL)
INSERT [dbo].[Solicitud] ([Id], [ImpresoraId], [EstadoSolicitudId], [FechaSolicitud], [ColorSolicitado], [Solicitante], [FechaEntrega], [MedioId], [Detalle], [ColorId], [UrlImagen]) VALUES (3, 13, 1, CAST(N'2023-06-01' AS Date), NULL, N'Soho ', NULL, 3, N'Algún detalle', 2, NULL)
INSERT [dbo].[Solicitud] ([Id], [ImpresoraId], [EstadoSolicitudId], [FechaSolicitud], [ColorSolicitado], [Solicitante], [FechaEntrega], [MedioId], [Detalle], [ColorId], [UrlImagen]) VALUES (4, 13, 2, CAST(N'2023-06-19' AS Date), NULL, N'Soho ', NULL, 3, N'Algún detalle', 2, NULL)
INSERT [dbo].[Solicitud] ([Id], [ImpresoraId], [EstadoSolicitudId], [FechaSolicitud], [ColorSolicitado], [Solicitante], [FechaEntrega], [MedioId], [Detalle], [ColorId], [UrlImagen]) VALUES (14, 12, 3, CAST(N'2023-06-14' AS Date), NULL, N'Auralila Echeverria ', NULL, 4, N'Para limpieza también ', 3, NULL)
INSERT [dbo].[Solicitud] ([Id], [ImpresoraId], [EstadoSolicitudId], [FechaSolicitud], [ColorSolicitado], [Solicitante], [FechaEntrega], [MedioId], [Detalle], [ColorId], [UrlImagen]) VALUES (15, 3, 1, CAST(N'2023-06-07' AS Date), NULL, N'Auralila Echeverria ', NULL, 5, N'Para limpieza también ', 1, NULL)
INSERT [dbo].[Solicitud] ([Id], [ImpresoraId], [EstadoSolicitudId], [FechaSolicitud], [ColorSolicitado], [Solicitante], [FechaEntrega], [MedioId], [Detalle], [ColorId], [UrlImagen]) VALUES (16, 5, 1, CAST(N'2023-06-02' AS Date), NULL, N'Auralila Echeverria ', NULL, 5, NULL, 4, N'024f26c4-730e-4ab3-bdea-d8df3abe9585.jfif')
INSERT [dbo].[Solicitud] ([Id], [ImpresoraId], [EstadoSolicitudId], [FechaSolicitud], [ColorSolicitado], [Solicitante], [FechaEntrega], [MedioId], [Detalle], [ColorId], [UrlImagen]) VALUES (17, 8, 1, CAST(N'2023-06-02' AS Date), NULL, N'Bessy Guzmán', NULL, 3, N'Algún detalle', 4, N'C:\Users\victor.yanez\source\repos\GestionImpresoras\GestionImpresoras\wwwroot\imagenes\solicitudes\b5371088-31d3-4b08-bb61-75e92d0eb484.mp4')
SET IDENTITY_INSERT [dbo].[Solicitud] OFF
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Medio_SolicitudId] FOREIGN KEY([MedioId])
REFERENCES [dbo].[Medio] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Medio_SolicitudId]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Color_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Color] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Color_ColorId]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_EstadoSolicitud_EstadoSolicitudId] FOREIGN KEY([EstadoSolicitudId])
REFERENCES [dbo].[EstadoSolicitud] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_EstadoSolicitud_EstadoSolicitudId]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Impresora_ImpresoraId] FOREIGN KEY([ImpresoraId])
REFERENCES [dbo].[Impresora] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Impresora_ImpresoraId]
GO
