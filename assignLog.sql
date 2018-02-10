USE [ULS_db1]
GO

/****** Object:  Table [dbo].[equip_edit_log]    Script Date: 10/19/2016 20:57:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[assign_log](
	[user_id] [varchar](50) NOT NULL,
	[change_dt] [datetime] NOT NULL,
	[assign_change] [varchar](2000) NOT NULL,
	[log_id] [int] IDENTITY(1,1) NOT NULL,
	[entity_id] [varchar](30) NOT NULL,
	[assign_type] [varchar](10) NULL,
 CONSTRAINT [PK_assign_log] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


