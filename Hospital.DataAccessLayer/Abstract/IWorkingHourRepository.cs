using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Abstract
{
    public interface IWorkingHourRepository
    {
        Task<WorkingHour> GetByIdAsync(int id);
        Task<List<WorkingHour>> GetAllAsync();
        Task AddAsync(WorkingHour workingHour);
        Task UpdateAsync(WorkingHour workingHour);
        Task DeleteAsync(WorkingHour workingHour);
    }
}
