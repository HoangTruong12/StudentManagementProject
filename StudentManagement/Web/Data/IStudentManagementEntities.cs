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
    }
}
