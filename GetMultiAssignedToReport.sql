USE [ULS_db1]
GO
drop procedure [dbo].[GetMultiAssignedToReport]
GO
/****** Object:  StoredProcedure [dbo].[GetAssignedToReport]    Script Date: 10/02/2016 20:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetMultiAssignedToReport]
	@assignedTos varchar(500)
AS
BEGIN


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select 
		a.assigned_to,
		a.assigned_dt,
		e.equip_id,
		et.type_desc,
		mk.make_descr,
		md.model_descr,
		c.condition_descr
	from
		dbo.assignments a
		inner join assign_to at on at.assign_to = a.assigned_to
		inner join dbo.fnSplitString(@assignedTos,';') sd on sd.splitdata = at.assign_to_id
		inner join dbo.equipment e on e.equip_id = a.equip_id
		left join dbo.condition_avt c on c.condition_id = a.asgn_condition_id
		left join dbo.equip_type_avt et on et.type_id = e.type_id
		left join dbo.make_avt mk on  mk.make_id = e.make_id
		left join dbo.model_avt md on md.model_id = e.model_id
	where 
--		a.assigned_to = @assignedTo and
		a.assigned_dt < GetDate() and
		a.return_dt is null
	order by a.assigned_dt desc
		
END