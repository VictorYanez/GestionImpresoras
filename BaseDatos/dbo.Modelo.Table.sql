USE [DBAppImpresoras]
GO
ALTER TABLE [Modelo] DROP CONSTRAINT [FK_Modelo_Marca_MarcaId]
GO
/****** Object:  Table [Modelo]    Script Date: 21/7/2023 16:45:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Modelo]') AND type in (N'U'))
DROP TABLE [Modelo]
GO
