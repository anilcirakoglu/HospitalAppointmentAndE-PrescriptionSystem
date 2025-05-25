using Hospital.BusinessLayer.Abstract;
using Hospital.DataAccessLayer.Abstract;
using Hospital.DtoLayer.MedicalReportDto;
using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Concrete
{
    public class MedicalReportManager : IMedicalReportService
    {
        private readonly IMedicalReportRepository _medicalReportRepository;
      

        public MedicalReportManager(IMedicalReportRepository medicalReportRepository, IDoctorRepository doctorRepository, IUserRepository userRepository, IPatientRepository patientRepository)
        {
            _medicalReportRepository = medicalReportRepository;
         
        }

        public async Task AddAsync(MedicalReport medicalReport)
        {
            await _medicalReportRepository.AddAsync(medicalReport);
        }

        public async Task<CreateMedicalReportDto> CreateMedicalReportAsync(CreateMedicalReportDto medicalReport)
        {
            var report = new MedicalReport/*adding some entities*/
                {
                Id = Guid.NewGuid(),
                PatientId= Guid.NewGuid(),
                ReportDate = DateTime.Now,
                ReportDetails= medicalReport.ReportDetails,
                ReportFilePath = medicalReport.ReportFilePath
            };
            await _medicalReportRepository.AddAsync(report);
            return medicalReport;
        }
     
        public async Task DeleteAsync(MedicalReport medicalReport)
        {
           await _medicalReportRepository.DeleteAsync(medicalReport);
        }

        public async Task<List<MedicalReport>> GetAllAsync()
        {
           return await _medicalReportRepository.GetAllAsync();
        }

        public async Task<MedicalReport> GetByIdAsync(Guid id)
        {
           return await _medicalReportRepository.GetByIdAsync(id);
        }

        public async Task<List<GetMedicalReportDto>> GetMedicalReportAsync()
        {

            var medicalReports = await _medicalReportRepository.GetAllAsync();

            var result = medicalReports.Select(x => new GetMedicalReportDto
            {
                DoctorName = x.Doctor.User.FullName,
                Specialty = x.Doctor.Specialty,
                Qualification = x.Doctor.Qualification,
                PatientName = x.Patient.User.FullName,
                ReportDate = x.ReportDate,
                ReportDetails = x.ReportDetails,
                ReportFilePath = x.ReportFilePath
            }).ToList();

            return result;
        }

        public async Task UpdateAsync(MedicalReport medicalReport)
        {
           await _medicalReportRepository.UpdateAsync(medicalReport);
        }
    }
}
