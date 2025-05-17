using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Abstract
{
    public interface IMedicalReportService
    {
        Task AddAsync(MedicalReport medicalReport);
        Task UpdateAsync(MedicalReport medicalReport);
        Task DeleteAsync(MedicalReport medicalReport);
        Task<List<MedicalReport>> GetAllAsync();
        Task<MedicalReport> GetByIdAsync(int id);
    }
}
