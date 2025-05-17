using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Abstract
{
    public interface IMedicationRepository
    {
        Task<Medication> GetByIdAsync(int id);
        Task<List<Medication>> GetAllAsync();
        Task AddAsync(Medication medication);
        Task UpdateAsync(Medication medication);
        Task DeleteAsync(Medication medication);
    }
}
