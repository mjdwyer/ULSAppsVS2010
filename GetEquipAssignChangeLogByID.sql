USE [ULS_db1]
GO

/****** Object:  StoredProcedure [dbo].[GetEquipAssignChangeLogByID]    Script Date: 11/01/2016 21:09:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEquipAssignChangeLogByID]
	@equip_id varchar(15)
	
AS
BEGIN
	select
		al.user_id,
		al.change_dt,
		al.assign_change,
		al.entity_id,
		eta.type_desc
	from
		dbo.assign_log al
		inner join dbo.equipment e on e.equip_id = al.entity_id
		inner join dbo.equip_type_avt eta on eta.type_id = e.type_id
	where
		al.entity_id = @equip_id and
		al.assign_type = 'Equip'
		
	order by al.change_dt desc
		
END
GO


