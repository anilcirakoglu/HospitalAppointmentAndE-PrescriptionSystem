using Hospital.BusinessLayer.Abstract;
using Hospital.DataAccessLayer.Abstract;
using Hospital.DataAccessLayer.Repositories;
using Hospital.DtoLayer.DoctorDto;
using Hospital.DtoLayer.PatientDto;
using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Concrete
{
    public class PatientManager : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        public PatientManager(IPatientRepository patientRepository, IUserRepository userRepository)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
        }
        public async Task AddAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
        }

        public async Task<CreatePatientDto> CreateAsync(CreatePatientDto createPatientDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                IdentityNumber = createPatientDto.IdentityNumber,
                Password = createPatientDto.Password,
                Email = createPatientDto.Email,
                FullName = createPatientDto.FullName,
                PhoneNumber = createPatientDto.PhoneNumber,
                RoleId = 3,
                CreatedDate =DateTime.Now,
                IsActive = true,

            };
            
            await _userRepository.AddAsync(user);

            var patient = new Patient
            {
                Id = Guid.NewGuid(),
                MedicalReportId = Guid.NewGuid(),
                UserId = user.Id,
                DateOfBirth = DateTime.Now,
                Gender = createPatientDto.Gender,
                Address = createPatientDto.Address,
                InsuranceNumber = createPatientDto.InsuranceNumber,

            };
            await _patientRepository.AddAsync(patient);
            return createPatientDto;
        }

        public async Task DeleteAsync(Patient patient)
        {
           await _patientRepository.DeleteAsync(patient);
        }

        public async Task<List<CreatePatientDto>> GetAllAsync()
        {
            var patient=await _patientRepository.GetAllAsync();
            return patient.Select(x => new CreatePatientDto
            {
                InsuranceNumber = x.User.IdentityNumber,
               FullName=x.User.FullName,
               Email = x.User.Email,
               PhoneNumber = x.User.PhoneNumber,
               DateOfBirth =x.DateOfBirth,
               Gender =x.Gender,
               Address =x.Address,
              


            }).ToList();  
        }

        public async Task<PatientDto> GetByIdAsync(Guid id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            var patientDto = new PatientDto
            {
                IdentityNumber = patient.User.IdentityNumber,
                FullName=patient.User.FullName,
                Email =patient.User.Email,
                PhoneNumber = patient.User.PhoneNumber,
                Address=patient.Address,
                DateOfBirth=patient.DateOfBirth,
                Gender = patient.Gender,
            };
            return patientDto;
        }

        public async Task UpdateAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
        }

        public async Task<UpdatePatientDto> UpdatePatientAsync(Guid patientId,UpdatePatientDto updatePatientDto)
        {
            var patient = await _patientRepository.GetByIdAsync(patientId);
            var user = await _userRepository.GetByIdAsync(patientId);


            user.PhoneNumber = updatePatientDto.PhoneNumber;
            user.Email = updatePatientDto.Email;
            await _userRepository.UpdateAsync(user);
            patient.Address = updatePatientDto.Address;
            await _patientRepository.UpdateAsync(patient);

            return updatePatientDto;
        }
    }
}
