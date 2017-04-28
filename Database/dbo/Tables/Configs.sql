CREATE TABLE [dbo].[Configs] (
    [ConfigId] INT             IDENTITY (1, 1) NOT NULL,
    [Key]      NVARCHAR (50)   NOT NULL,
    [Group]    NVARCHAR (50)   NOT NULL,
    [Value]    NVARCHAR (1024) NOT NULL,
    CONSTRAINT [PK_dbo.Configs] PRIMARY KEY CLUSTERED ([ConfigId] ASC)
);

