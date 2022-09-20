
CREATE PROCEDURE [dbo].[spGetBidItemsByStatus]
	@status varchar
AS
	SELECT 
		a.id, 
		a.Title, 
		a.BaselineCloseDate, 
		a.Brand, 
		a.Model, 
		a.LocationAddress, 
		a.LocationDescription,
		a.Status
	From BidItemFilterView a
	WHERE a.Status = @status;
GO