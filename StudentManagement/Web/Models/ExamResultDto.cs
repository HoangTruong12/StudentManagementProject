using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Data;

namespace Web.Models
{
    public class ExamResultDto
    {
        public int ResultID { get; set; }
        public int SubjectID { get; set; }
        public int StudentID { get; set; }
        public Nullable<double> StartTermPoint { get; set; }
        public Nullable<double> MidTermPoint { get; set; }
        public Nullable<double> EndTermPoint { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}