USE [Wares]
GO

/****** Object:  Table [dbo].[UnspscCodes]    Script Date: 10/31/2013 1:02:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.[UnspscCodes]', 'U') IS NOT NULL
DROP TABLE [dbo].[UnspscCodes]
GO

CREATE TABLE [dbo].[UnspscCodes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SegmentId] [nchar](10) NOT NULL,
	[SegmentTitle] [nvarchar](255) NOT NULL,
	[FamilyId] [nchar](10) NOT NULL,
	[FamilyTitle] [nvarchar](255) NOT NULL,
	[ClassId] [nchar](10) NOT NULL,
	[ClassTitle] [nvarchar](255) NOT NULL,
	[CommodityId] [nchar](10) NOT NULL,
	[CommodityTitle] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_UnspscCodes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [UnspscCodes] (
	[SegmentId],
	[SegmentTitle],
	[FamilyId],
	[FamilyTitle],
	[ClassId],
	[ClassTitle],
	[CommodityId],
	[CommodityTitle]
)
SELECT
	[SegmentId],
	[SegmentTitle],
	[FamilyId],
	[FamilyTitle],
	[ClassId],
	[ClassTitle],
	[CommodityId],
	[CommodityTitle]
FROM [Unspsc]
