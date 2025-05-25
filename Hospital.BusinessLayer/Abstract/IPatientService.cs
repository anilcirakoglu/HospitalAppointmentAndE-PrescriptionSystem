using Hospital.DtoLayer.DoctorDto;
using Hospital.DtoLayer.PatientDto;
using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Abstract
{
    public interface IPatientService
    {
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(Guid id);
        Task<List<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(Guid id);
        Task<CreatePatientDto> CreateAsync(CreatePatientDto createDoctorDto);
        Task<UpdatePatientDto> UpdatePatientAsync(Guid patientId, UpdatePatientDto updatePatientDto);
    }
}
