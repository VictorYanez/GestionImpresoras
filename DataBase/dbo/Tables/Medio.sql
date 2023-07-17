CREATE TABLE [dbo].[Medio] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]       NVARCHAR (150) NOT NULL,
    [ConRespuesta] BIT            NULL,
    [Descripcion]  NVARCHAR (200) NULL,
    CONSTRAINT [PK_Medio] PRIMARY KEY CLUSTERED ([Id] ASC)
);

