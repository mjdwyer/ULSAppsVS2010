<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %> 
    
<asp:Content ID="HeadContentFromPage" ContentPlaceHolderId="EquipHeadContent" runat="server">

    <link rel="stylesheet" type="text/css" media="screen" href="../../Content/superfish.css" />

    <script type="text/javascript" src="/Scripts/Qualificatons2.js?01"></script> 
    <script type="text/javascript" src="/Scripts/superfish.js"></script>
    <script type="text/javascript" src="/Scripts/supersubs.js"></script>
    <script type="text/javascript" src="/Scripts/superfish-navbar.js"></script>
	<script type="text/javascript">

		    // initialise plugins
		    jQuery(function() {
                $("ul.sf-menu").supersubs({ 
                    minWidth:    12,   // minimum width of sub-menus in em units 
                    maxWidth:    27,   // maximum width of sub-menus in em units 
                    extraWidth:  1     // extra width can ensure lines don't sometimes turn over 
                                       // due to slight rounding differences and font-family
                }).superfish();  // call supersubs first, then superfish, so that subs are
              		    });

  		    $(function() {
  		        $('input').filter('.datepicker').datepicker({
  		            changeMonth: true,
  		            changeYear: true
  		        });
  		    });

	</script>
    
</asp:Content>
    
<script runat="server" >
        
    
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="rpt_dialog" title="">
        <form id="rptDlgForm"  action="/Qualification/ShowReport" method="post"> 
        
        <center><div id="div1">Company</div></center>
        <center><select id ="ddlRptCompany" name="ddlRptCompany" onchange="LoadRptQualDDLs()"  >
	      <option value="NONE">  </option>
          <option value="MEA">MEA</option>
          <option value="SJG">SJG</option>
          <option value="UGI">UGI</option>
          <option value="WG">WG</option>
          <option value="PECO">PECO</option>
          <option value="ULS">ULS</option>
          <option value="GWS">GWS</option>
        </select></center>         
                
        <center>
        <div id="rpt_dlg_results"></div>
        </center>
        <br />
        <p style="padding-left:180px"><input type="submit" value="Show report" id="btnSubmit" style="float:left" onclick="ShowRptFormWait()"/> 
        <input type="button" onclick="CloseReportDialog()" value="Close" id="Button2" />
         </p>
        <p></p> 
        <input type="hidden"  id="hdnReportName" name="hdnReportName" value=""/>
        <input type="hidden"  id="hdnID" name="hdnID" value=""/>
        <br />
        <center><img id="rpt_loading" src="/Content/images/ajax-loader.gif" alt=""/></center>
        <br />
        <img src="/Content/images/help3.gif" alt=" " width="32" height="32" onclick="ShowHelp()" style="cursor:pointer; margin-left:475px" /> 
        </form>         
    </div>
    
    <div id="help_popup" style="background-color:#CCFFFF">
    <table>
    <tr>
    <td>
    <div id="help_results" style="color:#A20000"></div>
    </td>
    </tr>
    </table>
    </div>
<div id = "menu">
		<ul class="sf-menu">
			<li class="current">
                <%= Html.ActionLink("Main", "Qualification", "Qualification", null, null)%>
			</li>
			<li>
				<a href="#">Admin</a>
				<ul>
					<li><a href="#" onclick="AdminCertifications()">Certifications</a></li>
				</ul>
			</li>
			
			<li>
				<a href="#">Reports</a>
				<ul>
    	            <li><a href="#" onclick="EmployeeListByCertification()">Qualified Employee List by Certification</a></li>
    	            <li><a href="#" onclick="EmployeeListByCompany()">Qualified Employee List by Company</a></li>
    	            <li><a href="#" onclick="EmployeeListOfExpiredCerts()">Employee List With Expired Certifications</a></li>
    	            <li><a href="#" onclick="EmployeeListDueToExpireCerts()">Employee List With Certications Due To Expire(within 90 days)</a></li>
    	            <li><a href="#" onclick="CertListByEmployee()">Certifications For Selected Employee</a></li>
				</ul>
			</li>
		</ul>
</div><br /><br /><br />
<script type="text/javascript">
    //<!--
    function autoResize(id) {
        var newheight;
        var newwidth;

        if (document.getElementById) {
            newheight = document.getElementById(id).contentWindow.document.body.scrollHeight;
            newwidth = document.getElementById(id).contentWindow.document.body.scrollWidth;
        }

        document.getElementById(id).height = (newheight) + "px";
        document.getElementById(id).width = (newwidth) + "px";
    }
    //-->
</script>


<iframe src="../Legacy/ViewCertReports.aspx?value1=<%= ViewData["querystring"] %>" width="100%" height="200px" id="iframe1" marginheight="0" frameborder="0" onload="autoResize('iframe1');" scrolling="no"></iframe>


</asp:Content>
