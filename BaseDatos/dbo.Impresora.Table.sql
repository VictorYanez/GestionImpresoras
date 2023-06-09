USE [DBAppImpresoras]
GO
ALTER TABLE [dbo].[Impresora] DROP CONSTRAINT [FK_ImpresoraUnidadId]
GO
ALTER TABLE [dbo].[Impresora] DROP CONSTRAINT [FK_ImpresoraModeloId]
GO
ALTER TABLE [dbo].[Impresora] DROP CONSTRAINT [FK_ImpresoraMarcaId]
GO
ALTER TABLE [dbo].[Impresora] DROP CONSTRAINT [FK_ImpresoraInstitucionId]
GO
ALTER TABLE [dbo].[Impresora] DROP CONSTRAINT [FK_ImpresoraEstadoId]
GO
ALTER TABLE [dbo].[Impresora] DROP CONSTRAINT [FK_ImpresoraAreaId]
GO
/****** Object:  Table [dbo].[Impresora]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Impresora]') AND type in (N'U'))
DROP TABLE [dbo].[Impresora]
GO
/****** Object:  Table [dbo].[Impresora]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impresora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoActivoFijo] [nvarchar](22) NOT NULL,
	[MarcaId] [int] NOT NULL,
	[ModeloId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[DireccionIP] [nvarchar](15) NULL,
	[AreaId] [int] NOT NULL,
	[UnidadId] [int] NOT NULL,
	[InstitucionId] [int] NOT NULL,
	[Responsable] [nvarchar](125) NULL,
	[FechaRegistro] [date] NULL,
	[Caracteristicas] [nvarchar](200) NULL,
	[NumeroSerie] [nvarchar](22) NULL,
 CONSTRAINT [PK_Impresora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Impresora] ON 

INSERT [dbo].[Impresora] ([Id], [CodigoActivoFijo], [MarcaId], [ModeloId], [EstadoId], [DireccionIP], [AreaId], [UnidadId], [InstitucionId], [Responsable], [FechaRegistro], [Caracteristicas], [NumeroSerie]) VALUES (3, N'FAE-01-07-87-176-2022', 2, 3, 1, N'172.19.3.122', 1, 2, 1, NULL, NULL, N'B/N', NULL)
INSERT [dbo].[Impresora] ([Id], [CodigoActivoFijo], [MarcaId], [ModeloId], [EstadoId], [DireccionIP], [AreaId], [UnidadId], [InstitucionId], [Responsable], [FechaRegistro], [Caracteristicas], [NumeroSerie]) VALUES (5, N'FAE-01-07-87-176-444', 2, 1, 4, N'172.19.2.11', 1, 2, 3, NULL, NULL, N'B/N alto rendimiento ', NULL)
INSERT [dbo].[Impresora] ([Id], [CodigoActivoFijo], [MarcaId], [ModeloId], [EstadoId], [DireccionIP], [AreaId], [UnidadId], [InstitucionId], [Responsable], [FechaRegistro], [Caracteristicas], [NumeroSerie]) VALUES (6, N'FAE-01-07-87-44-2020', 1, 2, 1, N'172.19.3.044', 1, 2, 2, NULL, NULL, N'Con escaner', NULL)
INSERT [dbo].[Impresora] ([Id], [CodigoActivoFijo], [MarcaId], [ModeloId], [EstadoId], [DireccionIP], [AreaId], [UnidadId], [InstitucionId], [Responsable], [FechaRegistro], [Caracteristicas], [NumeroSerie]) VALUES (7, N'FAE-01-07-87-222-2002', 3, 4, 3, N'172.19.1.77', 3, 5, 1, NULL, NULL, N'Con escaner', NULL)
INSERT [dbo].[Impresora] ([Id], [CodigoActivoFijo], [MarcaId], [ModeloId], [EstadoId], [DireccionIP], [AreaId], [UnidadId], [InstitucionId], [Responsable], [FechaRegistro], [Caracteristicas], [NumeroSerie]) VALUES (8, N'FAE-01-07-87-44-1999', 2, 1, 3, N'172.19.3.044', 1, 2, 7, NULL, NULL, N'B/N alto rendimiento ', NULL)
INSERT [dbo].[Impresora] ([Id], [CodigoActivoFijo], [MarcaId], [ModeloId], [EstadoId], [DireccionIP], [AreaId], [UnidadId], [InstitucionId], [Responsable], [FechaRegistro], [Caracteristicas], [NumeroSerie]) VALUES (9, N'FAE-01-09-44-921-2020', 3, 4, 1, N'172.19.2.117', 1, 2, 2, NULL, NULL, N'B/N injeccion ', NULL)
INSERT [dbo].[Impresora] ([Id], [CodigoActivoFijo], [MarcaId], [ModeloId], [EstadoId], [DireccionIP], [AreaId], [UnidadId], [InstitucionId], [Responsable], [FechaRegistro], [Caracteristicas], [NumeroSerie]) VALUES (10, N'FAE-01-09-44-921-2020', 1, 2, 1, N'172.19.2.119', 3, 5, 2, NULL, NULL, N'Ninguna', NULL)
INSERT [dbo].[Impresora] ([Id], [CodigoActivoFijo], [MarcaId], [ModeloId], [EstadoId], [DireccionIP], [AreaId], [UnidadId], [InstitucionId], [Responsable], [FechaRegistro], [Caracteristicas], [NumeroSerie]) VALUES (11, N'FAE-01-09-44-921-1999', 3, 4, 1, N'172.19.1.222', 3, 5, 7, NULL, NULL, N'B/N injeccion ', NULL)
INSERT [dbo].[Impresora] ([Id], [CodigoActivoFijo], [MarcaId], [ModeloId], [EstadoId], [DireccionIP], [AreaId], [UnidadId], [InstitucionId], [Responsable], [FechaRegistro], [Caracteristicas], [NumeroSerie]) VALUES (12, N'FAE-01-09-44-921-0000', 2, 3, 10, N'172.19.2.000', 2, 3, 7, NULL, NULL, N'Ninguna modificada', NULL)
INSERT [dbo].[Impresora] ([Id], [CodigoActivoFijo], [MarcaId], [ModeloId], [EstadoId], [DireccionIP], [AreaId], [UnidadId], [InstitucionId], [Responsable], [FechaRegistro], [Caracteristicas], [NumeroSerie]) VALUES (13, N'E52FA03B2NMK00/1059B-2', 3, 1005, 6, N'172.19.2.127', 2, 3, 2, NULL, NULL, N'Ninguna modificada', NULL)
SET IDENTITY_INSERT [dbo].[Impresora] OFF
GO
ALTER TABLE [dbo].[Impresora]  WITH CHECK ADD  CONSTRAINT [FK_ImpresoraAreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Impresora] CHECK CONSTRAINT [FK_ImpresoraAreaId]
GO
ALTER TABLE [dbo].[Impresora]  WITH CHECK ADD  CONSTRAINT [FK_ImpresoraEstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[Impresora] CHECK CONSTRAINT [FK_ImpresoraEstadoId]
GO
ALTER TABLE [dbo].[Impresora]  WITH CHECK ADD  CONSTRAINT [FK_ImpresoraInstitucionId] FOREIGN KEY([InstitucionId])
REFERENCES [dbo].[Institucion] ([Id])
GO
ALTER TABLE [dbo].[Impresora] CHECK CONSTRAINT [FK_ImpresoraInstitucionId]
GO
ALTER TABLE [dbo].[Impresora]  WITH CHECK ADD  CONSTRAINT [FK_ImpresoraMarcaId] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marca] ([Id])
GO
ALTER TABLE [dbo].[Impresora] CHECK CONSTRAINT [FK_ImpresoraMarcaId]
GO
ALTER TABLE [dbo].[Impresora]  WITH CHECK ADD  CONSTRAINT [FK_ImpresoraModeloId] FOREIGN KEY([ModeloId])
REFERENCES [dbo].[Modelo] ([Id])
GO
ALTER TABLE [dbo].[Impresora] CHECK CONSTRAINT [FK_ImpresoraModeloId]
GO
ALTER TABLE [dbo].[Impresora]  WITH CHECK ADD  CONSTRAINT [FK_ImpresoraUnidadId] FOREIGN KEY([UnidadId])
REFERENCES [dbo].[Unidad] ([Id])
GO
ALTER TABLE [dbo].[Impresora] CHECK CONSTRAINT [FK_ImpresoraUnidadId]
GO
