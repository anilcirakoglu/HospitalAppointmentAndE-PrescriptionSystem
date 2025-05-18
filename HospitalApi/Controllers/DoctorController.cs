using Hospital.BusinessLayer.Abstract;
using Hospital.DtoLayer.DoctorDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctor = await _doctorService.GetAllDoctorInfoAsync();
            return Ok(doctor);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) 
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto createDoctorDto)
        {
           var doctor = await _doctorService.CreateAsync(createDoctorDto);
            return Ok(doctor);
        }
        [HttpPut("{doctorId}")]
        public async Task<IActionResult> UpdateDoctor(Guid doctorId, UpdateDoctorDto updateDoctorDto) 
        {
            var doctor = await _doctorService.UpdateDoctorAsync(doctorId, updateDoctorDto);
            return Ok(doctor);
        }
    }
}
