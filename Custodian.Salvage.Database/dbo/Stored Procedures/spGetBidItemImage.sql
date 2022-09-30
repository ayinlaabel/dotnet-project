CREATE PROCEDURE [dbo].[spGetBidItemImage]
	@id int
AS
BEGIN

	SELECT  
		a.ImageTag,
		a.ImageUrl
	FROM BidItemImageView a
	WHERE a.BidItemId = @id;

END