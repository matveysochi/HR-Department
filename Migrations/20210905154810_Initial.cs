using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRD.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DivisionMovements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ParentDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    MovementType = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivisionMovements_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivisionMovements_Divisions_ParentDivisionId",
                        column: x => x.ParentDivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMovements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    MovementType = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeMovements_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMovements_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1L, "001", "АУП" },
                    { 10L, "010", "Бассейн" },
                    { 8L, "008", "Отдел связи" },
                    { 7L, "007", "Горничные" },
                    { 6L, "006", "Дворники" },
                    { 9L, "009", "СПА" },
                    { 4L, "004", "ИТ" },
                    { 3L, "003", "Техническая служба" },
                    { 2L, "002", "Бухгалтерия" },
                    { 5L, "005", "СПИР" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Patronymic", "Surname" },
                values: new object[,]
                {
                    { 6L, "Юлия", "Михайловна", "Шумкова" },
                    { 1L, "Василий", "Олегович", "Петров" },
                    { 2L, "Петр", "Михайлович", "Иванов" },
                    { 3L, "Матвей", "Вячеславович", "Качуровский" },
                    { 4L, "Екатерина", "Юрьевна", "Шабунина" },
                    { 5L, "Атнонина", "Николаевна", "Бочарникова" },
                    { 7L, "Борис", "Борисович", "Шимякин" }
                });

            migrationBuilder.InsertData(
                table: "DivisionMovements",
                columns: new[] { "Id", "Date", "DivisionId", "MovementType", "ParentDivisionId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 0, null },
                    { 10L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, 0, 9L },
                    { 8L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L, 0, 4L },
                    { 7L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, 0, 5L },
                    { 6L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 0, 3L },
                    { 9L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, 0, 5L },
                    { 11L, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 2, 3L },
                    { 4L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 0, null },
                    { 3L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 0, null },
                    { 2L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 0, null },
                    { 5L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 0, null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeMovements",
                columns: new[] { "Id", "Date", "DivisionId", "EmployeeId", "MovementType" },
                values: new object[,]
                {
                    { 6L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 6L, 0 },
                    { 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, 0 },
                    { 2L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2L, 0 },
                    { 3L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 3L, 0 },
                    { 4L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 4L, 0 },
                    { 8L, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 4L, 2 },
                    { 5L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 5L, 0 },
                    { 7L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, 7L, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DivisionMovements_DivisionId",
                table: "DivisionMovements",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DivisionMovements_ParentDivisionId",
                table: "DivisionMovements",
                column: "ParentDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMovements_DivisionId",
                table: "EmployeeMovements",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMovements_EmployeeId",
                table: "EmployeeMovements",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DivisionMovements");

            migrationBuilder.DropTable(
                name: "EmployeeMovements");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
