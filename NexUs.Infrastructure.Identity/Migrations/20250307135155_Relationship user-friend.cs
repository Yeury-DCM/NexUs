using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Relationshipuserfriend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ApplicationUserId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApplicationUserId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserFriend",
                schema: "Identity",
                columns: table => new
                {
                    FriendId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriend", x => new { x.FriendId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserFriend_Users_FriendId",
                        column: x => x.FriendId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFriend_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriend_UserId",
                schema: "Identity",
                table: "UserFriend",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFriend",
                schema: "Identity");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApplicationUserId",
                schema: "Identity",
                table: "Users",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ApplicationUserId",
                schema: "Identity",
                table: "Users",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
