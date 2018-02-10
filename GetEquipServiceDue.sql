USE [ULS_db1]
GO

/****** Object:  StoredProcedure [dbo].[GetInvByTypeReport]    Script Date: 08/23/2015 18:30:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEquipServiceDue]
	@div varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select 
		e.equip_id,
		et.type_desc,
		mk.make_descr,
		md.model_descr,
		e.equip_year,
		e.registered_by,
		e.managed_by,
		a.assigned_to,
		e.service_due_num,
		e.miles_hours,
		@div as div
	from
		dbo.equipment e
		left join dbo.assignments a on a.equip_id = e.equip_id  and a.assigned_dt is not null and a.return_dt is null
		left join dbo.equip_type_avt et on et.type_id = e.type_id
		left join dbo.make_avt mk on  mk.make_id = e.make_id
		left join dbo.model_avt md on md.model_id = e.model_id
	where 
--		e.registered_by = @regBy and
		(e.registered_by = @div or
		e.managed_by = @div) AND
		e.sold <> 1 AND
		e.stolen <> 1 AND
		e.totaled <> 1 AND
		(e.service_due_num - e.miles_hours) <= e.service_rmdr_wks
	order by e.equip_id
		
END
GO


