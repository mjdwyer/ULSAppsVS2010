using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Web;

namespace ULS_Site.Legacy
{
    public partial class ViewCertReports : System.Web.UI.Page
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


                System.Data.DataSet ds = new System.Data.DataSet();
                //                System.Data.SqlClient.SqlConnection sqlcon = new System.Data.SqlClient.SqlConnection("Data Source=sql394.mysite4now.com;Initial Catalog=ULS_db1;User ID=uls2008;Password=2008uls");
                System.Data.SqlClient.SqlConnection sqlcon = new System.Data.SqlClient.SqlConnection("Data Source=(local);Initial Catalog=ULS_db1;User ID=uls2008;Password=uls2008");
                System.Data.SqlClient.SqlCommand comand = new System.Data.SqlClient.SqlCommand();
                comand.Connection = sqlcon;
                comand.CommandText = strSP;
                comand.CommandType = System.Data.CommandType.StoredProcedure;

                switch (strRpt)
                {

                    case "EmployeeListByCertification":
                        strReportPath = Server.MapPath("~/Reports/QualEmpListByCert.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@companyId", System.Data.SqlDbType.VarChar, 25));
                        comand.Parameters["@companyId"].Value = strParm1;
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@qualId", System.Data.SqlDbType.VarChar, 25));
                        comand.Parameters["@qualId"].Value = strParm2;
                        break;

                    case "EmployeeListByCompany":
                        strReportPath = Server.MapPath("~/Reports/QualEmpListByCompany.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@companyId", System.Data.SqlDbType.VarChar, 25));
                        comand.Parameters["@companyId"].Value = strParm1;
                        break;
                    case "CertListByEmployee":
                        strReportPath = Server.MapPath("~/Reports/CertListByEmployee.rpt");
                        comand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@employeeId", System.Data.SqlDbType.Int));
                        comand.Parameters["@employeeId"].Value = strParm1;
                        break;

                    case "EmpListExpiredCerts":
                        strReportPath = Server.MapPath("~/Reports/EmployeeListExpiredCerts.rpt");
                        break;

                    case "EmpListDueToExpire90Days":
                        strReportPath = Server.MapPath("~/Reports/EmployeeListDueToExpireCerts.rpt");
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
            }
        }

    }
}