-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSaveBid]
	-- Add the parameters for the stored procedure here
		@First_Name varchar(250),
		@Last_Name varchar(250),
		@Email varchar(100),
		@Phone_Number varchar(25),
		@BID_Value varchar(50),
		@BidItem_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT into tblBid (First_Name, Last_Name, email, Phone_Number, BID_Value, BidItem_ID)
	Values (@First_Name, @Last_Name, @Email, @Phone_Number, @BID_Value, @BidItem_ID)
	Declare @return_value int
	
End

Select @return_value as result