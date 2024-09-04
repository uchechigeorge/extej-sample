IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [dbo].[__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [dbo].[Transactions] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Reference] nvarchar(1024) NULL,
    [Amount] decimal(18,2) NULL,
    [Value] decimal(18,2) NULL,
    [Type] int NULL,
    [StatusId] int NOT NULL DEFAULT 0,
    [TransactionDate] datetime2 NULL,
    [DateModified] datetime2 NOT NULL DEFAULT ((GETUTCDATE())),
    [DateCreated] datetime2 NOT NULL DEFAULT ((GETUTCDATE())),
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240903203522_InitialCreate', N'8.0.4');
GO

COMMIT;
GO

