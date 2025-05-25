using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Abstract
{
    public interface IMedicalReportRepository
    {
        Task<MedicalReport> GetByIdAsync(Guid id);
        Task<List<MedicalReport>> GetAllAsync();
        Task AddAsync(MedicalReport medicalReport);
        Task UpdateAsync(MedicalReport medicalReport);
        Task DeleteAsync(MedicalReport medicalReport);
    }
}
