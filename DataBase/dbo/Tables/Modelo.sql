CREATE TABLE [dbo].[Modelo] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (MAX) NOT NULL,
    [MarcaId]     INT            NOT NULL,
    [Descripcion] NVARCHAR (200) NULL,
    [EsdeColor]   BIT            NULL,
    CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Modelo_Marca_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [dbo].[Marca] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Modelo_MarcaId]
    ON [dbo].[Modelo]([MarcaId] ASC);

