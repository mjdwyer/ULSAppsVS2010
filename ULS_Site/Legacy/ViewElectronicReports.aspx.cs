using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Web;

namespace ULS_Site.Legacy
{
    public partial class ViewElectronicReports : System.Web.UI.Page
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
                System.Data.SqlClient.SqlConnection sqlcon = new System.Data.SqlClient.SqlConnection("Data Source=(local);Initial Catalog=ULS_db1;User ID=uls2008;Password=uls2008");
                System.Data.SqlClient.SqlCommand comand = new System.Data.SqlClient.SqlCommand();
                comand.Connection = sqlcon;
                comand.CommandText = strSP;
                comand.CommandType = System.Data.CommandType.StoredProcedure;

                switch (strRpt)
                {
                    case "ElectronicsAssignedTo":
                        strReportPath = Server.MapPath("~/Reports/ElectronicsAssignTo.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTo", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@assignedTo"].Value = strParm1;

                        break;

                    case "ElectronicsAssignToHist":
                        strReportPath = Server.MapPath("~/Reports/EquipAssignToHist.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@assignedTo", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@assignedTo"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fromDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@fromDt"].Value = Convert.ToDateTime(strParm2);
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@toDt", System.Data.SqlDbType.DateTime));
                        comand.Parameters["@toDt"].Value = Convert.ToDateTime(strParm3);

                        break;

                    case "ElectronicsTotalInventory":
                        strReportPath = Server.MapPath("~/Reports/EquipTotalInventory.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "ElectronicsTotalInvRegBy":
                        strReportPath = Server.MapPath("~/Reports/EquipTotalInvRegBy.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@div", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@div"].Value = strParm1;

                        break;

                    case "ElectronicsInvByType":
                        strReportPath = Server.MapPath("~/Reports/ElectronicsInvByType.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@type_id", System.Data.SqlDbType.Int));
                        comand.Parameters["@type_id"].Value = Convert.ToInt32(strParm2);

                        break;

                    case "ElectronicsAirCardInv":
                        strReportPath = Server.MapPath("~/Reports/ElectronicsAirCardInv.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;

                        break;


                    case "ElectronicsInvByLoc":
                        strReportPath = Server.MapPath("~/Reports/EquipInvByLoc.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@regBy", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@regBy"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@workLoc", System.Data.SqlDbType.VarChar, 50));
                        comand.Parameters["@workLoc"].Value = strParm2;

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
        }

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