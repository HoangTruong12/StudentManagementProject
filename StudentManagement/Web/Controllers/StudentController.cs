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
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: Student
        public ActionResult Index(string studentName, int classID = 0)
        {
            var classes = _studentService.GetAllClasses();
            // Hiển thị ClassID bằng ClassName cho DropDownList bên View
            ViewBag.classID = new SelectList(classes, "ClassID", "ClassName");

            var listStudents = _studentService.GetStudents(studentName, classID);

            return View(listStudents.ToList());

        }

        public ActionResult Details(int id)
        {
            var details = _studentService.GetStudentByID(id);
            return View(details);
        }

        public ActionResult Create()
        {
            var classes = _studentService.GetAllClasses();
            ViewBag.createID = new SelectList(classes, "ClassID", "ClassName");
            return View(new StudentDto());
        }

        [HttpPost]
        public ActionResult Create(StudentDto student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentService.InsertStudent(student);
                    _studentService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Error");
            }
           
            return View(student);
        }

        public ActionResult Edit(int id)
        {
            StudentDto student = _studentService.GetStudentByID(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentDto student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentService.UpdateStudent(student);
                    _studentService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Error");
            }
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            StudentDto student = _studentService.GetStudentByID(id);
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            { 
                _studentService.DeleteStudent(id);
                _studentService.Save();
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

        public ActionResult Register(ExamResultDto examResult)
        {
            return View(examResult);
        }
    }
}