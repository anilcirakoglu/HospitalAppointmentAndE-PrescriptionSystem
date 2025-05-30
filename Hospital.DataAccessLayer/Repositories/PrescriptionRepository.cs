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
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly HospitalContext _context;
        public PrescriptionRepository(HospitalContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Prescription prescription)
        {
            await _context.Prescriptions.AddAsync(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Prescription prescription)
        {
            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Prescription>> GetAllAsync()
        {
            return await _context.Prescriptions.ToListAsync();
        }

        public async Task<Prescription> GetByIdAsync(int id)
        {
            return await _context.Prescriptions.FindAsync(id);
        }

        public async Task UpdateAsync(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            await _context.SaveChangesAsync();
        }
    }
}
