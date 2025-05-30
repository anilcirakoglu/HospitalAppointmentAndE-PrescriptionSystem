using Hospital.BusinessLayer.Abstract;
using Hospital.DtoLayer.MedicalReportDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalReportController : ControllerBase
    {
        private readonly IMedicalReportService _medicalReportService;
        public MedicalReportController(IMedicalReportService mediicalReportService)
        {
            _medicalReportService = mediicalReportService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicalReports = await _medicalReportService.GetMedicalReportAsync();
            return Ok(medicalReports);
        }
        [HttpPost("CreateMedicalReport")]
        public async Task<IActionResult> CreateMedicalReport(CreateMedicalReportDto createMedicalReport) 
        {
            var medicalReport = await _medicalReportService.CreateMedicalReportAsync(createMedicalReport);
            return Ok(medicalReport);
        }
    }
}
