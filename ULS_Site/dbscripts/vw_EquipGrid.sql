USE [ULS_db1]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[vw_EquipGrid]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [vw_EquipGrid]
GO
/****** Object:  View [dbo].[vw_EquipGrid]    Script Date: 09/15/2009 10:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

  CREATE VIEW [dbo].[vw_EquipGrid]
  AS SELECT
		e.equip_id,
		t.type_desc,
		mk.make_descr,
		md.model_descr,
		e.equip_year,
		e.work_loc,
		e.insp_due_dt,
		e.service_due_num,
		e.miles_hours,
		e.miles_dt,
		e.registered_by,
		e.managed_by,
		e.managed_by_dt,
		e.tag_expire_dt,
        CASE 
            WHEN DATEDIFF(dd,GETDATE(),insp_due_dt ) < insp_rmdr_wks * 7 THEN  'SET_RED'
            ELSE 'OK'
        END as 'inspection_warn',
        CASE 
            WHEN (service_due_num - miles_hours) <= service_rmdr_wks THEN  'SET_RED'
            ELSE 'OK'
        END as 'service_warn',
        CASE 
            WHEN DATEDIFF(dd, GETDATE(),tag_expire_dt) < tag_expire_rmdr_wks * 7  THEN  'SET_RED'
            ELSE 'OK'
        END as 'tag_warn',
        CASE 
			WHEN (managed_by <> registered_by) AND (managed_by <> '') THEN 'SET_PURPLE'
            ELSE 'OK'
        END as 'equip_loan_color',
        CASE 
            WHEN (assigned = 0)  THEN  'SET_GREEN'
            ELSE 'OK'
        END as 'equip_assign_color',
		e.insp_rmdr_wks,
		e.vin_num,
		e.title_num,
		e.gross_v_wt,
		e.gross_c_wt,
		e.unlaiden_wt,
		e.tag_num,
		e.tag_state,
		f.fuel_descr,
		e.cost,
		e.stolen,
		e.sold,
		e.lojack,
		e.comment,
		e.in_repair,
		e.totaled,
		e.tag_expire_rmdr_wks,
		e.hut_sticker,
		e.apportioned,
		e.ifta_sticker,
		e.gps,
		e.unknown,
		e.current_value,
		(select COUNT(*) from dbo.images where entity_id = e.equip_id and image_type = 'EQUIP') as img_cnt,
		e.leased,
		e.gps_num,
		e.ezpass,
		e.ezpass_num,
		e.fuelcard,
		e.fuelcard_num,
		ROW_NUMBER() OVER (ORDER BY e.equip_id) as rownum,
		e.to_be_sold,
		a.assigned_to,
		e.fuel_card_loc,
		e.other_antitheft,
		e.other_antitheft_type
  FROM equipment e
	LEFT JOIN equip_type_avt t ON e.type_id = t.type_id
	LEFT JOIN make_avt mk ON e.make_id = mk.make_id
	LEFT JOIN model_avt md ON e.model_id = md.model_id
	LEFT JOIN fuel_avt f ON e.fuel = f.fuel_id
	LEFT JOIN assignments a ON e.equip_id = a.equip_id and a.assigned_dt <= GETDATE() and a.return_dt is null

