USE [ULS_db1]
GO
/****** Object:  StoredProcedure [dbo].[GetEquipChangeLogByID]    Script Date: 10/20/2016 21:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetToolAssignChangeLogByID]
	@tool_id varchar(15)
	
AS
BEGIN
	select
		al.user_id,
		al.change_dt,
		al.assign_change,
		al.entity_id,
		tia.tools_type_descr
	from
		dbo.assign_log al
		inner join dbo.tools t on t.tool_id = al.entity_id
		inner join dbo.tools_item_avt tia on tia.tools_type_id = t.item_id
	where
		al.entity_id = @tool_id and
		al.assign_type = 'Tool'
		
	order by al.change_dt desc
		
END