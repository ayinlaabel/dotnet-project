
CREATE PROCEDURE [dbo].[spFetchBidItems]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT tblBidItems.id, tblBidItems.Title, tblBidItems.Status, tblBidItems.State, tblBidItems.Location,
	--tblBidItems.Close_Date as [Close Date], tblBidItemImage.Image_URL 
	--From tblBidItems INNER JOIN tblBidItemImage
	--ON tblBidItems.id = tblBidItemImage.BidItem_ID

	SELECT * From tblBidItems b
	JOIN tblBidItemImage i
	ON b.id = i.BidItem_ID

END