using Hospital.BusinessLayer.Abstract;
using Hospital.DtoLayer.PatientDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient() 
        {
            var patient = await _patientService.GetAllAsync();
            return Ok(patient);
        }
        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetbyIdPatient(Guid patientId) 
        {
            var patient = await _patientService.GetByIdAsync(patientId);
            return Ok(patient);
        }
        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePatientDto createPatientDto)
        {
            var patient = await _patientService.CreateAsync(createPatientDto);
            return Ok(patient);
        }
        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(Guid patientId,UpdatePatientDto updatePatientDto)
        {
            var patient = await _patientService.UpdatePatientAsync(patientId, updatePatientDto);
            return Ok(patient);
        }
    }
}
