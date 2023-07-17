CREATE TABLE [dbo].[EstadoSolicitud] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (200) NOT NULL,
    [Descripcion] NVARCHAR (200) NULL,
    [Orden]       INT            NULL,
    CONSTRAINT [PK_EstaoSolicitud] PRIMARY KEY CLUSTERED ([Id] ASC)
);

