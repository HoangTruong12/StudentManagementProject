using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Models;

namespace Web.Service.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<SearchInforDto> GetAllSearchInfor();

        IEnumerable<SearchInforDto> GetStudentsByClassName(string className);
        IEnumerable<SearchInforDto> GetStudentsByStudentName(string studentName);
        IEnumerable<SearchInforDto> GetStudentsByRating(string rating);
        IEnumerable<SearchInforDto> GetStudentsTop10();
        IEnumerable<SearchInforDto> GetStudentInfoByCondition(string studentName = "", string className = "", string rating = "");

        List<SelectListItem> ListRating();
        IEnumerable<ClassDto> GetAllClasses();
    }
}
