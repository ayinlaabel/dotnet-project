CREATE TABLE [dbo].[tblBidItemImage] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [BidItem_ID] INT            NOT NULL,
    [Image_URL]  NVARCHAR (250) NOT NULL,
    [Created_At] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_tblBidItemImage] PRIMARY KEY CLUSTERED ([id] ASC)
);

