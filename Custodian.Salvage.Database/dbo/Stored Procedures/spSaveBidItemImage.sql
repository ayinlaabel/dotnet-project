-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSaveBidItemImage]
	-- Add the parameters for the stored procedure here
	@BidItem_ID int,
	@image_Url nvarchar(250)
	--@created_at datetime2

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into tblBidItemImage (BidItem_ID, Image_URL) Values (@BidItem_ID, @image_Url)
END
