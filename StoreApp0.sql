
CREATE TABLE [Store].[Customer](
	[customerID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](255) NOT NULL,
	[lastName] [nvarchar](255) NOT NULL
) ON [PRIMARY]



CREATE TABLE [Store].[Orders](
	[orderID] [int] IDENTITY(1,1) NOT NULL,
	[customerID] [int] NOT NULL,
	[productID] [int] NULL,
	[locationID] [nvarchar](255) NOT NULL
) ON [PRIMARY]

CREATE TABLE [Store].[Location](
	[locationID] [int] IDENTITY(1,1) NOT NULL,
	[locationName] [nvarchar](255) NOT NULL
) ON [PRIMARY]


CREATE TABLE [Store].[Product](
	[productId] [int] NOT NULL,
	[productName] [nvarchar](255) NOT NULL,
	[prodcutctagory] [nvarchar](1) NULL
) ON [PRIMARY]
