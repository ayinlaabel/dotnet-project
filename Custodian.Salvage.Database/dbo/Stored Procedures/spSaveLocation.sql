CREATE PROCEDURE [dbo].[spSaveLocation]
	@locationId INT OUT,
	@LocationAddress VARCHAR(250),
	@LocationDescription VARCHAR(250)
AS
BEGIN
	INSERT INTO dbo.tblLocations (LocationAddress, LocationDescription)
	VALUES (@LocationAddress, @LocationDescription);

	SET @locationId = SCOPE_IDENTITY();
END
GO