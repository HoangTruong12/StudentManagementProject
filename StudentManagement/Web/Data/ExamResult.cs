//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExamResult
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
