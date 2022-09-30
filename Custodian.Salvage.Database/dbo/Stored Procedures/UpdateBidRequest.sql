CREATE PROCEDURE [dbo].[UpdateBidRequest]
	@BidItemId int,
	@Email VARCHAR(250),
	@Status VARCHAR(250),
	@Updated_At DATETIME
AS
BEGIN
	UPDATE tblBidRequest
	SET Status = @Status, 
		Updated_At =  @Updated_At
	WHERE BidItemId = @BidItemId
	AND Email = @Email
	AND Status = 'active'
END
GO