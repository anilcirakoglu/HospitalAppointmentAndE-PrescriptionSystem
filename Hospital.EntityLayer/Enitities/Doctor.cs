using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.EntityLayer.Enitities
{
    public class Doctor
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Specialty { get; set; }
        public string RoomNumber { get; set; }
        public string Qualification { get; set; }
        public string Description { get; set; }

        public ICollection<WorkingHour> WorkingHours { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalReport> MedicalReports { get; set; }
    }
}
 