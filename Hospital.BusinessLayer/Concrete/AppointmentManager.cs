using Hospital.BusinessLayer.Abstract;
using Hospital.DataAccessLayer.Abstract;
using Hospital.DataAccessLayer.Repositories;
using Hospital.EntityLayer.Enitities;
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
        public AppointmentManager(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task AddAsync(Appointment appointment)
        {
            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task DeleteAsync(Appointment appointment)
        {
            await _appointmentRepository.DeleteAsync(appointment);
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            await _appointmentRepository.UpdateAsync(appointment);
        }
    }
}
