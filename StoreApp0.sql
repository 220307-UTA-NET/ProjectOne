
CREATE TABLE [Store].[Customer](
	[customerID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](255) NOT NULL,
	[lastName] [nvarchar](255) NOT NULL
) ON [PRIMARY]


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
ALTER TABLE [Store].[Location] ADD PRIMARY KEY CLUSTERED 
(
	[locationID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Store].[Product](
	[productId] [int] NOT NULL,
	[productName] [nvarchar](255) NOT NULL,
	[prodcutctagory] [nvarchar](1) NULL
) ON [PRIMARY]
