CREATE TABLE [dbo].[tblBid] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [First_Name]   VARCHAR (250) NOT NULL,
    [Last_Name]    VARCHAR (250) NOT NULL,
    [Email]        VARCHAR (100) NOT NULL,
    [Phone_Number] VARCHAR (25)  NOT NULL,
    [BID_Value]    VARCHAR (50)  NOT NULL,
    [BidItem_ID]   INT           NOT NULL,
    [Created_At]   DATETIME2 (7) NULL,
    CONSTRAINT [PK_tblBid] PRIMARY KEY CLUSTERED ([id] ASC)
);

