using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class camposRestante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefit",
                table: "Volunteerings");

            migrationBuilder.DropColumn(
                name: "Responsibilitys",
                table: "Volunteerings");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Volunteerings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Volunteerings",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TypeVolunteering",
                table: "Volunteerings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Volunteerings");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Volunteerings");

            migrationBuilder.DropColumn(
                name: "TypeVolunteering",
                table: "Volunteerings");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Benefit",
                table: "Volunteerings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsibilitys",
                table: "Volunteerings",
                type: "TEXT",
                nullable: true);
        }
    }
}
