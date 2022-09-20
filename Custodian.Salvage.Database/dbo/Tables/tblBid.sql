CREATE TABLE [dbo].[tblBid] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (250) NOT NULL,
    [LastName]    VARCHAR (250) NOT NULL,
    [Email]        VARCHAR (100) NOT NULL,
    [Phone] VARCHAR (25)  NOT NULL,
    [BidValue]    VARCHAR (50)  NOT NULL,
    [BidItemId]   INT           NOT NULL,
    [Narration] VARCHAR(250) NOT NULL,
    [Created_At]   DATETIME2 (7) NULL,
    CONSTRAINT [PK_tblBid] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_tblBid_tblBidItems_Idx] FOREIGN KEY ([BidItemId]) REFERENCES dbo.tblBidItems(id)
    
);

