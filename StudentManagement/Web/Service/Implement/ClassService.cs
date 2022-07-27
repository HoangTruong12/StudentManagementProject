using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.Data;
using Web.Models;
using Web.Service.Interfaces;

namespace Web.Service.Implement
{
    public class ClassService : IClassService
    {
        private IStudentManagementEntities _studentManagementEntities;

        public ClassService(IStudentManagementEntities studentManagementEntities)
        {
            _studentManagementEntities = studentManagementEntities;
        }

        public IEnumerable<ClassDto> GetClasses(string className)
        {
            //var listClasses = from c in _studentManagementEntities.Classes
            //                  select c;

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    listClasses = listClasses.Where(x => x.ClassName.Contains(searchString));
            //}


            //return listClasses;
            var listClasses = _studentManagementEntities.Classes.Take(20).ToList();

            var result = listClasses.Select(x => new ClassDto
            {
                ClassID = x.ClassID,
                ClassName = x.ClassName
            });

            if (!string.IsNullOrEmpty(className))
            {
                result = result.Where(x => x.ClassName.Contains(className));
            }

            return result;
        }



        public ClassDto GetClassByID(int id)
        {
            var data = _studentManagementEntities.Classes.Find(id);
            var convert = new ClassDto()
            {
                ClassID = data.ClassID,
                ClassName = data.ClassName
            };
            return convert;
        }

        public void InsertClass(ClassDto classDto)
        {
            _studentManagementEntities.Classes.Add(new Class
            {
                ClassID = classDto.ClassID,
                ClassName = classDto.ClassName
            });
        }

        public void UpdateClass(ClassDto classDto)
        {
            var data = _studentManagementEntities.Classes.FirstOrDefault(x => x.ClassID == classDto.ClassID);
            data.ClassID = classDto.ClassID;
            data.ClassName = classDto.ClassName;
        }

        public void DeleteClass(int id)
        {
            var data = _studentManagementEntities.Classes.FirstOrDefault(x => x.ClassID == id);
            _studentManagementEntities.Classes.Remove(data);
        }

        public void Save()
        {
            _studentManagementEntities.SaveChanges();
        }

        //public IEnumerable<GetStudentByClassName_ResultDto> Search(string className)
        //{
        //    var std = _studentManagementEntities.GetStudentsByClassName(className);
        //    var convert = std.Select(x => new GetStudentByClassName_ResultDto
        //    {
        //        StudentName = x.StudentName,
        //        Age = x.Age,
        //        ClassName = x.ClassName,
        //        SubjectName = x.SubjectName,
        //        AvgScores = x.AvgScores
        //    }).ToList();

        //    return convert;
        //}
    }
}