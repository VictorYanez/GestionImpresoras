CREATE TABLE [dbo].[Unidad] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (MAX) NOT NULL,
    [AreaId]      INT            NOT NULL,
    [Descripcion] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Unidad] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Unidad_Area_AreaId] FOREIGN KEY ([AreaId]) REFERENCES [dbo].[Area] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UnidadAreaId] FOREIGN KEY ([AreaId]) REFERENCES [dbo].[Area] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Unidad_AreaId]
    ON [dbo].[Unidad]([AreaId] ASC);

