using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinSharkAPI.Migrations
{
    /// <inheritdoc />
    public partial class oneToOneComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e4c0365-85e2-4975-8eb4-b1f67b5a3a20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48f471dd-d9e2-4bf1-b371-e23116e03ef8");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0048ecfe-45f3-452a-8552-b2f840a4c734", null, "User", "USER" },
                    { "2ea9fed3-56d7-454b-9873-303ade7aea10", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0048ecfe-45f3-452a-8552-b2f840a4c734");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ea9fed3-56d7-454b-9873-303ade7aea10");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e4c0365-85e2-4975-8eb4-b1f67b5a3a20", null, "User", "USER" },
                    { "48f471dd-d9e2-4bf1-b371-e23116e03ef8", null, "Admin", "ADMIN" }
                });
        }
    }
}
