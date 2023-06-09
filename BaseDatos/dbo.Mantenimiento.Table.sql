USE [DBAppImpresoras]
GO
ALTER TABLE [dbo].[Mantenimiento] DROP CONSTRAINT [FK_Mantenimiento_Impresora_ImpresoraId]
GO
ALTER TABLE [dbo].[Mantenimiento] DROP CONSTRAINT [FK_Mantenimiento_EstadoMtto_EstadoId]
GO
/****** Object:  Table [dbo].[Mantenimiento]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Mantenimiento]') AND type in (N'U'))
DROP TABLE [dbo].[Mantenimiento]
GO
/****** Object:  Table [dbo].[Mantenimiento]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mantenimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImpresoraId] [int] NOT NULL,
	[EstadoMttoId] [int] NOT NULL,
	[FechaMantenimiento] [date] NULL,
	[FechaSolicitud] [date] NULL,
	[EsLocal] [bit] NULL,
 CONSTRAINT [PK_Mantenimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Mantenimiento] ON 

INSERT [dbo].[Mantenimiento] ([Id], [ImpresoraId], [EstadoMttoId], [FechaMantenimiento], [FechaSolicitud], [EsLocal]) VALUES (1, 3, 2, NULL, CAST(N'2023-04-29' AS Date), 0)
INSERT [dbo].[Mantenimiento] ([Id], [ImpresoraId], [EstadoMttoId], [FechaMantenimiento], [FechaSolicitud], [EsLocal]) VALUES (2, 3, 1, NULL, CAST(N'2023-05-04' AS Date), 1)
INSERT [dbo].[Mantenimiento] ([Id], [ImpresoraId], [EstadoMttoId], [FechaMantenimiento], [FechaSolicitud], [EsLocal]) VALUES (10, 5, 3, NULL, CAST(N'2023-04-11' AS Date), 0)
INSERT [dbo].[Mantenimiento] ([Id], [ImpresoraId], [EstadoMttoId], [FechaMantenimiento], [FechaSolicitud], [EsLocal]) VALUES (11, 8, 3, NULL, CAST(N'2023-02-14' AS Date), 1)
INSERT [dbo].[Mantenimiento] ([Id], [ImpresoraId], [EstadoMttoId], [FechaMantenimiento], [FechaSolicitud], [EsLocal]) VALUES (12, 12, 1, CAST(N'2023-06-09' AS Date), CAST(N'2023-06-09' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Mantenimiento] OFF
GO
ALTER TABLE [dbo].[Mantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_Mantenimiento_EstadoMtto_EstadoId] FOREIGN KEY([EstadoMttoId])
REFERENCES [dbo].[EstadoMtto] ([Id])
GO
ALTER TABLE [dbo].[Mantenimiento] CHECK CONSTRAINT [FK_Mantenimiento_EstadoMtto_EstadoId]
GO
ALTER TABLE [dbo].[Mantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_Mantenimiento_Impresora_ImpresoraId] FOREIGN KEY([ImpresoraId])
REFERENCES [dbo].[Impresora] ([Id])
GO
ALTER TABLE [dbo].[Mantenimiento] CHECK CONSTRAINT [FK_Mantenimiento_Impresora_ImpresoraId]
GO
