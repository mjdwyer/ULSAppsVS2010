USE [ULS_db1]
GO
/****** Object:  StoredProcedure [dbo].[GetToolsByTypeReport]    Script Date: 10/09/2017 21:21:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetToolsByTypeReport]
	@div varchar(50),
	@type int,
	@descr int
AS
BEGIN


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @descr > 0
	BEGIN
	Select 
		t.tool_id,
		tt.tools_type_descr,
		td.tools_descr_descr,
		ts.size_descr,
		tm.tool_mfg_descr,
		t.managed_by_dt,
		t.registered_by,
		t.managed_by,
		a.assigned_to
	from
		dbo.tools t 
		left join dbo.tools_assign a on a.tool_id = t.tool_id  and a.assigned_dt is not null and a.return_dt is null
		left join dbo.tools_item_avt tt on tt.tools_type_id = t.item_id
		left join dbo.tools_descr_avt td on  td.tools_descr_id = t.descr_id
		left join dbo.tool_size_avt ts on ts.size_id = t.size_id
		left join dbo.tool_mfgs_avt tm on tm.tool_mfg_id = t.mfg_id
	where 
		t.registered_by = @div and
		t.item_id = @type and
		t.descr_id = @descr
	order by t.tool_id asc
	End
	Else
	Begin 
	Select 
		t.tool_id,
		tt.tools_type_descr,
		td.tools_descr_descr,
		ts.size_descr,
		tm.tool_mfg_descr,
		t.managed_by_dt,
		t.registered_by,
		t.managed_by,
		a.assigned_to
	from
		dbo.tools t 
		left join dbo.tools_assign a on a.tool_id = t.tool_id  and a.assigned_dt is not null and a.return_dt is null
		left join dbo.tools_item_avt tt on tt.tools_type_id = t.item_id
		left join dbo.tools_descr_avt td on  td.tools_descr_id = t.descr_id
		left join dbo.tool_size_avt ts on ts.size_id = t.size_id
		left join dbo.tool_mfgs_avt tm on tm.tool_mfg_id = t.mfg_id
	where 
		t.registered_by = @div and
		t.item_id = @type AND
		t.totaled <> 1 AND
		t.sold <> 1 AND
		t.stolen <> 1 
	order by t.tool_id asc
	End
		
END