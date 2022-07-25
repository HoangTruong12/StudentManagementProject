using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data
{
    public interface IStudentManagementEntities
    {
        DbSet<Class> Classes { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<ExamResult> ExamResults { get; set; }

        ObjectResult<GetStudentsByClassName_Result> GetStudentsByClassName(string className);
        ObjectResult<GetAllSearchInfo_Result> GetAllSearchInfo();
        ObjectResult<GetStudentsByStudentName_Result> GetStudentsByStudentName(string studentName);
        ObjectResult<GetStudentsInfoByRating_Result> GetStudentsInfoByRating(string rating);
        ObjectResult<GetStudentsTop10_Result> GetStudentsTop10();

        ObjectResult<string> GetClassName();

        void SaveChanges();
        void Find();
        void Remove();
        void Include();

    }
}
