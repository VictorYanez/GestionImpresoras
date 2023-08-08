USE [DBAppImpresoras]
GO
ALTER TABLE [Unidad] DROP CONSTRAINT [FK_UnidadAreaId]
GO
ALTER TABLE [Unidad] DROP CONSTRAINT [FK_Unidad_Area_AreaId]
GO
/****** Object:  Table [Unidad]    Script Date: 21/7/2023 16:45:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Unidad]') AND type in (N'U'))
DROP TABLE [Unidad]
GO
