
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/26/2021 18:12:52
-- Generated from EDMX file: D:\Учеба\CS3\Home_work7\MovieTicketSalesEF\MovieDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MovieDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderId] int IDENTITY(1,1) NOT NULL,
    [TiketsCount] int  NOT NULL,
    [OrderTime] nvarchar(max)  NOT NULL,
    [SeanceSeanceId] int  NOT NULL
);
GO

-- Creating table 'Seances'
CREATE TABLE [dbo].[Seances] (
    [SeanceId] int IDENTITY(1,1) NOT NULL,
    [MovieName] nvarchar(max)  NOT NULL,
    [SeanceTime] time  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OrderId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [SeanceId] in table 'Seances'
ALTER TABLE [dbo].[Seances]
ADD CONSTRAINT [PK_Seances]
    PRIMARY KEY CLUSTERED ([SeanceId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SeanceSeanceId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderSeance]
    FOREIGN KEY ([SeanceSeanceId])
    REFERENCES [dbo].[Seances]
        ([SeanceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderSeance'
CREATE INDEX [IX_FK_OrderSeance]
ON [dbo].[Orders]
    ([SeanceSeanceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------