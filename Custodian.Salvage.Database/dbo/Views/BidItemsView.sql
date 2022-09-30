CREATE VIEW [dbo].[BidItemsView]
	AS SELECT
		a.id,
		a.Title,
		a.Regno,
		a.Brand,
		a.Model,
		a.ContactPerson,
		b.LocationAddress,
		b.LocationDescription,
		a.Description,
		a.Close_Date BaselineCloseDate,
		a.Created_At DateCreated
	FROM dbo.tblBidItems a
	JOIN dbo.tblLocations b on b.Id = a.LocationId
GO
