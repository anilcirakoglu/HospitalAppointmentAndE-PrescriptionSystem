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

        public async Task DeleteAsync(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<List<DoctorDto>> GetAllInfo()
        {
            var doctors = await _context.Doctors
                .Include(d => d.User) 
                .Select(d => new DoctorDto
                {
                    Fullname = d.User.FullName,
                    Qualification = d.Qualification,
                    Specialty = d.Specialty,
                    Description = d.Description,
                    Email = d.User.Email,
                    PhoneNumber = d.User.PhoneNumber,
                    RoomNumber = d.RoomNumber
                })
                .ToListAsync();

            return doctors;
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
