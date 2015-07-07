using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace ULS_Site.Controllers
{
    public class CrystalRptViewerController : Controller
    {
        //
        // GET: /CrystalRptViewer/

        public ActionResult Index(string value1)
        {

            ViewData["querystring"] = value1; 
            ViewData["default_division"] = Session["default_division"];

            return View();
        }

        public ActionResult SvcRptViewer(string value1)
        {

            ViewData["querystring"] = value1; 
            return View();
        }

        public ActionResult QualificationRptViewer(string value1)
        {

            ViewData["querystring"] = value1;
            return View();
        }

        public ActionResult ElectronicsRptViewer(string value1)
        {

            ViewData["querystring"] = value1;
            ViewData["default_division"] = Session["default_division"];

            return View();
        }

    }
}
