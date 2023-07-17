CREATE TABLE [dbo].[Marca] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (MAX) NOT NULL,
    [Descripcion] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED ([Id] ASC)
);

