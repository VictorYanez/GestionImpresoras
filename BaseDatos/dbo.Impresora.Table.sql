USE [DBAppImpresoras]
GO
ALTER TABLE [Impresora] DROP CONSTRAINT [FK_ImpresoraUnidadId]
GO
ALTER TABLE [Impresora] DROP CONSTRAINT [FK_ImpresoraModeloId]
GO
ALTER TABLE [Impresora] DROP CONSTRAINT [FK_ImpresoraMarcaId]
GO
ALTER TABLE [Impresora] DROP CONSTRAINT [FK_ImpresoraInstitucionId]
GO
ALTER TABLE [Impresora] DROP CONSTRAINT [FK_ImpresoraEstadoId]
GO
ALTER TABLE [Impresora] DROP CONSTRAINT [FK_ImpresoraAreaId]
GO
/****** Object:  Table [Impresora]    Script Date: 21/7/2023 16:45:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Impresora]') AND type in (N'U'))
DROP TABLE [Impresora]
GO
