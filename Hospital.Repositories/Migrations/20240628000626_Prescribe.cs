using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Prescribe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabReports_Prescription_PrescriptionId",
                table: "LabReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Medecines_Prescription_PrescriptionId",
                table: "Medecines");

            migrationBuilder.RenameColumn(
                name: "PrescriptionId",
                table: "Medecines",
                newName: "PrescribeMedecineId");

            migrationBuilder.RenameIndex(
                name: "IX_Medecines_PrescriptionId",
                table: "Medecines",
                newName: "IX_Medecines_PrescribeMedecineId");

            migrationBuilder.RenameColumn(
                name: "PrescriptionId",
                table: "LabReports",
                newName: "PrescribeLabReportId");

            migrationBuilder.RenameIndex(
                name: "IX_LabReports_PrescriptionId",
                table: "LabReports",
                newName: "IX_LabReports_PrescribeLabReportId");

            migrationBuilder.AddColumn<string>(
                name: "Advices",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BP",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PresentingComplain",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pulse",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PrescribeLabReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribeLabReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescribeLabReport_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescribeMedecine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribeMedecine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescribeMedecine_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescribeLabReport_PrescriptionId",
                table: "PrescribeLabReport",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribeMedecine_PrescriptionId",
                table: "PrescribeMedecine",
                column: "PrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabReports_PrescribeLabReport_PrescribeLabReportId",
                table: "LabReports",
                column: "PrescribeLabReportId",
                principalTable: "PrescribeLabReport",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medecines_PrescribeMedecine_PrescribeMedecineId",
                table: "Medecines",
                column: "PrescribeMedecineId",
                principalTable: "PrescribeMedecine",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabReports_PrescribeLabReport_PrescribeLabReportId",
                table: "LabReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Medecines_PrescribeMedecine_PrescribeMedecineId",
                table: "Medecines");

            migrationBuilder.DropTable(
                name: "PrescribeLabReport");

            migrationBuilder.DropTable(
                name: "PrescribeMedecine");

            migrationBuilder.DropColumn(
                name: "Advices",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "BP",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "PresentingComplain",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Pulse",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Prescription");

            migrationBuilder.RenameColumn(
                name: "PrescribeMedecineId",
                table: "Medecines",
                newName: "PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Medecines_PrescribeMedecineId",
                table: "Medecines",
                newName: "IX_Medecines_PrescriptionId");

            migrationBuilder.RenameColumn(
                name: "PrescribeLabReportId",
                table: "LabReports",
                newName: "PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_LabReports_PrescribeLabReportId",
                table: "LabReports",
                newName: "IX_LabReports_PrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabReports_Prescription_PrescriptionId",
                table: "LabReports",
                column: "PrescriptionId",
                principalTable: "Prescription",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medecines_Prescription_PrescriptionId",
                table: "Medecines",
                column: "PrescriptionId",
                principalTable: "Prescription",
                principalColumn: "Id");
        }
    }
}
