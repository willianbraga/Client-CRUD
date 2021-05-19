IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Client] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(100) NULL,
    [Email] varchar(100) NULL,
    [Phone] varchar(20) NULL,
    [BirthDate] datetime NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210519140437_Initial', N'3.1.1');

GO

