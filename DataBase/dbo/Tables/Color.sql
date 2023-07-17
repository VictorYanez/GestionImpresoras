CREATE TABLE [dbo].[Color] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Nombre] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED ([Id] ASC)
);

