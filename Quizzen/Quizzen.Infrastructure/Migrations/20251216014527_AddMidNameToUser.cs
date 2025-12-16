using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizzen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMidNameToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MidName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MidName",
                table: "AspNetUsers");
        }
    }
}
