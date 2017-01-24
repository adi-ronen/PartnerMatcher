
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/24/2017 12:46:07
-- Generated from EDMX file: D:\oll\nituz\yad2\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Yad2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AddCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Adds] DROP CONSTRAINT [FK_AddCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_AddLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Adds] DROP CONSTRAINT [FK_AddLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupAdd]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Adds] DROP CONSTRAINT [FK_GroupAdd];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_GroupCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupManager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_GroupManager];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupPartner_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupPartner] DROP CONSTRAINT [FK_GroupPartner_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupPartner_Partner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupPartner] DROP CONSTRAINT [FK_GroupPartner_Partner];
GO
IF OBJECT_ID(N'[dbo].[FK_Manager_inherits_Partner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Manager] DROP CONSTRAINT [FK_Manager_inherits_Partner];
GO
IF OBJECT_ID(N'[dbo].[FK_Partner_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Partner] DROP CONSTRAINT [FK_Partner_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_PartnersAds]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Adds] DROP CONSTRAINT [FK_PartnersAds];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMessageCreat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_UserMessageCreat];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMessageRecived_Message]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserMessageRecived] DROP CONSTRAINT [FK_UserMessageRecived_Message];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMessageRecived_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserMessageRecived] DROP CONSTRAINT [FK_UserMessageRecived_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Adds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Adds];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[GroupPartner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupPartner];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[Request]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Request];
GO
IF OBJECT_ID(N'[dbo].[UserMessageRecived]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserMessageRecived];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Users_Manager]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Manager];
GO
IF OBJECT_ID(N'[dbo].[Users_Partner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Partner];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Adds'
CREATE TABLE [dbo].[Adds] (
    [id] int  NOT NULL,
    [DatePublished] datetime  NOT NULL,
    [EventDate] datetime  NULL,
    [About] varchar(500)  NULL,
    [CategoryType] varchar(50)  NOT NULL,
    [LocationArea] varchar(50)  NOT NULL,
    [PartnerEmail] varchar(50)  NOT NULL,
    [Group_Id] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Type] varchar(50)  NOT NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Area] varchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Email] varchar(50)  NOT NULL,
    [Password] nchar(10)  NOT NULL,
    [FirstName] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [Age] int  NOT NULL,
    [Gender] bit  NOT NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [Id] int  NOT NULL,
    [ManagerEmail] varchar(50)  NOT NULL,
    [CategoryType] varchar(50)  NOT NULL,
    [Chat] varchar(1000)  NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [UserEmail] varchar(50)  NOT NULL
);
GO

-- Creating table 'Requests'
CREATE TABLE [dbo].[Requests] (
    [Id] int  NOT NULL,
    [status] bit  NOT NULL,
    [Rank] int  NULL,
    [Date] datetime  NOT NULL,
    [Add_id] int  NOT NULL,
    [User_Email] varchar(50)  NOT NULL,
    [Partner_Email] varchar(50)  NOT NULL
);
GO

-- Creating table 'Users_Partner'
CREATE TABLE [dbo].[Users_Partner] (
    [Email] varchar(50)  NOT NULL
);
GO

-- Creating table 'Users_Manager'
CREATE TABLE [dbo].[Users_Manager] (
    [Email] varchar(50)  NOT NULL
);
GO

-- Creating table 'GroupPartner'
CREATE TABLE [dbo].[GroupPartner] (
    [PartnerIn_Id] int  NOT NULL,
    [Partners_Email] varchar(50)  NOT NULL
);
GO

-- Creating table 'UserMessageRecived'
CREATE TABLE [dbo].[UserMessageRecived] (
    [UsersInMessage_Email] varchar(50)  NOT NULL,
    [MessagesRecived_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Adds'
ALTER TABLE [dbo].[Adds]
ADD CONSTRAINT [PK_Adds]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Type] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Type] ASC);
GO

-- Creating primary key on [Area] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([Area] ASC);
GO

-- Creating primary key on [Email] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Email] ASC);
GO

