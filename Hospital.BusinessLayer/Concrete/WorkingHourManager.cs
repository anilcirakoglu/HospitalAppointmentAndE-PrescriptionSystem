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
    public class WorkingHourManager : IWorkingHourService
    {
        private readonly IWorkingHourRepository _workingHourRepository;
        public WorkingHourManager(IWorkingHourRepository workingHourRepository)
        {
            _workingHourRepository = workingHourRepository;
        }
        public async Task AddAsync(WorkingHour workingHour)
        {
            await _workingHourRepository.AddAsync(workingHour);
        }

        public async Task DeleteAsync(WorkingHour workingHour)
        {
           await _workingHourRepository.DeleteAsync(workingHour);
        }

        public async Task<List<WorkingHour>> GetAllAsync()
        {
          return await _workingHourRepository.GetAllAsync();
        }

        public async Task<WorkingHour> GetByIdAsync(int id)
        {
           return await _workingHourRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(WorkingHour workingHour)
        {
            await _workingHourRepository.UpdateAsync(workingHour);
        }
    }
}
