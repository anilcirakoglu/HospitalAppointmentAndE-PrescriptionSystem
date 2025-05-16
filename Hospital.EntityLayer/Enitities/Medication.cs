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
        public string Dosage { get; set; }// Örn: "2x1", "1 tablet sabah akşam"
        public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
