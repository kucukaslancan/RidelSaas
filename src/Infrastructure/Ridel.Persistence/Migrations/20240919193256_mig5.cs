using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ridel.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_AspNetUsers_UserId",
                table: "UserDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetail",
                table: "UserDetail");

            migrationBuilder.RenameTable(
                name: "UserDetail",
                newName: "UserDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetail_UserId",
                table: "UserDetails",
                newName: "IX_UserDetails_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId",
                table: "UserDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId",
                table: "UserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails");

            migrationBuilder.RenameTable(
                name: "UserDetails",
                newName: "UserDetail");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetail",
                newName: "IX_UserDetail_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetail",
                table: "UserDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_AspNetUsers_UserId",
                table: "UserDetail",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
