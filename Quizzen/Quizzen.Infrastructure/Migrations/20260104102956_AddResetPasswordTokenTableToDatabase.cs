using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizzen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddResetPasswordTokenTableToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResetPasswordToken",
                table: "ResetPasswordToken");

            migrationBuilder.RenameTable(
                name: "ResetPasswordToken",
                newName: "ResetPasswordTokens");

            migrationBuilder.RenameIndex(
                name: "IX_ResetPasswordToken_UserId_Token",
                table: "ResetPasswordTokens",
                newName: "IX_ResetPasswordTokens_UserId_Token");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResetPasswordTokens",
                table: "ResetPasswordTokens",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResetPasswordTokens",
                table: "ResetPasswordTokens");

            migrationBuilder.RenameTable(
                name: "ResetPasswordTokens",
                newName: "ResetPasswordToken");

            migrationBuilder.RenameIndex(
                name: "IX_ResetPasswordTokens_UserId_Token",
                table: "ResetPasswordToken",
                newName: "IX_ResetPasswordToken_UserId_Token");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResetPasswordToken",
                table: "ResetPasswordToken",
                column: "Id");
        }
    }
}
