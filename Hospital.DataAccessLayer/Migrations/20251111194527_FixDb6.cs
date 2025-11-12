using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixDb6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Doctors_UserId",
                table: "WorkingHours");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Doctors_UserId",
                table: "WorkingHours",
                column: "UserId",
                principalTable: "Doctors",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Doctors_UserId",
                table: "WorkingHours");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Doctors_UserId",
                table: "WorkingHours",
                column: "UserId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
