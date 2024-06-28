using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Prescribechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabReports_PrescribeLabReport_PrescribeLabReportId",
                table: "LabReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Medecines_PrescribeMedecine_PrescribeMedecineId",
                table: "Medecines");

            migrationBuilder.DropIndex(
                name: "IX_Medecines_PrescribeMedecineId",
                table: "Medecines");

            migrationBuilder.DropIndex(
                name: "IX_LabReports_PrescribeLabReportId",
                table: "LabReports");

            migrationBuilder.DropColumn(
                name: "PrescribeMedecineId",
                table: "Medecines");

            migrationBuilder.DropColumn(
                name: "PrescribeLabReportId",
                table: "LabReports");

            migrationBuilder.AddColumn<int>(
                name: "MedecineId",
                table: "PrescribeMedecine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LabReportId",
                table: "PrescribeLabReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PrescribeMedecine_MedecineId",
                table: "PrescribeMedecine",
                column: "MedecineId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribeLabReport_LabReportId",
                table: "PrescribeLabReport",
                column: "LabReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribeLabReport_LabReports_LabReportId",
                table: "PrescribeLabReport",
                column: "LabReportId",
                principalTable: "LabReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribeMedecine_Medecines_MedecineId",
                table: "PrescribeMedecine",
                column: "MedecineId",
                principalTable: "Medecines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescribeLabReport_LabReports_LabReportId",
                table: "PrescribeLabReport");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescribeMedecine_Medecines_MedecineId",
                table: "PrescribeMedecine");

            migrationBuilder.DropIndex(
                name: "IX_PrescribeMedecine_MedecineId",
                table: "PrescribeMedecine");

            migrationBuilder.DropIndex(
                name: "IX_PrescribeLabReport_LabReportId",
                table: "PrescribeLabReport");

            migrationBuilder.DropColumn(
                name: "MedecineId",
                table: "PrescribeMedecine");

            migrationBuilder.DropColumn(
                name: "LabReportId",
                table: "PrescribeLabReport");

            migrationBuilder.AddColumn<int>(
                name: "PrescribeMedecineId",
                table: "Medecines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrescribeLabReportId",
                table: "LabReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medecines_PrescribeMedecineId",
                table: "Medecines",
                column: "PrescribeMedecineId");

            migrationBuilder.CreateIndex(
                name: "IX_LabReports_PrescribeLabReportId",
                table: "LabReports",
                column: "PrescribeLabReportId");

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
    }
}
