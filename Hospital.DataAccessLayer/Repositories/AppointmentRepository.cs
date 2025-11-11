using Hospital.DataAccessLayer.Abstract;
using Hospital.DataAccessLayer.Concrete;
using Hospital.EntityLayer.Enitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalContext _context;
        public AppointmentRepository(HospitalContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Appointment appointment)
        {
           _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task UpdateAsync(Appointment appointment)
        {

            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
