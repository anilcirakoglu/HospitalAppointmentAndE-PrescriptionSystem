using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Abstract
{
    public interface IAppointmentService
    {
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Appointment appointment);
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment> GetByIdAsync(int id);
    }
}
