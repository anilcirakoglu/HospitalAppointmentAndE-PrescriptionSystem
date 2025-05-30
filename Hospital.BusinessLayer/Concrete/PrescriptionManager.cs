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
    public class PrescriptionManager : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        public PrescriptionManager(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }
        public async Task AddAsync(Prescription prescription)
        {
            await _prescriptionRepository.AddAsync(prescription);
        }

        public async Task DeleteAsync(Prescription prescription)
        {
            await _prescriptionRepository.DeleteAsync(prescription);
        }

        public async Task<List<Prescription>> GetAllAsync()
        {
            return await _prescriptionRepository.GetAllAsync();
        }

        public async Task<Prescription> GetByIdAsync(int id)
        {
            return await _prescriptionRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Prescription prescription)
        {
            await _prescriptionRepository.UpdateAsync(prescription);
        }
    }
}
