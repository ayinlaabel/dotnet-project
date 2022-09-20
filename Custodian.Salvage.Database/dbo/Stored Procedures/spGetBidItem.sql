
CREATE PROCEDURE [dbo].[spGetBidItem]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		a.id, 
		a.Title, 
		a.BaselineCloseDate, 
		a.Brand, 
		a.Model, 
		a.LocationAddress, 
		a.LocationDescription 
	From BidItemsView a
	WHERE a.id = @id;
END
