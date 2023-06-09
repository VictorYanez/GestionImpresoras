USE [DBAppImpresoras]
GO
ALTER TABLE [dbo].[Modelo] DROP CONSTRAINT [FK_Modelo_Marca_MarcaId]
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Modelo]') AND type in (N'U'))
DROP TABLE [dbo].[Modelo]
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[MarcaId] [int] NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[EsdeColor] [bit] NULL,
 CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Modelo] ON 

INSERT [dbo].[Modelo] ([Id], [Nombre], [MarcaId], [Descripcion], [EsdeColor]) VALUES (1, N'IM 3000', 2, N'Impresoras y Scanner, Blanco/Negro', 0)
INSERT [dbo].[Modelo] ([Id], [Nombre], [MarcaId], [Descripcion], [EsdeColor]) VALUES (2, N'M604i', 1, N'Impresora Laser, gama media, Blanco/Negro', 1)
INSERT [dbo].[Modelo] ([Id], [Nombre], [MarcaId], [Descripcion], [EsdeColor]) VALUES (3, N'Aficio 2555', 2, N'Impresoras y Scanner, Colores, alto rendimiento ', 1)
INSERT [dbo].[Modelo] ([Id], [Nombre], [MarcaId], [Descripcion], [EsdeColor]) VALUES (4, N'M3040 DN', 3, N'Blanco y negro/Lasser', 0)
INSERT [dbo].[Modelo] ([Id], [Nombre], [MarcaId], [Descripcion], [EsdeColor]) VALUES (5, N'LJ 444 NS', 3, N'El impresor básico', 1)
INSERT [dbo].[Modelo] ([Id], [Nombre], [MarcaId], [Descripcion], [EsdeColor]) VALUES (6, N'IM 2555 c', 1, N'Gama media, colores', 1)
INSERT [dbo].[Modelo] ([Id], [Nombre], [MarcaId], [Descripcion], [EsdeColor]) VALUES (1005, N'EcoSys M3550idn', 3, N'Impresora B/N gama media ', 0)
SET IDENTITY_INSERT [dbo].[Modelo] OFF
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD  CONSTRAINT [FK_Modelo_Marca_MarcaId] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marca] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Modelo] CHECK CONSTRAINT [FK_Modelo_Marca_MarcaId]
GO
