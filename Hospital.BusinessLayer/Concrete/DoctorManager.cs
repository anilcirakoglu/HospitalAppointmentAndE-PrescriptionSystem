using Hospital.BusinessLayer.Abstract;
using Hospital.DataAccessLayer.Abstract;
using Hospital.DtoLayer.DoctorDto;
using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Concrete
{
    public class DoctorManager : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorManager(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task AddAsync(Doctor doctor)
        {
           await _doctorRepository.AddAsync(doctor);
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            await _doctorRepository.DeleteAsync(doctor);
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<List<DoctorDto>> GetAllDoctorInfoAsync()
        {
            return await _doctorRepository.GetAllInfo();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
           return await _doctorRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            await _doctorRepository.UpdateAsync(doctor);
        }
    }
}
