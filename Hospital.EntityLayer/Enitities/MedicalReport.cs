using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.EntityLayer.Enitities
{
    public class MedicalReport
    {
        public Guid Id { get; set; }

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime ReportDate { get; set; }
        public string ReportDetails { get; set; }

        public string ReportFilePath { get; set; }
    }
}
