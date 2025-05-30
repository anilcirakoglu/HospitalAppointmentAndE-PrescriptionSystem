using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.EntityLayer.Enitities
{
    public class Medication
    {
        public Guid Id { get; set; }
        public string MedicineName { get; set; }
        public string Description { get; set; }
       
        public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
