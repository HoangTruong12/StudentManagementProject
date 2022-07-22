using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Web.Data
{
    public partial class StudentManagementEntities : IStudentManagementEntities
    {
        public void Find()
        {
            this.Find();
        }

        public void Remove()
        {
            this.Remove();
        }

        public void Include()
        {
            this.Include();
        }

        void IStudentManagementEntities.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}