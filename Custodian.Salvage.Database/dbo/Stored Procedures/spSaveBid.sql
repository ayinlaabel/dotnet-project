CREATE PROCEDURE [dbo].[spSaveBid]
	@FirstName VARCHAR(250),
	@LastName VARCHAR(250),
	@Email VARCHAR(250),
	@Phone VARCHAR(50),
	@BidValue INT,
	@BidItemId INT,
	@Narration VARCHAR(250),
	@Created_At DATETIME
AS
BEGIN
	INSERT INTO dbo.tblBid 
		(
			FirstName, 
			LastName, 
			Email, 
			Phone, 
			BidValue,
			BidItemId, 
			Narration, 
			Created_At
		)
	VALUES 
		(
			@FirstName,
			@LastName,
			@Email,
			@Phone,
			@BidValue,
			@BidItemId,
			@Narration,
			@Created_At
		);
END
GO
