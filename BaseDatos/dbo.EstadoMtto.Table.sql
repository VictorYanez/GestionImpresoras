USE [DBAppImpresoras]
GO
/****** Object:  Table [EstadoMtto]    Script Date: 21/7/2023 16:45:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[EstadoMtto]') AND type in (N'U'))
DROP TABLE [EstadoMtto]
GO
