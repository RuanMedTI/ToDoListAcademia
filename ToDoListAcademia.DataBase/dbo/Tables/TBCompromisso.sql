CREATE TABLE [dbo].[TBCompromisso] (
    [Id]              INT           NOT NULL,
    [Assunto]         VARCHAR (200) NULL,
    [Local]           VARCHAR (50)  NULL,
    [DataCompromisso] DATETIME      NULL,
    [HoraInicio]      VARCHAR (50)  NULL,
    [DataTermino]     DATETIME      NULL,
    [Id_Contato] INT NULL CONSTRAINT [FK_TBCompromisso_TBContatos]
		FOREIGN KEY ([Id_Contato]) REFERENCES [dbo].[TBContatos] ([Id])
		ON DELETE SET NULL
    CONSTRAINT [PK_TBCompromisso] PRIMARY KEY CLUSTERED ([Id] ASC)
);
