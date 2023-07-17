CREATE TABLE [dbo].[Institucion] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (MAX) NOT NULL,
    [Descripcion] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Institucion] PRIMARY KEY CLUSTERED ([Id] ASC)
);

