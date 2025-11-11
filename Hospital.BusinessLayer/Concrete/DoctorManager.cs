using Hospital.BusinessLayer.Abstract;
using Hospital.DataAccessLayer.Abstract;
using Hospital.DataAccessLayer.Repositories;
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
        private readonly IUserRepository _userRepository;

        public DoctorManager(IUserRepository userRepository, IDoctorRepository doctorRepository)
        {
            _userRepository = userRepository;
            _doctorRepository = doctorRepository;
        }



        public async Task AddAsync(Doctor doctor)
        {
           await _doctorRepository.AddAsync(doctor);
        }

        public async Task<CreateDoctorDto> CreateAsync(CreateDoctorDto createDoctorDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                IdentityNumber = createDoctorDto.IdentityNumber,
                Password = createDoctorDto.Password, 
                Email = createDoctorDto.Email,
                FullName = createDoctorDto.FullName,
                PhoneNumber = createDoctorDto.PhoneNumber,
                RoleId = 2, 
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            await _userRepository.AddAsync(user); 

          
            var doctor = new Doctor
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Specialty = createDoctorDto.Specialty,
                RoomNumber = createDoctorDto.RoomNumber,
                Qualification = createDoctorDto.Qualification,
                Description = createDoctorDto.Description
            };

            await _doctorRepository.AddAsync(doctor);
            return createDoctorDto;
        }
        public async Task<UpdateDoctorDto> UpdateDoctorAsync(Guid doctorId,UpdateDoctorDto updateDoctorDto)
        {
          
            var doctor = await _doctorRepository.GetByIdAsync(doctorId);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
            var user = await _userRepository.GetByIdAsync(doctorId);
            if (user == null)
            {
                throw new Exception("User not found");
            }


            user.Email = updateDoctorDto.Email;
            user.PhoneNumber = updateDoctorDto.PhoneNumber;
            user.Password = updateDoctorDto.Password;

            await _userRepository.UpdateAsync(user);
   
            doctor.Qualification = updateDoctorDto.Qualification;
            doctor.Specialty = updateDoctorDto.Specialty;
            doctor.Description = updateDoctorDto.Description;
            doctor.RoomNumber = updateDoctorDto.RoomNumber;

            await _doctorRepository.UpdateAsync(doctor);

            return updateDoctorDto;
        }
        public async Task DeleteAsync(Guid doctorId)
        {
            var doctor = await _doctorRepository.GetByIdAsync(doctorId);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
            await _doctorRepository.DeleteAsync(doctorId);
            await _userRepository.DeleteAsync(doctorId);

        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<List<DoctorDto>> GetAllDoctorInfoAsync()
        {
            var doctor = await _doctorRepository.GetAllInfo();
            return doctor.Select(d => new DoctorDto
            {
                Fullname = d.User.FullName,
                Qualification = d.Qualification,
                Specialty = d.Specialty,
                Description = d.Description,
                Email = d.User.Email,
                PhoneNumber = d.User.PhoneNumber,
                RoomNumber = d.RoomNumber
            }).ToList();
        }

        public async Task<DoctorDto?> GetByIdAsync(Guid id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
        
                var doctorDto = new DoctorDto
                {
                    Fullname = doctor.User.FullName,
                    Qualification = doctor.Qualification,
                    Specialty = doctor.Specialty,
                    Description = doctor.Description,
                    Email = doctor.User.Email,
                    PhoneNumber = doctor.User.PhoneNumber,
                    RoomNumber = doctor.RoomNumber
                };
                return doctorDto;
           
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            await _doctorRepository.UpdateAsync(doctor);
        }

        
    }
}
