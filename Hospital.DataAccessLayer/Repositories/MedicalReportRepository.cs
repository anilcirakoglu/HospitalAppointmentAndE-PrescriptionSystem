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
    public class MedicalReportRepository : IMedicalReportRepository
    {
        private readonly HospitalContext _context;
        public MedicalReportRepository(HospitalContext context)
        {
            _context = context;
        }
        public async Task AddAsync(MedicalReport medicalReport)
        {
            await _context.MedicalReports.AddAsync(medicalReport);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(MedicalReport medicalReport)
        {
            _context.MedicalReports.Remove(medicalReport);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MedicalReport>> GetAllAsync()
        {
            return await _context.MedicalReports.ToListAsync();
        }

        public async Task<MedicalReport> GetByIdAsync(int id)
        {
            return await _context.MedicalReports.FindAsync(id);
        }

        public async Task UpdateAsync(MedicalReport medicalReport)
        {
            _context.MedicalReports.Update(medicalReport);
            await _context.SaveChangesAsync();
        }
    }
}
