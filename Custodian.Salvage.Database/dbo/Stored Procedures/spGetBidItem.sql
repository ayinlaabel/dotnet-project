
CREATE PROCEDURE [dbo].[spGetBidItem]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		a.id, 
		a.Title, 
		a.BaselineCloseDate as close_date, 
		a.Brand, 
		a.Model, 
		a.Description,
		a.Regno,
		a.ContactPerson,
		a.LocationAddress as address, 
		a.LocationDescription as state
	From BidItemsView a
	WHERE a.id = @id;
END
