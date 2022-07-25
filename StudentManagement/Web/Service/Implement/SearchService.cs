using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Data;
using Web.Models;
using Web.Service.Interfaces;

namespace Web.Service.Implement
{
    public class SearchService : ISearchService
    {
        private IStudentManagementEntities _studentManagementEntities;

        public SearchService(IStudentManagementEntities studentManagementEntities)
        {
            _studentManagementEntities = studentManagementEntities;
        }
        public IEnumerable<SearchInforDto> GetAllSearchInfor()
        {
            var listSearch = _studentManagementEntities.GetAllSearchInfo();

            var result = listSearch.Select(x => new SearchInforDto
            {
                StudentName = x.StudentName,
                Age = x.Age,
                ClassName = x.ClassName,
                SubjectName = x.SubjectName,
                AvgScore = x.AvgScore
            });

            return result;
        }

        public IEnumerable<SearchInforDto> GetStudentsByStudentName(string studentName)
        {
            var std = _studentManagementEntities.GetStudentsByStudentName(studentName).ToList();

            var convert = std.Select(x => new SearchInforDto
            {
                StudentName = x.StudentName,
                Age = x.Age,
                ClassName = x.ClassName,
                SubjectName = x.SubjectName,
                AvgScore = x.AvgScore
            }).ToList();

            return convert;
        }

        public IEnumerable<SearchInforDto> GetStudentsByClassName(string className)
        {
            var classes = _studentManagementEntities.GetStudentsByClassName(className).ToList();

            var convert = classes.Select(x => new SearchInforDto
            {
                StudentName = x.StudentName,
                Age = x.Age,
                ClassName = x.ClassName,
                SubjectName = x.SubjectName,
                AvgScore = x.AvgScore
            }).ToList();

            return convert;

        }

        

        public IEnumerable<SearchInforDto> GetStudentsByRating(string rating)
        {
            var std = _studentManagementEntities.GetStudentsInfoByRating(rating);

            var convert = std.Select(x => new SearchInforDto
            {
                StudentName = x.StudentName,
                Age = x.Age,
                ClassName = x.ClassName,
                SubjectName = x.SubjectName,
                AvgScore = x.AvgScore
            }).ToList();

            return convert;
        }



        public List<SelectListItem> ListRating()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text="Chọn học lực", Value = "0"});
            items.Add(new SelectListItem { Text = "Yếu", Value = "1", });
            items.Add(new SelectListItem { Text = "Trung bình", Value = "2" });
            items.Add(new SelectListItem { Text = "Khá", Value = "3" });
            items.Add(new SelectListItem { Text = "Giỏi", Value = "4" });
            return items;
        }

        public IEnumerable<ClassDto> GetAllClasses()
        {
            var listClasses = _studentManagementEntities.Classes.ToList();

            //var result = listClasses.Select(x => new ClassDto
            //{
            //    ClassID = x.ClassID,
            //    ClassName = x.ClassName,
            //});

            //return result.Distinct();

            var query = (from ClassName in listClasses
                         select ClassName
                         ).Distinct();

            var result = query.Select(x => new ClassDto
            {
                ClassID = x.ClassID,
                ClassName = x.ClassName,
            });


            return result;
        }

        public IEnumerable<SearchInforDto> GetStudentsTop10()
        {
            var students = _studentManagementEntities.GetStudentsTop10().ToList();

            var convert = students.Select(x => new SearchInforDto
            {
                StudentName = x.StudentName,
                Age = x.Age,
                ClassName = x.ClassName,
                SubjectName = x.SubjectName,
                AvgScore = x.AvgScore
            });

            return convert;
        }
    }
}