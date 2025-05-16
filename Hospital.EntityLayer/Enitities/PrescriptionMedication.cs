using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.EntityLayer.Enitities
{
    public class PrescriptionMedication
    {
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public Guid MedicationId { get; set; }
        public Medication Medication { get; set; }

        public string Instructions { get; set; }
    }
}
