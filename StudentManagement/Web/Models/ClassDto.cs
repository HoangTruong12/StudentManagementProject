using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Data;

namespace Web.Models
{
    public class ClassDto
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}