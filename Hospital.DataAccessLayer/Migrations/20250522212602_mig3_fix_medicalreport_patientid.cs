using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3_fix_medicalreport_patientid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Doctors_DoctorId",
                table: "MedicalReports");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Patients_PatientId1",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_MedicalReports_PatientId1",
                table: "MedicalReports");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "MedicalReports");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Doctors_DoctorId",
                table: "MedicalReports",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Doctors_DoctorId",
                table: "MedicalReports");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId1",
                table: "MedicalReports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_PatientId1",
                table: "MedicalReports",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Doctors_DoctorId",
                table: "MedicalReports",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Patients_PatientId1",
                table: "MedicalReports",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
