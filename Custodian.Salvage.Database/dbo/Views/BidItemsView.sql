CREATE VIEW [dbo].[BidItemsView]
	AS SELECT
		a.id,
		a.Close_Date BaselineCloseDate,
		a.Created_At DateCreated,
		a.Brand,
		a.Model,
		a.LocationId,
		a.Title,
		b.LocationAddress,
		b.LocationDescription
	FROM dbo.tblBidItems a
	JOIN dbo.tblLocations b on b.Id = a.LocationId
GO
