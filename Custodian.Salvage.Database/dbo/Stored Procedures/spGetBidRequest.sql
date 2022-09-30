CREATE PROCEDURE [dbo].[spGetRequestBid]
	@BidItemId Int,
	@Email VARCHAR(250)

AS
BEGIN
	SELECT 
		a.Email, 
		a.BidItemId, 
		a.BidValue, 
		a.Narration
	FROM BidRequestView a
	WHERE a.BidItemId = @BidItemId
	AND a.Email = @Email
END
GO
