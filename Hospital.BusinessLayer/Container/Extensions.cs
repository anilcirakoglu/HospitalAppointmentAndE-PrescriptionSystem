using Hospital.BusinessLayer.Abstract;
using Hospital.BusinessLayer.Concrete;
using Hospital.DataAccessLayer.Abstract;
using Hospital.DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService,AppointmentManager>();
            services.AddScoped<IAppointmentRepository,AppointmentRepository>();

            services.AddScoped<IDoctorService, DoctorManager>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            services.AddScoped<IMedicalReportService, MedicalReportManager>();
            services.AddScoped<IMedicalReportRepository, MedicalReportRepository>();

            services.AddScoped<IMedicationService, MedicationManager>();
            services.AddScoped<IMedicationRepository, MedicationRepository>();

            services.AddScoped<IPatientService, PatientManager>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddScoped<IPrescriptionMedicationService, PrescriptionMedicationManager>();
            services.AddScoped<IPrescriptionMedicationRepository, PrescriptionMedicationRepository>();

            services.AddScoped<IPrescriptionService, PrescriptionManager>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IWorkingHourService, WorkingHourManager>();
            services.AddScoped<IWorkingHourRepository, WorkingHourRepository>();
        }
    }
}
