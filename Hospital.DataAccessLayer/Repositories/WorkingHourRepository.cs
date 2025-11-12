using Hospital.DataAccessLayer.Abstract;
using Hospital.DataAccessLayer.Concrete;
using Hospital.EntityLayer.Enitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Repositories
{
    public class WorkingHourRepository : IWorkingHourRepository
    {
        private readonly HospitalContext _context;
        public WorkingHourRepository(HospitalContext context)
        {
            _context = context;
        }
        public async Task AddAsync(WorkingHour workingHour)
        {
            await _context.WorkingHours.AddAsync(workingHour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(WorkingHour workingHour)
        {
            _context.WorkingHours.Remove(workingHour);
            await _context.SaveChangesAsync();
        }

        public async Task<List<WorkingHour>> GetAllAsync()
        {
            return await _context.WorkingHours
                .Include(w => w.Doctor)
                .ThenInclude(d => d.User)
                .ToListAsync();
        }

        public async Task<List<WorkingHour>> GetByDoctorIdAsync(Guid doctorId)
        {
            return await _context.WorkingHours
                .Include(w => w.Doctor)
                .ThenInclude(d => d.User)
                .Where(w => w.UserId == doctorId)
                .ToListAsync();
        }

        public async Task<WorkingHour> GetByIdAsync(Guid id)
        {
            return await _context.WorkingHours
                .Include(w => w.Doctor)
                .ThenInclude(d => d.User)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task UpdateAsync(WorkingHour workingHour)
        {
            _context.WorkingHours.Update(workingHour);
            await _context.SaveChangesAsync();
        }
    }
}
