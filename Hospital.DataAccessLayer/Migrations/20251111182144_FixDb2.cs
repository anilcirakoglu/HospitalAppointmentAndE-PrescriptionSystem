using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Patients_PatientId",
                table: "MedicalReports");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "MedicalReports",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalReports_PatientId",
                table: "MedicalReports",
                newName: "IX_MedicalReports_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Patients_UserId",
                table: "MedicalReports",
                column: "UserId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Patients_UserId",
                table: "MedicalReports");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MedicalReports",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalReports_UserId",
                table: "MedicalReports",
                newName: "IX_MedicalReports_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Patients_PatientId",
                table: "MedicalReports",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
