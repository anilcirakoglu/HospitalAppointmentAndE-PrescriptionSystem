using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Patients_UserId",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UserId",
                table: "Patients");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Patients_UserId",
                table: "Patients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Patients_UserId",
                table: "MedicalReports",
                column: "UserId",
                principalTable: "Patients",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Patients_UserId",
                table: "MedicalReports");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Patients_UserId",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Patients_UserId",
                table: "MedicalReports",
                column: "UserId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
