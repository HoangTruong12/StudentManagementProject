using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Service.Interfaces
{
    public interface IClassService
    {
        IEnumerable<ClassDto> GetClasses(string className);
        ClassDto GetClassByID(int id);

        void InsertClass(ClassDto classDto);

        void UpdateClass(ClassDto classDto);
        void DeleteClass(int id);
        void Save();

    }
}
