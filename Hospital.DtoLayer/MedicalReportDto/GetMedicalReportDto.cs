using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DtoLayer.MedicalReportDto
{
    public class GetMedicalReportDto
    {
        public string DoctorName { get; set; }
        public string Specialty { get; set; }
        public string Qualification { get; set; }

        public string PatientName { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportDetails { get; set; }
        public string ReportFilePath { get; set; }
    }
}
