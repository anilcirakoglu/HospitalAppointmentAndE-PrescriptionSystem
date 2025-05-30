using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Abstract
{
    public interface IPrescriptionMedicationService
    {
        Task AddAsync(PrescriptionMedication prescriptionMedication);
        Task UpdateAsync(PrescriptionMedication prescriptionMedication);
        Task DeleteAsync(PrescriptionMedication prescriptionMedication);
        Task<List<PrescriptionMedication>> GetAllAsync();
        Task<PrescriptionMedication> GetByIdAsync(int id);
    }
}
