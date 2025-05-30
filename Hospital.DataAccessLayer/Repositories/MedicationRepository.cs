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
    public class MedicationRepository : IMedicationRepository
    {
        private readonly HospitalContext _context;
        public MedicationRepository(HospitalContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Medication medication)
        {
            await _context.Medications.AddAsync(medication);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Medication medication)
        {
            _context.Medications.Remove(medication);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Medication>> GetAllAsync()
        {
            return await _context.Medications.ToListAsync();
        }

        public async Task<Medication> GetByIdAsync(int id)
        {
            return await _context.Medications.FindAsync(id);
        }

        public async Task UpdateAsync(Medication medication)
        {
            _context.Medications.Update(medication);
            await _context.SaveChangesAsync();
        }
    }
}
