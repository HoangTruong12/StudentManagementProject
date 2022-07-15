using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ExamResultDto
    {
        public int ResultID { get; set; }
        public int SubjectID { get; set; }
        public int StudentID { get; set; }
        public double? AvgScores { get; set; }
    }
}