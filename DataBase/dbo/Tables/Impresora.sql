CREATE TABLE [dbo].[Impresora] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CodigoActivoFijo] NVARCHAR (22)  NOT NULL,
    [MarcaId]          INT            NOT NULL,
    [ModeloId]         INT            NOT NULL,
    [EstadoId]         INT            NOT NULL,
    [DireccionIP]      NVARCHAR (15)  NULL,
    [AreaId]           INT            NOT NULL,
    [UnidadId]         INT            NOT NULL,
    [InstitucionId]    INT            NOT NULL,
    [Responsable]      NVARCHAR (125) NULL,
    [FechaRegistro]    DATE           NULL,
    [Caracteristicas]  NVARCHAR (200) NULL,
    [NumeroSerie]      NVARCHAR (22)  NULL,
    CONSTRAINT [PK_Impresora] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ImpresoraAreaId] FOREIGN KEY ([AreaId]) REFERENCES [dbo].[Area] ([Id]),
    CONSTRAINT [FK_ImpresoraEstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [dbo].[Estado] ([Id]),
    CONSTRAINT [FK_ImpresoraInstitucionId] FOREIGN KEY ([InstitucionId]) REFERENCES [dbo].[Institucion] ([Id]),
    CONSTRAINT [FK_ImpresoraMarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [dbo].[Marca] ([Id]),
    CONSTRAINT [FK_ImpresoraModeloId] FOREIGN KEY ([ModeloId]) REFERENCES [dbo].[Modelo] ([Id]),
    CONSTRAINT [FK_ImpresoraUnidadId] FOREIGN KEY ([UnidadId]) REFERENCES [dbo].[Unidad] ([Id])
);

