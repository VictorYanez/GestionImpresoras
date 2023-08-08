USE [DBAppImpresoras]
GO
ALTER TABLE [Solicitud] DROP CONSTRAINT [FK_Solicitud_Impresora_ImpresoraId]
GO
ALTER TABLE [Solicitud] DROP CONSTRAINT [FK_Solicitud_EstadoSolicitud_EstadoSolicitudId]
GO
ALTER TABLE [Solicitud] DROP CONSTRAINT [FK_Solicitud_Color_ColorId]
GO
ALTER TABLE [Solicitud] DROP CONSTRAINT [FK_Medio_SolicitudId]
GO
/****** Object:  Table [Solicitud]    Script Date: 21/7/2023 16:45:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Solicitud]') AND type in (N'U'))
DROP TABLE [Solicitud]
GO
