using Hospital.BusinessLayer.Abstract;
using Hospital.DtoLayer.AppointmentDto;
using Hospital.EntityLayer.Enitities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// Get all appointments
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<AppointmentDto>>> GetAll()
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentInfoAsync();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get appointment by ID
        /// </summary>
        [HttpGet("{id:guid}", Name = "GetAppointmentById")]
        public async Task<ActionResult<AppointmentDto>> GetById(Guid id)
        {
            try
            {
                var appointment = await _appointmentService.GetByIdDtoAsync(id);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Create a new appointment
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CreateAppointmentDto>> Create([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            if (createAppointmentDto == null)
                return BadRequest(new { message = "Appointment data is required" });

            try
            {
                
                return await _appointmentService.CreateAsync(createAppointmentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Update an existing appointment
        /// </summary>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAppointmentDto updateAppointmentDto)
        {
            if (updateAppointmentDto == null)
                return BadRequest(new { message = "Appointment data is required" });

            try
            {
                var existing = await _appointmentService.GetByIdAsync(id);
                if (existing == null)
                    return NotFound(new { message = "Appointment not found" });

                await _appointmentService.UpdateAppointmentAsync(id, updateAppointmentDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Delete an appointment
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var existing = await _appointmentService.GetByIdAsync(id);
                if (existing == null)
                    return NotFound(new { message = "Appointment not found" });

                await _appointmentService.DeleteAsync(existing);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get appointments for a specific patient
        /// </summary>
        [HttpGet("patient/{patientId:guid}")]
        public async Task<ActionResult<List<AppointmentDto>>> GetByPatient(Guid patientId)
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentInfoAsync();
                var patientAppointments = appointments.FindAll(a => a.PatientId == patientId);

                if (patientAppointments.Count == 0)
                    return NotFound(new { message = "No appointments found for this patient" });

                return Ok(patientAppointments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get appointments for a specific doctor
        /// </summary>
        [HttpGet("doctor/{doctorId:guid}")]
        public async Task<ActionResult<List<AppointmentDto>>> GetByDoctor(Guid doctorId)
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentInfoAsync();
                var doctorAppointments = appointments.FindAll(a => a.DoctorId == doctorId);

                if (doctorAppointments.Count == 0)
                    return NotFound(new { message = "No appointments found for this doctor" });

                return Ok(doctorAppointments);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
