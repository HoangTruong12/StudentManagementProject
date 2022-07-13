using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Data;
using Web.Models;
using Web.Service.Interfaces;

namespace Web.Service.Implement
{
    public class ClassService : IClassService
    {
        private IStudentManagementEntities _studentManagementEntities;

        public ClassService(IStudentManagementEntities studentManagementEntities)
        {
            _studentManagementEntities = studentManagementEntities;
        }

        public IEnumerable<ClassDto> ClassDtos()
        {
            throw new NotImplementedException();
        }
    }
}