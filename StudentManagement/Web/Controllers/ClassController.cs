using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Service.Interfaces;

namespace Web.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        public ActionResult Index()
        {
            var listClasses = _classService.GetClasses();
            return View(listClasses);
        }
    }
}