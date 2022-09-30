CREATE VIEW [dbo].[BidRequestView]
	AS SELECT
		a.id,
		a.BidItemId,
		a.Email,
		a.BidValue,
		a.Narration
	FROM dbo.tblBidRequest a
GO
