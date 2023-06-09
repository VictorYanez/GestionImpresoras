USE [DBAppImpresoras]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Marca]') AND type in (N'U'))
DROP TABLE [dbo].[Marca]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Hewlett Packard -  HP', N'Impresoras y Scanner Hewlett Packard  ')
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Ricoh', N'Equipos Ricoh')
INSERT [dbo].[Marca] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Kyocera', N'Kyocera')
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
