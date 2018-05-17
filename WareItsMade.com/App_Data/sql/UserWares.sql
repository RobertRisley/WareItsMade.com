USE [Wares]
GO

/****** Object:  Table [dbo].[UserWares]    Script Date: 10/31/2013 1:35:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[UserWares]
GO

CREATE TABLE [dbo].[UserWares](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[CommodityId] [nchar](10) NOT NULL,
	[ObjectId] [nvarchar](50) NOT NULL,
	[ObjectName] [nvarchar](50) NOT NULL,
	[ObjectDescription] [nvarchar](255) NOT NULL,
	[ObjectUri] [nvarchar](255) NULL,
 CONSTRAINT [PK_UserWares] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_UserWares] UNIQUE NONCLUSTERED 
(
	[UserName] ASC,
	[CommodityId] ASC,
	[ObjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserWares]  WITH CHECK ADD  CONSTRAINT [FK_UserWares_Unspsc] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Unspsc] ([CommodityId])
GO

ALTER TABLE [dbo].[UserWares] CHECK CONSTRAINT [FK_UserWares_Unspsc]
GO

ALTER TABLE [dbo].[UserWares]  WITH CHECK ADD  CONSTRAINT [FK_UserWares_Users] FOREIGN KEY([UserName])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[UserWares] CHECK CONSTRAINT [FK_UserWares_Users]
GO


