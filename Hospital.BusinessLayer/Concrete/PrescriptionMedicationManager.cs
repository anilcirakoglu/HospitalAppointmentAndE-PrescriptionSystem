using Hospital.BusinessLayer.Abstract;
using Hospital.DataAccessLayer.Abstract;
using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Concrete
{
    public class PrescriptionMedicationManager : IPrescriptionMedicationService
    {
        private readonly IPrescriptionMedicationRepository _prescriptionMedicationRepository;
        public PrescriptionMedicationManager(IPrescriptionMedicationRepository prescriptionMedicationRepository)
        {
            _prescriptionMedicationRepository = prescriptionMedicationRepository;
        }
        public async Task AddAsync(PrescriptionMedication prescriptionMedication)
        {
           await _prescriptionMedicationRepository.AddAsync(prescriptionMedication);
        }

        public async Task DeleteAsync(PrescriptionMedication prescriptionMedication)
        {
            await _prescriptionMedicationRepository.DeleteAsync(prescriptionMedication);
        }

        public async Task<List<PrescriptionMedication>> GetAllAsync()
        {
            return await _prescriptionMedicationRepository.GetAllAsync();
        }

        public async Task<PrescriptionMedication> GetByIdAsync(int id)
        {
            return await _prescriptionMedicationRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(PrescriptionMedication prescriptionMedication)
        {
            await _prescriptionMedicationRepository.UpdateAsync(prescriptionMedication);
        }
    }
}
