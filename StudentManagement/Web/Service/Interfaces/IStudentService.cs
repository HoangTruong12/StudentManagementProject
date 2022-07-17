using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Service.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDto> GetStudents(string studentName);
        StudentDto GetStudentByID(int id);

        void InsertStudent(StudentDto student);

        void UpdateStudent(StudentDto student);

        void DeleteStudent(int id);

        //IEnumerable<ClassDto> GetClassNameByClassID(int classID);

        void Save();
    }
}
