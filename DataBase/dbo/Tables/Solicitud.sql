CREATE TABLE [dbo].[Solicitud] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [ImpresoraId]       INT            NOT NULL,
    [EstadoSolicitudId] INT            NOT NULL,
    [FechaSolicitud]    DATE           NULL,
    [ColorSolicitado]   NVARCHAR (200) NULL,
    [Solicitante]       NVARCHAR (200) NULL,
    [FechaEntrega]      DATE           NULL,
    [MedioId]           INT            NOT NULL,
    [Detalle]           NVARCHAR (200) NULL,
    [ColorId]           INT            NOT NULL,
    [UrlImagen]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Medio_SolicitudId] FOREIGN KEY ([MedioId]) REFERENCES [dbo].[Medio] ([Id]),
    CONSTRAINT [FK_Solicitud_Color_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Color] ([Id]),
    CONSTRAINT [FK_Solicitud_EstadoSolicitud_EstadoSolicitudId] FOREIGN KEY ([EstadoSolicitudId]) REFERENCES [dbo].[EstadoSolicitud] ([Id]),
    CONSTRAINT [FK_Solicitud_Impresora_ImpresoraId] FOREIGN KEY ([ImpresoraId]) REFERENCES [dbo].[Impresora] ([Id])
);

