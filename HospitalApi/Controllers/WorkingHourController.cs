using Hospital.BusinessLayer.Abstract;
using Hospital.DtoLayer.WorkingHourDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHourController : ControllerBase
    {
        private readonly IWorkingHourService _workingHourService;
        public WorkingHourController(IWorkingHourService workingHourService)
        {
            _workingHourService = workingHourService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkingHourDto>>> GetAll()
        {
            try
            {
                var workingHours = await _workingHourService.GetAllAsync();
                return Ok(workingHours);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("doctor/{doctorId:guid}")]
        public async Task<ActionResult<List<WorkingHourDto>>> GetByDoctorId(Guid doctorId)
        {
            try
            {
                var workingHours = await _workingHourService.GetByDoctorIdAsync(doctorId);
                if (workingHours == null || workingHours.Count == 0)
                    return NotFound(new { message = "No working hours found for this doctor" });

                return Ok(workingHours);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
