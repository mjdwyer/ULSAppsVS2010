USE [ULS_db1]
GO

/****** Object:  Table [dbo].[service_attachments]    Script Date: 07/05/2015 09:01:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[service_attachments](
	[attachment_id] [int] IDENTITY(1,1) NOT NULL,
	[svc_id] [int] NULL,
	[attachment_type] [varchar](12) NULL,
	[attachment_path] [varchar](200) NULL,
 CONSTRAINT [PK_service_attachments] PRIMARY KEY CLUSTERED 
(
	[attachment_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


