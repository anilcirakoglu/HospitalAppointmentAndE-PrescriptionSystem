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
    public class PatientManager : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientManager(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task AddAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
        }

        public async Task DeleteAsync(Patient patient)
        {
           await _patientRepository.DeleteAsync(patient);
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
        }
    }
}
