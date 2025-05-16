using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.EntityLayer.Enitities
{
    public class Prescription
    {
        public Guid Id { get; set; }  

        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Notes { get; set; }  

        public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
