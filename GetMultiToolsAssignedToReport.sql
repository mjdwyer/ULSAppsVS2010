USE [ULS_db1]
GO

/****** Object:  StoredProcedure [dbo].[GetToolsAssignedToReport]    Script Date: 10/04/2016 19:46:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMultiToolsAssignedToReport]
	@assignedTos varchar(500)
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
		c.condition_descr
	from
		dbo.tools_assign ta
		inner join dbo.tools t on t.tool_id = ta.tool_id
		inner join assign_to at on at.assign_to = ta.assigned_to
		inner join dbo.fnSplitString(@assignedTos,';') sd on sd.splitdata = at.assign_to_id
		left join dbo.tools_item_avt tt on tt.tools_type_id = t.item_id
		left join dbo.tools_descr_avt td on  td.tools_descr_id = t.descr_id
		left join dbo.tool_size_avt ts on ts.size_id = t.size_id
		left join dbo.tool_mfgs_avt tm on tm.tool_mfg_id = t.mfg_id
		left join dbo.condition_avt c on c.condition_id= ta.asgn_condition_id
	where 
--		ta.assigned_to = @assignedTo and
		ta.return_dt is null
	order by ta.assigned_dt desc
		
END
GO


