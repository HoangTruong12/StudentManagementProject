using DevExpress.XtraPrinting;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Web.Models;
using Web.Reports;
using Web.Service.Interfaces;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        private static IEnumerable<SearchInforDto> listStudent = new List<SearchInforDto>();

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

        public ActionResult Index(string studentName = "", string className = "", string rating = "")
        {
            var classes = _searchService.GetAllClasses();

            ViewBag.className = new SelectList(classes, "ClassName", "ClassName");

            if (studentName == string.Empty && rating == string.Empty && className == string.Empty)
            {
                //var list = _searchService.GetStudentsTop10().ToList();
                listStudent = _searchService.GetStudentsTop10().ToList();
                return View(listStudent.ToList());
            }

            //var result = _searchService.GetStudentInfoByCondition(studentName, className, rating);
            listStudent = _searchService.GetStudentInfoByCondition(studentName, className, rating).ToList();
            
            return View(listStudent.ToList());

            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["StudentManagementEntities1"].ConnectionString;

            //SqlCommand cmd = new SqlCommand()
            //{
            //    CommandText = "GetStudentSearchInfo",
            //    Connection = con,
            //    CommandType = CommandType.StoredProcedure
            //};

            //cmd.Parameters.Add("@studentName", SqlDbType.NVarChar).Value = studentName;
            //cmd.Parameters.Add("@className", SqlDbType.NVarChar).Value = className;
            //cmd.Parameters.Add("@rating", SqlDbType.NVarChar).Value = rating;

            //con.Open();
            //cmd.ExecuteReader();
            //con.Close();

            //return View(cmd);

            // ------------------------------------------

            //ViewBag.Rating = _searchService.ListRating();

            //var result = from d in _searchService.GetAllSearchInfor()
            //             where studentName != string.Empty  && d.StudentName == studentName
            //             &&  (rating != string.Empty  && d.Rating == rating);

            //var result = _searchService.GetAllSearchInfor();

            //if (!string.IsNullOrEmpty(rating) && !rating.Contains("Chọn học lực"))
            //{
            //     result = _searchService.GetStudentsByRating(rating).Take(20);
            //}

            //if (!string.IsNullOrEmpty(studentName))
            //{
            //    result = result.Where(x => x.StudentName == studentName ).Take(20).ToList();
            //    //result = _searchService.GetStudentsByStudentName(studentName);
            //}

            //if (!string.IsNullOrEmpty(className))
            //{
            //    result = result.Where(x => x.ClassName == className).ToList();
            //    //result = _searchService.GetStudentsByClassName(className);
            //}
            //else 
            //    if(rating == "Chọn học lực" && className == "" && studentName == "")
            //{
            //    result = _searchService.GetStudentsTop10();
            //}

            //return View(result.ToList());
        }

        public ActionResult ExportPDF() //string studentName = "", string className = "", string rating = ""
        {
            //var data = _searchService.GetAllSearchInfor();
            //return new PartialViewAsPdf("_GetAllSearch", data)
            //{
            //    FileName = "StudentManagement.pdf"
            //};

            //var list = _searchService.GetStudentsTop10().ToList();
            //var result = _searchService.GetStudentInfoByCondition(studentName, className, rating);

            StudentManagementReport rpt = new StudentManagementReport();
            rpt.DataSource = listStudent;

            MemoryStream stream = new MemoryStream();

            rpt.ExportToPdf(stream);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "StudentManagement.pdf",
                Inline = false
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(stream.ToArray(), "application/pdf");
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