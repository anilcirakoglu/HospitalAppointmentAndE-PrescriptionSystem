using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Abstract
{
    public interface IPrescriptionRepository
    {
        Task<Prescription> GetByIdAsync(int id);
        Task<List<Prescription>> GetAllAsync();
        Task AddAsync(Prescription prescription);
        Task UpdateAsync(Prescription prescription);
        Task DeleteAsync(Prescription prescription);
    }
}
