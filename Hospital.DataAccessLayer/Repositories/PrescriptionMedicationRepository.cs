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
    public class PrescriptionMedicationRepository : IPrescriptionMedicationRepository
    {
        private readonly HospitalContext _context;
        public PrescriptionMedicationRepository(HospitalContext context)
        {
            _context = context;
        }
        public async Task AddAsync(PrescriptionMedication prescriptionMedication)
        {
            await _context.PrescriptionMedications.AddAsync(prescriptionMedication);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PrescriptionMedication prescriptionMedication)
        {
            _context.PrescriptionMedications.Remove(prescriptionMedication);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PrescriptionMedication>> GetAllAsync()
        {
            return await _context.PrescriptionMedications.ToListAsync();
        }

        public async Task<PrescriptionMedication> GetByIdAsync(int id)
        {
            return await _context.PrescriptionMedications.FindAsync(id);
        }

        public async Task UpdateAsync(PrescriptionMedication prescriptionMedication)
        {
            _context.PrescriptionMedications.Update(prescriptionMedication);
            await _context.SaveChangesAsync();
        }
    }
}
