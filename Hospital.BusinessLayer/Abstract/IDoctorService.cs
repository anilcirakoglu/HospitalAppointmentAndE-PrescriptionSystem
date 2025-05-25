using Hospital.DtoLayer.DoctorDto;
using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Abstract
{
    public interface IDoctorService
    {
        Task AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(Guid doctorId);
        Task<List<Doctor>> GetAllAsync();
        Task<DoctorDto?> GetByIdAsync(Guid id);

        Task<CreateDoctorDto> CreateAsync(CreateDoctorDto dto);
        Task<UpdateDoctorDto> UpdateDoctorAsync(Guid doctorId, UpdateDoctorDto dto);
        Task<List<DoctorDto>> GetAllDoctorInfoAsync();
    }
}
