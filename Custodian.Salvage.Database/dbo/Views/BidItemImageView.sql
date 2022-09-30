CREATE VIEW [dbo].[BidItemImageView]
	AS SELECT 
		a.BidItemId,
		a.ImageUrl,
		a.ImageTag
	FROM dbo.tblBidItemImage a
GO
