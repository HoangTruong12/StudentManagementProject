using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SearchInforDto
    {
        public string StudentName { get; set; }
        public Nullable<int> Age { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        //public Nullable<double> StartTermPoint { get; set; }
        //public Nullable<double> MidTermPoint { get; set; }
        //public Nullable<double> EndTermPoint { get; set; }
        public Nullable<double> AvgScore { get; set; }
    }
}