using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fivesemtest.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdentityUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }
    }
}
