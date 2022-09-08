
CREATE PROCEDURE [dbo].[spGetBidItem]

	@id int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From tblBidItems where id = @id ;
	SELECT image_url from tblBidItemImage a where a.BidItem_ID = @id;

END
