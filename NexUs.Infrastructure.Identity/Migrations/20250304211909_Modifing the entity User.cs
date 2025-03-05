using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class ModifingtheentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Identity",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                schema: "Identity",
                table: "Users",
                newName: "Name");
        }
    }
}
