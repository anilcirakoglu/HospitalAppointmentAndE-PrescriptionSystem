using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DtoLayer.MedicalReportDto
{
    public class CreateMedicalReportDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DoctorId { get; set; }

        public DateTime ReportDate { get; set; }
        public string ReportDetails { get; set; }

        public string ReportFilePath { get; set; }
    }
}
