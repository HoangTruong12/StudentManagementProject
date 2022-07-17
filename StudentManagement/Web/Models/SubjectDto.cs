using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Data;

namespace Web.Models
{
    public class SubjectDto
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
    }
}