using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Abstract
{
    public interface IWorkingHourService
    {
        Task AddAsync(WorkingHour workingHour);
        Task UpdateAsync(WorkingHour workingHour);
        Task DeleteAsync(WorkingHour workingHour);
        Task<List<WorkingHour>> GetAllAsync();
        Task<WorkingHour> GetByIdAsync(Guid id);
        Task<List<WorkingHour>> GetByDoctorIdAsync(Guid doctorId);
    }
}
