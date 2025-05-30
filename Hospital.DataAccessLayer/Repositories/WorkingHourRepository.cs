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
            return await _context.WorkingHours.ToListAsync();
        }

        public async Task<WorkingHour> GetByIdAsync(int id)
        {
            return await _context.WorkingHours.FindAsync(id);
        }

        public async Task UpdateAsync(WorkingHour workingHour)
        {
            _context.WorkingHours.Update(workingHour);
            await _context.SaveChangesAsync();
        }
    }
}
