-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSaveBidItem]
	 --Add the parameters for the stored procedure here
	@title varchar(225),
	@status varchar(50),
	@state varchar(50),
	@closeDate datetime2,
	@location varchar(225),
	@sessions varchar(50),
	@updated_at datetime2,
	@created_at datetime2

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--INSERT into tblBidItems (Title, Status, State, Close_Date, Location, Sessions, Created_At, Updated_At
	--)
	--VALUES (@title, @status, @state, @closeDate, @location, @sessions, @created_at, @updated_at
	--)

	--SELECT MAX(id) as id from tblBidItems

	--Declare @return_value int
	
End

-- Select @return_value as result
