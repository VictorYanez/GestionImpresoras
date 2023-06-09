USE [DBAppImpresoras]
GO
ALTER TABLE [dbo].[Unidad] DROP CONSTRAINT [FK_UnidadAreaId]
GO
ALTER TABLE [dbo].[Unidad] DROP CONSTRAINT [FK_Unidad_Area_AreaId]
GO
/****** Object:  Table [dbo].[Unidad]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Unidad]') AND type in (N'U'))
DROP TABLE [dbo].[Unidad]
GO
/****** Object:  Table [dbo].[Unidad]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[AreaId] [int] NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_Unidad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Unidad] ON 

INSERT [dbo].[Unidad] ([Id], [Nombre], [AreaId], [Descripcion]) VALUES (2, N'Unidad Jurídica de Transito', 1, N'Unidad Jurídica de Transito')
INSERT [dbo].[Unidad] ([Id], [Nombre], [AreaId], [Descripcion]) VALUES (3, N'Unidad Jurídica de Transporte', 2, N'Unidad Jurídica de Transporte')
INSERT [dbo].[Unidad] ([Id], [Nombre], [AreaId], [Descripcion]) VALUES (4, N'Unidad Jurídica de Carga ', 3, N'Unidad Jurídica de Carga ')
INSERT [dbo].[Unidad] ([Id], [Nombre], [AreaId], [Descripcion]) VALUES (5, N'Unidad Técnica de Carga ', 3, N'Unidad Técnica de Carga')
SET IDENTITY_INSERT [dbo].[Unidad] OFF
GO
ALTER TABLE [dbo].[Unidad]  WITH CHECK ADD  CONSTRAINT [FK_Unidad_Area_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Unidad] CHECK CONSTRAINT [FK_Unidad_Area_AreaId]
GO
ALTER TABLE [dbo].[Unidad]  WITH CHECK ADD  CONSTRAINT [FK_UnidadAreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Unidad] CHECK CONSTRAINT [FK_UnidadAreaId]
GO
