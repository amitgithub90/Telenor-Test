using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "Integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(100)", nullable: false),
                    PhoneNo = table.Column<string>(type: "Varchar(20)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
