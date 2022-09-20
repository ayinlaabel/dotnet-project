CREATE PROCEDURE [dbo].[SaveBidItem]
	@Title VARCHAR(100),
	@Brand VARCHAR(100),
	@Model VARCHAR(100),
	@Created_At DATETIME,
	@Close_Date DATETIME,
	@LocationId INT
AS
BEGIN
	INSERT INTO dbo.tblBidItems (Title, Brand, Model, Close_Date, Created_At, LocationId) 
	VALUES (@Title, @Brand, @Model, @Close_Date, @Created_At, @LocationId);
END
GO