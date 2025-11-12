using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixDb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Doctors_DoctorId",
                table: "WorkingHours");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "WorkingHours",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingHours_DoctorId",
                table: "WorkingHours",
                newName: "IX_WorkingHours_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Doctors_UserId",
                table: "WorkingHours",
                column: "UserId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Doctors_UserId",
                table: "WorkingHours");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WorkingHours",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingHours_UserId",
                table: "WorkingHours",
                newName: "IX_WorkingHours_DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Doctors_DoctorId",
                table: "WorkingHours",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
