CREATE TABLE [dbo].[Mantenimiento] (
    [Id]                 INT  IDENTITY (1, 1) NOT NULL,
    [ImpresoraId]        INT  NOT NULL,
    [EstadoMttoId]       INT  NOT NULL,
    [FechaMantenimiento] DATE NULL,
    [FechaSolicitud]     DATE NULL,
    [EsLocal]            BIT  NULL,
    CONSTRAINT [PK_Mantenimiento] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Mantenimiento_EstadoMtto_EstadoId] FOREIGN KEY ([EstadoMttoId]) REFERENCES [dbo].[EstadoMtto] ([Id]),
    CONSTRAINT [FK_Mantenimiento_Impresora_ImpresoraId] FOREIGN KEY ([ImpresoraId]) REFERENCES [dbo].[Impresora] ([Id])
);

