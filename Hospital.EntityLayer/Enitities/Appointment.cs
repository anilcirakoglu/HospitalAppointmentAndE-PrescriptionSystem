using Hospital.EntityLayer.Enitities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.EntityLayer.Enitities
{
    public class Appointment
    {
        public Guid Id { get; set; } 

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
        public string Notes { get; set; }
    }
}
