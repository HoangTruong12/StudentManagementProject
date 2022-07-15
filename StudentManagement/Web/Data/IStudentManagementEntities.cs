using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        void SaveChanges();
        void Entry();
        void Find();
        void Remove();
    }
}
