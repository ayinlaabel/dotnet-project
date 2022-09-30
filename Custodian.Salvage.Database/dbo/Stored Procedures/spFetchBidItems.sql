
CREATE PROCEDURE [dbo].[spFetchBidItems]
	
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
		a.ContactPerson,
		a.Regno,
		a.LocationAddress as address, 
		a.LocationDescription as state 
	From BidItemsView a;
END