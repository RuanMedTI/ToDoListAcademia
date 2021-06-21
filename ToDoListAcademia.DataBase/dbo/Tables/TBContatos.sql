CREATE TABLE [dbo].[TBContatos] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (50)  NULL,
    [Email ]   VARCHAR (100) NULL,
    [Telefone] VARCHAR (15)  NULL,
    [Empresa]  VARCHAR (40)  NULL,
    [Cargo]    VARCHAR (40)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

