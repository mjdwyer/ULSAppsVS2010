USE [ULS_db1]
GO

/****** Object:  View [dbo].[vw_ToolsServiceGrid]    Script Date: 07/06/2015 20:38:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO



  CREATE VIEW [dbo].[vw_EquipServiceGrid]
  AS SELECT
		s.equip_id,
		s.mechanic,
		s.service_dt,
		s.labor_cost,
		s.parts_cost,
		s.mileage,
		s.hours,
		sd.serv_descr,
		s.serv_reqstd,
		s.serv_perf_descr,
		s.parts_reqrd,
		s.comments,
		s.service_id,
		sa.attachment_path
	FROM dbo.services s
	LEFT JOIN dbo.services_avt sd ON s.serv_perf_id = sd.serv_id
	LEFT JOIN dbo.service_attachments sa ON s.service_id = sa.svc_id AND sa.attachment_type = 'EQUIP_SVC'



GO


