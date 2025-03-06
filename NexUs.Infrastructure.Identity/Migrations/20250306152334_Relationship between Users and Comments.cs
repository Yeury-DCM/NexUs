using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipbetweenUsersandComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                schema: "dbo",
                table: "Comment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_UserId",
                schema: "dbo",
                table: "Comment",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_UserId",
                schema: "dbo",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserId",
                schema: "dbo",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Comment");
        }
    }
}
