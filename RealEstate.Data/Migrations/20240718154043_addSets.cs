using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class addSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_AspNetUsers_UserId",
                table: "Subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_SubscriptionCategory_SubscriptionCategoryId",
                table: "Subscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionCategory",
                table: "SubscriptionCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription");

            migrationBuilder.RenameTable(
                name: "SubscriptionCategory",
                newName: "SubscriptionCategories");

            migrationBuilder.RenameTable(
                name: "Subscription",
                newName: "Subscriptions");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_UserId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_SubscriptionCategoryId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_SubscriptionCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionCategories",
                table: "SubscriptionCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74b34122-4c01-4cc4-8c5a-ded91c63ab15", "AQAAAAEAACcQAAAAEGvtkmel1UfJQu0pDK4HkEc+oegopLiN4tYXnA2TkEOFJkOrgS1xOapZ3DMW+XEXoA==", "2031f90f-299c-4614-9924-39e2018513d3" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionCategories_SubscriptionCategoryId",
                table: "Subscriptions",
                column: "SubscriptionCategoryId",
                principalTable: "SubscriptionCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionCategories_SubscriptionCategoryId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionCategories",
                table: "SubscriptionCategories");

            migrationBuilder.RenameTable(
                name: "Subscriptions",
                newName: "Subscription");

            migrationBuilder.RenameTable(
                name: "SubscriptionCategories",
                newName: "SubscriptionCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscription",
                newName: "IX_Subscription_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_SubscriptionCategoryId",
                table: "Subscription",
                newName: "IX_Subscription_SubscriptionCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionCategory",
                table: "SubscriptionCategory",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9610790f-34f5-42b0-9eb0-5e5efa9e6a4a", "AQAAAAEAACcQAAAAEHyoHCEiY+gLuillqHKT+KzATvygQ11inliVVUZ5uZ4SBrdCnlcCGLcCSeIKS5VCSw==", "72baf486-cff0-4897-89f5-f75bc49c58ca" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_AspNetUsers_UserId",
                table: "Subscription",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_SubscriptionCategory_SubscriptionCategoryId",
                table: "Subscription",
                column: "SubscriptionCategoryId",
                principalTable: "SubscriptionCategory",
                principalColumn: "Id");
        }
    }
}
