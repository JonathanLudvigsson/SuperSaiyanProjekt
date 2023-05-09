using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperSaiyanProjekt.Migrations
{
    /// <inheritdoc />
    public partial class creation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_projects_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "timereports",
                columns: table => new
                {
                    RepoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    HoursWorked = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timereports", x => x.RepoId);
                    table.ForeignKey(
                        name: "FK_timereports_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_timereports_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "Age", "FirstName", "HireDate", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, 30, "John", new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", "123-456-7890" },
                    { 2, 29, "Jane", new DateTime(2019, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", "098-765-4321" },
                    { 3, 35, "Bob", new DateTime(2017, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "555-555-1234" },
                    { 4, 28, "Alice", new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", "555-555-5678" },
                    { 5, 32, "Charlie", new DateTime(2018, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", "555-555-9999" }
                });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "ProjectId", "EmployeeId", "EndDate", "ProjectDescription", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of Project A", "Project A", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of Project B", "Project B", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "timereports",
                columns: new[] { "RepoId", "EmployeeId", "HoursWorked", "ProjectId", "WeekNumber" },
                values: new object[,]
                {
                    { 1, 1, 40, 1, 1 },
                    { 2, 1, 35, 2, 2 },
                    { 3, 2, 30, 1, 1 },
                    { 4, 3, 20, 2, 2 },
                    { 5, 4, 45, 1, 3 },
                    { 6, 5, 25, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_projects_EmployeeId",
                table: "projects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_timereports_EmployeeId",
                table: "timereports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_timereports_ProjectId",
                table: "timereports",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "timereports");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
