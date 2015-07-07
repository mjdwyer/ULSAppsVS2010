USE [ULS_db1]
GO

/****** Object:  View [dbo].[vw_ToolsServiceGrid]    Script Date: 07/05/2015 08:44:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO



  CREATE VIEW [dbo].[vw_ToolsServiceGrid]
  AS SELECT
		s.tool_id,
		s.mechanic,
		s.service_dt,
		s.labor_cost,
		s.parts_cost,
		s.serv_reqstd,
		s.serv_perf_descr,
		s.parts_reqrd,
		sd.too_serv_descr,
		s.comments,
		s.service_id,
		sa.attachment_path,
		(select COUNT(*) from dbo.service_attachments where svc_id = s.service_id and attachment_type = 'TOOL_SVC') as attach_cnt
  FROM dbo.tools_serv s
	LEFT JOIN dbo.tools_serv_avt sd ON s.serv_perf_id = sd.tool_serv_id
	LEFT JOIN dbo.service_attachments sa ON s.service_id = sa.svc_id AND sa.attachment_type = 'TOOL_SVC'



GO


