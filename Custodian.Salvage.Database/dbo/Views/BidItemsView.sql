CREATE VIEW [dbo].[BidItemsView]
	AS SELECT
		a.id BidItemId,
		a.Close_Date BaselineCloseDate,
		a.Created_At DateCreated,
		a.LocationId,
		a.Title,
		b.LocationAddress,
		b.LocationDescription
	FROM dbo.tblBidItems a
	JOIN dbo.tblLocations b on b.Id = a.LocationId
GO
