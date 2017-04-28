CREATE TABLE [dbo].[Log] (
    [LogId]        INT              IDENTITY (1, 1) NOT NULL,
	[Level] [nvarchar](50) NOT NULL,
	[Logger] nvarchar(128) NOT NULL,
	[ThreadId] nvarchar(50) NOT NULL,
	[Exception] nvarchar(128) NULL,
    [Content]      NVARCHAR (MAX)   NULL,
    [StackTrace]   NVARCHAR (MAX)   NULL,
    [Date_Created] DATETIME2 (7)    CONSTRAINT [DF_Log_Date_Created] DEFAULT (getdate()) NOT NULL,
    [User_Created] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([LogId] ASC)
);

