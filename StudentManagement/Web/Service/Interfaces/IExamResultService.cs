using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Service.Interfaces
{
    public interface IExamResultService
    {
        IEnumerable<ExamResultDto> GetExamResults();

        ExamResultDto GetExamResultByID(int id);

        void InsertExamResult(ExamResultDto examResult);

        void UpdateExamResult(ExamResultDto examResult);

        void DeleteExamResult(int id);

        void Save();
    }
}
