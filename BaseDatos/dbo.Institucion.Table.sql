USE [DBAppImpresoras]
GO
/****** Object:  Table [dbo].[Institucion]    Script Date: 21/6/2023 16:00:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Institucion]') AND type in (N'U'))
DROP TABLE [dbo].[Institucion]
GO
/****** Object:  Table [dbo].[Institucion]    Script Date: 21/6/2023 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institucion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_Institucion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Institucion] ON 

INSERT [dbo].[Institucion] ([Id], [Nombre], [Descripcion]) VALUES (1, N'SITRAMS', N'Terminal SITRAMS')
INSERT [dbo].[Institucion] ([Id], [Nombre], [Descripcion]) VALUES (2, N'VMT Centro', N'VMT Centro (Gestores, Alcohol Test) ')
INSERT [dbo].[Institucion] ([Id], [Nombre], [Descripcion]) VALUES (3, N'FOVIAL', N'FOVIAL')
INSERT [dbo].[Institucion] ([Id], [Nombre], [Descripcion]) VALUES (5, N'SITRAMS 3', N'Terminal SITRAMS  3')
INSERT [dbo].[Institucion] ([Id], [Nombre], [Descripcion]) VALUES (7, N'SITRAMS  TK', N'Terminal SITRAMS  TK')
SET IDENTITY_INSERT [dbo].[Institucion] OFF
GO
