using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Abstract
{
    public interface IPrescriptionMedicationRepository
    {
        Task<PrescriptionMedication> GetByIdAsync(int id);
        Task<List<PrescriptionMedication>> GetAllAsync();
        Task AddAsync(PrescriptionMedication prescriptionMedication);
        Task UpdateAsync(PrescriptionMedication prescriptionMedication);
        Task DeleteAsync(PrescriptionMedication prescriptionMedication);
    }
}
