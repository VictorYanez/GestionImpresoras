USE [DBAppImpresoras]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area]') AND type in (N'U'))
DROP TABLE [dbo].[Area]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Dirección General de Transito', N'Dirección General de Transito')
INSERT [dbo].[Area] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Dirección General de Transporte Terrestre', N'Dirección General de Transporte Terrestre')
INSERT [dbo].[Area] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Dirección General de Transporte de Carga', N'Dirección General de Transporte de Carga')
INSERT [dbo].[Area] ([Id], [Nombre], [Descripcion]) VALUES (4, N'Dirección General de atención al usuario', N'Dirección General de atención al usuario')
INSERT [dbo].[Area] ([Id], [Nombre], [Descripcion]) VALUES (5, N'Área prueba 2', N'Área prueba 2  descripción 2')
INSERT [dbo].[Area] ([Id], [Nombre], [Descripcion]) VALUES (6, N'area de prueba 1', N'area de prueba 1')
SET IDENTITY_INSERT [dbo].[Area] OFF
GO
