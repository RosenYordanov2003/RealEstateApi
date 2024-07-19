using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class AddSubscriptionAndSubscriptionCategoryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AmenityCategory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SubscriptionCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscription_SubscriptionCategory_SubscriptionCategoryId",
                        column: x => x.SubscriptionCategoryId,
                        principalTable: "SubscriptionCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9610790f-34f5-42b0-9eb0-5e5efa9e6a4a", "AQAAAAEAACcQAAAAEHyoHCEiY+gLuillqHKT+KzATvygQ11inliVVUZ5uZ4SBrdCnlcCGLcCSeIKS5VCSw==", "72baf486-cff0-4897-89f5-f75bc49c58ca" });

            migrationBuilder.UpdateData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Тhree-bedroom apartment");

            migrationBuilder.UpdateData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Two-bedroom apartment");

            migrationBuilder.InsertData(
                table: "PropertyCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Four-bedroom apartment" },
                    { 5, "One-bedroom apartment" },
                    { 6, "Maisonette" },
                    { 7, "Villa" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "House" },
                    { 2, "Тhree-bedroom apartment" },
                    { 3, "Тwo-bedroom apartment" },
                    { 4, "Four-bedroom apartment" },
                    { 5, "Four-bedroom apartment" },
                    { 6, "Villa" },
                    { 7, "Maisonette" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_SubscriptionCategoryId",
                table: "Subscription",
                column: "SubscriptionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_UserId",
                table: "Subscription",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "SubscriptionCategory");

            migrationBuilder.DeleteData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AmenityCategory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff565ab9-ae3f-4f55-a2fd-9179b0d42a3d", "AQAAAAEAACcQAAAAEIhpt2fuujqqgqbaa9up8k3nbYEAzFlFrK3nUzMHhBCJhVQSyZEFwt+4Qvv5KQBhYw==", "2a7e616e-33f9-4852-ab83-db372ec58fa0" });

            migrationBuilder.UpdateData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Apartment");

            migrationBuilder.UpdateData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Studio");
        }
    }
}
