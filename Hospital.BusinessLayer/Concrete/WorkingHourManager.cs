using Hospital.BusinessLayer.Abstract;
using Hospital.DataAccessLayer.Abstract;
using Hospital.DtoLayer.WorkingHourDto;
using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<WorkingHour> GetByIdAsync(Guid id)
        {
            return await _workingHourRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(WorkingHour workingHour)
        {
            await _workingHourRepository.UpdateAsync(workingHour);
        }

        public async Task<List<WorkingHour>> GetByDoctorIdAsync(Guid doctorId)
        {
            return await _workingHourRepository.GetByDoctorIdAsync(doctorId);
        }

        // DTO versiyonları (isteğe bağlı - API'de kullanmak için)
        public async Task<List<WorkingHourDto>> GetAllWithDetailsAsync()
        {
            var workingHours = await _workingHourRepository.GetAllAsync();
            return workingHours.Select(w => new WorkingHourDto
            {
                Id = w.Id,
                UserId = w.UserId,
                DoctorName = w.Doctor?.User?.FullName ?? "Unknown",
                Specialty = w.Doctor?.Specialty ?? "Unknown",
                DayOfWeek = w.DayOfWeek,
                StartTime = w.StartTime,
                EndTime = w.EndTime
            }).ToList();
        }

       

       
    }
}
