using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using ProjectWork_M8_1247624.Models;



namespace ProjectWork_M8_1247624.Controllers
{
    public class HomeController : Controller
    {
        ProjectDbContext db = new ProjectDbContext();
        
        public ActionResult Index()
        {
           
            return View(db.Departments.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
          public ActionResult Report()
        {
            ViewBag.Message = "Your Report page.";

            return View();
        }
        public ActionResult Info()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/"), "Information.rpt"));
            var Info = (from d in db.Departments
                                  join e in db.Employees on d.DepartmentId equals e.DepartmentId
                                  select new { e.EmployeeName, d.DepartmentName, e.JoinDate,e.Grade }).ToList();
            rd.SetDataSource(Info);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Info.pdf");
        }

    }
}