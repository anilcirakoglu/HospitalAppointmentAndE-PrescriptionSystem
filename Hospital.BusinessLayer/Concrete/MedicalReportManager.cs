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
    public class MedicalReportManager : IMedicalReportService
    {
        private readonly IMedicalReportRepository _medicalReportRepository;
        public MedicalReportManager(IMedicalReportRepository medicalReportRepository)
        {
            _medicalReportRepository = medicalReportRepository;
        }
        public async Task AddAsync(MedicalReport medicalReport)
        {
            await _medicalReportRepository.AddAsync(medicalReport);
        }

        public async Task DeleteAsync(MedicalReport medicalReport)
        {
           await _medicalReportRepository.DeleteAsync(medicalReport);
        }

        public async Task<List<MedicalReport>> GetAllAsync()
        {
           return await _medicalReportRepository.GetAllAsync();
        }

        public async Task<MedicalReport> GetByIdAsync(int id)
        {
           return await _medicalReportRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(MedicalReport medicalReport)
        {
           await _medicalReportRepository.UpdateAsync(medicalReport);
        }
    }
}
