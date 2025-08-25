using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoLaunch.Migrations
{
    /// <inheritdoc />
    public partial class CreateFounderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Founders",
                columns: table => new
                {
                    FounderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Founders", x => x.FounderId);
                });

            migrationBuilder.CreateTable(
                name: "Startups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadquartersLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFounded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false),
                    FounderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Startups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Startups_Founders_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Founders",
                        principalColumn: "FounderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Startups_FounderId",
                table: "Startups",
                column: "FounderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Startups");

            migrationBuilder.DropTable(
                name: "Founders");
        }
    }
}
