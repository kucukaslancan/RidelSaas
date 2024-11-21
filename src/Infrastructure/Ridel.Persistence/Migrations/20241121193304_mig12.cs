using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ridel.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionPackage_SubscriptionPackageId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPackage",
                table: "SubscriptionPackage");

            migrationBuilder.RenameTable(
                name: "SubscriptionPackage",
                newName: "SubscriptionPackages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPackages",
                table: "SubscriptionPackages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionPackages_SubscriptionPackageId",
                table: "Subscriptions",
                column: "SubscriptionPackageId",
                principalTable: "SubscriptionPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionPackages_SubscriptionPackageId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPackages",
                table: "SubscriptionPackages");

            migrationBuilder.RenameTable(
                name: "SubscriptionPackages",
                newName: "SubscriptionPackage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPackage",
                table: "SubscriptionPackage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionPackage_SubscriptionPackageId",
                table: "Subscriptions",
                column: "SubscriptionPackageId",
                principalTable: "SubscriptionPackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
