CREATE TABLE [dbo].[EstadoMtto] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (200) NOT NULL,
    [Descripcion] NVARCHAR (200) NULL,
    CONSTRAINT [PK_EstadoMtto] PRIMARY KEY CLUSTERED ([Id] ASC)
);

