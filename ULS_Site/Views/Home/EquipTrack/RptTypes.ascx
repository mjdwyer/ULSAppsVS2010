<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="ULS_Site.Models"%>

<span>Equipment Type</span><br /><br />
<%= Html.DropDownList("lstTypes", (IEnumerable<SelectListItem>)ViewData["TypesList"], new { onchange = "CheckRptByTypeForm();" })%>
<br /><br />

