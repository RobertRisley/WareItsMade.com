USE [Wares]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Commoditys]
GO
DROP TABLE [dbo].[Classes]
GO
DROP TABLE [dbo].[Familys]
GO
DROP TABLE [dbo].[Segments]
GO


CREATE TABLE [dbo].[Segments](
	[SegmentId] [nchar](8) NOT NULL,
	[SegmentTitle] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Segments] PRIMARY KEY CLUSTERED 
(
	[SegmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[Segments](
	[SegmentId],
	[SegmentTitle]
)
SELECT DISTINCT
	[SegmentId],
	[SegmentTitle]
FROM dbo.Unspsc
GO



CREATE TABLE [dbo].[Familys](
	[FamilyId] [nchar](8) NOT NULL,
	[FamilyTitle] [nvarchar](255) NOT NULL,
	[SegmentId] [nchar](8) NOT NULL,
 CONSTRAINT [PK_Familys] PRIMARY KEY CLUSTERED 
(
	[FamilyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Familys]  WITH CHECK ADD  CONSTRAINT [FK_Familys_Segments] FOREIGN KEY([SegmentId])
REFERENCES [dbo].[Segments] ([SegmentId])
GO
ALTER TABLE [dbo].[Familys] CHECK CONSTRAINT [FK_Familys_Segments]
GO

INSERT INTO [dbo].[Familys](
	[FamilyId],
	[FamilyTitle],
	[SegmentId]
)
SELECT DISTINCT
	[FamilyId],
	[FamilyTitle],
	[SegmentId]
FROM dbo.Unspsc
GO



CREATE TABLE [dbo].[Classes](
	[ClassId] [nchar](8) NOT NULL,
	[ClassTitle] [nvarchar](255) NOT NULL,
	[FamilyId] [nchar](8) NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Familys] FOREIGN KEY([FamilyId])
REFERENCES [dbo].[Familys] ([FamilyId])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Familys]
GO

INSERT INTO [dbo].[Classes](
	[ClassId],
	[ClassTitle],
	[FamilyId]
)
SELECT DISTINCT
	[ClassId],
	[ClassTitle],
	[FamilyId]
FROM dbo.Unspsc
GO



CREATE TABLE [dbo].[Commoditys](
	[CommodityId] [nchar](8) NOT NULL,
	[CommodityTitle] [nvarchar](255) NOT NULL,
	[ClassId] [nchar](8) NOT NULL,
 CONSTRAINT [PK_Commoditys] PRIMARY KEY CLUSTERED 
(
	[CommodityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Commoditys]  WITH CHECK ADD  CONSTRAINT [FK_Commoditys_Classes] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
GO
ALTER TABLE [dbo].[Commoditys] CHECK CONSTRAINT [FK_Commoditys_Classes]
GO

INSERT INTO [dbo].[Commoditys](
	[CommodityId],
	[CommodityTitle],
	[ClassId]
)
SELECT DISTINCT
	[CommodityId],
	[CommodityTitle],
	[ClassId]
FROM dbo.Unspsc
GO
