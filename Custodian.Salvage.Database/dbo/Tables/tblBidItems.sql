CREATE TABLE [dbo].[tblBidItems] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [Title]      VARCHAR (50)  NOT NULL,
    [Status]     VARCHAR (50)  NOT NULL,
    [Close_Date] DATETIME2 (7) NOT NULL,
    [LocationId]   INT NOT NULL,
    [Created_At] DATETIME NOT NULL
    CONSTRAINT [PK_tblItems] PRIMARY KEY CLUSTERED ([id] ASC), 
    CONSTRAINT [FK_tblBidItems_tblLocation_idx] FOREIGN KEY ([LocationId]) REFERENCES dbo.tblLocations(Id)
);

