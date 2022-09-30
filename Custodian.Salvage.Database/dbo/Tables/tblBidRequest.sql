CREATE TABLE [dbo].[tblBidRequest] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [BidItemId]   INT           NOT NULL,
    [Email]        VARCHAR (100) NOT NULL,
    [Narration] VARCHAR(250) NOT NULL,
    [Status] VARCHAR(10) NOT NULL,
    [BidValue]    VARCHAR (50)  NOT NULL,
    [Created_At]   DATETIME2 (7) NOT NULL,
    [Updated_At]   DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_tblBid] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_tblBid_tblBidItems_Idx] FOREIGN KEY ([BidItemId]) REFERENCES dbo.tblBidItems(id)
    
);

