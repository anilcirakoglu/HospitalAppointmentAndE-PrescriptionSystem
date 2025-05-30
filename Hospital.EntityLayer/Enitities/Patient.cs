using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.EntityLayer.Enitities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public Guid MedicalReportId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string InsuranceNumber { get; set; }
        public ICollection<Appointment> Appointment{ get; set; }
        public ICollection<MedicalReport> MedicalReports { get; set; }
    }
}
