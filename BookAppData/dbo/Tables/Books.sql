CREATE TABLE [dbo].[Books] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (MAX)  NOT NULL,
    [Year]     INT             NOT NULL,
    [Price]    DECIMAL (18, 2) NOT NULL,
    [Genre]    NVARCHAR (MAX)  NOT NULL,
    [Publiser] NVARCHAR (MAX)  NULL,
    [AuthorID] INT             NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Books_Authors_AuthorID] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Authors] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Books_AuthorID]
    ON [dbo].[Books]([AuthorID] ASC);

