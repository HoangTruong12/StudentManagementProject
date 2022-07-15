using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class StudentDto
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int? Age { get; set; }
        public int? ClassID { get; set; }
    }
}