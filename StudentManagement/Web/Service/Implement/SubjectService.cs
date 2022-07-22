using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Data;
using Web.Models;
using Web.Service.Interfaces;
using System.Data.Entity;

namespace Web.Service.Implement
{
    public class SubjectService : ISubjectService
    {
        private IStudentManagementEntities _studentManagementEntities;

        public SubjectService(IStudentManagementEntities studentManagementEntities)
        {
            _studentManagementEntities = studentManagementEntities;
        }

        public IEnumerable<SubjectDto> GetSubjects(string subjectName)
        {
            var listSubjects = _studentManagementEntities.Subjects.ToList();

            var result = listSubjects.Select(x => new SubjectDto
            {
                SubjectID = x.SubjectID,
                SubjectName = x.SubjectName
            });

            if (!string.IsNullOrEmpty(subjectName))
            {
                result = result.Where(x => x.SubjectName.Contains(subjectName));
            }

            return result;
        }

        public SubjectDto GetSubjectByID(int id)
        {
            var data = _studentManagementEntities.Subjects.Find(id);
            var convert = new SubjectDto()
            {
                SubjectID = data.SubjectID,
                SubjectName = data.SubjectName
            };
            return convert;
        }

        public void InsertSubject(SubjectDto subject)
        {
            _studentManagementEntities.Subjects.Add(new Subject
            {
                SubjectID = subject.SubjectID,
                SubjectName = subject.SubjectName
            });
        }

        public void UpdateSubject(SubjectDto subject)
        {
            var data = _studentManagementEntities.Subjects.FirstOrDefault(x => x.SubjectID == subject.SubjectID);
            if (data != null)
            {
                data.SubjectID = subject.SubjectID;
                data.SubjectName = subject.SubjectName;
            }
        }

        public void DeleteSubject(int id)
        {
            var data = _studentManagementEntities.Subjects.FirstOrDefault(x => x.SubjectID == id);
            _studentManagementEntities.Subjects.Remove(data);
        }

        public void Save()
        {
            _studentManagementEntities.SaveChanges();
        }
    }
}