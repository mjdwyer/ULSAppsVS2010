USE [ULS_db1]
GO
/****** Object:  StoredProcedure [dbo].[GetToolsCalibrationDueReport]    Script Date: 03/26/2017 06:50:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
DROP PROCEDURE [dbo].[GetToolsCalibrationDueReport]
GO
CREATE PROCEDURE [dbo].[GetToolsCalibrationDueReport]
	@regBy varchar(50),
	@startDt datetime,
	@endDt datetime
AS
BEGIN


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select 
		t.tool_id,
		tt.tools_type_descr,
		td.tools_descr_descr,
		ts.size_descr,
		tm.tool_mfg_descr,
		ta.assigned_to,
		ta.assigned_dt,
		c.condition_descr,
		t.calibration_due_dt,
		t.managed_by as managed_by,
		@regBy as regin,
		@startDt as startdate

	from
		dbo.tools_assign ta
		inner join dbo.tools t on t.tool_id = ta.tool_id
		left join dbo.tools_item_avt tt on tt.tools_type_id = t.item_id
		left join dbo.tools_descr_avt td on  td.tools_descr_id = t.descr_id
		left join dbo.tool_size_avt ts on ts.size_id = t.size_id
		left join dbo.tool_mfgs_avt tm on tm.tool_mfg_id = t.mfg_id
		left join dbo.condition_avt c on c.condition_id= ta.asgn_condition_id
	where 
		(t.registered_by = @regBy or t.managed_by = @regBy) and
		t.calibration_due_dt >=  @startDt and
		t.calibration_due_dt < @endDt and
		ta.return_dt is null
	order by ta.assigned_dt desc
		
END