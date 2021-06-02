using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mc.Migrations
{
    public partial class Regenerated_EmployeeInformationMaster2824 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeInformationMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    EmpId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BioId = table.Column<long>(type: "bigint", nullable: true),
                    InternalId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Doc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ForH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PresentAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    AltContactNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    NoOfDependents = table.Column<int>(type: "int", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DOJ = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IhExp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalExp = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PfNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EsiNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AcNo = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    PpNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PAN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BG = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CL = table.Column<int>(type: "int", nullable: true),
                    EL = table.Column<int>(type: "int", nullable: true),
                    SL = table.Column<int>(type: "int", nullable: true),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HRA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Conveyance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Incentive = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MedicalAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherAllowances = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UanNo = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EmployeementUnder = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Division = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ContractorId = table.Column<long>(type: "bigint", nullable: true),
                    MessBill = table.Column<bool>(type: "bit", nullable: false),
                    Onroll = table.Column<bool>(type: "bit", nullable: false),
                    NameInTelugu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RjDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInformationMasters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformationMasters_TenantId",
                table: "EmployeeInformationMasters",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeInformationMasters");
        }
    }
}
