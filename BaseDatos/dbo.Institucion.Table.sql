USE [DBAppImpresoras]
GO
/****** Object:  Table [Institucion]    Script Date: 21/7/2023 16:45:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Institucion]') AND type in (N'U'))
DROP TABLE [Institucion]
GO
