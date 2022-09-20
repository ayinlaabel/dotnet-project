
CREATE PROCEDURE [dbo].[spFetchBidItems]
	
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
	From BidItemsView a;
END