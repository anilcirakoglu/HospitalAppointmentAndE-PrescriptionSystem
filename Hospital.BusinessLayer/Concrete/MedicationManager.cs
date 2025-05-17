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
    public class MedicationManager : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;
        public MedicationManager(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }
        public async Task AddAsync(Medication medication)
        {
            await _medicationRepository.AddAsync(medication);
        }

        public async Task DeleteAsync(Medication medication)
        {
           await _medicationRepository.DeleteAsync(medication);
        }

        public async Task<List<Medication>> GetAllAsync()
        {
            return await _medicationRepository.GetAllAsync();
        }

        public Task<Medication> GetByIdAsync(int id)
        {
            return _medicationRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Medication medication)
        {
            await _medicationRepository.UpdateAsync(medication);
        }
    }
}
