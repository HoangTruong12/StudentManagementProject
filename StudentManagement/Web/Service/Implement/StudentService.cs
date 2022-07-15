using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Data;
using Web.Models;
using Web.Service.Interfaces;

namespace Web.Service.Implement
{
    public class StudentService : IStudentService
    {
        private IStudentManagementEntities _studentManagementEntities;

        public StudentService(IStudentManagementEntities studentManagementEntities)
        {
            _studentManagementEntities = studentManagementEntities;
        }


        public IEnumerable<StudentDto> GetStudents()
        {
            var listStudents = _studentManagementEntities.Students.ToList();

            var result = listStudents.Select(x => new StudentDto
            {
                StudentID = x.StudentID,
                StudentName = x.StudentName,
                Age = x.Age,
                ClassID = x.ClassID
            });

            return result;
        }

        public StudentDto GetStudentByID(int id)
        {
            var data = _studentManagementEntities.Students.Find(id);
            var convert = new StudentDto()
            {
                StudentID = data.StudentID,
                StudentName = data.StudentName,
                Age = data.Age,
                ClassID = data.ClassID
            };
            return convert;
        }

        public void InsertStudent(StudentDto student)
        {
            _studentManagementEntities.Students.Add(new Student
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName,
                Age = student.Age,
                ClassID = student.ClassID
            });
        }

        public void UpdateStudent(StudentDto student)
        {
            var data = _studentManagementEntities.Students.FirstOrDefault(x => x.StudentID == student.StudentID);
            if(data != null)
            {
                data.StudentID = student.StudentID;
                data.StudentName = student.StudentName;
                data.Age = student.Age;
                data.ClassID = student.ClassID;
            }
        }

        public void DeleteStudent(int id)
        {
            var data = _studentManagementEntities.Students.FirstOrDefault(x => x.StudentID == id);
            _studentManagementEntities.Students.Remove(data);
        }

        public void Save()
        {
            _studentManagementEntities.SaveChanges();
        }
    }
}