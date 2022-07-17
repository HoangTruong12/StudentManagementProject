using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
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

        public ActionResult Index(string className)
        {
            var listClasses = _classService.GetClasses(className);
            return View(listClasses);
        }

        public ActionResult Details(int id)
        {
            var details = _classService.GetClassByID(id);
            return View(details);
        }

        public ActionResult Create()
        {
            return View(new ClassDto());
        }

        [HttpPost]
        public ActionResult Create(ClassDto classDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _classService.InsertClass(classDto);
                    _classService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Error");
            }
            return View(classDto);
        }

        public ActionResult Edit(int id)
        {
            ClassDto classDto = _classService.GetClassByID(id);
            return View(classDto);
        }

        [HttpPost]
        public ActionResult Edit(ClassDto classDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _classService.UpdateClass(classDto);
                    _classService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Error");
            }
            return View(classDto);
        }

        public ActionResult Delete(int id)
        {
            ClassDto classDto = _classService.GetClassByID(id);
            return View(classDto);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                //SubjectDto subject = _subjectService.GetSubjectByID(subjectID);
                _classService.DeleteClass(id);
                _classService.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary
                {
                    {"id", id },
                    {"saveChangesError", true }
                });
            }
            return RedirectToAction("Index");
        }
    }
}