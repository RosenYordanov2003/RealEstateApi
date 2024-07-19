using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class removeSubScriptionCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionCategories_SubscriptionCategoryId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "SubscriptionCategories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc4a885e-54a4-424c-96fe-887cc8fb12e0", "AQAAAAEAACcQAAAAEDveX8LZp/thXnZinjj1GSiCdNnVoLc0gfb33Q8P5nVcDOluTKFrbcoh3KGMdpND/Q==", "b29f8b53-8e9c-4c01-bd62-8a0bd8b7a162" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_PropertyCategories_SubscriptionCategoryId",
                table: "Subscriptions",
                column: "SubscriptionCategoryId",
                principalTable: "PropertyCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_PropertyCategories_SubscriptionCategoryId",
                table: "Subscriptions");

            migrationBuilder.CreateTable(
                name: "SubscriptionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionCategories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b27008d-350b-4843-af07-be921ec32578", "AQAAAAEAACcQAAAAELbZLCL+0zF/OD+es4ybGLWUWukNYRP/zRKmAYD1UG5kaJJZr70YSCqISjn+DNKUyQ==", "f7b25ed5-7548-4f2d-a143-f0bf095c9bc0" });

            migrationBuilder.InsertData(
                table: "SubscriptionCategories",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionCategories_SubscriptionCategoryId",
                table: "Subscriptions",
                column: "SubscriptionCategoryId",
                principalTable: "SubscriptionCategories",
                principalColumn: "Id");
        }
    }
}
