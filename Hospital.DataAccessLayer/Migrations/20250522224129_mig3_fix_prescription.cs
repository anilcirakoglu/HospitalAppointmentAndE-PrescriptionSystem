using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3_fix_prescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Medications");

            migrationBuilder.RenameColumn(
                name: "Instructions",
                table: "PrescriptionMedications",
                newName: "UsageNote");

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "PrescriptionMedications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "PrescriptionMedications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "PrescriptionMedications");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PrescriptionMedications");

            migrationBuilder.RenameColumn(
                name: "UsageNote",
                table: "PrescriptionMedications",
                newName: "Instructions");

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
