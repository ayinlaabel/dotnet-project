CREATE PROCEDURE [dbo].[spSaveBid]
	@BidItemId INT,
	@Email VARCHAR(250),
	@Narration VARCHAR(250),
	@Status VARCHAR(10),
	@BidValue INT,
	@Created_At DATETIME,
	@Updated_At DATETIME
AS
BEGIN
	INSERT INTO dbo.tblBidRequest
		(
			BidItemId, 
			Email,  
			Narration, 
			Status,
			BidValue,
			Created_At,
			Updated_At
		)
	VALUES 
		(
			@BidItemId,
			@Email,
			@Narration,
			@Status,
			@BidValue,
			@Created_At,
			@Updated_At
		);
END
GO
