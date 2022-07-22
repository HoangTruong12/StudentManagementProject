using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Data;
using Web.Models;
using Web.Service.Interfaces;

namespace Web.Service.Implement
{
    public class ExamResultService : IExamResultService
    {
        private IStudentManagementEntities _studentManagementEntities;

        public ExamResultService(IStudentManagementEntities studentManagementEntities)
        {
            _studentManagementEntities = studentManagementEntities;
        }

        public IEnumerable<ExamResultDto> GetExamResults()
        {
            var listScores = _studentManagementEntities.ExamResults.Include("Subject").Include("Student").ToList();

            var result = listScores.Select(x => new ExamResultDto
            {
                ResultID = x.ResultID,
                StudentID = x.StudentID,
                SubjectID = x.SubjectID,
                StartTermPoint = x.StartTermPoint,
                MidTermPoint = x.MidTermPoint,
                EndTermPoint = x.EndTermPoint,
                Subject = x.Subject,
                Student = x.Student,
            });

            return result;
        }

        public ExamResultDto GetExamResultByID(int id)
        {
            var data = _studentManagementEntities.ExamResults.Find(id);
            var convert = new ExamResultDto()
            {
                ResultID = data.ResultID,
                SubjectID = data.SubjectID,
                StudentID = data.StudentID,
                StartTermPoint = data.StartTermPoint,
                MidTermPoint = data.MidTermPoint,
                EndTermPoint = data.EndTermPoint,
            };
            return convert;
        }

        public void InsertExamResult(ExamResultDto examResult)
        {
            _studentManagementEntities.ExamResults.Add(new ExamResult
            {
                ResultID = examResult.ResultID,
                SubjectID = examResult.SubjectID,
                StudentID = examResult.StudentID,
                StartTermPoint = examResult.StartTermPoint,
                MidTermPoint = examResult.MidTermPoint,
                EndTermPoint = examResult.EndTermPoint,
            });
        }

        public void UpdateExamResult(ExamResultDto examResult)
        {
            var data = _studentManagementEntities.ExamResults.FirstOrDefault(x => x.ResultID == examResult.ResultID);
            if(data != null)
            {
                data.ResultID = examResult.ResultID;
                data.SubjectID = examResult.SubjectID;
                data.StudentID = examResult.StudentID;
                data.StartTermPoint = examResult.StartTermPoint;
                data.MidTermPoint = examResult.MidTermPoint;
                data.EndTermPoint = examResult.EndTermPoint;
            }
        }

        public void DeleteExamResult(int id)
        {
            var data = _studentManagementEntities.ExamResults.FirstOrDefault(x => x.ResultID == id);
            _studentManagementEntities.ExamResults.Remove(data);
        }

        public void Save()
        {
            _studentManagementEntities.SaveChanges();
        }
    }
}