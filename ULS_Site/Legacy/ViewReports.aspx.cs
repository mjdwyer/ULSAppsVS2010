using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Web;

namespace ULS_Site
{
    public partial class ViewReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            CrystalDecisions.Shared.ToolbarStyle toolbarStyle = new CrystalDecisions.Shared.ToolbarStyle();
            toolbarStyle.BackColor = System.Drawing.Color.LightGray;
            CrystalReportViewer1.ToolbarStyle = toolbarStyle;
            CrystalReportViewer1.HasCrystalLogo = false;
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None;

            Print();
        }

        public void Print()
        {
            try
            {

                string strReportPath;
                string strParm1 = "";

                string strParm2 = "";

                string strParm3 = "";
                string strParm4 = "";
                string strParm5 = "";
                string strParm6 = "";

                string strValue1 = Request.QueryString["value1"];

                string[] parms = strValue1.Split(',');

                int intNumParms = parms.Count();

                string strRpt = parms[0];

                string strSP = parms[1];

                if (intNumParms >= 3)
                {
                    strParm1 = parms[2];
                }

                if (intNumParms >= 4)
                {
                    strParm2 = parms[3];
                }

                if (intNumParms >= 5)
                {
                    strParm3 = parms[4];
                }

                if (intNumParms >= 6)
                {
                    strParm4 = parms[5];
                }

                if (intNumParms >= 7)
                {
                    strParm5 = parms[6];
                }

                if (intNumParms >= 8)
                {
                    strParm6 = parms[7];
                }


                System.Data.DataSet ds = new System.Data.DataSet();
                //                System.Data.SqlClient.SqlConnection sqlcon = new System.Data.SqlClient.SqlConnection("Data Source=sql394.mysite4now.com;Initial Catalog=ULS_db1;User ID=uls2008;Password=2008uls");
                System.Data.SqlClient.SqlConnection sqlcon = new System.Data.SqlClient.SqlConnection("Data Source=(local);Initial Catalog=ULS_db1;User ID=uls2008;Password=uls2008");
                System.Data.SqlClient.SqlCommand comand = new System.Data.SqlClient.SqlCommand();
                comand.Connection = sqlcon;
                comand.CommandText = strSP;
                comand.CommandType = System.Data.CommandType.StoredProcedure;

                switch (strRpt)
                {
                    case "EquipAssignedTo":
                        strReportPath = Server.MapPath("~/Reports/EquipAssinedTo.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTo", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@assignedTo"].Value = strParm1;

                        break;

                    case "EquipMultiAssignedTo":
                        strReportPath = Server.MapPath("~/Reports/EquipMultiAssignedTo.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTos", System.Data.SqlDbType.VarChar, 500));
                        comand.Parameters["@assignedTos"].Value = strParm1;

                        break;

                    case "ToolMultiAssignedTo":
                        strReportPath = Server.MapPath("~/Reports/ToolsMutiAssignedTo.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTos", System.Data.SqlDbType.VarChar, 500));
                        comand.Parameters["@assignedTos"].Value = strParm1;

                        break;

                    case "EquipAssignToHist":
                        strReportPath = Server.MapPath("~/Reports/EquipAssignToHist.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTo", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@assignedTo"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "EquipTotalInventory":
                        strReportPath = Server.MapPath("~/Reports/EquipTotalInventory.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipTotalInvRegBy":
                        strReportPath = Server.MapPath("~/Reports/EquipTotalInvRegBy.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipBrokenHist":
                        strReportPath = Server.MapPath("~/Reports/EquipBrokeHist.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTo", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@assignedTo"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "EquipMngByHist":
                        strReportPath = Server.MapPath("~/Reports/EquipMngByHist.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mngBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@mngBy"].Value = strParm2;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm3);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm4);

                        break;

                    case "EquipmentOnLoan":
                        strReportPath = Server.MapPath("~/Reports/EquipmentOnLoan.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@manageBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@manageBy"].Value = strParm2;

                        break;

                    case "EquipmentInvByType":
                        strReportPath = Server.MapPath("~/Reports/EquipmentInvByType.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@type_id", System.Data.SqlDbType.Int));
                        comand.Parameters["@type_id"].Value = Convert.ToInt32(strParm2);

                        break;

                    case "EquipInspectionDue":
                        strReportPath = Server.MapPath("~/Reports/EquipInspectionDue.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@startDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@endDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@endDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "EquipInspectionDueMngBy":
                        strReportPath = Server.MapPath("~/Reports/EquipInspectionDueMngBy.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@startDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@endDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@endDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "ToolsCalibrationDueRpt":
                        strReportPath = Server.MapPath("~/Reports/ToolsCalibrationDueRpt.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@startDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@endDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@endDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "SmallToolsCalibrationDueReport":
                        strReportPath = Server.MapPath("~/Reports/SmallToolsCalibrationDueReport.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@startDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@endDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@endDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "EquipInvByLoc":
                        strReportPath = Server.MapPath("~/Reports/EquipInvByLoc.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@workLoc", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@workLoc"].Value = strParm2;

                        break;

                    case "Test1":
                        strReportPath = Server.MapPath("~/Reports/Test1.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@workLoc", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@workLoc"].Value = strParm2;

                        break;

                    case "EquipHUTInv":

                        strReportPath = Server.MapPath("~/Reports/EquipHUTInv.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipSvcDue":

                        strReportPath = Server.MapPath("~/Reports/EquipSvcDue.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipApportionedInv":

                        strReportPath = Server.MapPath("~/Reports/EquipApportionedInv.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipLojackInv":

                        strReportPath = Server.MapPath("~/Reports/EquipLojackInventory.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipOtherAntiTheftInv":

                        strReportPath = Server.MapPath("~/Reports/EquipOtherAntiTheftInventory.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipToBeSoldInv":

                        strReportPath = Server.MapPath("~/Reports/EquipToBeSold.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "ToolsToBeSold":

                        strReportPath = Server.MapPath("~/Reports/ToolToBeSold.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipUnknownInventory":

                        strReportPath = Server.MapPath("~/Reports/EquipUnknownInventory.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipGPSInv":

                        strReportPath = Server.MapPath("~/Reports/EquipGPSInv.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipEZPASSInv":

                        strReportPath = Server.MapPath("~/Reports/EquipEZPASS.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipFuelCardInv":

                        strReportPath = Server.MapPath("~/Reports/EquipFuelCard.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipLeasedInv":

                        strReportPath = Server.MapPath("~/Reports/EquipLeasedInventory.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "EquipIFTAInv":

                        strReportPath = Server.MapPath("~/Reports/EquipIFTAInv.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "ToolsAssignedTo":
                        strReportPath = Server.MapPath("~/Reports/ToolsAssignedTo.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTo", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@assignedTo"].Value = strParm1;

                        break;

                    case "ToolsAssignedToHist":
                        strReportPath = Server.MapPath("~/Reports/ToolsAssignedToHist.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTo", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@assignedTo"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "ToolsBrokenHist":
                        strReportPath = Server.MapPath("~/Reports/ToolsBrokenHist.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTo", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@assignedTo"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "ToolsOnLoan":
                        strReportPath = Server.MapPath("~/Reports/ToolsOnLoan.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@manageBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@manageBy"].Value = strParm2;

                        break;

                    case "ToolsInvByType":
                        strReportPath = Server.MapPath("~/Reports/ToolsInvByType.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@type", System.Data.SqlDbType.Int));
                        comand.Parameters["@type"].Value = Convert.ToInt32(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@descr", System.Data.SqlDbType.Int));
                        comand.Parameters["@descr"].Value = Convert.ToInt32(strParm3);

                        break;

                    case "ToolsTotalInv":

                        strReportPath = Server.MapPath("~/Reports/ToolsTotalInv.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "ToolsTotalInvRegBy":

                        strReportPath = Server.MapPath("~/Reports/ToolsTotalInvRegBy.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "ToolsLojackInv":

                        strReportPath = Server.MapPath("~/Reports/ToolLojackInventory.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "ToolsUnknownInv":

                        strReportPath = Server.MapPath("~/Reports/ToolsUnknownInv.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "ToolInvByLoc":
                        strReportPath = Server.MapPath("~/Reports/ToolInvByLoc.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@workLoc", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@workLoc"].Value = strParm2;

                        break;

                    case "EquipOneReport":

                        strReportPath = Server.MapPath("~/Reports/EquipOneReport.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@equip_id", System.Data.SqlDbType.VarChar, 15));
                        comand.Parameters["@equip_id"].Value = strParm1;
                        break;

                    case "ToolOneReport":

                        strReportPath = Server.MapPath("~/Reports/ToolOneReport.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tool_id", System.Data.SqlDbType.VarChar, 15));
                        comand.Parameters["@tool_id"].Value = strParm1;
                        break;

                    case "EquipInvByTypeAndLoc":
                        strReportPath = Server.MapPath("~/Reports/EquipInvByTypeAndLoc.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@workLoc", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@workLoc"].Value = strParm2;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@type_id", System.Data.SqlDbType.Int));
                        comand.Parameters["@type_id"].Value = Convert.ToInt32(strParm1);

                        break;

                    case "SmallToolsAssignedTo":
                        strReportPath = Server.MapPath("~/Reports/SmallToolsAssignedTo.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTo", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@assignedTo"].Value = strParm1;

                        break;

                    case "EquipOneSvcReport":

                        strReportPath = Server.MapPath("~/Reports/EquipOneSvcReport.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@service_id", System.Data.SqlDbType.Int));
                        comand.Parameters["@service_id"].Value = Convert.ToInt32(strParm1);
                        break;

                    case "ToolOneSvcReport":

                        strReportPath = Server.MapPath("~/Reports/ToolOneSvcReport.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@service_id", System.Data.SqlDbType.Int));
                        comand.Parameters["@service_id"].Value = Convert.ToInt32(strParm1);
                        break;

                    case "EquipSvcCostHist":
                        strReportPath = Server.MapPath("~/Reports/EquipSvcCostHist.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@equip_id", System.Data.SqlDbType.VarChar, 15));
                        comand.Parameters["@equip_id"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "ToolSvcCostHistReport":
                        strReportPath = Server.MapPath("~/Reports/ToolSvcCostHistReport.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tool_id", System.Data.SqlDbType.VarChar, 15));
                        comand.Parameters["@tool_id"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "EquipSvcCostHistByType":
                        strReportPath = Server.MapPath("~/Reports/EquipSvcCostHistByType.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@equip_type", System.Data.SqlDbType.Int));
                        comand.Parameters["@equip_type"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm4;

                        break;

                    case "EquipSvcCostHistBySvcType":
                        strReportPath = Server.MapPath("~/Reports/EquipSvcCostHistBySvcType.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@serv_perf_id", System.Data.SqlDbType.Int));
                        comand.Parameters["@serv_perf_id"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm4;

                        break;

                    case "ToolSvcCostHistBySvcType":
                        strReportPath = Server.MapPath("~/Reports/ToolSvcCostHistReportBySvcType.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@serv_perf_id", System.Data.SqlDbType.Int));
                        comand.Parameters["@serv_perf_id"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm4;

                        break;

                    case "EquipSvcCostHistAll":
                        strReportPath = Server.MapPath("~/Reports/EquipSvcCostHistAll.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm1);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm3;

                        break;

                    case "ToolSvcCostHistByType":
                        strReportPath = Server.MapPath("~/Reports/ToolSvcCostHistByType.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@item_id", System.Data.SqlDbType.Int));
                        comand.Parameters["@item_id"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm4;

                        break;

                    case "ToolSvcCostHistAll":
                        strReportPath = Server.MapPath("~/Reports/ToolSvcCostHistAll.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm1);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm3;

                        break;

                    case "EquipSvcCostHistAllTypesDivs":
                        strReportPath = Server.MapPath("~/Reports/EquipSvcCostHistAllTypesDivs.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@equip_type", System.Data.SqlDbType.Int));
                        comand.Parameters["@equip_type"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@serv_perf_id", System.Data.SqlDbType.Int));
                        comand.Parameters["@serv_perf_id"].Value = strParm2;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm5);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm6);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regby", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regby"].Value = strParm3;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mngby", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@mngby"].Value = strParm4;

                        break;

                    case "EquipInvWithCost":
                        strReportPath = Server.MapPath("~/Reports/EquipInvWithCost.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@equip_type", System.Data.SqlDbType.Int));
                        comand.Parameters["@equip_type"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regby", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regby"].Value = strParm2;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mngby", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@mngby"].Value = strParm3;

                        break;

                    case "EquipInvByGVW":
                        strReportPath = Server.MapPath("~/Reports/EquipInvByGVW.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@gvw_type", System.Data.SqlDbType.Int));
                        comand.Parameters["@gvw_type"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regby", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regby"].Value = strParm2;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mngby", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@mngby"].Value = strParm3;

                        break;

                    case "EquipChangeLogByID":

                        strReportPath = Server.MapPath("~/Reports/EquipChangeLogByID.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@equip_id", System.Data.SqlDbType.VarChar, 15));
                        comand.Parameters["@equip_id"].Value = strParm1;

                        break;

                    case "EquipAssignLogByID":

                        strReportPath = Server.MapPath("~/Reports/EquipAssignLogById.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@equip_id", System.Data.SqlDbType.VarChar, 15));
                        comand.Parameters["@equip_id"].Value = strParm1;

                        break;

                    case "ToolsChangeLogByID":

                        strReportPath = Server.MapPath("~/Reports/ToolsChangeLogById.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tool_id", System.Data.SqlDbType.VarChar, 15));
                        comand.Parameters["@tool_id"].Value = strParm1;

                        break;

                    case "ToolsAssignLogByID":

                        strReportPath = Server.MapPath("~/Reports/ToolsAssignLogById.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tool_id", System.Data.SqlDbType.VarChar, 15));
                        comand.Parameters["@tool_id"].Value = strParm1;

                        break;

                    case "EquipChangeLogHist":
                        strReportPath = Server.MapPath("~/Reports/EquipChangeLogHst.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm1);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm2);

                        break;

                    case "EquipAssignLogHist":
                        strReportPath = Server.MapPath("~/Reports/EquipAssignLogHist.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm1);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm2);

                        break;

                    case "ToolsChangeLogHist":
                        strReportPath = Server.MapPath("~/Reports/ToolChangeLogHist.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm1);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm2);

                        break;

                    case "ToolsAssignLogHist":
                        strReportPath = Server.MapPath("~/Reports/ToolAssignLogHist.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm1);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm2);

                        break;

                    case "EquipFuelCardDivInv":
                        strReportPath = Server.MapPath("~/Reports/EquipFuelCardDivInv.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;


                    default:
                        strReportPath = Server.MapPath("~/Reports/EquipAssinedTo.rpt");
                        break;
                }


                System.Data.SqlClient.SqlDataAdapter sqladp = new System.Data.SqlClient.SqlDataAdapter(comand);

                sqlcon.Open();
                sqladp.Fill(ds, "myDataSet");

                CrystalDecisions.CrystalReports.Engine.ReportDocument oRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                oRpt.Load(strReportPath);

                oRpt.SetDataSource(ds.Tables[0]);

                CrystalReportViewer1.ReportSource = oRpt;

                sqlcon.Close();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Logit(msg);
            }
            finally
            {
//                CrystalReportViewer1.ReportSource.Close();
            }
        }

//        private void CleanOutViewer(
//            if !(this.CrystalReportViewer1.ReportSource()
//    If Not Me.CrystalReportViewer1.ReportSource() Is Nothing Then
//        CType(Me.CrystalReportViewer1.ReportSource(), CrystalDecisions.CrystalReports.Engine.ReportDocument).Close()
//        CType(Me.CrystalReportViewer1.ReportSource(), CrystalDecisions.CrystalReports.Engine.ReportDocument).Dispose()
//        Me.CrystalReportViewer1.ReportSource() = Nothing
//        GC.Collect()
//    End If
//End Sub

        public void Logit(string strMsg)
        {
            string logFilePath = "C:\\HostingSpaces\\admin\\ULSCorp.com\\applog\\";

            string strDay;
            strDay = "";

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    strDay = "Mon";
                    break;
                case DayOfWeek.Tuesday:
                    strDay = "Tue";
                    break;
                case DayOfWeek.Wednesday:
                    strDay = "Wed";
                    break;
                case DayOfWeek.Thursday:
                    strDay = "Thu";
                    break;
                case DayOfWeek.Friday:
                    strDay = "Fri";
                    break;
                case DayOfWeek.Saturday:
                    strDay = "Sat";
                    break;
                case DayOfWeek.Sunday:
                    strDay = "Sun";
                    break;
            }

            string logFileNamePath = logFilePath + strDay + "_" + "ulserror.log";


            System.IO.FileInfo fi = new System.IO.FileInfo(logFileNamePath);
            if (fi.Exists)
            {
                if ((fi.LastWriteTime.AddDays(5)) < DateTime.Now)
                {
                    fi.Delete();
                }
            }

            if (!fi.Exists)
            {
                System.IO.FileStream fs = new System.IO.FileStream(logFileNamePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                System.IO.StreamWriter s = new System.IO.StreamWriter(fs);
                s.Close();
                fs.Close();
            }

            System.IO.FileStream fs1 = new System.IO.FileStream(logFileNamePath, System.IO.FileMode.Append, System.IO.FileAccess.Write);
            System.IO.StreamWriter s1 = new System.IO.StreamWriter(fs1);
            string strPtr;
            strPtr = " ==> ";

            s1.Write(DateTime.Now.ToString() + strPtr + ": " + strMsg + "\r\n");
            s1.Close();
            fs1.Close();

        }
    


    }
}