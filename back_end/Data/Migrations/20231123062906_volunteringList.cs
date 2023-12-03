using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class volunteringList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVolunteering_Users_UsersId",
                table: "UserVolunteering");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserVolunteering",
                newName: "UsersParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVolunteering_Users_UsersParticipantsId",
                table: "UserVolunteering",
                column: "UsersParticipantsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVolunteering_Users_UsersParticipantsId",
                table: "UserVolunteering");

            migrationBuilder.RenameColumn(
                name: "UsersParticipantsId",
                table: "UserVolunteering",
                newName: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVolunteering_Users_UsersId",
                table: "UserVolunteering",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
