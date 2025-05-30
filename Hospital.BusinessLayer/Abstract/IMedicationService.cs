using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Abstract
{
    public interface IMedicationService
    {
        Task AddAsync(Medication medication);
        Task UpdateAsync(Medication medication);
        Task DeleteAsync(Medication medication);
        Task<List<Medication>> GetAllAsync();
        Task<Medication> GetByIdAsync(int id);
    }
}
