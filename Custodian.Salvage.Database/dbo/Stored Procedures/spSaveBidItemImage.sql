CREATE PROCEDURE [dbo].[spSaveBidItemImage]
	@BidItemId INT,
	@ImageUrl VARCHAR
AS
	INSERT INTO dbo.tblBidItemImage (BidItemId, ImageUrl)
	VALUES (@BidItemId, @ImageUrl);
GO