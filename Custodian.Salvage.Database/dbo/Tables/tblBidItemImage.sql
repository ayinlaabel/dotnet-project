CREATE TABLE [dbo].[tblBidItemImage] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [BidItemId] INT            NOT NULL,
    [ImageUrl]  NVARCHAR (250) NOT NULL,
    [Created_At] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_tblBidItemImage] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_tblBidItemImage_tblBidItems_idx] FOREIGN KEY ([BidItemId]) REFERENCES dbo.tblBidItems(Id)
);

