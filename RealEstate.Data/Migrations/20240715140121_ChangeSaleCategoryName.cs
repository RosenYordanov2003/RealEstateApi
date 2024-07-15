using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class ChangeSaleCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SaleCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2f2abc7-38ab-42f9-88a9-debbc3b717ff", "AQAAAAEAACcQAAAAEFENKwiw/8gdXcpVourKc/2LDhIz1Sg8a/8gDHVjwRPPvcvTsHfLg9SFzyllfDP1Ew==", "2685a5d8-6030-486f-9c5b-e638477e7841" });

            migrationBuilder.UpdateData(
                table: "SaleCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Airbnb");

            migrationBuilder.InsertData(
                table: "SaleCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Sale" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SaleCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cbe4247-0dc3-4587-a8ad-1c33091f22d6", "AQAAAAEAACcQAAAAENlETdnfAjV96dFQqEFq3Xu/bLc7ic4XUHmcb6CWPJveRbCth+vr79KhtabmGhDMtA==", "31eac542-7609-4c96-87af-4ef534374036" });

            migrationBuilder.UpdateData(
                table: "SaleCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "airbnb");

            migrationBuilder.InsertData(
                table: "SaleCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Sale" });
        }
    }
}
