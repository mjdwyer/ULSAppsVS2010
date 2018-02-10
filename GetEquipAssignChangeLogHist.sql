USE [ULS_db1]
GO

/****** Object:  StoredProcedure [dbo].[GetEquipAssignChangeLogHist]    Script Date: 11/01/2016 21:13:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetEquipAssignChangeLogHist]
			@fromDt datetime,
			@toDt datetime

	
AS
BEGIN
	select
		al.user_id,
		al.change_dt,
		al.assign_change,
		al.entity_id,
		eta.type_desc,
		@fromDt as fromdt,
		@toDt as todt
	from
		dbo.assign_log al
		inner join dbo.equipment e on e.equip_id = al.entity_id
		inner join dbo.equip_type_avt eta on eta.type_id = e.type_id
	where
		al.change_dt >= @fromDt and
		al.change_dt <= @toDt and
		al.assign_type = 'Equip'

	order by al.entity_id, al.change_dt desc
		
END
GO


