using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Data
{
    public partial class StudentManagementEntities : IStudentManagementEntities
    {
        void IStudentManagementEntities.SaveChanges()
        {
            this.SaveChanges();
        }

        public void Entry()
        {
            this.Entry();
        }

        public void Find()
        {
            this.Find();
        }

        public void Remove()
        {
            this.Remove();
        }

    }
}