CREATE VIEW [dbo].[BidItemFilterView]
	AS 
		SELECT 
			a.id,
			a.Created_At DateCreated,
			a.Close_Date BaseLineCloseDate,
			a.Title,
			a.Brand,
			a.Model,
			a.LocationId,
			b.LocationAddress,
			b.LocationDescription,
			c.Action Status
		FROM tblBidItems a
		JOIN tblLocations b ON b.Id = a.LocationId
		JOIN tblBidItemLog c ON c.BidItemId = a.id
		WHERE a.id IN 
			(
				SELECT
					BidItemId
				FROM 
					tblBidItemLog
			)
GO