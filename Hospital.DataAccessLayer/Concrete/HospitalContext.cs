using Hospital.EntityLayer.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Concrete
{
    public class HospitalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-BPFOCPL;initial Catalog=HospitalDb;integrated Security=true;TrustServerCertificate=True;");
        }



        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedication> PrescriptionMedications { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkingHour>WorkingHours  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasIndex(u => u.IdentityNumber).IsUnique();

            modelBuilder.Entity<Role>().HasData(
             new Role { Id = 1, Name = "Admin" },
             new Role { Id = 2, Name = "Doctor" },
             new Role { Id = 3, Name = "Patient" } );

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                 .WithOne()
                 .HasForeignKey<Doctor>(d => d.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
               .HasOne(p => p.User)
               .WithOne()
               .HasForeignKey<Patient>(p => p.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                 .HasOne(a => a.Patient)
                 .WithMany() 
                 .HasForeignKey(a => a.PatientId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<PrescriptionMedication>()
                .HasKey(pm => new { pm.PrescriptionId, pm.MedicationId });

            modelBuilder.Entity<PrescriptionMedication>()
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedications)
                .HasForeignKey(pm => pm.PrescriptionId);

            modelBuilder.Entity<PrescriptionMedication>()
                .HasOne(pm => pm.Medication)
                .WithMany(m => m.PrescriptionMedications)
                .HasForeignKey(pm => pm.MedicationId);

            modelBuilder.Entity<MedicalReport>()
                 .HasOne(m => m.Patient)
                 .WithMany(p => p.MedicalReports) 
                 .HasForeignKey(m => m.PatientId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicalReport>()
                .HasOne(m => m.Doctor)
                .WithMany(d => d.MedicalReports) 
                .HasForeignKey(m => m.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
