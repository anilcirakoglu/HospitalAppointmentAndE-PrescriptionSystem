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
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalContext _context;
        public PatientRepository(HospitalContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid patientId)
        {
            var patient = await _context.Patients
                .Include(y=>y.User)
                .FirstOrDefaultAsync(x => x.UserId == patientId);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            var patients = await _context.Patients
                .Include(x=>x.User)
                .ToListAsync();
            return patients;
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            var patient = await _context.Patients
                .Include(x=>x.User)
                .FirstOrDefaultAsync(x=>x.UserId==id);
            return patient;
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}
