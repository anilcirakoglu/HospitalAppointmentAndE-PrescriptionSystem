using Hospital.DtoLayer.DoctorDto;
using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Abstract
{
    public interface IDoctorRepository
    {
        Task<Doctor?> GetByIdAsync(Guid id);
        Task<List<Doctor>> GetAllAsync();
        Task AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(Guid doctorId);

        Task<List<Doctor>> GetAllInfo();


    }
}
