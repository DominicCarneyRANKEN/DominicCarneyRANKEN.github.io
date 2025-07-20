IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    CREATE TABLE [Anime] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [AnimeLink] nvarchar(max) NULL,
        [ImagePath] nvarchar(max) NULL,
        [GenreId] int NULL,
        CONSTRAINT [PK_Anime] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    CREATE TABLE [Genres] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    CREATE TABLE [Users] (
        [AccountId] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NULL,
        [Email] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NULL,
        [Role] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([AccountId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    CREATE TABLE [AnimeGenres] (
        [AnimeId] int NOT NULL,
        [GenreId] int NOT NULL,
        CONSTRAINT [PK_AnimeGenres] PRIMARY KEY ([AnimeId], [GenreId]),
        CONSTRAINT [FK_AnimeGenres_Anime_AnimeId] FOREIGN KEY ([AnimeId]) REFERENCES [Anime] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AnimeGenres_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    CREATE TABLE [Bookmarks] (
        [Id] int NOT NULL IDENTITY,
        [AccountId] int NOT NULL,
        [AnimeId] int NOT NULL,
        CONSTRAINT [PK_Bookmarks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Bookmarks_Anime_AnimeId] FOREIGN KEY ([AnimeId]) REFERENCES [Anime] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Bookmarks_Users_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Users] ([AccountId]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AnimeLink', N'Description', N'GenreId', N'ImagePath', N'Title') AND [object_id] = OBJECT_ID(N'[Anime]'))
        SET IDENTITY_INSERT [Anime] ON;
    EXEC(N'INSERT INTO [Anime] ([Id], [AnimeLink], [Description], [GenreId], [ImagePath], [Title])
    VALUES (1, N''https://www.crunchyroll.com/series/G649PJ0JY/blue-exorcist'', N''The story revolves around Rin Okumura, a teenager who discovers that he and his twin brother Yukio are the sons of Satan, born from a human woman, and he is the inheritor of Satan''''s powers.'', NULL, N''/AnimeImages/s-l1200.jpg'', N''Blue Exorcist''),
    (2, N''https://www.crunchyroll.com/series/G4PH0WEKE/blue-lock'', N'' Three hundred high school players are pitted against each other for the position, but only one will come out on top. Who among them will be the striker to usher in a new era of Japanese soccer?'', NULL, N''/AnimeImages/blueLock.jpg'', N''BLUE LOCK''),
    (3, N''https://www.crunchyroll.com/series/G63VMKVQY/yamada-kun-and-the-seven-witches'', N''Suzaku High School student and problem kid, Ryu Yamada, is in a bad mood after being chewed out again by the teacher today. As if his day couldn’t get any worse, he falls down the top of the stairs with honor student, Urara Shiraishi! When he comes to, he’s switched bodies with her!'', NULL, N''/AnimeImages/sevenWitches.jpg'', N''Yamada-kun and the Seven Witches''),
    (4, N''https://www.crunchyroll.com/series/GYZJ43JMR/that-time-i-got-reincarnated-as-a-slime'', CONCAT(CAST(N''Corporate worker Mikami Satoru is stabbed by a random killer, and is reborn to an alternate world. But he turns out to be reborn a slime!'' AS nvarchar(max)), nchar(13), nchar(10), N''Thrown into this new world with the name Rimuru, he begins his quest to create a world that’s welcoming to all races.''), NULL, N''/AnimeImages/reincarnationAsASlime.jpg'', N''That Time I Got Reincarnation as a Slime'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AnimeLink', N'Description', N'GenreId', N'ImagePath', N'Title') AND [object_id] = OBJECT_ID(N'[Anime]'))
        SET IDENTITY_INSERT [Anime] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
        SET IDENTITY_INSERT [Genres] ON;
    EXEC(N'INSERT INTO [Genres] ([Id], [Name])
    VALUES (1, N''Action''),
    (2, N''Adventure''),
    (3, N''Comedy''),
    (4, N''Drama''),
    (5, N''Fantasy''),
    (6, N''Romance''),
    (7, N''Sports'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
        SET IDENTITY_INSERT [Genres] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AccountId', N'Email', N'Password', N'Role', N'Username') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([AccountId], [Email], [Password], [Role], [Username])
    VALUES (1, N''admin@email.com'', N''password123'', N''Admin'', N''Admin_Creator''),
    (2, N''guest@email.com'', N''password123'', N''User'', N''Guest'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AccountId', N'Email', N'Password', N'Role', N'Username') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AnimeId', N'GenreId') AND [object_id] = OBJECT_ID(N'[AnimeGenres]'))
        SET IDENTITY_INSERT [AnimeGenres] ON;
    EXEC(N'INSERT INTO [AnimeGenres] ([AnimeId], [GenreId])
    VALUES (1, 1),
    (1, 2),
    (1, 3),
    (1, 5),
    (2, 4),
    (2, 7),
    (3, 3),
    (3, 4),
    (3, 5),
    (3, 6),
    (4, 1),
    (4, 2),
    (4, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AnimeId', N'GenreId') AND [object_id] = OBJECT_ID(N'[AnimeGenres]'))
        SET IDENTITY_INSERT [AnimeGenres] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccountId', N'AnimeId') AND [object_id] = OBJECT_ID(N'[Bookmarks]'))
        SET IDENTITY_INSERT [Bookmarks] ON;
    EXEC(N'INSERT INTO [Bookmarks] ([Id], [AccountId], [AnimeId])
    VALUES (1, 1, 1),
    (2, 1, 4)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccountId', N'AnimeId') AND [object_id] = OBJECT_ID(N'[Bookmarks]'))
        SET IDENTITY_INSERT [Bookmarks] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    CREATE INDEX [IX_AnimeGenres_GenreId] ON [AnimeGenres] ([GenreId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    CREATE INDEX [IX_Bookmarks_AccountId] ON [Bookmarks] ([AccountId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    CREATE INDEX [IX_Bookmarks_AnimeId] ON [Bookmarks] ([AnimeId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250423142450_Initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250423142450_Initial', N'9.0.4');
END;

COMMIT;
GO

