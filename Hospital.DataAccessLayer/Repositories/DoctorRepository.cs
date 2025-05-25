using Hospital.DataAccessLayer.Abstract;
using Hospital.DataAccessLayer.Concrete;
using Hospital.DtoLayer.DoctorDto;
using Hospital.EntityLayer.Enitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalContext _context;
        public DoctorRepository(HospitalContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid doctorId)
        {
            var doctor = await _context.Doctors
                   .Include(y=>y.User)
                   .FirstOrDefaultAsync(x => x.UserId == doctorId);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<List<Doctor>> GetAllInfo()
        {
            var doctors = await _context.Doctors
                .Include(d => d.User)
                .ToListAsync();

            return doctors;
        }

        public async Task<Doctor?> GetByIdAsync(Guid id)
        {
            var doctor = await _context.Doctors
               .Include(d => d.User)
               .FirstOrDefaultAsync(x => x.UserId == id); 
            return doctor;
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
