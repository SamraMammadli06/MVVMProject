using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesengerApp.Migrations
{
    /// <inheritdoc />
    public partial class Updatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Users_UserId",
                table: "Chat");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Chat",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_UserId",
                table: "Chat",
                newName: "IX_Chat_SenderId");

            migrationBuilder.AddColumn<int>(
                name: "RecieverId",
                table: "Chat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Users_SenderId",
                table: "Chat",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Users_SenderId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "RecieverId",
                table: "Chat");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Chat",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_SenderId",
                table: "Chat",
                newName: "IX_Chat_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Users_UserId",
                table: "Chat",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
