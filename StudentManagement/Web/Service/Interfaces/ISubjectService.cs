using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Service.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<SubjectDto> GetSubjects(string subjectName);

        SubjectDto GetSubjectByID(int id);

        void InsertSubject(SubjectDto subject);

        void UpdateSubject(SubjectDto subject);
        void DeleteSubject(int id);
        void Save();
    }
}
