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

