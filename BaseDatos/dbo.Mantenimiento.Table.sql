USE [DBAppImpresoras]
GO
ALTER TABLE [Mantenimiento] DROP CONSTRAINT [FK_Mantenimiento_Impresora_ImpresoraId]
GO
ALTER TABLE [Mantenimiento] DROP CONSTRAINT [FK_Mantenimiento_EstadoMtto_EstadoId]
GO
/****** Object:  Table [Mantenimiento]    Script Date: 21/7/2023 16:45:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Mantenimiento]') AND type in (N'U'))
DROP TABLE [Mantenimiento]
GO
