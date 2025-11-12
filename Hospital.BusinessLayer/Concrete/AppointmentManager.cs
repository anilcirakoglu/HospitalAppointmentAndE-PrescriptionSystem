using Hospital.BusinessLayer.Abstract;
using Hospital.DataAccessLayer.Abstract;
using Hospital.DataAccessLayer.Repositories;
using Hospital.DtoLayer.AppointmentDto;
using Hospital.EntityLayer.Enitities;
using Hospital.EntityLayer.Enitities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IWorkingHourRepository _workingHourRepository;

        public AppointmentManager(
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,
            IWorkingHourRepository workingHourRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _workingHourRepository = workingHourRepository;
        }

        public async Task AddAsync(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            //ValidateAppointment(appointment);
            //await ValidateDoctorWorkingHours(appointment.UserId, appointment.AppointmentDate);

            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task<CreateAppointmentDto> CreateAsync(CreateAppointmentDto createAppointmentDto)
        {
            if (createAppointmentDto == null)
            {
                throw new ArgumentNullException(nameof(createAppointmentDto));
            }

            var patient = await _patientRepository.GetByIdAsync(createAppointmentDto.PatientId);
            if (patient == null)
            {
                throw new Exception("Patient not found");
            }

            var doctor = await _doctorRepository.GetByIdAsync(createAppointmentDto.DoctorId);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }

            if (createAppointmentDto.AppointmentDate <= DateTime.Now)
                throw new Exception("Appointment date must be in the future");

            await ValidateDoctorWorkingHours(createAppointmentDto.DoctorId, createAppointmentDto.AppointmentDate);

            await CheckAppointmentConflict(
                createAppointmentDto.PatientId,
                createAppointmentDto.DoctorId,
                createAppointmentDto.AppointmentDate);

            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                DoctorId = createAppointmentDto.DoctorId,
                PatientId = createAppointmentDto.PatientId,
                AppointmentDate = createAppointmentDto.AppointmentDate,
                Status = AppointmentStatus.Pending,
                Notes = createAppointmentDto.Notes,
               
            };

            await _appointmentRepository.AddAsync(appointment);
            return createAppointmentDto;
        }

        public async Task DeleteAsync(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            var existing = await _appointmentRepository.GetByIdAsync(appointment.Id);
            if (existing == null)
                throw new Exception("Appointment not found");

            await _appointmentRepository.DeleteAsync(existing);
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<List<AppointmentDto>> GetAllAppointmentInfoAsync()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                PatientName = a.Patient?.User?.FullName ?? "Unknown",
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor?.User?.FullName ?? "Unknown",
                DoctorSpecialty = a.Doctor?.Specialty ?? "Unknown",
                AppointmentDate = a.AppointmentDate,
                Status = a.Status.ToString(),
                Notes = a.Notes
            }).OrderBy(a => a.AppointmentDate).ToList();
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                throw new Exception("Appointment not found");
            return appointment;
        }

        public async Task<AppointmentDto> GetByIdDtoAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                throw new Exception("Appointment not found");

            return new AppointmentDto
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.User?.FullName ?? "Unknown",
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor?.User?.FullName ?? "Unknown",
                DoctorSpecialty = appointment.Doctor?.Specialty ?? "Unknown",
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status.ToString(),
                Notes = appointment.Notes
            };
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            var existing = await _appointmentRepository.GetByIdAsync(appointment.Id);
            if (existing == null)
                throw new Exception("Appointment not found");

            ValidateAppointmentForUpdate(appointment, existing);
            await ValidateDoctorWorkingHours(appointment.DoctorId, appointment.AppointmentDate);

            existing.AppointmentDate = appointment.AppointmentDate;
            existing.DoctorId = appointment.DoctorId;
            existing.PatientId = appointment.PatientId;
            existing.Notes = appointment.Notes;
            existing.Status = appointment.Status;

            await _appointmentRepository.UpdateAsync(existing);
        }

        public async Task<UpdateAppointmentDto> UpdateAppointmentAsync(Guid appointmentId, UpdateAppointmentDto updateAppointmentDto)
        {
            if (updateAppointmentDto == null)
                throw new ArgumentNullException(nameof(updateAppointmentDto));

            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            if (appointment == null)
                throw new Exception("Appointment not found");

            var patient = await _patientRepository.GetByIdAsync(updateAppointmentDto.PatientId);
            if (patient == null)
                throw new Exception("Patient not found");

            var doctor = await _doctorRepository.GetByIdAsync(updateAppointmentDto.DoctorId);
            if (doctor == null)
                throw new Exception("Doctor not found");

            if (updateAppointmentDto.AppointmentDate <= DateTime.Now)
                throw new Exception("Appointment date must be in the future");

            await ValidateDoctorWorkingHours(updateAppointmentDto.DoctorId, updateAppointmentDto.AppointmentDate);

            // Check conflicts excluding current appointment
            var allAppointments = await _appointmentRepository.GetAllAsync();
            if (allAppointments.Any(a => a.Id != appointmentId &&
                a.DoctorId == updateAppointmentDto.DoctorId &&
                a.AppointmentDate == updateAppointmentDto.AppointmentDate &&
                a.Status != AppointmentStatus.Cancelled))
                throw new Exception("Doctor already has an appointment at this date/time");

            if (allAppointments.Any(a => a.Id != appointmentId &&
                a.PatientId == updateAppointmentDto.PatientId &&
                a.AppointmentDate == updateAppointmentDto.AppointmentDate &&
                a.Status != AppointmentStatus.Cancelled))
                throw new Exception("Patient already has an appointment at this date/time");

            appointment.PatientId = updateAppointmentDto.PatientId;
            appointment.DoctorId = updateAppointmentDto.DoctorId;
            appointment.AppointmentDate = updateAppointmentDto.AppointmentDate;
            appointment.Notes = updateAppointmentDto.Notes;

            if (Enum.TryParse<AppointmentStatus>(updateAppointmentDto.Status, true, out var status))
            {
                appointment.Status = status;
            }

            await _appointmentRepository.UpdateAsync(appointment);
            return updateAppointmentDto;
        }

        private void ValidateAppointment(Appointment appointment)
        {
            if (appointment.PatientId == Guid.Empty)
                throw new Exception("Patient ID is required");

            if (appointment.DoctorId == Guid.Empty)
                throw new Exception("Doctor ID is required");

            if (appointment.AppointmentDate <= DateTime.Now)
                throw new Exception("Appointment date must be in the future");
        }

        private void ValidateAppointmentForUpdate(Appointment newAppointment, Appointment existingAppointment)
        {
            ValidateAppointment(newAppointment);

            if (existingAppointment.Status == AppointmentStatus.Completed)
                throw new Exception("Cannot update a completed appointment");

            if (existingAppointment.Status == AppointmentStatus.Cancelled)
                throw new Exception("Cannot update a cancelled appointment");
        }

        private async Task CheckAppointmentConflict(Guid patientId, Guid doctorId, DateTime appointmentDate)
        {
            var allAppointments = await _appointmentRepository.GetAllAsync();

            if (allAppointments.Any(a =>
                a.DoctorId == doctorId &&
                a.AppointmentDate == appointmentDate &&
                a.Status != AppointmentStatus.Cancelled))
                throw new Exception("Doctor already has an appointment at this date/time");

            if (allAppointments.Any(a =>
                a.PatientId == patientId &&
                a.AppointmentDate == appointmentDate &&
                a.Status != AppointmentStatus.Cancelled))
                throw new Exception("Patient already has an appointment at this date/time");
        }

        private async Task ValidateDoctorWorkingHours(Guid doctorId, DateTime appointmentDate)
        {
            var doctorWorkingHours = await _workingHourRepository.GetByDoctorIdAsync(doctorId);

            if (!doctorWorkingHours.Any())
                throw new Exception("Doctor has no working hours defined");

            var appointmentDayOfWeek = appointmentDate.DayOfWeek;
            var appointmentTime = appointmentDate.TimeOfDay;

            var workingHourForDay = doctorWorkingHours
                .FirstOrDefault(w => w.DayOfWeek == appointmentDayOfWeek);

            if (workingHourForDay == null)
                throw new Exception($"Doctor is not working on {appointmentDayOfWeek}");

            if (appointmentTime < workingHourForDay.StartTime || appointmentTime > workingHourForDay.EndTime)
                throw new Exception($"Appointment time must be between {workingHourForDay.StartTime:hh\\:mm} and {workingHourForDay.EndTime:hh\\:mm}");
        }
    }
}
