using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Data;
using Web.Service.Implement;
using Web.Service.Interfaces;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentManagementEntities _studentManagementEntities;
        public HomeController(IStudentManagementEntities studentManagementEntities)
        {
            _studentManagementEntities = studentManagementEntities;
        }
        public ActionResult Index()
        {
            //var tests = _studentManagementEntities.Classes();
            return View();
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
    }
}