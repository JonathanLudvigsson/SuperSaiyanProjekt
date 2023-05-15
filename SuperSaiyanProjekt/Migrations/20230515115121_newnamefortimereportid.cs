using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperSaiyanProjekt.Migrations
{
    /// <inheritdoc />
    public partial class newnamefortimereportid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepoId",
                table: "timereports",
                newName: "TimeReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeReportId",
                table: "timereports",
                newName: "RepoId");
        }
    }
}
