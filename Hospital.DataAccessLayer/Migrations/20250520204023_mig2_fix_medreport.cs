using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2_fix_medreport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MedicalReports_MedicalReportId1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MedicalReportId1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MedicalReportId1",
                table: "Patients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MedicalReportId1",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalReportId1",
                table: "Patients",
                column: "MedicalReportId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MedicalReports_MedicalReportId1",
                table: "Patients",
                column: "MedicalReportId1",
                principalTable: "MedicalReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
