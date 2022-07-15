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
    public class ExamResultController : Controller
    {
        private readonly IExamResultService _examResultService;
        public ExamResultController(IExamResultService examResultService)
        {
            _examResultService = examResultService;
        }
        // GET: Score
        public ActionResult Index()
        {
            var listScores = _examResultService.GetExamResults();
            return View(listScores);
        }

        public ActionResult Details(int id)
        {
            var details = _examResultService.GetExamResultByID(id);
            return View(details);
        }

        public ActionResult Create()
        {
            return View(new ExamResultDto());
        }

        [HttpPost]
        public ActionResult Create(ExamResultDto examResult)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _examResultService.InsertExamResult(examResult);
                    _examResultService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Error");
            }
            return View(examResult);
        }

        public ActionResult Edit(int id)
        {
            ExamResultDto examResult = _examResultService.GetExamResultByID(id);
            return View(examResult);
        }

        [HttpPost]
        public ActionResult Edit(ExamResultDto examResult)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _examResultService.UpdateExamResult(examResult);
                    _examResultService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Error");
            }
            return View(examResult);
        }

        public ActionResult Delete(int id)
        {
            ExamResultDto examResult = _examResultService.GetExamResultByID(id);
            return View(examResult);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                _examResultService.DeleteExamResult(id);
                _examResultService.Save();
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