-- Creating primary key on [Id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [PK_Requests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Email] in table 'Users_Partner'
ALTER TABLE [dbo].[Users_Partner]
ADD CONSTRAINT [PK_Users_Partner]
    PRIMARY KEY CLUSTERED ([Email] ASC);
GO

-- Creating primary key on [Email] in table 'Users_Manager'
ALTER TABLE [dbo].[Users_Manager]
ADD CONSTRAINT [PK_Users_Manager]
    PRIMARY KEY CLUSTERED ([Email] ASC);
GO

-- Creating primary key on [PartnerIn_Id], [Partners_Email] in table 'GroupPartner'
ALTER TABLE [dbo].[GroupPartner]
ADD CONSTRAINT [PK_GroupPartner]
    PRIMARY KEY CLUSTERED ([PartnerIn_Id], [Partners_Email] ASC);
GO

-- Creating primary key on [UsersInMessage_Email], [MessagesRecived_Id] in table 'UserMessageRecived'
ALTER TABLE [dbo].[UserMessageRecived]
ADD CONSTRAINT [PK_UserMessageRecived]
    PRIMARY KEY CLUSTERED ([UsersInMessage_Email], [MessagesRecived_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryType] in table 'Adds'
ALTER TABLE [dbo].[Adds]
ADD CONSTRAINT [FK_AddCategory]
    FOREIGN KEY ([CategoryType])
    REFERENCES [dbo].[Categories]
        ([Type])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddCategory'
CREATE INDEX [IX_FK_AddCategory]
ON [dbo].[Adds]
    ([CategoryType]);
GO

-- Creating foreign key on [LocationArea] in table 'Adds'
ALTER TABLE [dbo].[Adds]
ADD CONSTRAINT [FK_AddLocation]
    FOREIGN KEY ([LocationArea])
    REFERENCES [dbo].[Locations]
        ([Area])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddLocation'
CREATE INDEX [IX_FK_AddLocation]
ON [dbo].[Adds]
    ([LocationArea]);
GO

-- Creating foreign key on [Group_Id] in table 'Adds'
ALTER TABLE [dbo].[Adds]
ADD CONSTRAINT [FK_GroupAdd]
    FOREIGN KEY ([Group_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupAdd'
CREATE INDEX [IX_FK_GroupAdd]
ON [dbo].[Adds]
    ([Group_Id]);
GO

-- Creating foreign key on [ManagerEmail] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_GroupManager]
    FOREIGN KEY ([ManagerEmail])
    REFERENCES [dbo].[Users_Manager]
        ([Email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupManager'
CREATE INDEX [IX_FK_GroupManager]
ON [dbo].[Groups]
    ([ManagerEmail]);
GO

-- Creating foreign key on [PartnerIn_Id] in table 'GroupPartner'
ALTER TABLE [dbo].[GroupPartner]
ADD CONSTRAINT [FK_GroupPartner_Group]
    FOREIGN KEY ([PartnerIn_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Partners_Email] in table 'GroupPartner'
ALTER TABLE [dbo].[GroupPartner]
ADD CONSTRAINT [FK_GroupPartner_Partner]
    FOREIGN KEY ([Partners_Email])
    REFERENCES [dbo].[Users_Partner]
        ([Email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupPartner_Partner'
CREATE INDEX [IX_FK_GroupPartner_Partner]
ON [dbo].[GroupPartner]
    ([Partners_Email]);
GO

-- Creating foreign key on [CategoryType] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_GroupCategory]
    FOREIGN KEY ([CategoryType])
    REFERENCES [dbo].[Categories]
        ([Type])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupCategory'
CREATE INDEX [IX_FK_GroupCategory]
ON [dbo].[Groups]
    ([CategoryType]);
GO

-- Creating foreign key on [UserEmail] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_UserMessageCreat]
    FOREIGN KEY ([UserEmail])
    REFERENCES [dbo].[Users]
        ([Email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessageCreat'
CREATE INDEX [IX_FK_UserMessageCreat]
ON [dbo].[Messages]
    ([UserEmail]);
GO

-- Creating foreign key on [UsersInMessage_Email] in table 'UserMessageRecived'
ALTER TABLE [dbo].[UserMessageRecived]
ADD CONSTRAINT [FK_UserMessageRecived_User]
    FOREIGN KEY ([UsersInMessage_Email])
    REFERENCES [dbo].[Users]
        ([Email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MessagesRecived_Id] in table 'UserMessageRecived'
ALTER TABLE [dbo].[UserMessageRecived]
ADD CONSTRAINT [FK_UserMessageRecived_Message]
    FOREIGN KEY ([MessagesRecived_Id])
    REFERENCES [dbo].[Messages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessageRecived_Message'
CREATE INDEX [IX_FK_UserMessageRecived_Message]
ON [dbo].[UserMessageRecived]
    ([MessagesRecived_Id]);
GO

-- Creating foreign key on [PartnerEmail] in table 'Adds'
ALTER TABLE [dbo].[Adds]
ADD CONSTRAINT [FK_PartnersAds]
    FOREIGN KEY ([PartnerEmail])
    REFERENCES [dbo].[Users_Partner]
        ([Email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PartnersAds'
CREATE INDEX [IX_FK_PartnersAds]
ON [dbo].[Adds]
    ([PartnerEmail]);
GO

-- Creating foreign key on [Add_id] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK_RequestAdd]
    FOREIGN KEY ([Add_id])
    REFERENCES [dbo].[Adds]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RequestAdd'
CREATE INDEX [IX_FK_RequestAdd]
ON [dbo].[Requests]
    ([Add_id]);
GO

-- Creating foreign key on [User_Email] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK_RequestUser]
    FOREIGN KEY ([User_Email])
    REFERENCES [dbo].[Users]
        ([Email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RequestUser'
CREATE INDEX [IX_FK_RequestUser]
ON [dbo].[Requests]
    ([User_Email]);
GO

-- Creating foreign key on [Partner_Email] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK_PartnerRequest]
    FOREIGN KEY ([Partner_Email])
    REFERENCES [dbo].[Users_Partner]
        ([Email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PartnerRequest'
CREATE INDEX [IX_FK_PartnerRequest]
ON [dbo].[Requests]
    ([Partner_Email]);
GO

-- Creating foreign key on [Email] in table 'Users_Partner'
ALTER TABLE [dbo].[Users_Partner]
ADD CONSTRAINT [FK_Partner_inherits_User]
    FOREIGN KEY ([Email])
    REFERENCES [dbo].[Users]
        ([Email])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Email] in table 'Users_Manager'
ALTER TABLE [dbo].[Users_Manager]
ADD CONSTRAINT [FK_Manager_inherits_Partner]
    FOREIGN KEY ([Email])
    REFERENCES [dbo].[Users_Partner]
        ([Email])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------