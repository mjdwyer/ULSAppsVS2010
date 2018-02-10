USE [ULS_db1]
GO

/****** Object:  StoredProcedure [dbo].[GetSmallToolsAssignedToReport]    Script Date: 03/26/2017 06:58:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--DROP PROCEDURE [dbo].[GetSmallToolsCailibrationDueReport]
GO
CREATE PROCEDURE [dbo].[GetSmallToolsCailibrationDueReport]
	@regBy varchar(50),
	@startDt datetime,
	@endDt datetime
AS
BEGIN


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select 
		st.item,
		st.description,
		st.size,
		st.MFG,
		st.Assigned_to,
		st.Assigned_dt,
		c.condition_descr,
		st.calibration_due_dt,
		@regBy as regin,
		@startDt as startdate
	from
		dbo.smalltools st
		left join dbo.condition_avt c on c.condition_id= st.ConditionId
	where 
		(st.Reg_by = @regBy or st.managed_by = @regBy) and
		st.calibration_due_dt >=  @startDt and
		st.calibration_due_dt < @endDt
	order by st.calibration_due_dt desc
		
END
GO


