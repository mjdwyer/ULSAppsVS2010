USE [ULS_db1]
GO
/****** Object:  StoredProcedure [dbo].[GetEquipChangeLogHist]    Script Date: 10/30/2016 20:24:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetToolAssignChangeLogHist]
			@fromDt datetime,
			@toDt datetime

	
AS
BEGIN
	select
		al.user_id,
		al.change_dt,
		al.assign_change,
		al.entity_id,
		tia.tools_type_descr,
		@fromDt as fromdt,
		@toDt as todt
	from
		dbo.assign_log al
		inner join dbo.tools t on t.tool_id = al.entity_id
		inner join dbo.tools_item_avt tia on tia.tools_type_id = t.item_id
	where
		al.change_dt >= @fromDt and
		al.change_dt <= @toDt and
		al.assign_type = 'Tool'

	order by al.entity_id, al.change_dt desc
		
END