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
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: Subject
        public ActionResult Index()
        {
            var listSubjects = _subjectService.GetSubjects();
            return View(listSubjects);
        }

        public ActionResult Details(int id)
        {
            var details = _subjectService.GetSubjectByID(id);
            return View(details);
        }

        public ActionResult Create()
        {
            return View(new SubjectDto());
        }

        [HttpPost]
        public ActionResult Create(SubjectDto subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _subjectService.InsertSubject(subject);
                    _subjectService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Error");
            }
            return View(subject);
        }

        public ActionResult Edit(int id)
        {
            SubjectDto subject = _subjectService.GetSubjectByID(id);
            return View(subject);
        }

        [HttpPost]
        public ActionResult Edit(SubjectDto subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _subjectService.UpdateSubject(subject);
                    _subjectService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Error");
            }
            return View(subject);
        }

        public ActionResult Delete(int id)
        {
            SubjectDto subject = _subjectService.GetSubjectByID(id);
            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                //SubjectDto subject = _subjectService.GetSubjectByID(subjectID);
                _subjectService.DeleteSubject(id);
                _subjectService.Save();
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