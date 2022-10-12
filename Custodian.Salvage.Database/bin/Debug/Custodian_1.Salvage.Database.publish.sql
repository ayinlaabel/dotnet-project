﻿/*
Deployment script for salvage

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "salvage"
:setvar DefaultFilePrefix "salvage"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'Creating Table [dbo].[tblAdmin]...';


GO
CREATE TABLE [dbo].[tblAdmin] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [First_Name]   VARCHAR (200) NOT NULL,
    [Last_Name]    VARCHAR (200) NOT NULL,
    [email]        VARCHAR (100) NOT NULL,
    [Phone_Number] VARCHAR (50)  NOT NULL,
    [Password]     VARCHAR (100) NOT NULL,
    [role]         VARCHAR (50)  NOT NULL,
    [Created_At]   DATETIME2 (7) NOT NULL,
    [Updated_At]   DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating Table [dbo].[tblAuditLog]...';


GO
CREATE TABLE [dbo].[tblAuditLog] (
    [Id]         INT           NOT NULL,
    [AdminId]    INT           NOT NULL,
    [BidItemId]  INT           NOT NULL,
    [Action]     VARCHAR (250) NOT NULL,
    [ActionDate] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[tblBidItemImage]...';


GO
CREATE TABLE [dbo].[tblBidItemImage] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [BidItemId]  INT            NOT NULL,
    [ImageUrl]   NVARCHAR (250) NOT NULL,
    [ImageTag]   VARCHAR (100)  NOT NULL,
    [Created_At] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_tblBidItemImage] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating Table [dbo].[tblBidItemLog]...';


GO
CREATE TABLE [dbo].[tblBidItemLog] (
    [Id]         INT           NOT NULL,
    [AdminId]    INT           NOT NULL,
    [BidItemId]  INT           NOT NULL,
    [Action]     VARCHAR (250) NOT NULL,
    [ActionDate] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[tblBidItems]...';


GO
CREATE TABLE [dbo].[tblBidItems] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [Title]         VARCHAR (50)  NOT NULL,
    [Regno]         VARCHAR (100) NOT NULL,
    [Description]   VARCHAR (250) NOT NULL,
    [ContactPerson] VARCHAR (100) NOT NULL,
    [Brand]         VARCHAR (50)  NOT NULL,
    [Model]         VARCHAR (50)  NOT NULL,
    [Close_Date]    DATETIME2 (7) NOT NULL,
    [LocationId]    INT           NOT NULL,
    [Created_At]    DATETIME      NOT NULL,
    CONSTRAINT [PK_tblItems] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating Table [dbo].[tblBidRequest]...';


GO
CREATE TABLE [dbo].[tblBidRequest] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [BidItemId]  INT           NOT NULL,
    [Email]      VARCHAR (100) NOT NULL,
    [Narration]  VARCHAR (250) NOT NULL,
    [Status]     VARCHAR (10)  NOT NULL,
    [BidValue]   VARCHAR (50)  NOT NULL,
    [Created_At] DATETIME2 (7) NOT NULL,
    [Updated_At] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_tblBid] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating Table [dbo].[tblBidUploadDetail]...';


GO
CREATE TABLE [dbo].[tblBidUploadDetail] (
    [Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[tblBidUploads]...';


GO
CREATE TABLE [dbo].[tblBidUploads] (
    [Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[tblLocations]...';


GO
CREATE TABLE [dbo].[tblLocations] (
    [Id]                  INT           NOT NULL,
    [LocationAddress]     VARCHAR (250) NULL,
    [LocationDescription] VARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblBidItemImage_tblBidItems_idx]...';


GO
ALTER TABLE [dbo].[tblBidItemImage] WITH NOCHECK
    ADD CONSTRAINT [FK_tblBidItemImage_tblBidItems_idx] FOREIGN KEY ([BidItemId]) REFERENCES [dbo].[tblBidItems] ([id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblBidItems_tblLocation_idx]...';


GO
ALTER TABLE [dbo].[tblBidItems] WITH NOCHECK
    ADD CONSTRAINT [FK_tblBidItems_tblLocation_idx] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[tblLocations] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblBid_tblBidItems_Idx]...';


GO
ALTER TABLE [dbo].[tblBidRequest] WITH NOCHECK
    ADD CONSTRAINT [FK_tblBid_tblBidItems_Idx] FOREIGN KEY ([BidItemId]) REFERENCES [dbo].[tblBidItems] ([id]);


GO
PRINT N'Creating View [dbo].[BidItemFilterView]...';


GO
CREATE VIEW [dbo].[BidItemFilterView]
	AS 
		SELECT 
			a.id,
			a.Created_At DateCreated,
			a.Close_Date BaseLineCloseDate,
			a.Title,
			a.Brand,
			a.Model,
			a.LocationId,
			b.LocationAddress,
			b.LocationDescription,
			c.Action Status
		FROM tblBidItems a
		JOIN tblLocations b ON b.Id = a.LocationId
		JOIN tblBidItemLog c ON c.BidItemId = a.id
		WHERE a.id IN 
			(
				SELECT
					BidItemId
				FROM 
					tblBidItemLog
			)
GO
PRINT N'Creating View [dbo].[BidItemImageView]...';


GO
CREATE VIEW [dbo].[BidItemImageView]
	AS SELECT 
		a.BidItemId,
		a.ImageUrl,
		a.ImageTag
	FROM dbo.tblBidItemImage a
GO
PRINT N'Creating View [dbo].[BidItemsView]...';


GO
CREATE VIEW [dbo].[BidItemsView]
	AS SELECT
		a.id,
		a.Title,
		a.Brand,
		a.Model,
		a.LocationId,
		b.LocationAddress,
		b.LocationDescription,
		a.Description,
		c.ImageTag,
		c.ImageUrl,
		a.Close_Date BaselineCloseDate,
		a.Created_At DateCreated
	FROM dbo.tblBidItems a
	JOIN dbo.tblLocations b on b.Id = a.LocationId
	JOIN dbo.tblBidItemImage c on c.BidItemId = a.id
GO
PRINT N'Creating View [dbo].[BidRequestView]...';


GO
CREATE VIEW [dbo].[BidRequestView]
	AS SELECT
		a.id,
		a.BidItemId,
		a.Email,
		a.BidValue,
		a.Narration
	FROM dbo.tblBidRequest a
GO
PRINT N'Creating Procedure [dbo].[SaveBidItem]...';


GO
CREATE PROCEDURE [dbo].[SaveBidItem]
	@Title VARCHAR(100),
	@Brand VARCHAR(100),
	@Model VARCHAR(100),
	@Created_At DATETIME,
	@Close_Date DATETIME,
	@LocationId INT
AS
BEGIN
	INSERT INTO dbo.tblBidItems (Title, Brand, Model, Close_Date, Created_At, LocationId) 
	VALUES (@Title, @Brand, @Model, @Close_Date, @Created_At, @LocationId);
END
GO
PRINT N'Creating Procedure [dbo].[spFetchBidItems]...';


GO

CREATE PROCEDURE [dbo].[spFetchBidItems]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		a.id, 
		a.Title, 
		a.BaselineCloseDate, 
		a.Brand, 
		a.Model, 
		a.ImageTag,
		a.ImageUrl,
		a.LocationAddress, 
		a.LocationDescription 
	From BidItemsView a;
END
GO
PRINT N'Creating Procedure [dbo].[spGetBidItem]...';


GO

CREATE PROCEDURE [dbo].[spGetBidItem]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		a.id, 
		a.Title, 
		a.BaselineCloseDate, 
		a.Brand, 
		a.Model, 
		a.LocationAddress, 
		a.LocationDescription 
	From BidItemsView a
	WHERE a.id = @id;
END
GO
PRINT N'Creating Procedure [dbo].[spGetBidItemImage]...';


GO
CREATE PROCEDURE [dbo].[spGetBidItemImage]
	@id int
AS
BEGIN

	SELECT  
		a.ImageUrl
	FROM BidItemImageView a
	WHERE a.BidItemId = @id;

END
GO
PRINT N'Creating Procedure [dbo].[spGetBidItemsByStatus]...';


GO

CREATE PROCEDURE [dbo].[spGetBidItemsByStatus]
	@status varchar
AS
	SELECT 
		a.id, 
		a.Title, 
		a.BaselineCloseDate, 
		a.Brand, 
		a.Model, 
		a.LocationAddress, 
		a.LocationDescription,
		a.Status
	From BidItemFilterView a
	WHERE a.Status = @status;
GO
PRINT N'Creating Procedure [dbo].[spGetRequestBid]...';


GO
CREATE PROCEDURE [dbo].[spGetRequestBid]
	@BidItemId Int,
	@Email VARCHAR(250)

AS
BEGIN
	SELECT 
		a.Email, 
		a.BidItemId, 
		a.BidValue, 
		a.Narration
	FROM BidRequestView a
	WHERE a.BidItemId = @BidItemId
	AND a.Email = @Email
END
GO
PRINT N'Creating Procedure [dbo].[spSaveBid]...';


GO
CREATE PROCEDURE [dbo].[spSaveBid]
	@BidItemId INT,
	@Email VARCHAR(250),
	@Narration VARCHAR(250),
	@Status VARCHAR(10),
	@BidValue INT,
	@Created_At DATETIME,
	@Updated_At DATETIME
AS
BEGIN
	INSERT INTO dbo.tblBidRequest
		(
			BidItemId, 
			Email,  
			Narration, 
			Status,
			BidValue,
			Created_At,
			Updated_At
		)
	VALUES 
		(
			@BidItemId,
			@Email,
			@Narration,
			@Status,
			@BidValue,
			@Created_At,
			@Updated_At
		);
END
GO
PRINT N'Creating Procedure [dbo].[spSaveBidItemImage]...';


GO
CREATE PROCEDURE [dbo].[spSaveBidItemImage]
	@BidItemId INT,
	@ImageUrl VARCHAR
AS
	INSERT INTO dbo.tblBidItemImage (BidItemId, ImageUrl)
	VALUES (@BidItemId, @ImageUrl);
GO
PRINT N'Creating Procedure [dbo].[spSaveLocation]...';


GO
CREATE PROCEDURE [dbo].[spSaveLocation]
	@locationId INT OUT,
	@LocationAddress VARCHAR(250),
	@LocationDescription VARCHAR(250)
AS
BEGIN
	INSERT INTO dbo.tblLocations (LocationAddress, LocationDescription)
	VALUES (@LocationAddress, @LocationDescription);

	SET @locationId = SCOPE_IDENTITY();
END
GO
PRINT N'Creating Procedure [dbo].[UpdateBidRequest]...';


GO
CREATE PROCEDURE [dbo].[UpdateBidRequest]
	@BidItemId int,
	@Email VARCHAR(250),
	@Status VARCHAR(250),
	@Updated_At DATETIME
AS
BEGIN
	UPDATE tblBidRequest
	SET Status = @Status, 
		Updated_At =  @Updated_At
	WHERE BidItemId = @BidItemId
	AND Email = @Email
	AND Status = 'active'
END
GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblBidItemImage] WITH CHECK CHECK CONSTRAINT [FK_tblBidItemImage_tblBidItems_idx];

ALTER TABLE [dbo].[tblBidItems] WITH CHECK CHECK CONSTRAINT [FK_tblBidItems_tblLocation_idx];

ALTER TABLE [dbo].[tblBidRequest] WITH CHECK CHECK CONSTRAINT [FK_tblBid_tblBidItems_Idx];


GO
PRINT N'Update complete.';


GO