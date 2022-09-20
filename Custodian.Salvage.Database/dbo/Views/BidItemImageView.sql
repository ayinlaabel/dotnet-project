CREATE VIEW [dbo].[BidItemImageView]
	AS SELECT 
		a.BidItemId,
		a.ImageUrl
	FROM dbo.tblBidItemImage a
GO
