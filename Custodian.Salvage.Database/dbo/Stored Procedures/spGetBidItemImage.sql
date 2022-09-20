CREATE PROCEDURE [dbo].[spGetBidItemImage]
	@id int
AS
BEGIN

	SELECT  
		a.ImageUrl
	FROM BidItemImageView a
	WHERE a.BidItemId = @id;

END