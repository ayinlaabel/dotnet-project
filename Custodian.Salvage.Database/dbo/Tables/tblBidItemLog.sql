﻿CREATE TABLE [dbo].[tblBidItemLog]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[AdminId] INT NOT NULL,
	[BidItemId] INT NOT NULL,
	[Action] VARCHAR(250) NOT NULL,
	[ActionDate] DATETIME NOT NULL,
)
