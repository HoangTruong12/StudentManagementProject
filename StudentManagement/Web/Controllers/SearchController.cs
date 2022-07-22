using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Service.Interfaces;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        // GET: Search
        //public ActionResult Index(string option, string searchString)
        //{

        //    if (option == "ClassNameSearch")
        //    {
        //        var classNameSearch = _searchService.GetStudentsByClassName(searchString);
        //        return View(classNameSearch);

        //    }
        //    if (option == "StudentNameSearch")
        //    {
        //        var studentNameSearch = _searchService.GetStudentsByStudentName(searchString);
        //        return View(studentNameSearch);
        //    }
        //    if (option == "Rating")
        //    {
        //        var rating = _searchService.GetStudentsByRating(searchString);
        //        return View(rating);
        //    }
        //    if (option == "Reset")
        //    {
        //        ModelState.Clear();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        var classes = _searchService.GetAllSearchInfor();
        //        return View(classes);
        //    }

        //}

        public ActionResult Index(string className, string studentName, string rating)
        {
            var classes = _searchService.GetAllClasses();
            ViewBag.className = new SelectList(classes, "ClassName", "ClassName");

            //ViewBag.Rating = _searchService.ListRating();

            var result = _searchService.GetAllSearchInfor();

            if (!string.IsNullOrEmpty(rating) && !rating.Contains("Chọn học lực"))
            {
                result = _searchService.GetStudentsByRating(rating);
            }

            if (!string.IsNullOrEmpty(studentName))
            {
                result = result.Where(x => x.StudentName == studentName).ToList();
            }

            if (!string.IsNullOrEmpty(className))
            {
                result = result.Where(x => x.ClassName == className).ToList();
            }
            else 
                if(rating == "Chọn học lực" && className == "" && studentName == "")
            {
                result = _searchService.GetStudentsTop10();
            }

           
            return View(result.ToList());
        }

        

        //public PartialViewResult GetAllSearch()
        //{
        //    var getAllSearch = _searchService.GetAllSearchInfor();
        //    return PartialView("_GetAllSearch", getAllSearch);
        //}

        //public PartialViewResult GetInfoSearchByStudentName(string searchString)
        //{
        //    var searchByStudentName = _searchService.GetStudentsByStudentName(searchString);
        //    return PartialView("_GetAllSearch", searchByStudentName);
        //}

        //public PartialViewResult GetInfoSearchByClassName(string searchString)
        //{
        //    var searchByStudentName = _searchService.GetStudentsByClassName(searchString);
        //    return PartialView("_GetAllSearch", searchByStudentName);
        //}


    }
}