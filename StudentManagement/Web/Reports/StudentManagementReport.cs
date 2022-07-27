using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Web.Reports
{
    public partial class StudentManagementReport : DevExpress.XtraReports.UI.XtraReport
    {
        public StudentManagementReport()
        {
            InitializeComponent();
        }

        private void StudentManagementReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
    }
}
