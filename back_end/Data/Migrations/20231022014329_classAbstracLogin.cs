using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class classAbstracLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Institutes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Institutes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Institutes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefit",
                table: "Volunteerings");

            migrationBuilder.DropColumn(
                name: "Responsibilitys",
                table: "Volunteerings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Institutes");
        }
    }
}
