using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignityQuest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBPreviousTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    todaysDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    firstOccurrenceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    previousOccurenceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    nextOccurrenceDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBPreviousTasks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBPreviousTasks");
        }
    }
}
